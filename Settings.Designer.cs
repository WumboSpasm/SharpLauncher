namespace SharpLauncher
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
            this.SettingsTabControl = new System.Windows.Forms.TabControl();
            this.GeneralTab = new System.Windows.Forms.TabPage();
            this.GeneralLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PathButton = new System.Windows.Forms.Button();
            this.PathInput = new System.Windows.Forms.TextBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.CLIFpButton = new System.Windows.Forms.Button();
            this.CLIFpInput = new System.Windows.Forms.TextBox();
            this.CLIFpLabel = new System.Windows.Forms.Label();
            this.ServerInput = new System.Windows.Forms.TextBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.FiltersTab = new System.Windows.Forms.TabPage();
            this.FilterLabel = new System.Windows.Forms.Label();
            this.FilterList = new System.Windows.Forms.ListView();
            this.FilterColumnName = new System.Windows.Forms.ColumnHeader();
            this.FilterColumnDescription = new System.Windows.Forms.ColumnHeader();
            this.DataTab = new System.Windows.Forms.TabPage();
            this.DataClearContainer = new System.Windows.Forms.TableLayoutPanel();
            this.DataClearLegacy = new System.Windows.Forms.Button();
            this.DataClearGameZIP = new System.Windows.Forms.Button();
            this.DataClearCache = new System.Windows.Forms.Button();
            this.DataGameZIPSize = new System.Windows.Forms.Label();
            this.DataLegacySize = new System.Windows.Forms.Label();
            this.DataLabel = new System.Windows.Forms.Label();
            this.SettingsControls = new System.Windows.Forms.FlowLayoutPanel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SettingsTabControl.SuspendLayout();
            this.GeneralTab.SuspendLayout();
            this.GeneralLayout.SuspendLayout();
            this.FiltersTab.SuspendLayout();
            this.DataTab.SuspendLayout();
            this.DataClearContainer.SuspendLayout();
            this.SettingsControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsTabControl
            // 
            this.SettingsTabControl.Controls.Add(this.GeneralTab);
            this.SettingsTabControl.Controls.Add(this.FiltersTab);
            this.SettingsTabControl.Controls.Add(this.DataTab);
            this.SettingsTabControl.ItemSize = new System.Drawing.Size(64, 20);
            this.SettingsTabControl.Location = new System.Drawing.Point(6, 6);
            this.SettingsTabControl.Name = "SettingsTabControl";
            this.SettingsTabControl.SelectedIndex = 0;
            this.SettingsTabControl.Size = new System.Drawing.Size(524, 189);
            this.SettingsTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.SettingsTabControl.TabIndex = 4;
            this.SettingsTabControl.SelectedIndexChanged += new System.EventHandler(this.SettingsTabControl_tabChanged);
            // 
            // GeneralTab
            // 
            this.GeneralTab.Controls.Add(this.GeneralLayout);
            this.GeneralTab.Location = new System.Drawing.Point(4, 24);
            this.GeneralTab.Name = "GeneralTab";
            this.GeneralTab.Padding = new System.Windows.Forms.Padding(2);
            this.GeneralTab.Size = new System.Drawing.Size(516, 161);
            this.GeneralTab.TabIndex = 0;
            this.GeneralTab.Text = "General";
            this.GeneralTab.UseVisualStyleBackColor = true;
            // 
            // GeneralLayout
            // 
            this.GeneralLayout.ColumnCount = 3;
            this.GeneralLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.GeneralLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 256F));
            this.GeneralLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.GeneralLayout.Controls.Add(this.PathButton, 2, 0);
            this.GeneralLayout.Controls.Add(this.PathInput, 1, 0);
            this.GeneralLayout.Controls.Add(this.PathLabel, 0, 0);
            this.GeneralLayout.Controls.Add(this.CLIFpButton, 2, 1);
            this.GeneralLayout.Controls.Add(this.CLIFpInput, 1, 1);
            this.GeneralLayout.Controls.Add(this.CLIFpLabel, 0, 1);
            this.GeneralLayout.Controls.Add(this.ServerInput, 1, 2);
            this.GeneralLayout.Controls.Add(this.ServerLabel, 0, 2);
            this.GeneralLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.GeneralLayout.Location = new System.Drawing.Point(2, 2);
            this.GeneralLayout.Name = "GeneralLayout";
            this.GeneralLayout.RowCount = 3;
            this.GeneralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.GeneralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.GeneralLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.GeneralLayout.Size = new System.Drawing.Size(512, 120);
            this.GeneralLayout.TabIndex = 5;
            // 
            // PathButton
            // 
            this.PathButton.Location = new System.Drawing.Point(426, 9);
            this.PathButton.Margin = new System.Windows.Forms.Padding(10, 9, 0, 0);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(75, 23);
            this.PathButton.TabIndex = 1;
            this.PathButton.Text = "Browse";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_click);
            // 
            // PathInput
            // 
            this.PathInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathInput.Location = new System.Drawing.Point(160, 9);
            this.PathInput.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.PathInput.Name = "PathInput";
            this.PathInput.Size = new System.Drawing.Size(256, 23);
            this.PathInput.TabIndex = 0;
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PathLabel.Location = new System.Drawing.Point(6, 12);
            this.PathLabel.Margin = new System.Windows.Forms.Padding(6, 12, 0, 0);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(154, 28);
            this.PathLabel.TabIndex = 1;
            this.PathLabel.Text = "Path to Flashpoint folder:";
            // 
            // CLIFpButton
            // 
            this.CLIFpButton.Location = new System.Drawing.Point(426, 49);
            this.CLIFpButton.Margin = new System.Windows.Forms.Padding(10, 9, 0, 0);
            this.CLIFpButton.Name = "CLIFpButton";
            this.CLIFpButton.Size = new System.Drawing.Size(75, 23);
            this.CLIFpButton.TabIndex = 1;
            this.CLIFpButton.Text = "Browse";
            this.CLIFpButton.UseVisualStyleBackColor = true;
            this.CLIFpButton.Click += new System.EventHandler(this.CLIFpButton_click);
            // 
            // CLIFpInput
            // 
            this.CLIFpInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLIFpInput.Location = new System.Drawing.Point(160, 49);
            this.CLIFpInput.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.CLIFpInput.Name = "CLIFpInput";
            this.CLIFpInput.Size = new System.Drawing.Size(256, 23);
            this.CLIFpInput.TabIndex = 0;
            // 
            // CLIFpLabel
            // 
            this.CLIFpLabel.AutoSize = true;
            this.CLIFpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CLIFpLabel.Location = new System.Drawing.Point(6, 52);
            this.CLIFpLabel.Margin = new System.Windows.Forms.Padding(6, 12, 0, 0);
            this.CLIFpLabel.Name = "CLIFpLabel";
            this.CLIFpLabel.Size = new System.Drawing.Size(154, 28);
            this.CLIFpLabel.TabIndex = 1;
            this.CLIFpLabel.Text = "Path to CLIFp:";
            // 
            // ServerInput
            // 
            this.ServerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerInput.Location = new System.Drawing.Point(160, 89);
            this.ServerInput.Margin = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.ServerInput.Name = "ServerInput";
            this.ServerInput.Size = new System.Drawing.Size(256, 23);
            this.ServerInput.TabIndex = 0;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerLabel.Location = new System.Drawing.Point(6, 92);
            this.ServerLabel.Margin = new System.Windows.Forms.Padding(6, 12, 0, 0);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(154, 28);
            this.ServerLabel.TabIndex = 1;
            this.ServerLabel.Text = "Infinity server URL:";
            // 
            // FiltersTab
            // 
            this.FiltersTab.Controls.Add(this.FilterLabel);
            this.FiltersTab.Controls.Add(this.FilterList);
            this.FiltersTab.Location = new System.Drawing.Point(4, 24);
            this.FiltersTab.Name = "FiltersTab";
            this.FiltersTab.Padding = new System.Windows.Forms.Padding(3);
            this.FiltersTab.Size = new System.Drawing.Size(516, 161);
            this.FiltersTab.TabIndex = 1;
            this.FiltersTab.Text = "Filters";
            this.FiltersTab.UseVisualStyleBackColor = true;
            // 
            // FilterLabel
            // 
            this.FilterLabel.Location = new System.Drawing.Point(6, 3);
            this.FilterLabel.Name = "FilterLabel";
            this.FilterLabel.Size = new System.Drawing.Size(504, 22);
            this.FilterLabel.TabIndex = 1;
            this.FilterLabel.Text = "Entries with can be hidden from view using the filters below. Check a filter to a" +
    "ctivate it.";
            this.FilterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FilterList
            // 
            this.FilterList.CheckBoxes = true;
            this.FilterList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FilterColumnName,
            this.FilterColumnDescription});
            this.FilterList.FullRowSelect = true;
            this.FilterList.GridLines = true;
            this.FilterList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.FilterList.Location = new System.Drawing.Point(6, 28);
            this.FilterList.MultiSelect = false;
            this.FilterList.Name = "FilterList";
            this.FilterList.Size = new System.Drawing.Size(504, 127);
            this.FilterList.TabIndex = 0;
            this.FilterList.UseCompatibleStateImageBehavior = false;
            this.FilterList.View = System.Windows.Forms.View.Details;
            // 
            // FilterColumnName
            // 
            this.FilterColumnName.Text = "Name";
            this.FilterColumnName.Width = 150;
            // 
            // FilterColumnDescription
            // 
            this.FilterColumnDescription.Text = "Description";
            this.FilterColumnDescription.Width = 330;
            // 
            // DataTab
            // 
            this.DataTab.Controls.Add(this.DataClearContainer);
            this.DataTab.Controls.Add(this.DataGameZIPSize);
            this.DataTab.Controls.Add(this.DataLegacySize);
            this.DataTab.Controls.Add(this.DataLabel);
            this.DataTab.Location = new System.Drawing.Point(4, 24);
            this.DataTab.Name = "DataTab";
            this.DataTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataTab.Size = new System.Drawing.Size(516, 161);
            this.DataTab.TabIndex = 2;
            this.DataTab.Text = "Data";
            this.DataTab.UseVisualStyleBackColor = true;
            // 
            // DataClearContainer
            // 
            this.DataClearContainer.ColumnCount = 3;
            this.DataClearContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.DataClearContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.DataClearContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.DataClearContainer.Controls.Add(this.DataClearLegacy, 0, 0);
            this.DataClearContainer.Controls.Add(this.DataClearGameZIP, 1, 0);
            this.DataClearContainer.Controls.Add(this.DataClearCache, 2, 0);
            this.DataClearContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DataClearContainer.Location = new System.Drawing.Point(3, 126);
            this.DataClearContainer.Margin = new System.Windows.Forms.Padding(4);
            this.DataClearContainer.Name = "DataClearContainer";
            this.DataClearContainer.RowCount = 1;
            this.DataClearContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.DataClearContainer.Size = new System.Drawing.Size(510, 32);
            this.DataClearContainer.TabIndex = 5;
            // 
            // DataClearLegacy
            // 
            this.DataClearLegacy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataClearLegacy.Location = new System.Drawing.Point(3, 3);
            this.DataClearLegacy.Name = "DataClearLegacy";
            this.DataClearLegacy.Size = new System.Drawing.Size(163, 26);
            this.DataClearLegacy.TabIndex = 0;
            this.DataClearLegacy.Text = "Clear Legacy downloads";
            this.DataClearLegacy.UseVisualStyleBackColor = true;
            this.DataClearLegacy.Click += new System.EventHandler(this.DataClear_click);
            // 
            // DataClearGameZIP
            // 
            this.DataClearGameZIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataClearGameZIP.Location = new System.Drawing.Point(172, 3);
            this.DataClearGameZIP.Name = "DataClearGameZIP";
            this.DataClearGameZIP.Size = new System.Drawing.Size(164, 26);
            this.DataClearGameZIP.TabIndex = 1;
            this.DataClearGameZIP.Text = "Clear GameZIP downloads";
            this.DataClearGameZIP.UseVisualStyleBackColor = true;
            this.DataClearGameZIP.Click += new System.EventHandler(this.DataClear_click);
            // 
            // DataClearCache
            // 
            this.DataClearCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataClearCache.Location = new System.Drawing.Point(342, 3);
            this.DataClearCache.Name = "DataClearCache";
            this.DataClearCache.Size = new System.Drawing.Size(165, 26);
            this.DataClearCache.TabIndex = 2;
            this.DataClearCache.Text = "Clear cached save data";
            this.DataClearCache.UseVisualStyleBackColor = true;
            this.DataClearCache.Click += new System.EventHandler(this.DataClear_click);
            // 
            // DataGameZIPSize
            // 
            this.DataGameZIPSize.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataGameZIPSize.Location = new System.Drawing.Point(3, 77);
            this.DataGameZIPSize.Name = "DataGameZIPSize";
            this.DataGameZIPSize.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.DataGameZIPSize.Size = new System.Drawing.Size(510, 24);
            this.DataGameZIPSize.TabIndex = 4;
            this.DataGameZIPSize.Text = "The total file size of downloaded entries using the GameZIP format is ?? MB.";
            this.DataGameZIPSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataLegacySize
            // 
            this.DataLegacySize.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataLegacySize.Location = new System.Drawing.Point(3, 41);
            this.DataLegacySize.Name = "DataLegacySize";
            this.DataLegacySize.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.DataLegacySize.Size = new System.Drawing.Size(510, 36);
            this.DataLegacySize.TabIndex = 3;
            this.DataLegacySize.Text = "The total file size of downloaded entries using the Legacy format is ?? MB.";
            this.DataLegacySize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DataLabel
            // 
            this.DataLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DataLabel.Location = new System.Drawing.Point(3, 3);
            this.DataLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DataLabel.Name = "DataLabel";
            this.DataLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.DataLabel.Size = new System.Drawing.Size(510, 38);
            this.DataLabel.TabIndex = 2;
            this.DataLabel.Text = "The size of Flashpoint grows with the amount of entries you play. Cached save dat" +
    "a can take up storage space as well.";
            this.DataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(365, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 231);
            this.Controls.Add(this.SettingsControls);
            this.Controls.Add(this.SettingsTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.SettingsTabControl.ResumeLayout(false);
            this.GeneralTab.ResumeLayout(false);
            this.GeneralLayout.ResumeLayout(false);
            this.GeneralLayout.PerformLayout();
            this.FiltersTab.ResumeLayout(false);
            this.DataTab.ResumeLayout(false);
            this.DataClearContainer.ResumeLayout(false);
            this.SettingsControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl SettingsTabControl;
        private TabPage GeneralTab;
        private FlowLayoutPanel SettingsControls;
        private Button OKButton;
        private Button CancelButton;
        private TabPage FiltersTab;
        private ListView FilterList;
        private Label FilterLabel;
        private ColumnHeader FilterColumnName;
        private ColumnHeader FilterColumnDescription;
        private TabPage DataTab;
        private TableLayoutPanel GeneralLayout;
        private Button PathButton;
        private TextBox PathInput;
        private Label PathLabel;
        private Button CLIFpButton;
        private TextBox CLIFpInput;
        private Label CLIFpLabel;
        private TextBox ServerInput;
        private Label ServerLabel;
        private Label DataLabel;
        private Label DataGameZIPSize;
        private Label DataLegacySize;
        private TableLayoutPanel DataClearContainer;
        private Button DataClearLegacy;
        private Button DataClearGameZIP;
        private Button DataClearCache;
    }
}