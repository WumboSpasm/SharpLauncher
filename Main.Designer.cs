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
            this.ArchiveInfoContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchiveInfoTitle = new System.Windows.Forms.Label();
            this.ArchiveInfoDeveloper = new System.Windows.Forms.Label();
            this.ArchiveInfoData = new System.Windows.Forms.RichTextBox();
            this.ArchiveImagesContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchiveImagesLogoContainer = new System.Windows.Forms.GroupBox();
            this.ArchiveImagesLogo = new System.Windows.Forms.PictureBox();
            this.ArchiveImagesScreenshotContainer = new System.Windows.Forms.GroupBox();
            this.ArchiveImagesScreenshot = new System.Windows.Forms.PictureBox();
            this.ArchiveRadioContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ArchiveRadioHeader = new System.Windows.Forms.Panel();
            this.ArchiveRadioAnimations = new System.Windows.Forms.RadioButton();
            this.ArchiveRadioGames = new System.Windows.Forms.RadioButton();
            this.ArchiveListFooter = new System.Windows.Forms.Panel();
            this.EntryCountLabel = new System.Windows.Forms.Label();
            this.AdjustColumnsButton = new System.Windows.Forms.Button();
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
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButtonContainer = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.LaunchEntry = new System.Diagnostics.Process();
            this.ArchiveLayout.SuspendLayout();
            this.ArchiveInfoContainer.SuspendLayout();
            this.ArchiveImagesContainer.SuspendLayout();
            this.ArchiveImagesLogoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveImagesLogo)).BeginInit();
            this.ArchiveImagesScreenshotContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveImagesScreenshot)).BeginInit();
            this.ArchiveRadioContainer.SuspendLayout();
            this.ArchiveRadioHeader.SuspendLayout();
            this.ArchiveListFooter.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.DatabasePathContainer.SuspendLayout();
            this.ArchiveTab.SuspendLayout();
            this.ButtonContainer.SuspendLayout();
            this.Container.SuspendLayout();
            this.SearchButtonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchiveLayout
            // 
            this.ArchiveLayout.ColumnCount = 3;
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ArchiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.ArchiveLayout.Controls.Add(this.ArchiveList, 1, 0);
            this.ArchiveLayout.Controls.Add(this.ArchiveInfoContainer, 2, 0);
            this.ArchiveLayout.Controls.Add(this.ArchiveRadioContainer, 0, 0);
            this.ArchiveLayout.Controls.Add(this.ArchiveListFooter, 1, 1);
            this.ArchiveLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveLayout.Location = new System.Drawing.Point(3, 3);
            this.ArchiveLayout.Name = "ArchiveLayout";
            this.ArchiveLayout.RowCount = 2;
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
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
            this.ArchiveList.Location = new System.Drawing.Point(300, 0);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(0);
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
            // ArchiveInfoContainer
            // 
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoTitle);
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoDeveloper);
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveInfoData);
            this.ArchiveInfoContainer.Controls.Add(this.ArchiveImagesContainer);
            this.ArchiveInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveInfoContainer.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.ArchiveInfoContainer.Location = new System.Drawing.Point(947, 3);
            this.ArchiveInfoContainer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.ArchiveInfoContainer.Name = "ArchiveInfoContainer";
            this.ArchiveInfoContainer.Size = new System.Drawing.Size(294, 652);
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
            this.ArchiveInfoData.BackColor = System.Drawing.SystemColors.Window;
            this.ArchiveInfoData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ArchiveInfoData.DetectUrls = false;
            this.ArchiveInfoData.Location = new System.Drawing.Point(3, 51);
            this.ArchiveInfoData.Name = "ArchiveInfoData";
            this.ArchiveInfoData.ReadOnly = true;
            this.ArchiveInfoData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ArchiveInfoData.Size = new System.Drawing.Size(291, 256);
            this.ArchiveInfoData.TabIndex = 7;
            this.ArchiveInfoData.Text = "";
            // 
            // ArchiveImagesContainer
            // 
            this.ArchiveImagesContainer.BackColor = System.Drawing.Color.Transparent;
            this.ArchiveImagesContainer.Controls.Add(this.ArchiveImagesLogoContainer);
            this.ArchiveImagesContainer.Controls.Add(this.ArchiveImagesScreenshotContainer);
            this.ArchiveImagesContainer.Location = new System.Drawing.Point(3, 310);
            this.ArchiveImagesContainer.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.ArchiveImagesContainer.Name = "ArchiveImagesContainer";
            this.ArchiveImagesContainer.Size = new System.Drawing.Size(293, 144);
            this.ArchiveImagesContainer.TabIndex = 8;
            this.ArchiveImagesContainer.Visible = false;
            // 
            // ArchiveImagesLogoContainer
            // 
            this.ArchiveImagesLogoContainer.Controls.Add(this.ArchiveImagesLogo);
            this.ArchiveImagesLogoContainer.Location = new System.Drawing.Point(3, 3);
            this.ArchiveImagesLogoContainer.Name = "ArchiveImagesLogoContainer";
            this.ArchiveImagesLogoContainer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.ArchiveImagesLogoContainer.Size = new System.Drawing.Size(140, 140);
            this.ArchiveImagesLogoContainer.TabIndex = 0;
            this.ArchiveImagesLogoContainer.TabStop = false;
            this.ArchiveImagesLogoContainer.Text = "Logo";
            // 
            // ArchiveImagesLogo
            // 
            this.ArchiveImagesLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchiveImagesLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveImagesLogo.Location = new System.Drawing.Point(4, 20);
            this.ArchiveImagesLogo.Name = "ArchiveImagesLogo";
            this.ArchiveImagesLogo.Size = new System.Drawing.Size(132, 108);
            this.ArchiveImagesLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArchiveImagesLogo.TabIndex = 0;
            this.ArchiveImagesLogo.TabStop = false;
            this.ArchiveImagesLogo.Click += new System.EventHandler(this.ArchiveImages_click);
            // 
            // ArchiveImagesScreenshotContainer
            // 
            this.ArchiveImagesScreenshotContainer.Controls.Add(this.ArchiveImagesScreenshot);
            this.ArchiveImagesScreenshotContainer.Location = new System.Drawing.Point(149, 3);
            this.ArchiveImagesScreenshotContainer.Name = "ArchiveImagesScreenshotContainer";
            this.ArchiveImagesScreenshotContainer.Padding = new System.Windows.Forms.Padding(4, 4, 4, 12);
            this.ArchiveImagesScreenshotContainer.Size = new System.Drawing.Size(140, 140);
            this.ArchiveImagesScreenshotContainer.TabIndex = 0;
            this.ArchiveImagesScreenshotContainer.TabStop = false;
            this.ArchiveImagesScreenshotContainer.Text = "Screenshot";
            // 
            // ArchiveImagesScreenshot
            // 
            this.ArchiveImagesScreenshot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArchiveImagesScreenshot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveImagesScreenshot.Location = new System.Drawing.Point(4, 20);
            this.ArchiveImagesScreenshot.Name = "ArchiveImagesScreenshot";
            this.ArchiveImagesScreenshot.Size = new System.Drawing.Size(132, 108);
            this.ArchiveImagesScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ArchiveImagesScreenshot.TabIndex = 1;
            this.ArchiveImagesScreenshot.TabStop = false;
            this.ArchiveImagesScreenshot.Click += new System.EventHandler(this.ArchiveImages_click);
            // 
            // ArchiveRadioContainer
            // 
            this.ArchiveRadioContainer.Controls.Add(this.ArchiveRadioHeader);
            this.ArchiveRadioContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveRadioContainer.Location = new System.Drawing.Point(1, 3);
            this.ArchiveRadioContainer.Margin = new System.Windows.Forms.Padding(1, 3, 7, 0);
            this.ArchiveRadioContainer.Name = "ArchiveRadioContainer";
            this.ArchiveRadioContainer.Size = new System.Drawing.Size(292, 652);
            this.ArchiveRadioContainer.TabIndex = 9;
            // 
            // ArchiveRadioHeader
            // 
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioAnimations);
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioGames);
            this.ArchiveRadioHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveRadioHeader.Location = new System.Drawing.Point(0, 0);
            this.ArchiveRadioHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioHeader.Name = "ArchiveRadioHeader";
            this.ArchiveRadioHeader.Size = new System.Drawing.Size(297, 53);
            this.ArchiveRadioHeader.TabIndex = 10;
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
            this.ArchiveRadioAnimations.Location = new System.Drawing.Point(0, 25);
            this.ArchiveRadioAnimations.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioAnimations.Name = "ArchiveRadioAnimations";
            this.ArchiveRadioAnimations.Size = new System.Drawing.Size(297, 25);
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
            this.ArchiveRadioGames.Location = new System.Drawing.Point(0, 0);
            this.ArchiveRadioGames.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioGames.Name = "ArchiveRadioGames";
            this.ArchiveRadioGames.Size = new System.Drawing.Size(297, 25);
            this.ArchiveRadioGames.TabIndex = 9;
            this.ArchiveRadioGames.TabStop = true;
            this.ArchiveRadioGames.Text = "All Games";
            this.ArchiveRadioGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioGames.UseVisualStyleBackColor = false;
            this.ArchiveRadioGames.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
            // 
            // ArchiveListFooter
            // 
            this.ArchiveListFooter.Controls.Add(this.EntryCountLabel);
            this.ArchiveListFooter.Controls.Add(this.AdjustColumnsButton);
            this.ArchiveListFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveListFooter.Location = new System.Drawing.Point(300, 660);
            this.ArchiveListFooter.Margin = new System.Windows.Forms.Padding(0, 5, 0, 1);
            this.ArchiveListFooter.Name = "ArchiveListFooter";
            this.ArchiveListFooter.Size = new System.Drawing.Size(644, 24);
            this.ArchiveListFooter.TabIndex = 10;
            // 
            // EntryCountLabel
            // 
            this.EntryCountLabel.Location = new System.Drawing.Point(444, 5);
            this.EntryCountLabel.Name = "EntryCountLabel";
            this.EntryCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EntryCountLabel.Size = new System.Drawing.Size(200, 15);
            this.EntryCountLabel.TabIndex = 2;
            this.EntryCountLabel.Text = "Loading...";
            this.EntryCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AdjustColumnsButton
            // 
            this.AdjustColumnsButton.FlatAppearance.BorderSize = 0;
            this.AdjustColumnsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.AdjustColumnsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.AdjustColumnsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AdjustColumnsButton.Location = new System.Drawing.Point(0, 0);
            this.AdjustColumnsButton.Margin = new System.Windows.Forms.Padding(0);
            this.AdjustColumnsButton.Name = "AdjustColumnsButton";
            this.AdjustColumnsButton.Size = new System.Drawing.Size(100, 24);
            this.AdjustColumnsButton.TabIndex = 1;
            this.AdjustColumnsButton.Text = "Adjust Columns";
            this.AdjustColumnsButton.UseVisualStyleBackColor = true;
            this.AdjustColumnsButton.Click += new System.EventHandler(this.AdjustColumnsButton_click);
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
            this.HomeTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.DatabasePathLabel.Size = new System.Drawing.Size(140, 15);
            this.DatabasePathLabel.TabIndex = 1;
            this.DatabasePathLabel.Text = "Path to Flashpoint folder:";
            // 
            // DatabasePathInput
            // 
            this.DatabasePathInput.Location = new System.Drawing.Point(155, 9);
            this.DatabasePathInput.Name = "DatabasePathInput";
            this.DatabasePathInput.Size = new System.Drawing.Size(384, 23);
            this.DatabasePathInput.TabIndex = 0;
            this.DatabasePathInput.Text = ".";
            // 
            // DatabasePathButton
            // 
            this.DatabasePathButton.Location = new System.Drawing.Point(545, 9);
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
            this.Container.Controls.Add(this.SearchBox);
            this.Container.Controls.Add(this.SearchButtonContainer);
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
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(154, 6);
            this.SearchBox.Margin = new System.Windows.Forms.Padding(0);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.PlaceholderText = "Search the archive...";
            this.SearchBox.Size = new System.Drawing.Size(200, 23);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_keyDown);
            // 
            // SearchButtonContainer
            // 
            this.SearchButtonContainer.Controls.Add(this.SearchButton);
            this.SearchButtonContainer.Location = new System.Drawing.Point(357, 6);
            this.SearchButtonContainer.Name = "SearchButtonContainer";
            this.SearchButtonContainer.Size = new System.Drawing.Size(50, 20);
            this.SearchButtonContainer.TabIndex = 3;
            // 
            // SearchButton
            // 
            this.SearchButton.BackColor = System.Drawing.Color.Transparent;
            this.SearchButton.FlatAppearance.BorderSize = 0;
            this.SearchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.SearchButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchButton.Location = new System.Drawing.Point(0, -1);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(50, 24);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_click);
            // 
            // LaunchEntry
            // 
            this.LaunchEntry.StartInfo.Domain = "";
            this.LaunchEntry.StartInfo.FileName = "CLIFp.exe";
            this.LaunchEntry.StartInfo.LoadUserProfile = false;
            this.LaunchEntry.StartInfo.Password = null;
            this.LaunchEntry.StartInfo.StandardErrorEncoding = null;
            this.LaunchEntry.StartInfo.StandardInputEncoding = null;
            this.LaunchEntry.StartInfo.StandardOutputEncoding = null;
            this.LaunchEntry.StartInfo.UserName = "";
            this.LaunchEntry.StartInfo.UseShellExecute = true;
            this.LaunchEntry.SynchronizingObject = this;
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
            this.ArchiveInfoContainer.ResumeLayout(false);
            this.ArchiveInfoContainer.PerformLayout();
            this.ArchiveImagesContainer.ResumeLayout(false);
            this.ArchiveImagesLogoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveImagesLogo)).EndInit();
            this.ArchiveImagesScreenshotContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ArchiveImagesScreenshot)).EndInit();
            this.ArchiveRadioContainer.ResumeLayout(false);
            this.ArchiveRadioHeader.ResumeLayout(false);
            this.ArchiveListFooter.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.HomeTab.ResumeLayout(false);
            this.DatabasePathContainer.ResumeLayout(false);
            this.DatabasePathContainer.PerformLayout();
            this.ArchiveTab.ResumeLayout(false);
            this.ButtonContainer.ResumeLayout(false);
            this.Container.ResumeLayout(false);
            this.Container.PerformLayout();
            this.SearchButtonContainer.ResumeLayout(false);
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
        private FlowLayoutPanel ArchiveInfoContainer;
        private Label ArchiveInfoTitle;
        private Label ArchiveInfoDeveloper;
        private RichTextBox ArchiveInfoData;
        private RadioButton ArchiveRadioAnimations;
        private FlowLayoutPanel ArchiveRadioContainer;
        private Panel ArchiveRadioHeader;
        private RadioButton ArchiveRadioGames;
        private TextBox SearchBox;
        private FlowLayoutPanel ArchiveImagesContainer;
        private GroupBox ArchiveImagesLogoContainer;
        private GroupBox ArchiveImagesScreenshotContainer;
        private PictureBox ArchiveImagesLogo;
        private PictureBox ArchiveImagesScreenshot;
        private Button SearchButton;
        private Panel SearchButtonContainer;
        private System.Diagnostics.Process LaunchEntry;
        private Panel ArchiveListFooter;
        private Label EntryCountLabel;
    }
}