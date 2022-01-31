namespace WumboLauncher
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ArchiveLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ArchiveList = new System.Windows.Forms.ListView();
            this.ResetColumnsButton = new System.Windows.Forms.Button();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.ArchiveEntryInfo = new System.Windows.Forms.RichTextBox();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.HomeTab = new System.Windows.Forms.TabPage();
            this.DatabasePathContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.DatabasePathLabel = new System.Windows.Forms.Label();
            this.DatabasePathInput = new System.Windows.Forms.TextBox();
            this.DatabasePathButton = new System.Windows.Forms.Button();
            this.ArchiveTab = new System.Windows.Forms.TabPage();
            this.ButtonContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.HelpButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.Container = new System.Windows.Forms.Panel();
            this.DatabasePathDialog = new System.Windows.Forms.OpenFileDialog();
            this.ArchiveLayout.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.DatabasePathContainer.SuspendLayout();
            this.ArchiveTab.SuspendLayout();
            this.ButtonContainer.SuspendLayout();
            this.Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchiveLayout
            // 
            this.ArchiveLayout.ColumnCount = 3;
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveLayout.Controls.Add(this.ArchiveList, 1, 0);
            this.ArchiveLayout.Controls.Add(this.ResetColumnsButton, 1, 1);
            this.ArchiveLayout.Controls.Add(this.DebugLabel, 0, 0);
            this.ArchiveLayout.Controls.Add(this.ArchiveEntryInfo, 2, 0);
            this.ArchiveLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveLayout.Location = new System.Drawing.Point(3, 3);
            this.ArchiveLayout.Name = "ArchiveLayout";
            this.ArchiveLayout.RowCount = 2;
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.ArchiveLayout.Size = new System.Drawing.Size(1244, 685);
            this.ArchiveLayout.TabIndex = 3;
            // 
            // ArchiveList
            // 
            this.ArchiveList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.ArchiveList.AllowColumnReorder = true;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.FullRowSelect = true;
            this.ArchiveList.GridLines = true;
            this.ArchiveList.LabelWrap = false;
            this.ArchiveList.Location = new System.Drawing.Point(300, 2);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(0, 2, 0, 4);
            this.ArchiveList.MultiSelect = false;
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.Size = new System.Drawing.Size(644, 655);
            this.ArchiveList.TabIndex = 0;
            this.ArchiveList.UseCompatibleStateImageBehavior = false;
            this.ArchiveList.View = System.Windows.Forms.View.Details;
            this.ArchiveList.VirtualMode = true;
            this.ArchiveList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ArchiveList_columnClick);
            this.ArchiveList.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.ArchiveList_columnChanged);
            this.ArchiveList.ItemActivate += new System.EventHandler(this.ArchiveList_itemAccess);
            this.ArchiveList.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.ArchiveList_retrieveItem);
            this.ArchiveList.SelectedIndexChanged += new System.EventHandler(this.ArchiveList_itemSelect);
            this.ArchiveList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ArchiveList_mouseMove);
            // 
            // ResetColumnsButton
            // 
            this.ResetColumnsButton.FlatAppearance.BorderSize = 0;
            this.ResetColumnsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ResetColumnsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ResetColumnsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetColumnsButton.Location = new System.Drawing.Point(300, 661);
            this.ResetColumnsButton.Margin = new System.Windows.Forms.Padding(0);
            this.ResetColumnsButton.Name = "ResetColumnsButton";
            this.ResetColumnsButton.Size = new System.Drawing.Size(100, 24);
            this.ResetColumnsButton.TabIndex = 1;
            this.ResetColumnsButton.Text = "Adjust Columns";
            this.ResetColumnsButton.UseVisualStyleBackColor = true;
            this.ResetColumnsButton.Click += new System.EventHandler(this.AdjustColumnsButton_click);
            // 
            // DebugLabel
            // 
            this.DebugLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DebugLabel.Location = new System.Drawing.Point(3, 0);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(294, 15);
            this.DebugLabel.TabIndex = 4;
            // 
            // ArchiveEntryInfo
            // 
            this.ArchiveEntryInfo.BackColor = System.Drawing.SystemColors.Window;
            this.ArchiveEntryInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiveEntryInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveEntryInfo.Location = new System.Drawing.Point(947, 3);
            this.ArchiveEntryInfo.Name = "ArchiveEntryInfo";
            this.ArchiveEntryInfo.ReadOnly = true;
            this.ArchiveEntryInfo.Size = new System.Drawing.Size(294, 655);
            this.ArchiveEntryInfo.TabIndex = 5;
            this.ArchiveEntryInfo.Text = "";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.HomeTab);
            this.TabControl.Controls.Add(this.ArchiveTab);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.ItemSize = new System.Drawing.Size(72, 24);
            this.TabControl.Location = new System.Drawing.Point(3, 3);
            this.TabControl.Margin = new System.Windows.Forms.Padding(0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1258, 723);
            this.TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControl.TabIndex = 4;
            this.TabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabControl_click);
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.DatabasePathContainer);
            this.HomeTab.Location = new System.Drawing.Point(4, 28);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.Padding = new System.Windows.Forms.Padding(3);
            this.HomeTab.Size = new System.Drawing.Size(1250, 691);
            this.HomeTab.TabIndex = 0;
            this.HomeTab.Text = "Home";
            this.HomeTab.UseVisualStyleBackColor = true;
            // 
            // DatabasePathContainer
            // 
            this.DatabasePathContainer.Controls.Add(this.DatabasePathLabel);
            this.DatabasePathContainer.Controls.Add(this.DatabasePathInput);
            this.DatabasePathContainer.Controls.Add(this.DatabasePathButton);
            this.DatabasePathContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.DatabasePathContainer.Location = new System.Drawing.Point(3, 3);
            this.DatabasePathContainer.Name = "DatabasePathContainer";
            this.DatabasePathContainer.Padding = new System.Windows.Forms.Padding(6);
            this.DatabasePathContainer.Size = new System.Drawing.Size(1244, 40);
            this.DatabasePathContainer.TabIndex = 2;
            // 
            // DatabasePathLabel
            // 
            this.DatabasePathLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DatabasePathLabel.AutoSize = true;
            this.DatabasePathLabel.Location = new System.Drawing.Point(9, 13);
            this.DatabasePathLabel.Name = "DatabasePathLabel";
            this.DatabasePathLabel.Size = new System.Drawing.Size(156, 15);
            this.DatabasePathLabel.TabIndex = 1;
            this.DatabasePathLabel.Text = "Path to Flashpoint database:";
            // 
            // DatabasePathInput
            // 
            this.DatabasePathInput.Location = new System.Drawing.Point(171, 9);
            this.DatabasePathInput.Name = "DatabasePathInput";
            this.DatabasePathInput.Size = new System.Drawing.Size(384, 23);
            this.DatabasePathInput.TabIndex = 0;
            this.DatabasePathInput.Text = "Data\\flashpoint.sqlite";
            // 
            // DatabasePathButton
            // 
            this.DatabasePathButton.Location = new System.Drawing.Point(561, 9);
            this.DatabasePathButton.Name = "DatabasePathButton";
            this.DatabasePathButton.Size = new System.Drawing.Size(75, 23);
            this.DatabasePathButton.TabIndex = 1;
            this.DatabasePathButton.Text = "Browse";
            this.DatabasePathButton.UseVisualStyleBackColor = true;
            this.DatabasePathButton.Click += new System.EventHandler(this.DatabasePathButton_click);
            // 
            // ArchiveTab
            // 
            this.ArchiveTab.Controls.Add(this.ArchiveLayout);
            this.ArchiveTab.Location = new System.Drawing.Point(4, 28);
            this.ArchiveTab.Name = "ArchiveTab";
            this.ArchiveTab.Padding = new System.Windows.Forms.Padding(3);
            this.ArchiveTab.Size = new System.Drawing.Size(1250, 691);
            this.ArchiveTab.TabIndex = 1;
            this.ArchiveTab.Text = "Archive";
            this.ArchiveTab.UseVisualStyleBackColor = true;
            // 
            // ButtonContainer
            // 
            this.ButtonContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonContainer.BackColor = System.Drawing.Color.Transparent;
            this.ButtonContainer.Controls.Add(this.HelpButton);
            this.ButtonContainer.Controls.Add(this.SettingsButton);
            this.ButtonContainer.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.ButtonContainer.Location = new System.Drawing.Point(1059, 3);
            this.ButtonContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonContainer.Name = "ButtonContainer";
            this.ButtonContainer.Size = new System.Drawing.Size(200, 24);
            this.ButtonContainer.TabIndex = 0;
            // 
            // HelpButton
            // 
            this.HelpButton.BackColor = System.Drawing.Color.Transparent;
            this.HelpButton.FlatAppearance.BorderSize = 0;
            this.HelpButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.HelpButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.HelpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButton.Location = new System.Drawing.Point(140, 0);
            this.HelpButton.Margin = new System.Windows.Forms.Padding(0);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(60, 24);
            this.HelpButton.TabIndex = 1;
            this.HelpButton.Text = "Help";
            this.HelpButton.UseVisualStyleBackColor = false;
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Location = new System.Drawing.Point(80, 0);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(60, 24);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            // 
            // Container
            // 
            this.Container.BackColor = System.Drawing.Color.Transparent;
            this.Container.Controls.Add(this.ButtonContainer);
            this.Container.Controls.Add(this.TabControl);
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(0, 0);
            this.Container.Margin = new System.Windows.Forms.Padding(0);
            this.Container.Name = "Container";
            this.Container.Padding = new System.Windows.Forms.Padding(3);
            this.Container.Size = new System.Drawing.Size(1264, 729);
            this.Container.TabIndex = 0;
            // 
            // DatabasePathDialog
            // 
            this.DatabasePathDialog.FileName = "openFileDialog1";
            this.DatabasePathDialog.Filter = "SQLite database|*.sqlite";
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.Container);
            this.Name = "Main";
            this.Text = "Launcher";
            this.Load += new System.EventHandler(this.Main_load);
            this.Resize += new System.EventHandler(this.Main_resize);
            this.ArchiveLayout.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.HomeTab.ResumeLayout(false);
            this.DatabasePathContainer.ResumeLayout(false);
            this.DatabasePathContainer.PerformLayout();
            this.ArchiveTab.ResumeLayout(false);
            this.ButtonContainer.ResumeLayout(false);
            this.Container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel ArchiveLayout;
        private ListView ArchiveList;
        private TabControl TabControl;
        private TabPage HomeTab;
        private TabPage ArchiveTab;
        private FlowLayoutPanel ButtonContainer;
        private Button SettingsButton;
        private Panel Container;
        private Button HelpButton;
        private Button ResetColumnsButton;
        private Label DebugLabel;
        private Label DatabasePathLabel;
        private TextBox DatabasePathInput;
        private FlowLayoutPanel DatabasePathContainer;
        private Button DatabasePathButton;
        private OpenFileDialog DatabasePathDialog;
        private RichTextBox ArchiveEntryInfo;
    }
}