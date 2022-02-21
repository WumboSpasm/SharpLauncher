using System.Text;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;

namespace WumboLauncher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /*-----------+
         | VARIABLES |
         +-----------*/

        // Previous width of the list
        int prevWidth;
        // Metadata fields to be retrieved alongside their proper names
        string[,] metadataFields =
        {
            { "Title", "title" },
            { "Alternate Titles", "alternateTitles" },
            { "Series", "series" },
            { "Developer", "developer" },
            { "Publisher", "publisher" },
            { "Source", "source" },
            { "Release Date", "releaseDate" },
            { "Platform", "platform" },
            { "Version", "version" },
            { "Tags", "tagsStr" },
            { "Language", "language" },
            { "Play Mode", "playMode" },
            { "Status", "status" },
            { "Legacy Game", "activeDataOnDisk" },
            { "Notes", "notes" },
            { "Original Description", "originalDescription" }
        };
        // Titles to be displayed above each column
        string[] columnHeaders = { "Title", "Developer", "Publisher" };
        // Calculated column widths before conversion to int
        List<double> columnWidths = new();
        // Names of tags to be filtered
        List<string> filteredTags = new();
        // Characters that cause issues in searches ( % _ ' " )
        string unsafeChars = "%_\'\""; 
        // Query fragments used to fetch entries
        string queryLibrary = "arcade";
        int queryOrderBy = 0;
        int queryDirection = 1;
        string querySearch = "";
        // Template for list items
        class QueryItem
        {
            public string Title { get; set; } = "";
            public string Developer { get; set; } = "";
            public string Publisher { get; set; } = "";
            public string ID { get; set; } = "";
        }
        // Cache of all items to be displayed in list
        List<QueryItem> queryCache = new();
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
                Config.Read();
            else
                Config.Write();

            if (File.Exists("downloads.fp"))
                playedEntries = File.ReadAllLines("downloads.fp").ToList();
            else
                File.Create("downloads.fp");

            if (File.Exists("favorites.fp"))
                favoritedEntries = File.ReadAllLines("favorites.fp").ToList();
            else
                File.Create("favorites.fp");

            // Why Visual Studio doesn't let me do this the regular way, I don't know
            SearchBox.AutoSize = false;
            SearchBox.Height = 20;

            // Give the additional apps button an arrow
            AlternateButton.Text = char.ConvertFromUtf32(0x2BC5);
        }

        private void Main_resize(object sender, EventArgs e)
        {
            // Scale column widths to list width
            if (columnChanged)
                ScaleColumns();
            else
                AdjustColumns();

            prevWidth = ArchiveList.ClientSize.Width;

            // Resize metadata textbox to new height
            ArchiveInfoData.Height = GetInfoHeight();
        }

        // Initialize list when Archive tab is accessed for the first time
        // Update column widths if window is resized while in a different tab
        private void TabControl_tabChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 1)
            {
                if (Config.NeedsRefresh)
                    InitializeDatabase();
                else if (columnChanged)
                    ScaleColumns();
                else
                    AdjustColumns();
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
                InitializeDatabase();
        }

        // Display items on list when fetched
        private void ArchiveList_retrieveItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            ListViewItem entry = new(queryCache[e.ItemIndex].Title);
            entry.SubItems.Add(queryCache[e.ItemIndex].Developer);
            entry.SubItems.Add(queryCache[e.ItemIndex].Publisher);

            e.Item = entry;
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

            List<string> metadataOutput = new(metadataFields.GetLength(0));
            string entryID = queryCache[selectedIndices[0]].ID;

            for (int i = 0; i < metadataFields.GetLength(0); i++)
                metadataOutput.Add(
                    DatabaseQuery($"SELECT {metadataFields[i, 1]} from GAME where id = '{entryID}'")[0]
                );

            // Header

            ArchiveInfoTitle.Text = metadataOutput[0];

            if (metadataOutput[3] != "")
                ArchiveInfoDeveloper.Text = $"by {metadataOutput[3]}";
            else
                ArchiveInfoDeveloper.Text = "by unknown developer";

            ArchiveInfoData.Height = GetInfoHeight();

            // Metadata

            string entryData = @"{\rtf1 ";

            for (int i = 1; i < metadataOutput.Count; i++)
                if (metadataOutput[i] != "")
                {
                    if (metadataFields[i, 0] == "Legacy Game")
                        entryData += $"\\b {metadataFields[i, 0]}: \\b0 {(metadataOutput[i] == "0" ? "Yes" : "No")}\\line";
                    else if (metadataFields[i, 0] == "Notes" || metadataFields[i, 0] == "Original Description")
                        entryData += $"\\line\\b {metadataFields[i, 0]}:\\line\\b0 {ToUnicode(metadataOutput[i])}\\line";
                    else
                        entryData += $"\\b {metadataFields[i, 0]}: \\b0 {ToUnicode(metadataOutput[i])}\\line";
                }

            entryData += "}";

            ArchiveInfoData.Rtf = entryData;

            // Images

            if (!ArchiveImagesContainer.Visible)
                ArchiveImagesContainer.Visible = true;
            
            foreach (string folder in new string[] { "Logos", "Screenshots" })
            {
                string[] imageTree = { entryID.Substring(0, 2), entryID.Substring(2, 2) };
                string imagePath = $"\\Data\\Images\\{folder}\\{imageTree[0]}\\{imageTree[1]}\\{entryID}.png";

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
                        ArchiveImagesLogo.ImageLocation = Config.FlashpointServer + imagePath;
                    else if (folder == "Screenshots")
                        ArchiveImagesScreenshot.ImageLocation = Config.FlashpointServer + imagePath;
                }
            }

            // Footer

            List<string> additionalApps = DatabaseQuery($"SELECT name FROM additional_app WHERE parentGameId = '{entryID}'");

            // Display or hide additional apps button if they exist
            if (additionalApps.Count > 0)
            {
                PlayButton.Width = 238;
                AlternateButton.Visible = true;
            }
            else
            {
                AlternateButton.Visible = false;
                PlayButton.Width = 253;
            }

            if (favoritedEntries.Contains(queryCache[ArchiveList.SelectedIndices[0]].ID))
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

        // Launch selected entry
        private void ArchiveList_itemAccess(object sender, EventArgs e)
        {
            if (!InitializeCLIFp())
                return;

            string entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;

            LaunchEntry.StartInfo.Arguments = $"play -i {entryID}";
            LaunchEntry.Start();

            // Add to list of played entries (if it hasn't been played already)
            if (!playedEntries.Contains(entryID))
            {
                playedEntries.Add(entryID);

                using (StreamWriter newText = File.AppendText("downloads.fp"))
                    newText.WriteLine(entryID);
            }
        }

        // Display additional apps when arrow button is clicked
        private void AlternateButton_click(object sender, EventArgs e)
        {
            AlternateMenu.Items.Clear();
            string entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;

            int i = 0;
            foreach (string name in DatabaseQuery($"SELECT name FROM additional_app WHERE parentGameId = '{entryID}'"))
            {
                AlternateMenu.Items.Add($"Launch:  {name}");
                AlternateMenu.Items[i].Tag = DatabaseQuery($"SELECT id FROM additional_app WHERE name = '{name}'")[0];

                i++;
            }

            Point menuPosition = AlternateButton.Parent.PointToScreen(AlternateButton.Location);
            menuPosition.X += AlternateButton.Width;

            AlternateMenu.Show(menuPosition, ToolStripDropDownDirection.AboveLeft);
        }

        // Launch additional app
        private void AlternateMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!InitializeCLIFp())
                return;

            string entryID = (string)e.ClickedItem.Tag;
            string entryAppPath = DatabaseQuery($"SELECT applicationPath FROM additional_app WHERE id = '{entryID}'")[0];

            LaunchEntry.StartInfo.Arguments = $"play -i {entryID}";

            if (entryAppPath != ":extras:" && entryAppPath != ":message:")
            {
                string entryParentID = DatabaseQuery($"SELECT parentGameId FROM additional_app WHERE id = '{entryID}'")[0];

                // Add to list of played entries (if it hasn't been played already)
                if (!playedEntries.Contains(entryParentID))
                {
                    playedEntries.Add(entryParentID);

                    using (StreamWriter newText = File.AppendText("downloads.fp"))
                        newText.WriteLine(entryParentID);
                }
            }

            LaunchEntry.Start();
        }

        // Add or remove entry from favorites list and change image
        private void FavoriteButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox favoriteButton = (CheckBox)sender;

            string entryID = queryCache[ArchiveList.SelectedIndices[0]].ID;

            if (favoriteButton.Checked)
            {
                if (!favoritedEntries.Contains(entryID))
                    favoritedEntries.Add(entryID);

                favoriteButton.ImageIndex = 1;
            }
            else
            {
                if (favoritedEntries.Contains(entryID))
                    favoritedEntries.Remove(entryID);

                favoriteButton.ImageIndex = 0;
            }

            using (FileStream favorites = new("favorites.fp", FileMode.Open, FileAccess.Write, FileShare.ReadWrite))
            {
                lock (favorites)
                    favorites.SetLength(0);

                favorites.Write(Encoding.ASCII.GetBytes(String.Join(Environment.NewLine, favoritedEntries)));
            }
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

        // Automatically sort clicked column
        private void ArchiveList_columnClick(object sender, ColumnClickEventArgs e)
        {
            // Set column to sort by and reverse direction
            queryOrderBy = e.Column;
            queryDirection *= -1;

            // Remove any indicators that might be visible
            for (int i = 0; i < columnHeaders.Length; i++)
                if (ArchiveList.Columns[i].Text != columnHeaders[i])
                    ArchiveList.Columns[i].Text = columnHeaders[i];

            // Add a new arrow indicator to column header
            string arrow = char.ConvertFromUtf32(0x2192 + queryDirection);
            ArchiveList.Columns[queryOrderBy].Text = $"{columnHeaders[queryOrderBy]}  {arrow}";

            SortColumns();
            ClearInfoPanel();

            ArchiveList.VirtualListSize = 0;
            ArchiveList.VirtualListSize = Convert.ToInt32(queryCache.Count);
        }

        // Preserve arrow cursor when hovering over selected item
        private void ArchiveList_mouseMove(object sender, MouseEventArgs e) { base.Cursor = Cursors.Arrow; }

        // Reroute Adjust Columns button to its appropriate function
        private void AdjustColumnsButton_click(object sender, EventArgs e) { AdjustColumns(); }

        // Change library when left panel radio is changed
        private void ArchiveRadio_checkedChanged(object sender, EventArgs e)
        {
            RadioButton checkedRadio = (RadioButton)sender;

            if (checkedRadio.Checked)
            {
                if (checkedRadio.Name == "ArchiveRadioGames")
                    queryLibrary = "arcade";
                if (checkedRadio.Name == "ArchiveRadioAnimations")
                    queryLibrary = "theatre";

                RefreshDatabase();
            }
        }

        private void ArchiveImages_loadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (((PictureBox)sender).Name == "ArchiveImagesLogo")
                logoLoaded = true;
            else if (((PictureBox)sender).Name == "ArchiveImagesScreenshot")
                screenshotLoaded = true;
        }

        // Display picture viwwer 
        private void ArchiveImages_click(object sender, EventArgs e)
        {
            string pictureName = ((PictureBox)sender).Name;

            if ((pictureName == "ArchiveImagesLogo" && logoLoaded) ||
                (pictureName == "ArchiveImagesScreenshot" && screenshotLoaded))
            {
                Form pictureViewer = new();
                pictureViewer.Size = new Size(640, 480);
                pictureViewer.Controls.Add(new PictureBox()
                {
                    Name = "PictureContainer",
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = pictureName == "ArchiveImagesLogo" ? ArchiveImagesLogo.Image : ArchiveImagesScreenshot.Image,
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
                Config.NeedsRefresh = false;

            string databasePath = Config.FlashpointPath + @"\Data\flashpoint.sqlite";
            byte[] header = new byte[16];

            if (File.Exists(databasePath))
            {
                using (FileStream fileStream = new(databasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    fileStream.Read(header, 0, 16);

                if (Encoding.ASCII.GetString(header).Contains("SQLite format"))
                {
                    LoadFilteredTags();
                    RefreshDatabase();

                    // Add columns to list and get width for later
                    if (ArchiveList.Columns.Count != columnHeaders.Length)
                    {
                        for (int i = 0; i < columnHeaders.Length; i++)
                        {
                            ArchiveList.Columns.Add(columnHeaders[i]);
                            columnWidths.Add(ArchiveList.Columns[i].Width);
                        }

                        prevWidth = ArchiveList.ClientSize.Width;
                    }

                    if (queryLibrary == "arcade")
                        ArchiveRadioGames.Checked = true;
                    else if (queryLibrary == "theatre")
                        ArchiveRadioAnimations.Checked = true;

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
        private void RefreshDatabase()
        {
            ClearInfoPanel();
            queryCache.Clear();

            List<string> queryTitle = new();
            List<string> queryDeveloper = new();
            List<string> queryPublisher = new();
            List<string> queryTags = new();
            List<string> queryID = new();

            // Get values to be inserted into QueryItem objects
            if (ArchiveRadioPlays.Checked || ArchiveRadioFavorites.Checked)
            {
                foreach (string id in ArchiveRadioPlays.Checked ? playedEntries : favoritedEntries)
                {
                    if (DatabaseQuery($"SELECT id FROM game WHERE id = '{id}'").Count == 0)
                        continue;

                    queryTitle.Add(DatabaseQuery($"SELECT title FROM game WHERE id = '{id}'")[0]);
                    queryDeveloper.Add(DatabaseQuery($"SELECT developer FROM game WHERE id = '{id}'")[0]);
                    queryPublisher.Add(DatabaseQuery($"SELECT publisher FROM game WHERE id = '{id}'")[0]);
                    queryTags.Add(DatabaseQuery($"SELECT tagsStr FROM game WHERE id = '{id}'")[0]);
                    queryID.Add(id);
                }
            }
            else
            {
                queryTitle = DatabaseQuery(GetQuery("title"));
                queryDeveloper = DatabaseQuery(GetQuery("developer"));
                queryPublisher = DatabaseQuery(GetQuery("publisher"));
                queryTags = DatabaseQuery(GetQuery("tagsStr"));
                queryID = DatabaseQuery(GetQuery("id"));
            }

            // If item is not filtered, create QueryItem object and add to queryCache
            for (int i = 0; i < queryTitle.Count; i++)
                if (!filteredTags.Intersect(queryTags[i].Split("; ")).Any())
                    queryCache.Add(new QueryItem
                    {
                        Title = queryTitle[i],
                        Developer = queryDeveloper[i],
                        Publisher = queryPublisher[i],
                        ID = queryID[i]
                    });

            // Sort new queryCache
            SortColumns();

            // Display entry count in bottom right corner
            EntryCountLabel.Text = $"Displaying {queryCache.Count} entr{(queryCache.Count == 1 ? "y" : "ies")}.";

            // Force list to reload items
            ArchiveList.VirtualListSize = 0;
            ArchiveList.VirtualListSize = Convert.ToInt32(queryCache.Count);

            // Prevent column widths from breaking out of list
            if (columnChanged)
                ScaleColumns();
            else
                AdjustColumns();
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
            filteredTags.Clear();

            if (File.Exists("filters.json"))
            {
                using (StreamReader jsonStream = new("filters.json"))
                {
                    dynamic? filterArray = JsonConvert.DeserializeObject(jsonStream.ReadToEnd());

                    foreach (var item in filterArray)
                        if (item.filtered == true)
                            foreach (var tag in item.tags)
                                filteredTags.Add(tag.ToString());
                }
            }
            else
                MessageBox.Show(
                    "filters.json was not found, and as a result the archive will be unfiltered. Use at your own risk.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning
                );
        }

        // Return items from the Flashpoint database
        private List<string> DatabaseQuery(string query)
        {
            SqliteConnection connection = new($"Data Source={Config.FlashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();

            SqliteCommand command = new(query, connection);

            List<string> data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    data.Add(dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));

            connection.Close();

            return data;
        }

        // Query template to make things easier
        private string GetQuery(string column, int offset = -1) =>
            $"SELECT {column} FROM game WHERE library = '{queryLibrary}'" +
            (querySearch != "" ? $"AND title LIKE '%{querySearch}%'" : "") +
            $"ORDER BY title {(offset != -1 ? $"LIMIT {offset}, 1" : "")}";

        private void ExecuteSearchQuery()
        {
            StringBuilder safeQuery = new();

            foreach (char inputChar in SearchBox.Text.ToLower())
            {
                if (unsafeChars.Contains(inputChar))
                    safeQuery.Append("_");
                else
                    safeQuery.Append(inputChar);
            }

            querySearch = safeQuery.ToString();
            RefreshDatabase();

            TabControl.SelectTab(1);
        }

        private void OpenSettings()
        {
            Settings SettingsMenu = new Settings();
            SettingsMenu.FormClosed += new FormClosedEventHandler(SettingsMenu_formClosed);

            SettingsMenu.ShowDialog();
        }

        // Resize columns proportional to new list size
        private void ScaleColumns()
        {
            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                columnWidths[i] *= (double)ArchiveList.ClientSize.Width / prevWidth;
                ArchiveList.Columns[i].Width = (int)columnWidths[i];
            }
        }

        // Resize columns to fill list width
        private void AdjustColumns()
        {
            int divisor = ArchiveList.Columns.Count + 1;

            ArchiveList.BeginUpdate();
            for (int i = 0; i < ArchiveList.Columns.Count; i++)
            {
                columnWidths[i] = (ArchiveList.ClientSize.Width / divisor) * (i == 0 ? 2 : 1);
                ArchiveList.Columns[i].Width = (int)columnWidths[i];
            }
            ArchiveList.EndUpdate();

            if (columnChanged)
                columnChanged = false;
        }

        // Sort items by a specific column
        private void SortColumns()
        {
            switch (columnHeaders[queryOrderBy])
            {
                case "Title":
                    queryCache = (
                        queryDirection == 1
                        ? queryCache.OrderBy(i => i.Title)
                        : queryCache.OrderByDescending(i => i.Title)
                    ).ToList();
                    break;

                case "Developer":
                    queryCache = (
                        queryDirection == 1
                        ? queryCache.OrderBy(i => i.Developer)
                        : queryCache.OrderByDescending(i => i.Developer)
                    ).ToList();
                    break;

                case "Publisher":
                    queryCache = (
                        queryDirection == 1
                        ? queryCache.OrderBy(i => i.Publisher)
                        : queryCache.OrderByDescending(i => i.Publisher)
                    ).ToList();
                    break;
            }
        }

        // Leave the right amount of room for metadata text box
        private int GetInfoHeight()
        {
            int desiredHeight = ArchiveInfoContainer.Height - 14;

            foreach (Control control in ArchiveInfoContainer.Controls)
                if (control.Name != "ArchiveInfoData")
                    desiredHeight -= control.Height;

            return desiredHeight;
        }

        private void ClearInfoPanel()
        {
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

        // Make strings suitable for RTF text box
        // Adapted from https://stackoverflow.com/a/30363185
        static string ToUnicode(string data)
        {
            StringBuilder escapedData = new();

            foreach (char c in data)
            {
                if (c == '\\' || c == '{' || c == '}')
                    escapedData.Append(@"\" + c);
                else if (c <= 0x7f)
                    escapedData.Append(c);
                else
                    escapedData.Append(@"\u" + Convert.ToUInt32(c) + "?");
            }

            return escapedData.ToString().Replace("\n", @"\line ");
        }
    }
}