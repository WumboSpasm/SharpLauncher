using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace SharpLauncher
{
    public partial class Settings : Form
    {
        // A string containing a copy of sharpFilters.json.
        private string filterJSON = "";

        public static readonly object filterLock = new object();

        public Settings()
        {
            InitializeComponent();

            // Load configuration data into text boxes.
            PathInput.Text = Config.FlashpointPath;
            CLIFpInput.Text = Config.CLIFpPath;
            ServerInput.Text = Config.FlashpointServer;
            ImageCheckbox.Checked = Config.DisplayImages;

            // Load tag filters into Filters menu.
            if (File.Exists("sharpFilters.json"))
            {
                lock (filterLock)
                {
                    using (var jsonStream = new StreamReader("sharpFilters.json"))
                    {
                        filterJSON = jsonStream.ReadToEnd();

                        dynamic filterArray = JsonConvert.DeserializeObject(filterJSON);

                        foreach (var item in filterArray)
                        {
                            var filterItem = new ListViewItem((string)item.name);
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
            var PathDialog = new CommonOpenFileDialog() { IsFolderPicker = true };

            if (PathDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PathInput.Text = PathDialog.FileName;
            }
        }

        private void CLIFpButton_click(object sender, EventArgs e)
        {
            var CLIFpDialog = new OpenFileDialog() { Filter = "Executable files (*.exe)|*.exe" };

            if (CLIFpDialog.ShowDialog() == DialogResult.OK)
            {
                CLIFpInput.Text = CLIFpDialog.FileName;
            }
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
                    var clearCache = new Process();

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

            if (selectedTab == 1 && !File.Exists("sharpFilters.json"))
            {
                MessageBox.Show("sharpFilters.json was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            {
                SetDownloadedFileSizes();
            }
        }

        // Verify and save the new configuration if the OK button is clicked, then close the menu.
        private void OKButton_click(object sender, EventArgs e)
        {
            bool[] valid = Config.Validate(PathInput.Text, CLIFpInput.Text);

            if (!valid.All(v => v))
            {
                DialogResult warningResult = MessageBox.Show(
                    "The following values are invalid:" +
                    (valid[0] ? "" : "\n- Path to Flashpoint folder") +
                    (valid[1] ? "" : "\n- Path to CLIFp"),
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error
                );

                return;
            }

            Config.FlashpointPath = PathInput.Text;
            Config.CLIFpPath = CLIFpInput.Text;
            Config.FlashpointServer = ServerInput.Text;
            Config.DisplayImages = ImageCheckbox.Checked;
            Config.Write();

            if (filterJSON.Length > 0)
            {
                lock (filterLock)
                {
                    using (var filters = new FileStream("sharpFilters.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {

                        filters.SetLength(0);

                        dynamic filterArray = JsonConvert.DeserializeObject(filterJSON);

                        int i = 0;
                        foreach (var item in filterArray)
                        {
                            filterArray[i].filtered = FilterList.Items[i].Checked;
                            i++;
                        }

                        byte[] data = Encoding.ASCII.GetBytes(filterArray.ToString());
                        filters.Write(data, 0, data.Length);
                    }
                }
            }

            Config.Configured = true;
            Config.Initialized = false;
            Config.InitStarted = false;

            Close();
        }

        // Close menu without saving if the Cancel button is clicked.
        private void CancelButton_click(object sender, EventArgs e) => Close();

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