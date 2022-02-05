namespace WumboLauncher
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathInput = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.PathContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.PathLabel = new System.Windows.Forms.Label();
            this.ServerContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.ServerInput = new System.Windows.Forms.TextBox();
            this.CLIFpContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.CLIFpLabel = new System.Windows.Forms.Label();
            this.CLIFpInput = new System.Windows.Forms.TextBox();
            this.CLIFpButton = new System.Windows.Forms.Button();
            this.SettingsControls = new System.Windows.Forms.FlowLayoutPanel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SettingsTabControl.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.PathContainer.SuspendLayout();
            this.ServerContainer.SuspendLayout();
            this.CLIFpContainer.SuspendLayout();
            this.SettingsControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathInput
            // 
            this.PathInput.Location = new System.Drawing.Point(159, 9);
            this.PathInput.Name = "PathInput";
            this.PathInput.Size = new System.Drawing.Size(259, 23);
            this.PathInput.TabIndex = 0;
            // 
            // PathButton
            // 
            this.PathButton.Location = new System.Drawing.Point(424, 9);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(75, 23);
            this.PathButton.TabIndex = 1;
            this.PathButton.Text = "Browse";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_click);
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.GeneralTab);
            this.SettingsTabControl.Location = new System.Drawing.Point(6, 6);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(524, 189);
            this.SettingsTabControl.TabIndex = 4;
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.PathContainer);
            this.GeneralTab.Controls.Add(this.ServerContainer);
            this.GeneralTab.Controls.Add(this.CLIFpContainer);
            this.GeneralTab.Location = new System.Drawing.Point(4, 24);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralTab.Size = new System.Drawing.Size(516, 161);
            this.GeneralTab.TabIndex = 0;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // PathContainer
            // 
            this.PathContainer.Controls.Add(this.PathLabel);
            this.PathContainer.Controls.Add(this.PathInput);
            this.PathContainer.Controls.Add(this.PathButton);
            this.PathContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PathContainer.Location = new System.Drawing.Point(3, 3);
            this.PathContainer.Name = "PathContainer";
            this.PathContainer.Padding = new System.Windows.Forms.Padding(6);
            this.PathContainer.Size = new System.Drawing.Size(510, 40);
            this.PathContainer.TabIndex = 3;
            // 
            // PathLabel
            // 
            this.PathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(6, 13);
            this.PathLabel.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(140, 15);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Path to Flashpoint folder:";
            // 
            // ServerContainer
            // 
            this.ServerContainer.Controls.Add(this.ServerLabel);
            this.ServerContainer.Controls.Add(this.ServerInput);
            this.ServerContainer.Location = new System.Drawing.Point(3, 79);
            this.ServerContainer.Name = "ServerContainer";
            this.ServerContainer.Padding = new System.Windows.Forms.Padding(6);
            this.ServerContainer.Size = new System.Drawing.Size(510, 40);
            this.ServerContainer.TabIndex = 4;
            // 
            // ServerLabel
            // 
            this.ServerLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(6, 13);
            this.ServerLabel.Margin = new System.Windows.Forms.Padding(0, 0, 45, 0);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(105, 15);
            this.ServerLabel.TabIndex = 1;
            this.ServerLabel.Text = "Infinity server URL:";
            // 
            // ServerInput
            // 
            this.ServerInput.Location = new System.Drawing.Point(159, 9);
            this.ServerInput.Name = "ServerInput";
            this.ServerInput.Size = new System.Drawing.Size(259, 23);
            this.ServerInput.TabIndex = 0;
            // 
            // CLIFpContainer
            // 
            this.CLIFpContainer.Controls.Add(this.CLIFpLabel);
            this.CLIFpContainer.Controls.Add(this.CLIFpInput);
            this.CLIFpContainer.Controls.Add(this.CLIFpButton);
            this.CLIFpContainer.Location = new System.Drawing.Point(3, 40);
            this.CLIFpContainer.Name = "CLIFpContainer";
            this.CLIFpContainer.Padding = new System.Windows.Forms.Padding(6);
            this.CLIFpContainer.Size = new System.Drawing.Size(510, 40);
            this.CLIFpContainer.TabIndex = 4;
            // 
            // CLIFpLabel
            // 
            this.CLIFpLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CLIFpLabel.AutoSize = true;
            this.CLIFpLabel.Location = new System.Drawing.Point(6, 13);
            this.CLIFpLabel.Margin = new System.Windows.Forms.Padding(0, 0, 69, 0);
            this.CLIFpLabel.Name = "CLIFpLabel";
            this.CLIFpLabel.Size = new System.Drawing.Size(81, 15);
            this.CLIFpLabel.TabIndex = 1;
            this.CLIFpLabel.Text = "Path to CLIFp:";
            // 
            // CLIFpInput
            // 
            this.CLIFpInput.Location = new System.Drawing.Point(159, 9);
            this.CLIFpInput.Name = "CLIFpInput";
            this.CLIFpInput.Size = new System.Drawing.Size(259, 23);
            this.CLIFpInput.TabIndex = 0;
            // 
            // CLIFpButton
            // 
            this.CLIFpButton.Location = new System.Drawing.Point(424, 9);
            this.CLIFpButton.Name = "CLIFpButton";
            this.CLIFpButton.Size = new System.Drawing.Size(75, 23);
            this.CLIFpButton.TabIndex = 1;
            this.CLIFpButton.Text = "Browse";
            this.CLIFpButton.UseVisualStyleBackColor = true;
            this.CLIFpButton.Click += new System.EventHandler(this.CLIFpButton_Click);
            // 
            // SettingsControls
            // 
            this.SettingsControls.Controls.Add(this.CancelButton);
            this.SettingsControls.Controls.Add(this.OKButton);
            this.SettingsControls.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.SettingsControls.Location = new System.Drawing.Point(6, 198);
            this.SettingsControls.Name = "SettingsControls";
            this.SettingsControls.Size = new System.Drawing.Size(524, 29);
            this.SettingsControls.TabIndex = 4;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(446, 3);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(365, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 231);
            this.Controls.Add(this.SettingsControls);
            this.Controls.Add(this.SettingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.SettingsTabControl.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.PathContainer.ResumeLayout(false);
            this.PathContainer.PerformLayout();
            this.ServerContainer.ResumeLayout(false);
            this.ServerContainer.PerformLayout();
            this.CLIFpContainer.ResumeLayout(false);
            this.CLIFpContainer.PerformLayout();
            this.SettingsControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TextBox PathInput;
        private Button PathButton;
        private TabControl SettingsTabControl;
        private TabPage GeneralTab;
        private FlowLayoutPanel PathContainer;
        private Label PathLabel;
        private FlowLayoutPanel SettingsControls;
        private Button OKButton;
        private Button CancelButton;
        private FlowLayoutPanel ServerContainer;
        private Label ServerLabel;
        private TextBox ServerInput;
        private FlowLayoutPanel CLIFpContainer;
        private Label CLIFpLabel;
        private TextBox CLIFpInput;
        private Button CLIFpButton;
    }
}