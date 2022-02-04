using Microsoft.Data.Sqlite;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Text;

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
        // Index of currently-selected item
        int selectedIndex = 0;
        // Calculated column widths before conversion to int
        List<double> columnWidths = new();
        string[,] metadataNames =
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
            { "Notes", "notes" },
            { "Original Description", "originalDescription" }
        };
        // Indices of metadataNames items to be used for displaying columns
        int[] columnIndices = { 0, 3, 4 };
        // Characters that are safe to use in searches
        // Hopefully to be replaced with a better solution in the future
        string acceptableChars = "abcdefghijklmnopqrstuvwxyz1234567890 ";
        // Path to Flashpoint database
        string flashpointPath = ".";
        // Path to Flashpoint server
        string flashpointServer = "http://infinity.unstable.life/Flashpoint";
        // Query fragments used to fetch entries
        string queryLibrary = "arcade";
        string queryOrderBy = "title";
        string queryDirection = "ASC";
        string querySearch = "";
        // Current query range
        int queryStart = 0;
        int queryLength = 1000;
        /*
         *  Query data from within specified range
         *  
         *  This should ALWAYS have columnNames.GetLength(0) lists in the
         *  first dimension and queryLength strings in the second dimension
         *  
         *  Anything else risks an "index out of range" exception
         */
        List<List<string>> queryData = new();
        // Check if Archive tab has been clicked
        bool archiveTabClicked = false;
        // Check if column width has been changed manually
        bool columnChanged = false;

        /*--------+
         | EVENTS |
         +--------*/

        private void Main_load(object sender, EventArgs e)
        {
            foreach (int _ in columnIndices)
                queryData.Add(Enumerable.Repeat("", queryLength).ToList());

            // Why Visual Studio doesn't let me do this the regular way, I don't know
            SearchBox.AutoSize = false;
            SearchBox.Height = 20;
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

        // Open file dialog when Flashpoint path Browse button is clicked
        private void DatabasePathButton_click(object sender, EventArgs e)
        {
            CommonOpenFileDialog DatabasePathDialog = new() { IsFolderPicker = true };

            if (DatabasePathDialog.ShowDialog() == CommonFileDialogResult.Ok)
                DatabasePathInput.Text = DatabasePathDialog.FileName;
        }

        // Initialize list when Archive tab is accessed for the first time
        // Update column widths if window is resized while in a different tab
        private void TabControl_click(object sender, MouseEventArgs e)
        {
            TabControl clickedTab = (TabControl)sender;

            if (clickedTab.SelectedIndex == 1)
            {
                if (DatabasePathInput.Text != flashpointPath || !archiveTabClicked)
                    ValidateDatabase();

                if (!archiveTabClicked)
                {
                    InitializeColumns();
                    AdjustColumns();

                    if (queryLibrary == "arcade")
                        ArchiveRadioGames.Checked = true;
                    else if (queryLibrary == "theatre")
                        ArchiveRadioAnimations.Checked = true;

                    archiveTabClicked = true;
                }
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

        // Add items to list and improve performance by using larger, less frequent SQL queries
        private void ArchiveList_retrieveItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // If item information is not already found in queryData, generate a new list
            if (e.ItemIndex >= queryStart + queryLength || e.ItemIndex < queryStart || e.ItemIndex == 0)
            {
                queryStart = e.ItemIndex - (e.ItemIndex % queryLength);

                List<List<string>> tempData = new();

                foreach (int i in columnIndices)
                    tempData.Add(
                        DatabaseQuery(GetQuery(metadataNames[i, 1], queryStart, queryLength))
                    );

                queryData = tempData;
            }

            ListViewItem entry = new(queryData[0][e.ItemIndex % queryLength]);

            for (int i = 1; i < columnIndices.Length; i++)
                entry.SubItems.Add(queryData[i][e.ItemIndex % queryLength]);

            e.Item = entry;
        }

        // Display information about selected entry
        private void ArchiveList_itemSelect(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = ArchiveList.SelectedIndices;

            // This is the only way I can grab the selected index without an error
            foreach (int index in selectedIndices)
                selectedIndex = index;

            List<string> metadataOutput = new(metadataNames.GetLength(0));

            for (int i = 0; i < metadataNames.GetLength(0); i++)
                metadataOutput.Add(
                    DatabaseQuery(GetQuery(metadataNames[i, 1], selectedIndex))[0]
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
                    if (metadataNames[i, 1] == "notes" || metadataNames[i, 1] == "originalDescription")
                        entryData += $"\\line\\b {metadataNames[i, 0]}:\\line\\b0 {ToUnicode(metadataOutput[i])}\\line";
                    else
                        entryData += $"\\b {metadataNames[i, 0]}: \\b0 {ToUnicode(metadataOutput[i])}\\line";
                }

            entryData += "}";

            ArchiveInfoData.Rtf = entryData;

            // Images

            ArchiveImagesLogo.Image = null;
            ArchiveImagesScreenshot.Image = null;

            if (!ArchiveImagesContainer.Visible)
                ArchiveImagesContainer.Visible = true;

            string entryId = DatabaseQuery(GetQuery("id", selectedIndex))[0];
            string[] imageFolders = { "Logos", "Screenshots" };
            foreach (string folder in imageFolders)
            {
                string[] imageTree = { entryId.Substring(0, 2), entryId.Substring(2, 2) };
                string imagePath = $"\\Data\\Images\\{folder}\\{imageTree[0]}\\{imageTree[1]}\\{entryId}.png";

                if (folder == "Logos")
                {
                    if (File.Exists(flashpointPath + imagePath))
                        ArchiveImagesLogo.Image = Image.FromFile(flashpointPath + imagePath);
                    else
                        ArchiveImagesLogo.ImageLocation = flashpointServer + imagePath;
                }
                else if (folder == "Screenshots")
                {
                    if (File.Exists(flashpointPath + imagePath))
                        ArchiveImagesScreenshot.Image = Image.FromFile(flashpointPath + imagePath);
                    else
                        ArchiveImagesScreenshot.ImageLocation = flashpointServer + imagePath;
                }
            }
        }

        // Launch selected entry (PLACEHOLDER)
        private void ArchiveList_itemAccess(object sender, EventArgs e)
        {
            int entryIndex = ArchiveList.SelectedIndices[0];

            LaunchEntry.StartInfo.WorkingDirectory = flashpointPath + @"\Launcher";
            LaunchEntry.StartInfo.Arguments = $"play -i {DatabaseQuery(GetQuery("id", entryIndex))[0]}";
            LaunchEntry.Start();
        }

        // Update columnWidths in case column is changed manually
        private void ArchiveList_columnChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            ListView changedList = (ListView)sender;

            if (changedList.ClientSize.Width == prevWidth)
            {
                columnWidths[e.ColumnIndex] = ArchiveList.Columns[e.ColumnIndex].Width;
                columnChanged = true;
            }
        }

        // Automatically sort clicked column
        private void ArchiveList_columnClick(object sender, ColumnClickEventArgs e)
        {
            queryOrderBy = metadataNames[columnIndices[e.Column], 1];
            queryDirection = queryDirection == "DESC" ? "ASC" : "DESC";

            for (int i = 0; i < ArchiveList.Columns.Count; i++)
                ArchiveList.Columns[i].Text = metadataNames[columnIndices[i], 0];

            string arrow = char.ConvertFromUtf32(queryDirection == "ASC" ? 0x2193 : 0x2191);
            ArchiveList.Columns[e.Column].Text = $"{metadataNames[columnIndices[e.Column], 0]}  {arrow}";

            RefreshDatabase();
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
                else if (checkedRadio.Name == "ArchiveRadioAnimations")
                    queryLibrary = "theatre";

                if (archiveTabClicked)
                    RefreshDatabase();
            }
        }

        // Display picture viwwer 
        private void ArchiveImages_click(object sender, EventArgs e)
        {
            Form pictureViewer = new();
            pictureViewer.Size = new Size(640, 480);
            pictureViewer.Controls.Add(new PictureBox()
            {
                Name = "PictureContainer",
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = ((PictureBox)sender).Name == "ArchiveImagesLogo" ? ArchiveImagesLogo.Image : ArchiveImagesScreenshot.Image,
            });
            pictureViewer.ShowInTaskbar = false;
            pictureViewer.Show();
        }

        /*-----------+
         | FUNCTIONS |
         +-----------*/

        // SQLite query template to make things easier
        private string GetQuery(string column, int offset, int length = 1) =>
            $"SELECT {column} FROM game " +
            $"WHERE library = '{queryLibrary}'" +
            (querySearch != "" ? $"AND title LIKE '%{querySearch}%'" : "") +
            $"ORDER BY {queryOrderBy} {queryDirection} " +
            $"LIMIT {offset}, {length}";

        // Make strings suitable for RTF text box
        // Adapted from https://stackoverflow.com/a/30363185
        static string ToUnicode(string data)
        {
            var escapedData = new StringBuilder();

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

        // Leave the right amount of room for metadata text box
        private int GetInfoHeight()
        {
            int desiredHeight = ArchiveInfoContainer.Height - 14;

            foreach (Control control in ArchiveInfoContainer.Controls)
                if (control.Name != "ArchiveInfoData")
                    desiredHeight -= control.Height;

            return desiredHeight;
        }

        private void ExecuteSearchQuery()
        {
            StringBuilder safeQuery = new();

            foreach (char inputChar in SearchBox.Text.ToLower())
            {
                if (acceptableChars.Contains(inputChar))
                    safeQuery.Append(inputChar);
                else
                    safeQuery.Append('_');
            }

            querySearch = safeQuery.ToString();
            RefreshDatabase();
        }

        // Check if specified database exists and is an SQLite database
        // Adapted from https://stackoverflow.com/a/70291358
        private void ValidateDatabase()
        {
            string databasePath = DatabasePathInput.Text + @"\Data\flashpoint.sqlite";
            byte[] header = new byte[16];

            if (File.Exists(databasePath))
            {
                using (FileStream fileStream = new(databasePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    fileStream.Read(header, 0, 16);

                if (Encoding.ASCII.GetString(header).Contains("SQLite format"))
                {
                    flashpointPath = DatabasePathInput.Text;
                    RefreshDatabase();

                    return;
                }
            }

            MessageBox.Show("Invalid database!", "Error");

            DatabasePathInput.Text = flashpointPath;
            TabControl.SelectTab(0);
        }

        // Reload list and update entry count display
        private void RefreshDatabase()
        {
            queryStart = 0;

            string entryCount = DatabaseQuery(
                $"SELECT COUNT(id) FROM game " +
                $"WHERE library = '{queryLibrary}'" +
                (querySearch != "" ? $"AND title LIKE '%{querySearch}%' ESCAPE '?'" : "")
            )[0];

            EntryCountLabel.Text = $"Displaying {entryCount} entr" + (entryCount == "1" ? "y" : "ies") + ".";

            ArchiveList.VirtualListSize = 0;
            ArchiveList.VirtualListSize = Convert.ToInt32(entryCount);
        }

        // Add columns from columnNames to list and get width for later
        private void InitializeColumns()
        {
            for (int i = 0; i < columnIndices.Length; i++)
            {
                ArchiveList.Columns.Add(metadataNames[columnIndices[i], 0]);
                columnWidths.Add(ArchiveList.Columns[i].Width);
            }

            prevWidth = ArchiveList.ClientSize.Width;
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

        // Return array containing results of SQL query
        private List<string> DatabaseQuery(string query)
        {
            SqliteConnection connection = new($"Data Source={flashpointPath}\\Data\\flashpoint.sqlite");
            connection.Open();

            SqliteCommand command = new(query, connection);

            List<string> data = new();

            using (SqliteDataReader dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    data.Add(dataReader.IsDBNull(0) ? "" : dataReader.GetString(0));

            connection.Close();

            return data;
        }
    }
}