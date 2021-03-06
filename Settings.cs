using System.Text;
using System.Diagnostics;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace SharpLauncher
{
    public partial class Settings : Form
    {
        // A string containing a copy of filters.json.
        private string filterJSON = "";

        public static readonly object filterLock = new();

        public Settings()
        {
            InitializeComponent();

            // Load configuration data into text boxes.
            PathInput.Text = Config.FlashpointPath;
            CLIFpInput.Text = Config.CLIFpPath;
            ServerInput.Text = Config.FlashpointServer;

            // Load tag filters into Filters menu.
            if (File.Exists("filters.json"))
            {
                lock (filterLock)
                {
                    using (StreamReader jsonStream = new("filters.json"))
                    {
                        filterJSON = jsonStream.ReadToEnd();

                        dynamic? filterArray = JsonConvert.DeserializeObject(filterJSON);

                        foreach (var item in filterArray)
                        {
                            ListViewItem filterItem = new((string)item.name);
                            filterItem.SubItems.Add((string)item.description);
                            filterItem.Checked = item.filtered;

                            FilterList.Items.Add(filterItem);
                        }
                    }
                }
            }
        }

        // Open file dialogs for Flashpoint and CLIFp paths when Browse button is clicked.

        private void PathButton_click(object sender, EventArgs e)
        {
            CommonOpenFileDialog PathDialog = new() { IsFolderPicker = true };

            if (PathDialog.ShowDialog() == CommonFileDialogResult.Ok)
                PathInput.Text = PathDialog.FileName;
        }

        private void CLIFpButton_click(object sender, EventArgs e)
        {
            OpenFileDialog CLIFpDialog = new() { Filter = "Executable files (*.exe)|*.exe" };

            if (CLIFpDialog.ShowDialog() == DialogResult.OK)
                CLIFpInput.Text = CLIFpDialog.FileName;
        }

        // Clear data corresponding to clicked button in Data tab.
        private void DataClear_click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "DataClearLegacy":
                    Directory.Delete(PathInput.Text + @"\Legacy\htdocs", true);
                    Directory.CreateDirectory(PathInput.Text + @"\Legacy\htdocs");

                    SetDownloadedFileSizes();
                    MessageBox.Show("File deletion successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "DataClearGameZIP":
                    Directory.Delete(PathInput.Text + @"\Data\Games", true);
                    Directory.CreateDirectory(PathInput.Text + @"\Data\Games");

                    SetDownloadedFileSizes();
                    MessageBox.Show("File deletion successful!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "DataClearCache":
                    Process clearCache = new();

                    clearCache.StartInfo.FileName = "RunDll32.exe";
                    clearCache.StartInfo.Arguments = "InetCpl.cpl, ClearMyTracksByProcess 8";

                    clearCache.Start();

                    break;
            }
        }

        // Throw errors if needed data is not found.
        private void SettingsTabControl_tabChanged(object sender, EventArgs e)
        {
            int selectedTab = ((TabControl)sender).SelectedIndex;

            if (selectedTab == 1 && !File.Exists("filters.json"))
            {
                MessageBox.Show("filters.json was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SettingsTabControl.SelectTab(0);
            }
            else if (selectedTab == 2
                  && (!Directory.Exists(PathInput.Text + @"\Legacy\htdocs")
                  || !Directory.Exists(PathInput.Text + @"\Data\Games")))
            {
                MessageBox.Show(
                    "Entry download folders were not found! Is your Flashpoint path set correctly?", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                SettingsTabControl.SelectTab(0);
            }
            else if (selectedTab == 2)
                SetDownloadedFileSizes();
        }

        // Write values to file and close the menu when the OK button is clicked.
        private void OKButton_click(object sender, EventArgs e)
        {
            // Check if database and CLIFp exist under Flashpoint path
            if (!File.Exists(PathInput.Text + @"\Data\flashpoint.sqlite")
             || !File.Exists(CLIFpInput.Text)
             || !CLIFpInput.Text.Contains(PathInput.Text))
            {
                DialogResult warningResult = MessageBox.Show(
                    "One or more values are invalid. Continue?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation
                );

                if (warningResult == DialogResult.No)
                    return;
            }

            Config.FlashpointPath = PathInput.Text;
            Config.CLIFpPath = CLIFpInput.Text;
            Config.FlashpointServer = ServerInput.Text;
            Config.Write();

            if (filterJSON.Length > 0)
            {
                lock (filterLock)
                {
                    using (FileStream filters = new("filters.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {

                        filters.SetLength(0);

                        dynamic? filterArray = JsonConvert.DeserializeObject(filterJSON);

                        int i = 0;
                        foreach (var item in filterArray)
                        {
                            filterArray[i].filtered = FilterList.Items[i].Checked;
                            i++;
                        }

                        filters.Write(Encoding.ASCII.GetBytes(filterArray.ToString()));
                    }
                }
            }

            Config.NeedsRefresh = true;

            Close();
        }

        // Close menu without saving if the Cancel button is clicked.
        private void CancelButton_click(object sender, EventArgs e) { Close(); }

        // Fill in total file sizes in the Data tab.
        private void SetDownloadedFileSizes()
        {
            int legacyFileSize = (int)
                new DirectoryInfo(PathInput.Text + @"\Legacy\htdocs")
                .EnumerateFiles("*", SearchOption.AllDirectories).Sum(i => i.Length);
            int gameZIPFileSize = (int)
                new DirectoryInfo(PathInput.Text + @"\Data\Games")
                .EnumerateFiles("*", SearchOption.AllDirectories).Sum(i => i.Length);

            DataLegacySize.Text = "The total file size of downloaded entries using the Legacy format is " +
                ((legacyFileSize - (legacyFileSize % 1048576)) / 1048576) + " MB.";
            DataGameZIPSize.Text = "The total file size of downloaded entries using the GameZIP format is " +
                ((gameZIPFileSize - (gameZIPFileSize % 1048576)) / 1048576) + " MB.";
        }
    }
}