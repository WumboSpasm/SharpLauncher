using Microsoft.Data.Sqlite;

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
        private int prevWidth;
        // Calculated column widths before conversion to int
        List<double> columnWidths = new();
        // Column names to restore from when sort direction arrow is cleared
        string[,] columnNames =
        {
            { "Title", "title" },
            { "Developer", "developer" },
            { "Publisher", "publisher" }
        };
        // Path to Flashpoint database
        string databasePath = "";
        // Query fragments used to fetch entries
        string queryLibrary = "arcade";
        string queryOrderBy = "title";
        string queryDirection = "ASC";
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
            for (int i = 0; i < columnNames.GetLength(0); i++)
                queryData.Add(Enumerable.Repeat("", queryLength).ToList());
        }

        // Scale column widths to list width
        private void Main_resize(object sender, EventArgs e)
        {
            if (columnChanged)
                ScaleColumns();
            else
                AdjustColumns();

            prevWidth = ArchiveList.ClientSize.Width;
        }

        private void DatabasePathButton_click(object sender, EventArgs e)
        {
            if (DatabasePathDialog.ShowDialog() == DialogResult.OK)
                DatabasePathInput.Text = DatabasePathDialog.FileName;
        }

        // Initialize list when Archive tab is accessed for the first time
        // Update column widths if window is resized while in a different tab
        private void TabControl_click(object sender, MouseEventArgs e)
        {
            TabControl clickedTab = (TabControl)sender;

            if (clickedTab.SelectedIndex == 1)
            {
                if (DatabasePathInput.Text != databasePath || DatabasePathInput.Text == "")
                    ValidateDatabase();

                if (!archiveTabClicked)
                {
                    InitializeColumns();
                    AdjustColumns();

                    archiveTabClicked = true;
                }
                else if (columnChanged)
                    ScaleColumns();
                else
                    AdjustColumns();
            }
        }

        // Add items to list and improve performance by using larger, less frequent SQL queries
        private void ArchiveList_retrieveItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            // If item information is not already found in queryData, generate a new list
            if (e.ItemIndex >= queryStart + queryLength || e.ItemIndex < queryStart || e.ItemIndex == 0)
            {
                queryStart = e.ItemIndex - (e.ItemIndex % queryLength);

                List<List<string>> tempData = new();

                for (int i = 0; i < columnNames.GetLength(0); i++)
                    tempData.Add(DatabaseQuery(
                        $"SELECT {columnNames[i, 1]} FROM game " +
                        $"WHERE library = '{queryLibrary}'" +
                        $"ORDER BY {queryOrderBy} {queryDirection} " +
                        $"LIMIT {queryStart}, {queryLength}"
                    ));

                queryData = tempData;
            }

            DebugLabel.Text = $"{e.ItemIndex} | {queryStart}";

            ListViewItem entry = new(queryData[0][e.ItemIndex % queryLength]);

            for (int i = 1; i < columnNames.GetLength(0); i++)
                entry.SubItems.Add(queryData[i][e.ItemIndex % queryLength]);

            e.Item = entry;
        }

        // Display information about selected entry
        private void ArchiveList_itemSelect(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection selectedIndices = ArchiveList.SelectedIndices;

            // This is the only way I can grab the selected index without an error
            int index = 0;
            foreach (int tempIndex in selectedIndices)
                index = tempIndex;
            
            List<string> metadataInputs = new()
            {
                "title",
                "alternateTitles",
                "series",
                "developer",
                "publisher",
                "source"
            };
            List<string> metadataOutput = new(metadataInputs.Count);

            foreach (string input in metadataInputs)
            {
                metadataOutput.Add(DatabaseQuery(
                    $"SELECT {input} FROM game " +
                    $"WHERE library = '{queryLibrary}'" +
                    $"ORDER BY {queryOrderBy} {queryDirection} " +
                    $"LIMIT {index}, 1"
                )[0]);
            }

            ArchiveEntryInfo.Rtf = @"{\rtf1\ansi " +
                @"\b Title: \b0" + metadataOutput[0] + @"\line" +
                @"\b Alternate titles: \b0" + metadataOutput[1] + @"\line" +
                @"\b Series: \b0" + metadataOutput[2] + @"\line" +
                @"\b Developer: \b0" + metadataOutput[3] + @"\line" +
                @"\b Publisher: \b0" + metadataOutput[4] + @"\line" +
                @"\b Source: \b0" + metadataOutput[5] + "}";
            
        }

        // Launch selected entry (PLACEHOLDER)
        private void ArchiveList_itemAccess(object sender, EventArgs e)
        {
            int entryIndex = ArchiveList.SelectedIndices[0];

            MessageBox.Show(DatabaseQuery(
                $"SELECT id FROM game " +
                $"WHERE library = '{queryLibrary}'" +
                $"ORDER BY {queryOrderBy} {queryDirection} " +
                $"LIMIT {entryIndex}, 1"
            )[0], DatabaseQuery(
                $"SELECT title FROM game " +
                $"WHERE library = '{queryLibrary}'" +
                $"ORDER BY {queryOrderBy} {queryDirection} " +
                $"LIMIT {entryIndex}, 1"
            )[0]);
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
            queryOrderBy = columnNames[e.Column, 1];
            queryDirection = queryDirection == "DESC" ? "ASC" : "DESC";

            for (int i = 0; i < ArchiveList.Columns.Count; i++)
                ArchiveList.Columns[i].Text = columnNames[i, 0];

            string arrow = char.ConvertFromUtf32(queryDirection == "ASC" ? 0x2193 : 0x2191);
            ArchiveList.Columns[e.Column].Text = $"{columnNames[e.Column, 0]}  {arrow}";

            RefreshDatabase();
        }

        // Preserve arrow cursor when hovering over selected item
        private void ArchiveList_mouseMove(object sender, MouseEventArgs e) { base.Cursor = Cursors.Arrow; }

        // Reroute Adjust Columns button to its appropriate function
        private void AdjustColumnsButton_click(object sender, EventArgs e) { AdjustColumns(); }

        /*-----------+
         | FUNCTIONS |
         +-----------*/

        // Check if specified database exists and is an SQLite database
        // Adapted from https://stackoverflow.com/a/70291358
        private void ValidateDatabase()
        {
            byte[] header = new byte[16];

            if (File.Exists(DatabasePathInput.Text))
            {
                using (FileStream fileStream = new(DatabasePathInput.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    fileStream.Read(header, 0, 16);

                if (System.Text.Encoding.ASCII.GetString(header).Contains("SQLite format"))
                {
                    databasePath = DatabasePathInput.Text;
                    RefreshDatabase();

                    return;
                }
            }

            MessageBox.Show("Invalid database!", "Error");

            DatabasePathInput.Text = databasePath;
            TabControl.SelectTab(0);
        }

        private void RefreshDatabase()
        {
            queryStart = 0;
            
            ArchiveList.VirtualListSize = 0;
            ArchiveList.VirtualListSize = Convert.ToInt32(DatabaseQuery($"SELECT COUNT(id) FROM game WHERE library = '{queryLibrary}'")[0]);
        }

        // Add columns from columnNames to list and get width for later
        private void InitializeColumns()
        {
            for (int i = 0; i < columnNames.GetLength(0); i++)
            {
                ArchiveList.Columns.Add(columnNames[i, 0]);
                columnWidths.Add(ArchiveList.Columns[i].Width);
            }

            prevWidth = ArchiveList.ClientSize.Width;
        }

        // Resize columns proportional to new list size
        private void ScaleColumns()
        {
            Main.ActiveForm.Text = ArchiveList.ClientSize.Width.ToString();

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
            SqliteConnection connection = new($"Data Source={databasePath}");
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