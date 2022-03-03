using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static SharpLauncher.DBFunctions;
using static SharpLauncher.Settings;

namespace SharpLauncher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            // Call RebuildColumns to pick up on IDColumn's invisibility.
            ArchiveList.RebuildColumns();
            this.DoubleBuffered = true;
        }

        /*-----------+
         | VARIABLES |
         +-----------*/

        // Previous width of the list
        int prevWidth;
        // Calculated column widths before conversion to int
        List<double> columnWidths = new();
        // Names of tags to be filtered
        List<string> filteredTags = new();
        // Query fragments used to fetch entries
        string queryLibrary = "";
        string querySearch = "";
        List<string> queryOperations = new();

        // Cache of all items to be displayed in list
        public static List<QueryItem> queryCache = new();
        // An object for locking access to the queryCache between threads.
        public static readonly object queryCacheLock = new();
        // A ManualResetEvent that the main thread should wait on until the queryCache is ready for reading.
        ManualResetEventSlim queryCacheWH = new(true);
        // A lock to ensure that we only run one DB refresh at a time.
        readonly object DBRefreshLock = new();
        // Locks access to downloads.fp.
        readonly object downloadsFPLock = new();
        // Locks access to favorites.fp.
        readonly object favoritesFPLock = new();
        // Array of all entries that have been played
        List<string> playedEntries = new();
        // Array of all entries that have been favorited
        List<string> favoritedEntries = new();
        // Check if column width has been changed manually
        bool columnChanged = false;
        // Check if images have been loaded
        bool logoLoaded = false;
        bool screenshotLoaded = false;

        /*--------+
         | EVENTS |
         +--------*/

        private void Main_load(object sender, EventArgs e)
        {
            // Create data files if they don't exist, otherwise load

            if (File.Exists("config.json") && File.ReadAllText("config.json").Length > 0)
            {
                Config.Read();
            }
            else
            {
                Config.Write();
            }

            // Get width for later

            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                columnWidths.Add(ArchiveList.Columns[i].Width);
            }

            ResetColumns();

            // Why Visual Studio doesn't let me do this the regular way, I don't know
            SearchBox.AutoSize = false;
            SearchBox.Height = 20;

            // Fix search box being randomly foxused when launcher is opened
            HomeContainer.Select();

            // Give the additional apps button an arrow
            AlternateButton.Text = char.ConvertFromUtf32(0x2BC5);

            HomeContainer.Location = GetHomepagePosition();
            RandomButton.Location = GetRandomButtonPosition();

            // Run this on startup, it will outsource the actual db-reading to another thread.
            InitializeDatabase();
        }

        private void Main_resize(object sender, EventArgs e)
        {
            // Scale column widths to list width
            if (columnChanged)
            {
                ScaleColumns();
            }
            else
            {
                ResetColumns();
            }

            prevWidth = ArchiveList.ClientSize.Width;

            // Resize metadata textbox to new height
            ArchiveInfoData.Height = GetInfoHeight();

            // Re-position Home tab contents
            HomeContainer.Location = GetHomepagePosition();

            // Center Random button
            RandomButton.Location = GetRandomButtonPosition();
        }

        // Initialize list when Archive tab is accessed for the first time
        // Update column widths if window is resized while in a different tab
        private void TabControl_tabChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 1)
            {
                if (Config.NeedsRefresh)
                {
                    InitializeDatabase();
                }
                else if (columnChanged)
                {
                    ScaleColumns();
                }
                else
                {
                    ResetColumns();
                }
            }
            else
            {
                HomeContainer.Location = GetHomepagePosition();
            }
        }

        // Execute search if enter is pressed
        private void SearchBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteSearchQuery();
                e.SuppressKeyPress = true;
            }
        }

        // Execute search if Search button is clicked
        private void SearchButton_click(object sender, EventArgs e) { ExecuteSearchQuery(); }

        // Display setttings menu when Settings button is clicked
        private void SettingsButton_click(object sender, EventArgs e) { OpenSettings(); }

        // Reload database when 
        private void SettingsMenu_formClosed(object? sender, FormClosedEventArgs e)
        {
            Config.Read();

            if (TabControl.SelectedIndex == 1 && Config.NeedsRefresh)
            {
                InitializeDatabase();
            }
        }

        // Display items on list when fetched
        private void ArchiveList_retrieveItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            QueryItem item;
            lock (queryCacheLock)
            {
                item = queryCache[e.ItemIndex];
            }
            e.Item = new(item.Title);
            e.Item.SubItems.Add(item.Developer);
            e.Item.SubItems.Add(item.Publisher);
        }

        // Display information about selected entry in info panel
        private void ArchiveList_itemSelect(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = ((ListView)sender).SelectedIndices;

            /*
             *  I need to figure out how to clear the info panel only when an item is deselected
             *  Otherwise, the list flickers every time a new item is selected
             *  
             *  SelectedIndexChanged fires twice, returning empty SelectedIndices the first time
             *  SelectedItemsChanged fires once but doesn't fire when item is deselected
             */
            if (selectedIndices.Count == 0)
            {
                ClearInfoPanel();
                return;
            }
            QueryItem entry;
            lock (queryCacheLock)
            {
                entry = queryCache[selectedIndices[0]];
            }
            MetaDataObj metadataOutput = DatabaseQueryMeta(entry, queryLibrary);

            // Header

            ArchiveInfoTitle.Text = metadataOutput.Title;

            ArchiveInfoDeveloper.Text = metadataOutput.Developer != "" ? $"by {metadataOutput.Developer}" : "by unknown developer";

            ArchiveInfoData.Height = GetInfoHeight();

            // Metadata
            ArchiveInfoData.Rtf = BuildEntryData(metadataOutput);

            // Images

            if (!ArchiveImagesContainer.Visible)
            {
                ArchiveImagesContainer.Visible = true;
            }

            foreach (string folder in new string[] { "Logos", "Screenshots" })
            {
                string[] imageTree = { entry.ID.Substring(0, 2), entry.ID.Substring(2, 2) };
                string imagePath = $"\\Data\\Images\\{folder}\\{imageTree[0]}\\{imageTree[1]}\\{entry.ID}.png";

                if (File.Exists(Config.FlashpointPath + imagePath))
                {
                    if (folder == "Logos")
                    {
                        ArchiveImagesLogo.Image = Image.FromFile(Config.FlashpointPath + imagePath);
                        logoLoaded = true;
                    }
                    else if (folder == "Screenshots")
                    {
                        ArchiveImagesScreenshot.Image = Image.FromFile(Config.FlashpointPath + imagePath);
                        screenshotLoaded = true;
                    }
                }
                else
                {
                    if (folder == "Logos")
                    {
                        ArchiveImagesLogo.ImageLocation = Config.FlashpointServer + imagePath;
                    }
                    else if (folder == "Screenshots")
                    {
                        ArchiveImagesScreenshot.ImageLocation = Config.FlashpointServer + imagePath;
                    }
                }
            }

            // Footer

            // Display or hide additional apps button if they exist
            if (DatabaseGetAddAppCount(entry.ID) > 0)
            {
                PlayButton.Width = 238;
                AlternateButton.Visible = true;
            }
            else
            {
                AlternateButton.Visible = false;
                PlayButton.Width = 253;
            }

            if (favoritedEntries.Contains(entry.ID))
            {
                FavoriteButton.Checked = true;
                FavoriteButton.ImageIndex = 1;
            }
            else
            {
                FavoriteButton.Checked = false;
                FavoriteButton.ImageIndex = 0;
            }

            PlayContainer.Visible = true;
        }

        /// <summary>
        /// Builds the string to display in the panel from a metadata input.
        /// </summary>
        /// <param name="meta">The metadata object describing the selected game.</param>
        /// <returns>The RTF display string.</returns>
        private static string BuildEntryData(MetaDataObj meta)
        {
            string entryData = @"{\rtf1 ";
            entryData += meta.AlternateTitles == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["alternateTitles"]}: \\b0 {ToUnicode(meta.AlternateTitles)}\\line";
            entryData += meta.Series == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["series"]}: \\b0 {ToUnicode(meta.Series)}\\line";
            entryData += meta.Developer == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["developer"]}: \\b0 {ToUnicode(meta.Developer)}\\line";
            entryData += meta.Publisher == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["publisher"]}: \\b0 {ToUnicode(meta.Publisher)}\\line";
            entryData += meta.Source == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["source"]}: \\b0 {ToUnicode(meta.Source)}\\line";
            entryData += meta.ReleaseDate == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["releaseDate"]}: \\b0 {ToUnicode(meta.ReleaseDate)}\\line";
            entryData += meta.Platform == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["platform"]}: \\b0 {ToUnicode(meta.Platform)}\\line";
            entryData += meta.Version == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["version"]}: \\b0 {ToUnicode(meta.Version)}\\line";
            entryData += meta.Library == "" ? "" : $"\\b {MetaDataObj.metadataFields["library"]}: \\b0 " +
                                ToUnicode(meta.Library[0].ToString().ToUpper() + meta.Library[1..]) +
                                "\\line";
            entryData += meta.Tags == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["tagsStr"]}: \\b0 {ToUnicode(meta.Tags)}\\line";
            entryData += meta.Language == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["language"]}: \\b0 {ToUnicode(meta.Language)}\\line";
            entryData += meta.PlayMode == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["playMode"]}: \\b0 {ToUnicode(meta.PlayMode)}\\line";
            entryData += meta.Status == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["status"]}: \\b0 {ToUnicode(meta.Status)}\\line";
            entryData += meta.Format == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["activeDataOnDisk"]}: \\b0 {(meta.Format == "0" ? "Legacy" : "GameZIP")}\\line";
            entryData += meta.Notes == "" ? "" :
                $"\\line\\b {MetaDataObj.metadataFields["notes"]}:\\line\\b0 {ToUnicode(meta.Notes)}\\line";
            entryData += meta.OriginalDescription == "" ? "" :
                $"\\line\\b {MetaDataObj.metadataFields["originalDescription"]}:\\line\\b0 {ToUnicode(meta.OriginalDescription)}\\line";
            entryData += "}";
            return entryData;
        }

        // Launch selected entry
        private void ArchiveList_itemAccess(object sender, EventArgs e)
        {
            if (!InitializeCLIFp())
            {
                return;
            }

            string entryID;
            lock (queryCacheLock)
            {
                entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;
            }

            LaunchEntry.StartInfo.Arguments = $"play -i {entryID}";
            LaunchEntry.Start();

            EnsurePlaysLoaded();

            // Add to list of played entries (if it hasn't been played already)
            if (!playedEntries.Contains(entryID))
            {
                playedEntries.Add(entryID);

                UpdateListFile("downloads.fp", playedEntries, downloadsFPLock);
            }
        }

        // Display additional apps when arrow button is clicked
        private void AlternateButton_click(object sender, EventArgs e)
        {
            AlternateMenu.Items.Clear();

            string entryID;
            lock (queryCacheLock)
            {
                entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;
            }

            int i = 0;
            foreach (AddApp entry in DatabaseQueryAddApp(entryID))
            {
                AlternateMenu.Items.Add($"Launch: " + entry.Name);
                AlternateMenu.Items[i].Tag = entry;

                i++;
            }

            Point menuPosition = AlternateButton.Parent.PointToScreen(AlternateButton.Location);
            menuPosition.X += AlternateButton.Width;

            AlternateMenu.Show(menuPosition, ToolStripDropDownDirection.AboveLeft);
        }

        // Launch additional app
        private void AlternateMenu_itemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!InitializeCLIFp())
            {
                return;
            }

            AddApp entry = (AddApp)e.ClickedItem.Tag;

            LaunchEntry.StartInfo.Arguments = $"play -i {entry.ID}";

            if (entry.ApplicationPath != ":extras:" && entry.ApplicationPath != ":message:")
            {

                // Add to list of played entries (if it hasn't been played already)
                if (!playedEntries.Contains(entry.ParentGameId))
                {
                    playedEntries.Add(entry.ParentGameId);

                    UpdateListFile("downloads.fp", playedEntries, downloadsFPLock);
                }
            }

            LaunchEntry.Start();
        }

        // Add or remove entry from favorites list and change image
        private void FavoriteButton_checkedChanged(object sender, EventArgs e)
        {
            EnsureFavoritesLoaded();

            CheckBox favoriteButton = (CheckBox)sender;

            string entryID;
            lock (queryCacheLock)
            {
                entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;
            }

            if (favoriteButton.Checked)
            {
                if (!favoritedEntries.Contains(entryID))
                {
                    favoritedEntries.Add(entryID);
                }

                favoriteButton.ImageIndex = 1;
            }
            else
            {
                if (favoritedEntries.Contains(entryID))
                {
                    favoritedEntries.Remove(entryID);
                }

                favoriteButton.ImageIndex = 0;
            }

            UpdateListFile("favorites.fp", favoritedEntries, favoritesFPLock);
        }

        // Update columnWidths in case column is changed manually
        private void ArchiveList_columnChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (ArchiveList.ClientSize.Width == prevWidth)
            {
                columnWidths[e.ColumnIndex] = ArchiveList.Columns[e.ColumnIndex].Width;
                columnChanged = true;
            }
        }

        // Preserve arrow cursor when hovering over selected item
        private void ArchiveList_mouseMove(object sender, MouseEventArgs e) { base.Cursor = Cursors.Arrow; }

        // Direct Reset Columns button to its appropriate function
        private void ResetColumnsButton_click(object sender, EventArgs e) { ResetColumns(); }

        // Focus on a random entry when Random button is clicked
        Random rng = new();
        private void RandomButton_Click(object sender, EventArgs e)
        {
            if (ArchiveList.VirtualListSize == 0)
            {
                return;
            }

            int randomEntryIndex = rng.Next(ArchiveList.VirtualListSize);

            ArchiveList.Select();
            ArchiveList.Items[randomEntryIndex].Selected = true;
            ArchiveList.Items[randomEntryIndex].EnsureVisible();
        }

        // Change library when left panel radio is changed
        bool activateOnce = true;
        private void ArchiveRadio_checkedChanged(object sender, EventArgs e)
        {
            // Prevent event from firing twice
            activateOnce = !activateOnce;

            if (!activateOnce)
            {
                return;
            }

            RadioButton checkedRadio = (RadioButton)sender;

            if (checkedRadio.Checked)
            {
                switch (checkedRadio.Name)
                {
                    case "ArchiveRadioEverything":
                        queryLibrary = "";
                        break;

                    case "ArchiveRadioGames":
                        queryLibrary = "arcade";
                        break;

                    case "ArchiveRadioAnimations":
                        queryLibrary = "theatre";
                        break;

                    case "ArchiveRadioPlays":
                        if (File.Exists("downloads.fp") && playedEntries.Count == 0)
                        {
                            playedEntries = File.ReadAllLines("downloads.fp").ToList();
                        }

                        break;

                    case "ArchiveRadioFavorites":
                        if (File.Exists("favorites.fp") && favoritedEntries.Count == 0)
                        {
                            favoritedEntries = File.ReadAllLines("favorites.fp").ToList();
                        }

                        break;
                }

                RefreshDatabase_Block();
            }
        }

        private void ArchiveImages_loadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (((PictureBox)sender).Name == "ArchiveImagesLogo")
            {
                logoLoaded = true;
            }
            else if (((PictureBox)sender).Name == "ArchiveImagesScreenshot")
            {
                screenshotLoaded = true;
            }
        }

        // Display picture viwwer 
        private void ArchiveImages_click(object sender, EventArgs e)
        {
            string pictureName = ((PictureBox)sender).Name;

            if ((pictureName == "ArchiveImagesLogo" && logoLoaded) ||
                (pictureName == "ArchiveImagesScreenshot" && screenshotLoaded))
            {
                Form pictureViewer = new()
                {
                    Text = "Picture Viewer",
                    Size = new Size(640, 480),
                    ShowIcon = false
                };

                pictureViewer.Controls.Add(new PictureBox()
                {
                    Name = "PictureContainer",
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = pictureName == "ArchiveImagesLogo" ? ArchiveImagesLogo.Image : ArchiveImagesScreenshot.Image
                });

                pictureViewer.Show();
            }
        }

        /*-----------+
         | FUNCTIONS |
         +-----------*/

        // Check if database is valid and load if so
        // Adapted from https://stackoverflow.com/a/70291358
        private void InitializeDatabase()
        {
            if (Config.NeedsRefresh)
            {
                Config.NeedsRefresh = false;
            }

            string databasePath = Config.FlashpointPath + @"\Data\flashpoint.sqlite";
            byte[] header = new byte[16];

            if (File.Exists(databasePath))
            {
                using (FileStream fileStream = new(databasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fileStream.Read(header, 0, 16);
                }

                if (Encoding.ASCII.GetString(header).Contains("SQLite format"))
                {
                    LoadFilteredTags();
                    RefreshDatabase_Block();

                    prevWidth = ArchiveList.ClientSize.Width;

                    return;
                }
            }

            ArchiveList.VirtualListSize = 0;
            ClearInfoPanel();

            MessageBox.Show("Database is either corrupted or missing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            TabControl.SelectTab(0);
            OpenSettings();

            Config.NeedsRefresh = true;
        }

        // Generate new cache and refresh list
        // TODO: make this into a thread wrapper-func.
        private void RefreshDatabase()
        {
            new Thread(() => RefreshDatabase_OnThread(columnChanged, ArchiveRadioPlays.Checked, ArchiveRadioFavorites.Checked,
                playedEntries, favoritedEntries, querySearch, queryOperations, queryLibrary)).Start();
        }

        // Generate new cache and refresh list
        private void RefreshDatabase_Block()
        {
            new Thread(() => RefreshDatabase_OnThread_BlockBased(columnChanged, ArchiveRadioPlays.Checked, ArchiveRadioFavorites.Checked,
                playedEntries, favoritedEntries, querySearch, queryOperations, queryLibrary, BlockSize,
                ArchiveList.PrimarySortColumn == null ? "Title" : ArchiveList.PrimarySortColumn.AspectName,
                ArchiveList.PrimarySortOrder == SortOrder.Descending ? 0 : 1, filteredTags)).Start();
        }

        // TODO: MAKE THIS THREAD-SAFE, i.e. near-static.
        public void RefreshDatabase_OnThread(bool colChanged, bool playsChecked, bool favoritesChecked, List<string> playedEnts, List<string> favoritedEnts,
            string qSearch, List<string> qOperations, string qLibrary)
        {
            lock (DBRefreshLock)
            {
                ClearInfoPanel();
                SetEntryCountText("Loading...");
                lock (queryCacheLock)
                {
                    queryCache.Clear();
                }
                UpdateArchiveListLength();

                List<QueryItem> temp;

                // Get values to be inserted into QueryItem objects
                if (playsChecked || favoritesChecked)
                {
                    temp = new();
                    foreach (string id in playsChecked ? playedEnts : favoritedEnts)
                    {
                        // TODO: disable this, and ask Wumbo why it's here. We shouldn't have invalid IDs.
                        /*if (DatabaseQuery($"SELECT id FROM game WHERE id = '{id}'").Count == 0)
                        {
                            continue;
                        }*/

                        // TODO: make one enormous list of OR'd conditions, so that we don't end up with hundreds of separate
                        // queries, when we could have one large one.
                        temp.AddRange(DatabaseQueryEntry(GetAltQuery(id, qSearch, qOperations)));
                    }
                }
                else
                {
                    temp = DatabaseQueryEntry(GetQuery(qOperations, qSearch, qLibrary));
                }

                // If item is not filtered, create QueryItem object and add to queryCache
                lock (filterLock)
                {
                    temp = temp.FindAll((QueryItem elem) => !filteredTags.Intersect(elem.tagsStr.Split("; ")).Any());
                }

                int length;
                lock (queryCacheLock)
                {
                    queryCache.AddRange(temp);
                    length = queryCache.Count;
                }

                // Sort new queryCache
                ArchiveList.Sort();

                // Display entry count in bottom right corner
                SetEntryCountText($"Displaying {length} entr{(length == 1 ? "y" : "ies")}.");

                // Force list to reload items
                UpdateArchiveListLength();

                // Prevent column widths from breaking out of list
                if (colChanged)
                {
                    ScaleColumns();
                }
                else
                {
                    ResetColumns();
                }
            }
        }
        // TODO: MAKE THIS THREAD-SAFE, i.e. near-static.
        public void RefreshDatabase_OnThread_BlockBased(bool colChanged, bool playsChecked, bool favoritesChecked, List<string> playedEnts, List<string> favoritedEnts,
            string qSearch, List<string> qOperations, string qLibrary, int blockSize, string sortBy, int direction, List<string> tagFilters)
        {
            lock (DBRefreshLock)
            {
                ClearInfoPanel();
                SetEntryCountText("Loading...");
                lock (queryCacheLock)
                {
                    queryCache.Clear();
                }
                UpdateArchiveListLength();

                List<QueryItem> temp;
                QueryItem lastItem = new();
                int lastBlockSize = blockSize;
                // queryCache.Count, but without the need for locking.
                // Scale the columns nicely.
                if (colChanged)
                {
                    ScaleColumns();
                }
                else
                {
                    ResetColumns();
                }
                // Get values to be inserted into QueryItem objects
                if (playsChecked || favoritesChecked)
                {
                    temp = new();
                    foreach (string id in playsChecked ? playedEnts : favoritedEnts)
                    {
                        // TODO: disable this, and ask Wumbo why it's here. We shouldn't have invalid IDs.
                        /*if (DatabaseQuery($"SELECT id FROM game WHERE id = '{id}'").Count == 0)
                        {
                            continue;
                        }*/

                        // TODO: make one enormous list of OR'd conditions, so that we don't end up with hundreds of separate
                        // queries, when we could have one large one.
                        temp.AddRange(DatabaseQueryEntry(GetAltQuery(id, qSearch, qOperations)));
                    }
                    temp = FilterData(temp, tagFilters);
                    lock (queryCacheLock)
                    {
                        queryCache.AddRange(temp);
                    }
                    UpdateArchiveListLength();
                    ArchiveList.Sort();
                }
                else
                {
                    SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
                    connection.Open();
                    // Keep going until we get back fewer than we requested: when that happens, we're at the end.
                    while (lastBlockSize == blockSize)
                    {
                        // If we haven't yet displayed the first page and we have enough results to do so, do it.
                        if (true)//(!pastFirstPage && length >= blockSize)
                        {
                            // Set the list length appropriately.
                            UpdateArchiveListLength();
                        }

                        // Query the DB for one block.
                        lock (filterLock)
                        {
                            temp = FilterDataBlock(DatabaseQueryEntry(GetQueryBlock(qOperations, lastElem: lastItem.GetPropertyFromName(sortBy), lastId: lastItem.ID,
                            sortByColumn: sortBy.ToLower(), sortDirection: direction == 1, blockSize: blockSize, search: qSearch, library: qLibrary), connection),
                            // Set lastItem and lastBlockSize properly.
                            tagFilters, out lastItem, out lastBlockSize);
                        }

                        // Lock queryCache and add all of temp's elements.
                        lock (queryCacheLock)
                        {
                            queryCache.AddRange(temp);
                        }

                    }
                    connection.Close();
                }

                // Sort new queryCache
                //SortColumns();
                int length;
                lock (queryCacheLock)
                {
                    length = queryCache.Count;
                }
                // Display entry count in bottom right corner
                SetEntryCountText($"Displaying {length} entr{(length == 1 ? "y" : "ies")}.");

                // Force list to reload items
                UpdateArchiveListLength();

                // Prevent column widths from breaking out of list
                if (colChanged)
                {
                    ScaleColumns();
                }
                else
                {
                    ResetColumns();
                }
            }
        }

        private bool InitializeCLIFp()
        {
            if (File.Exists(Config.CLIFpPath))
            {
                LaunchEntry.StartInfo.FileName = Config.CLIFpPath;
                return true;
            }
            else
            {
                MessageBox.Show("CLIFp not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenSettings();
                return false;
            }
        }

        private void LoadFilteredTags()
        {
            bool errorState = false;
            lock (filterLock)
            {
                filteredTags.Clear();

                if (File.Exists("filters.json"))
                {
                    using (StreamReader jsonStream = new("filters.json"))
                    {
                        dynamic? filterArray = JsonConvert.DeserializeObject(jsonStream.ReadToEnd());

                        foreach (var item in filterArray)
                        {
                            if (item.filtered == true)
                            {
                                foreach (var tag in item.tags)
                                {
                                    filteredTags.Add(tag.ToString());
                                }
                            }
                        }
                    }
                }
                else
                {
                    errorState = true;
                }
            }
            if (errorState)
            {
                MessageBox.Show(
                        "filters.json was not found, and as a result the archive will be unfiltered. Use at your own risk.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );
            }
        }

        // Handle read/write from .fp files

        private void EnsurePlaysLoaded()
        {
            if (File.Exists("downloads.fp") && playedEntries.Count == 0)
            {
                playedEntries = File.ReadAllLines("downloads.fp").ToList();
            }
        }

        private void EnsureFavoritesLoaded()
        {
            if (File.Exists("favorites.fp") && favoritedEntries.Count == 0)
            {
                favoritedEntries = File.ReadAllLines("favorites.fp").ToList();
            }
        }

        private void UpdateListFile(string fileName, List<string> list, object locker)
        {
            lock (locker)
            {
                using (FileStream file = new(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
                {

                    file.SetLength(0);

                    file.Write(Encoding.ASCII.GetBytes(String.Join(Environment.NewLine, list)));
                }
            }
        }
        // TODO: mess with this, ensure it escapes stuff properly.
        private void ExecuteSearchQuery()
        {
            // TODO: memory leak
            queryOperations = new();

            StringBuilder safeQuery = new();

            // Replace unsafe characters
            // TODO: slow? benchmark this.
            foreach (char inputChar in SearchBox.Text)
            {
                if (inputChar == '\'' || inputChar == '"' || inputChar == '%')
                {
                    // Fine, but I don't like it.
                    // TODO: discuss better ways to do this.
                    safeQuery.Append('_');
                }
                else
                {
                    safeQuery.Append(inputChar);
                }
            }

            string tempSearch = safeQuery.ToString();

            // Initialize search operators

            int leftBracketCount = tempSearch.Count(i => i == '[');
            int rightBracketCount = tempSearch.Count(i => i == ']');

            // Make sure there are brackets in the search query
            if (leftBracketCount > 0 && leftBracketCount == rightBracketCount)
            {
                // Iterate through each group of brackets
                for (int i = 0; i < leftBracketCount; i++)
                {
                    // Get indicies of brackets
                    // HACK: because this doesn't correctly deal with nested brackets.
                    int leftBracket = tempSearch.IndexOf('[');
                    int rightBracket = tempSearch.IndexOf(']');

                    // Check if brackets are formatted correctly
                    if (rightBracket > leftBracket && leftBracket != -1)
                    {
                        // Get array containing each parameter
                        string[] operationParams = tempSearch.Substring(leftBracket + 1, rightBracket - leftBracket - 1).Split(':');

                        // Create operation if parameters are valid
                        if (operationParams.Length == 2)
                        {
                            // TODO: aliases of meta names.
                            if (MetaDataObj.metadataFields.ContainsKey(operationParams[0]))
                            {


                                // Check for OR | operators and update query accordingly
                                if (operationParams[1].Contains('|'))
                                {
                                    // TODO: make this efficient. How many lists are we using?
                                    string[] operationValues = operationParams[1].Split("|");
                                    List<string> queryOr = new();

                                    foreach (string value in operationValues)
                                    {
                                        queryOr.Add($"{operationParams[0]} LIKE '%{value}%'");
                                    }

                                    queryOperations.Add($"({string.Join(" OR ", queryOr)})");
                                }
                                else
                                {
                                    queryOperations.Add($"{operationParams[0]} LIKE '%{operationParams[1]}%'");
                                }
                            }
                        }

                        // Remove brackets and everything in them.
                        tempSearch = tempSearch.Remove(leftBracket, rightBracket - leftBracket + 1);
                    }
                }
            }

            // Remove padding
            tempSearch = tempSearch.Trim();

            // Apply remaining string to generic search query
            querySearch = tempSearch;

            // Refresh and open list
            RefreshDatabase_Block();
            TabControl.SelectTab(1);
        }

        private void OpenSettings()
        {
            Settings SettingsMenu = new Settings();
            SettingsMenu.FormClosed += new FormClosedEventHandler(SettingsMenu_formClosed);

            SettingsMenu.ShowDialog();
        }

        /// <summary>
        /// Resize columns proportional to new list size
        /// Self-invokes on main thread if needed.
        /// </summary>
        private void ScaleColumns()
        {
            // If we're not on the main thread,
            if (ArchiveList.InvokeRequired)
            {
                // Invoke this on the main thread.
                ArchiveList.Invoke(delegate { ScaleColumns(); });
                // Return so that we don't continue to the other stuff.
                return;
            }
            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                columnWidths[i] *= (double)ArchiveList.ClientSize.Width / prevWidth;
                ArchiveList.Columns[i].Width = (int)columnWidths[i];
            }
        }

        /// <summary>
        /// Resize columns to fill list width.
        /// Self-invokes on main thread if needed.
        /// </summary>
        private void ResetColumns()
        {
            // If we're not on the main thread,
            if (ArchiveList.InvokeRequired)
            {
                // Invoke this on the main thread.
                ArchiveList.Invoke(delegate { ResetColumns(); });
                // Return so that we don't continue to the other stuff.
                return;
            }
            int divisor = ArchiveList.Columns.Count + 1;

            ArchiveList.BeginUpdate();
            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                // Double width of first column
                columnWidths[i] = (ArchiveList.ClientSize.Width / divisor) * (i == 0 ? 2 : 1);
                ArchiveList.Columns[i].Width = (int)columnWidths[i];
            }
            ArchiveList.EndUpdate();

            if (columnChanged)
            {
                columnChanged = false;
            }
        }

        // Position homepage contents to middle of window
        private Point GetHomepagePosition() =>
            new Point(
                (HomeTab.Width - HomeContainer.Width) / 2,
                (HomeTab.Height - HomeContainer.Height) / 2
            );

        private Point GetRandomButtonPosition() => new Point((ArchiveListFooter.Width - RandomButton.Width) / 2, 1);

        // Leave the right amount of room for metadata text box
        private int GetInfoHeight()
        {
            int desiredHeight = ArchiveInfoContainer.Height - 14;

            foreach (Control control in ArchiveInfoContainer.Controls)
            {
                if (control.Name != "ArchiveInfoData")
                {
                    desiredHeight -= control.Height;
                }
            }

            return desiredHeight;
        }
        /// <summary>
        /// Clears the info panel on the left.
        /// Invokes itself on the main thread if needed.
        /// </summary>
        private void ClearInfoPanel()
        {
            // If we're not on the main thread,
            if (ArchiveInfoData.InvokeRequired)
            {
                // Invoke this on the main thread.
                ArchiveInfoData.Invoke(delegate { ClearInfoPanel(); });
                // Return so that we don't continue to the other stuff.
                return;
            }
            ArchiveInfoTitle.Text = "";
            ArchiveInfoDeveloper.Text = "";
            ArchiveInfoData.Rtf = "";
            ArchiveInfoData.Height = 0;
            ArchiveImagesContainer.Visible = false;
            ArchiveImagesLogo.Image = null;
            ArchiveImagesScreenshot.Image = null;
            logoLoaded = false;
            screenshotLoaded = false;
            PlayContainer.Visible = false;
        }

        /// <summary>
        /// A wrapper around ArchiveList.UpdateVirtualListSize that self-invokes on the main thread before setting.
        /// </summary>
        /// <remarks>This obtains the new length by calling FPVirtualListDataSource.GetObjectCount.</remarks>
        private void UpdateArchiveListLength()
        {
            // If we're not on the main thread,
            if (ArchiveList.InvokeRequired)
            {
                // Invoke this on the main thread.
                ArchiveList.Invoke(delegate { UpdateArchiveListLength(); });
                // Return so that we don't continue to the other stuff.
                return;
            }
            ArchiveList.UpdateVirtualListSize();
        }

        /// <summary>
        /// A wrapper around EntryCountLabel.Text that self-invokes on the main thread before setting.
        /// </summary>
        /// <param name="newlen">The new value for EntryCountLabel.Text.</param>
        private void SetEntryCountText(string newText)
        {
            // If we're not on the main thread,
            if (EntryCountLabel.InvokeRequired)
            {
                // Invoke this on the main thread.
                EntryCountLabel.Invoke(delegate { SetEntryCountText(newText); });
                // Return so that we don't continue to the other stuff.
                return;
            }
            EntryCountLabel.Text = newText;
        }

        // Make strings suitable for RTF text box
        // Adapted from https://stackoverflow.com/a/30363185
        static string ToUnicode(string data)
        {
            StringBuilder escapedData = new();

            foreach (char c in data)
            {
                if (c == '\\' || c == '{' || c == '}')
                {
                    escapedData.Append(@"\" + c);
                }
                else if (c <= 0x7f)
                {
                    escapedData.Append(c);
                }
                else
                {
                    escapedData.Append(@"\u" + Convert.ToUInt32(c) + "?");
                }
            }

            return escapedData.ToString().Replace("\n", @"\line ");
        }

        /*---------------+
         | LINK HANDLERS |
         +---------------*/

        private void GitHubButton_click(object sender, EventArgs e)
        {
            Process.Start("explorer", "https://github.com/WumboSpasm/SharpLauncher");
        }

        private void HomeLink_linkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // ((LinkLabel)sender).LinkVisited = true;

            switch (((LinkLabel)sender).Name)
            {
                case "HomeLinkWebsite":
                    Process.Start("explorer", "https://bluemaxima.org/flashpoint/");
                    break;
                case "HomeLinkWiki":
                    Process.Start("explorer", "https://bluemaxima.org/flashpoint/datahub/Main_Page");
                    break;
                case "HomeLinkGitHub":
                    Process.Start("explorer", "https://github.com/FlashpointProject");
                    break;
                case "HomeLinkDiscord":
                    Process.Start("explorer", "http://discord.gg/S9uJ794");
                    break;
            }
        }
    }
}