using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace WumboLauncher
{
    public partial class Settings : Form
    {
        // String copy of filters.json
        private string filterJSON = "";

        // Read values from file
        public Settings()
        {
            InitializeComponent();

            PathInput.Text = Config.FlashpointPath;
            CLIFpInput.Text = Config.CLIFpPath;
            ServerInput.Text = Config.FlashpointServer;
        }

        // Browse for Flashpoint path
        private void PathButton_click(object sender, EventArgs e)
        {
            CommonOpenFileDialog PathDialog = new() { IsFolderPicker = true };

            if (PathDialog.ShowDialog() == CommonFileDialogResult.Ok)
                PathInput.Text = PathDialog.FileName;
        }

        // Browse for CLIFp path
        private void CLIFpButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog CLIFpDialog = new() { Filter = "Executable files (*.exe)|*.exe" };

            if (CLIFpDialog.ShowDialog() == DialogResult.OK)
                CLIFpInput.Text = CLIFpDialog.FileName;
        }

        // Load tag filters into list
        private void SettingsTabControl_TabChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 1)
            {
                if (File.Exists("filters.json"))
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
                else
                {
                    MessageBox.Show("filters.json was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SettingsTabControl.SelectTab(0);
                }
            }
        }

        // Write values to file and close
        private void OKButton_Click(object sender, EventArgs e)
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
                using (FileStream filters = new("filters.json", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    lock (filters)
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

            Config.NeedsRefresh = true;

            Close();
        }

        // Close without saving
        private void CancelButton_Click(object sender, EventArgs e) { Close(); }
    }
}