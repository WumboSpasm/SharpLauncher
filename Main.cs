using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
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

        #region Important Variables

        // The width of the list prior to resize.
        int prevWidth;
        // The exact values of calculated column widths before conversion to int.
        List<double> columnWidths = new();
        // A list containing each tag to be filtered.
        List<string> filteredTags = new();
        // Query fragments used to fetch entries.
        string queryLibrary = "";
        string querySearch = "";
        List<string> queryOperations = new();

        // A list containing every item to be displayed in the list.
        public static List<QueryItem> queryCache = new();
        // An object for locking access to the queryCache between threads.
        public static readonly object queryCacheLock = new();
        // A lock to ensure that we only run one DB refresh at a time.
        readonly object DBRefreshLock = new();
        // Locks access to downloads.fp.
        readonly object downloadsFPLock = new();
        // Locks access to favorites.fp.
        readonly object favoritesFPLock = new();
        // An array of all entries that have been played.
        List<string> playedEntries = new();
        // An array of all entries that have been favorited.
        List<string> favoritedEntries = new();
        // Keep track of whether column width has been changed manually.
        bool columnChanged = false;
        // Keep track of whether requested curation images have been loaded.
        bool logoLoaded = false;
        bool screenshotLoaded = false;

        #endregion

        #region Form Component Triggers

        private void Main_load(object sender, EventArgs e)
        {
            // Create configuration file if one doesn't exist. Otherwise, load it.

            if (File.Exists("config.json") && File.ReadAllText("config.json").Length > 0)
            {
                Config.Read();
            }
            else
            {
                Config.Write();
            }

            // Initialize list columns and their widths.

            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                columnWidths.Add(ArchiveList.Columns[i].Width);
            }

            ResetColumns();

            // Fix search box being focused when the launcher is opened.
            // TODO: Figure out why this happens.
            HomeContainer.Select();

            // Position some manually-centered controls.
            HomeContainer.Location = GetHomepagePosition();
            RandomButton.Location = GetRandomButtonPosition();

            // Run this on startup, it will outsource the actual db-reading to another thread.
            InitializeDatabase();
        }

        private void Main_resize(object sender, EventArgs e)
        {
            // Scale column widths based on the list width.
            if (columnChanged)
            {
                ScaleColumns();
            }
            else
            {
                ResetColumns();
            }

            prevWidth = ArchiveList.ClientSize.Width;

            // Resize the metadata textbox to the appropriate height.
            ArchiveInfoData.Height = GetInfoHeight();

            // Re-position the contents of the Home tab.
            HomeContainer.Location = GetHomepagePosition();

            // Center the Random button.
            RandomButton.Location = GetRandomButtonPosition();
        }

        // Initialize list when the Archive tab is accessed for the first time.
        // Otherwise, update column widths if window is resized while in a different tab.
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

        // Execute search when the enter key is pressed.
        private void SearchBox_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ExecuteSearchQuery();
                e.SuppressKeyPress = true;
            }
        }

        // Execute search when the Search button is clicked.
        private void SearchButton_click(object sender, EventArgs e) { ExecuteSearchQuery(); }

        // Display settings menu when the Settings button is clicked.
        private void SettingsButton_click(object sender, EventArgs e) { OpenSettings(); }

        // Reload database when the Settings menu is closed.
        private void SettingsMenu_formClosed(object? sender, FormClosedEventArgs e)
        {
            Config.Read();

            if (TabControl.SelectedIndex == 1 && Config.NeedsRefresh)
            {
                InitializeDatabase();
            }
        }

        // Display information about the selected entry in the right-hand panel.
        private void ArchiveList_itemSelect(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = ((ListView)sender).SelectedIndices;

            // Clear panel if item is deselected.
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

            MetaDataObj? metadataOutput = DatabaseQueryMeta(entry, queryLibrary);

            // Check: was the entry found?
            if (metadataOutput == null)
            {
                // Error: the entry wasn't found in the database.
                // Exit nicely, instead of making a mess of things.
                return;
            }

            /* HEADER */

            ArchiveInfoTitle.Text = metadataOutput.Title;

            ArchiveInfoDeveloper.Text = metadataOutput.Developer != "" ? $"by {metadataOutput.Developer}" : "by unknown developer";

            ArchiveInfoData.Height = GetInfoHeight();

            /* METADATA */

            ArchiveInfoData.Rtf = BuildEntryData(metadataOutput);

            /* IMAGES */

            if (!ArchiveImagesContainer.Visible)
            {
                ArchiveImagesContainer.Visible = true;
            }

            // TODO: make images persistent.
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

            /* FOOTER */

            // If additional applications exist for the selected entry, display an arrow button with a menu.
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

        // Launch the selected entry.
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

            // If the entry hasn't been played already, add it to the list of played entries.
            if (!playedEntries.Contains(entryID))
            {
                playedEntries.Add(entryID);

                UpdateFPFile("downloads.fp", playedEntries, downloadsFPLock);
            }
        }

        // Display additional applications when the arrow next to the Play button is clicked.
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

        // Launch an additional application.
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

                    UpdateFPFile("downloads.fp", playedEntries, downloadsFPLock);
                }
            }

            LaunchEntry.Start();
        }

        // Add or remove an entry from favorites list and update star icon.
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

            UpdateFPFile("favorites.fp", favoritedEntries, favoritesFPLock);
        }

        // Update columnWidths in case a column's width is changed manually.
        private void ArchiveList_columnChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (ArchiveList.ClientSize.Width == prevWidth)
            {
                columnWidths[e.ColumnIndex] = ArchiveList.Columns[e.ColumnIndex].Width;
                columnChanged = true;
            }
        }

        // Preserve arrow cursor when hovering over the selected item.
        private void ArchiveList_mouseMove(object sender, MouseEventArgs e) { base.Cursor = Cursors.Arrow; }

        // Reset column widths when the Reset Columns button is clicked.
        private void ResetColumnsButton_click(object sender, EventArgs e) { ResetColumns(); }

        // Focus on a random entry when the Random (dice) button is clicked.
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

        // Change list when a different one is selected through the left panel.
        bool activateOnce = true;
        private void ArchiveRadio_checkedChanged(object sender, EventArgs e)
        {
            // Prevent event from firing twice.
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

        // Display a picture viwwer with the clicked image.
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

        #endregion

        #region Form Component-changing Functions

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

        // Generate a new cache and refresh list.
        private void RefreshDatabase_Block()
        {
            new Thread(() => RefreshDatabase_OnThread_BlockBased(columnChanged, ArchiveRadioPlays.Checked, ArchiveRadioFavorites.Checked,
                playedEntries, favoritedEntries, querySearch, queryOperations, queryLibrary, BlockSize,
                ArchiveList.PrimarySortColumn == null ? "Title" : ArchiveList.PrimarySortColumn.AspectName,
                ArchiveList.PrimarySortOrder == SortOrder.Descending ? 0 : 1, filteredTags)).Start();
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
                
                // Get values to be inserted into QueryItem objects
                if (playsChecked || favoritesChecked)
                {
                    temp = new();
                    foreach (string id in playsChecked ? playedEnts : favoritedEnts)
                    {
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
                    // Ooh, look at me being clever. For-loops can have arbitrary conditions. This is a while-loop, but with a loop counter.
                    for (int iterationNum=0; lastBlockSize == blockSize; iterationNum++)
                    {
                        // Update the columns after the first block is done.
                        if (iterationNum == 1)
                        {
                            // Scale the columns nicely.
                            if (colChanged)
                            {
                                ScaleColumns();
                            }
                            else
                            {
                                ResetColumns();
                            }
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
                        // Set the list length appropriately.
                        UpdateArchiveListLength();

                    }
                    connection.Close();
                }

                // Sort new queryCache
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

        // TODO: mess with this, ensure it escapes stuff properly.
        private void ExecuteSearchQuery()
        {
            // TODO: memory leak
            queryOperations = new();

            // Replace characters { " \ % } with _ to prevent errors.
            string tempSearch = Regex.Replace(SearchBox.Text, "[\"\\%]", "_");

            // Initialize search operators.
            int leftBracketCount = tempSearch.Count(i => i == '[');
            int rightBracketCount = tempSearch.Count(i => i == ']');

            // Check if brackets exist in the search query.
            if (leftBracketCount > 0 && leftBracketCount == rightBracketCount)
            {
                // Iterate through each group of brackets.
                for (int i = 0; i < leftBracketCount; i++)
                {
                    // Get indices of each bracket.
                    // HACK: because this doesn't correctly deal with nested brackets.
                    int leftBracket = tempSearch.IndexOf('[');
                    int rightBracket = tempSearch.IndexOf(']');

                    // Check if brackets are formatted correctly.
                    if (rightBracket > leftBracket && leftBracket != -1)
                    {
                        // Get an array containing each parameter.
                        string[] operationParams = tempSearch.Substring(leftBracket + 1, rightBracket - leftBracket - 1).Split(':');

                        // Create operation if parameters are valid.
                        if (operationParams.Length == 2)
                        {
                            // TODO: aliases of meta names.
                            if (MetaDataObj.metadataFields.ContainsKey(operationParams[0]))
                            {
                                // Check for | (or) operators and update query accordingly.
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

            // Remove padding left from operations being cut out of query.
            tempSearch = tempSearch.Trim();

            // Apply remaining string to generic search query.
            querySearch = tempSearch;

            // Refresh list and open it.
            RefreshDatabase_Block();
            TabControl.SelectTab(1);
        }

        // Create Settings menu instance and attach event for when it is closed.
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
                // The condition at the end ensures that the first column is double the length of the others.
                columnWidths[i] = (ArchiveList.ClientSize.Width / divisor) * (i == 0 ? 2 : 1);
                ArchiveList.Columns[i].Width = (int)columnWidths[i];
            }
            ArchiveList.EndUpdate();

            if (columnChanged)
            {
                columnChanged = false;
            }
        }

        /// <summary>
        /// Clears the info panel on the right.
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

        #endregion

        #region Utility Functions

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
            entryData += meta.Library == "" ? "" :
                $"\\b {MetaDataObj.metadataFields["library"]}: \\b0 " +
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

        // Read filters.json and load any tags under active filters into the filteredTags list.
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

        // Return an RTF-compatible string.
        // (Adapted from https://stackoverflow.com/a/30363185)
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

        #region *.fp Read/Write Functions

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

        private void UpdateFPFile(string fileName, List<string> list, object locker)
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

        #endregion

        #region Property Calculation Functions

        private Point GetHomepagePosition() =>
            new Point(
                (HomeTab.Width - HomeContainer.Width) / 2,
                (HomeTab.Height - HomeContainer.Height) / 2
            );

        private Point GetRandomButtonPosition() => new Point((ArchiveListFooter.Width - RandomButton.Width) / 2, 1);

        // Return the appropriate height for the metadata text box.
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

        #endregion

        #endregion

        #region Link Handlers

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

        #endregion
    }
}