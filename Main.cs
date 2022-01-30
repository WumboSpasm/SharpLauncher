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
        string queryOrderBy = "title";
        string queryDirection = "ASC";
        // Current query range
        int queryStart = 0;
        int queryLength = 100;
        // Query data from within specified range
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
                else
                {
                    if (columnChanged)
                        ScaleColumns();
                    else
                        AdjustColumns();
                }
            }
        }

        // Add items to list and improve performance by using larger, less frequent SQL queries
        private void ArchiveList_retrieveItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            DebugLabel.Text = $"{e.ItemIndex} | {e.ItemIndex % queryLength} | {queryStart}";

            // If item information is not already found in queryData, generate a new list
            if (e.ItemIndex >= queryStart + queryLength || e.ItemIndex < queryStart || e.ItemIndex == 0)
            {
                queryStart = e.ItemIndex - (e.ItemIndex % queryLength);
                queryData.Clear();

                for (int i = 0; i < columnNames.GetLength(0); i++)
                    queryData.Add(DatabaseQuery(
                        $"SELECT {columnNames[i, 1]} FROM game " +
                        $"ORDER BY {queryOrderBy} {queryDirection} " +
                        $"LIMIT {queryStart}, {queryLength}"
                    ));

                DebugLabel.Text += " LOAD";
            }

            ListViewItem entry = new(queryData[0][e.ItemIndex % queryLength]);

            for (int i = 1; i < columnNames.GetLength(0); i++)
                entry.SubItems.Add(queryData[i][e.ItemIndex % queryLength]);

            e.Item = entry;
        }

        // Launch entry (PLACEHOLDER)
        private void ArchiveList_itemClick(object sender, EventArgs e)
        {
            int entryIndex = ((ListView)sender).SelectedIndices[0];

            MessageBox.Show(DatabaseQuery(
                $"SELECT id FROM game " + 
                $"ORDER BY {queryOrderBy} {queryDirection} " + 
                $"LIMIT {entryIndex}, 1"
            )[0], DatabaseQuery(
                $"SELECT title FROM game " +
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
                using (FileStream fileStream = new(DatabasePathInput.Text, FileMode.Open, FileAccess.Read))
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
            queryData.Clear();

            ArchiveList.VirtualListSize = 0;
            ArchiveList.VirtualListSize = Convert.ToInt32(DatabaseQuery("SELECT COUNT(id) FROM game")[0]);
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