using Microsoft.WindowsAPICodePack.Dialogs;

namespace WumboLauncher
{
    public partial class Settings : Form
    {
        // Read values from file
        public Settings()
        {
            InitializeComponent();

            PathInput.Text = Config.Data[0];
            CLIFpInput.Text = Config.Data[1];
            ServerInput.Text = Config.Data[2];
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

            Config.Data[0] = PathInput.Text;
            Config.Data[1] = CLIFpInput.Text;
            Config.Data[2] = ServerInput.Text;
            Config.Write();

            Config.NeedsRefresh = true;

            Close();
        }

        // Close without saving
        private void CancelButton_Click(object sender, EventArgs e) { Close(); }
    }
}