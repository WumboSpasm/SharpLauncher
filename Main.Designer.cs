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
            this.AdjustColumnsButton = new System.Windows.Forms.Button();
            this.ArchiveInfoContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchiveInfoTitle = new System.Windows.Forms.Label();
            this.ArchiveInfoDeveloper = new System.Windows.Forms.Label();
            this.ArchiveInfoData = new System.Windows.Forms.RichTextBox();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.ArchiveRadioContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchiveRadioPanel = new System.Windows.Forms.Panel();
            this.ArchiveRadioAnimations = new System.Windows.Forms.RadioButton();
            this.ArchiveRadioGames = new System.Windows.Forms.RadioButton();
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
            this.ArchiveInfoContainer.SuspendLayout();
            this.ArchiveRadioContainer.SuspendLayout();
            this.ArchiveRadioPanel.SuspendLayout();
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
            this.ArchiveLayout.Controls.Add(this.AdjustColumnsButton, 1, 1);
            this.ArchiveLayout.Controls.Add(this.ArchiveInfoContainer, 2, 0);
            this.ArchiveLayout.Controls.Add(this.DebugLabel, 0, 1);
            this.ArchiveLayout.Controls.Add(this.ArchiveRadioContainer, 0, 0);
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
            // AdjustColumnsButton
            // 
            this.AdjustColumnsButton.FlatAppearance.BorderSize = 0;
            this.AdjustColumnsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.AdjustColumnsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.AdjustColumnsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdjustColumnsButton.Location = new System.Drawing.Point(300, 661);
            this.AdjustColumnsButton.Margin = new System.Windows.Forms.Padding(0);
            this.AdjustColumnsButton.Name = "AdjustColumnsButton";
            this.AdjustColumnsButton.Size = new System.Drawing.Size(100, 24);
            this.AdjustColumnsButton.TabIndex = 1;
            this.AdjustColumnsButton.Text = "Adjust Columns";
            this.AdjustColumnsButton.UseVisualStyleBackColor = true;
            this.AdjustColumnsButton.Click += new System.EventHandler(this.AdjustColumnsButton_click);
            // 
            // ArchiveInfoContainer
            // 
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoTitle);
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoDeveloper);
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoData);
            this.ArchiveInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveInfoContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ArchiveInfoContainer.Location = new System.Drawing.Point(947, 3);
            this.ArchiveInfoContainer.Name = "ArchiveInfoContainer";
            this.ArchiveInfoContainer.Size = new System.Drawing.Size(294, 655);
            this.ArchiveInfoContainer.TabIndex = 6;
            // 
            // ArchiveInfoTitle
            // 
            this.ArchiveInfoTitle.AutoSize = true;
            this.ArchiveInfoTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ArchiveInfoTitle.Location = new System.Drawing.Point(1, 0);
            this.ArchiveInfoTitle.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.ArchiveInfoTitle.Name = "ArchiveInfoTitle";
            this.ArchiveInfoTitle.Size = new System.Drawing.Size(296, 25);
            this.ArchiveInfoTitle.TabIndex = 5;
            // 
            // ArchiveInfoDeveloper
            // 
            this.ArchiveInfoDeveloper.AutoSize = true;
            this.ArchiveInfoDeveloper.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveInfoDeveloper.Location = new System.Drawing.Point(3, 26);
            this.ArchiveInfoDeveloper.Margin = new System.Windows.Forms.Padding(3, 1, 3, 7);
            this.ArchiveInfoDeveloper.Name = "ArchiveInfoDeveloper";
            this.ArchiveInfoDeveloper.Size = new System.Drawing.Size(291, 15);
            this.ArchiveInfoDeveloper.TabIndex = 6;
            // 
            // ArchiveInfoData
            // 
            this.ArchiveInfoData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ArchiveInfoData.BackColor = System.Drawing.SystemColors.Window;
            this.ArchiveInfoData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiveInfoData.Location = new System.Drawing.Point(3, 51);
            this.ArchiveInfoData.Name = "ArchiveInfoData";
            this.ArchiveInfoData.ReadOnly = true;
            this.ArchiveInfoData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ArchiveInfoData.Size = new System.Drawing.Size(291, 256);
            this.ArchiveInfoData.TabIndex = 7;
            this.ArchiveInfoData.Text = "";
            // 
            // DebugLabel
            // 
            this.DebugLabel.AutoSize = true;
            this.DebugLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugLabel.Location = new System.Drawing.Point(3, 664);
            this.DebugLabel.Margin = new System.Windows.Forms.Padding(3);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(294, 18);
            this.DebugLabel.TabIndex = 7;
            // 
            // ArchiveRadioContainer
            // 
            this.ArchiveRadioContainer.Controls.Add(this.ArchiveRadioPanel);
            this.ArchiveRadioContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveRadioContainer.Location = new System.Drawing.Point(0, 0);
            this.ArchiveRadioContainer.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioContainer.Name = "ArchiveRadioContainer";
            this.ArchiveRadioContainer.Size = new System.Drawing.Size(300, 661);
            this.ArchiveRadioContainer.TabIndex = 9;
            // 
            // ArchiveRadioPanel
            // 
            this.ArchiveRadioPanel.Controls.Add(this.ArchiveRadioAnimations);
            this.ArchiveRadioPanel.Controls.Add(this.ArchiveRadioGames);
            this.ArchiveRadioPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveRadioPanel.Location = new System.Drawing.Point(0, 0);
            this.ArchiveRadioPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioPanel.Name = "ArchiveRadioPanel";
            this.ArchiveRadioPanel.Padding = new System.Windows.Forms.Padding(0, 3, 4, 0);
            this.ArchiveRadioPanel.Size = new System.Drawing.Size(297, 53);
            this.ArchiveRadioPanel.TabIndex = 10;
            // 
            // ArchiveRadioAnimations
            // 
            this.ArchiveRadioAnimations.Appearance = System.Windows.Forms.Appearance.Button;
            this.ArchiveRadioAnimations.BackColor = System.Drawing.Color.Transparent;
            this.ArchiveRadioAnimations.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveRadioAnimations.FlatAppearance.BorderSize = 0;
            this.ArchiveRadioAnimations.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ArchiveRadioAnimations.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ArchiveRadioAnimations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ArchiveRadioAnimations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArchiveRadioAnimations.Location = new System.Drawing.Point(0, 28);
            this.ArchiveRadioAnimations.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioAnimations.Name = "ArchiveRadioAnimations";
            this.ArchiveRadioAnimations.Size = new System.Drawing.Size(293, 25);
            this.ArchiveRadioAnimations.TabIndex = 8;
            this.ArchiveRadioAnimations.TabStop = true;
            this.ArchiveRadioAnimations.Text = "All Animations";
            this.ArchiveRadioAnimations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioAnimations.UseVisualStyleBackColor = false;
            this.ArchiveRadioAnimations.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
            // 
            // ArchiveRadioGames
            // 
            this.ArchiveRadioGames.Appearance = System.Windows.Forms.Appearance.Button;
            this.ArchiveRadioGames.BackColor = System.Drawing.Color.Transparent;
            this.ArchiveRadioGames.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveRadioGames.FlatAppearance.BorderSize = 0;
            this.ArchiveRadioGames.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ArchiveRadioGames.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ArchiveRadioGames.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ArchiveRadioGames.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArchiveRadioGames.Location = new System.Drawing.Point(0, 3);
            this.ArchiveRadioGames.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioGames.Name = "ArchiveRadioGames";
            this.ArchiveRadioGames.Size = new System.Drawing.Size(293, 25);
            this.ArchiveRadioGames.TabIndex = 9;
            this.ArchiveRadioGames.TabStop = true;
            this.ArchiveRadioGames.Text = "All Games";
            this.ArchiveRadioGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioGames.UseVisualStyleBackColor = false;
            this.ArchiveRadioGames.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
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
            this.ArchiveLayout.PerformLayout();
            this.ArchiveInfoContainer.ResumeLayout(false);
            this.ArchiveInfoContainer.PerformLayout();
            this.ArchiveRadioContainer.ResumeLayout(false);
            this.ArchiveRadioPanel.ResumeLayout(false);
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
        private Button AdjustColumnsButton;
        private Label DatabasePathLabel;
        private TextBox DatabasePathInput;
        private FlowLayoutPanel DatabasePathContainer;
        private Button DatabasePathButton;
        private OpenFileDialog DatabasePathDialog;
        private FlowLayoutPanel ArchiveInfoContainer;
        private Label ArchiveInfoTitle;
        private Label ArchiveInfoDeveloper;
        private RichTextBox ArchiveInfoData;
        private Label DebugLabel;
        private RadioButton ArchiveRadioAnimations;
        private FlowLayoutPanel ArchiveRadioContainer;
        private Panel ArchiveRadioPanel;
        private RadioButton ArchiveRadioGames;
    }
}