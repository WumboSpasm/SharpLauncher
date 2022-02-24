namespace SharpLauncher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
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
            this.ArchiveRadioPlays = new System.Windows.Forms.RadioButton();
            this.ArchiveRadioFavorites = new System.Windows.Forms.RadioButton();
            this.ArchiveRadioAnimations = new System.Windows.Forms.RadioButton();
            this.ArchiveRadioGames = new System.Windows.Forms.RadioButton();
            this.DebugLabel = new System.Windows.Forms.Label();
            this.ArchiveListFooter = new System.Windows.Forms.Panel();
            this.RandomButton = new System.Windows.Forms.Button();
            this.EntryCountLabel = new System.Windows.Forms.Label();
            this.AdjustColumnsButton = new System.Windows.Forms.Button();
            this.PlayContainer = new System.Windows.Forms.Panel();
            this.AlternateButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.FavoriteButton = new System.Windows.Forms.CheckBox();
            this.FavoriteButtonImages = new System.Windows.Forms.ImageList(this.components);
            this.TabControl = new System.Windows.Forms.TabControl();
            this.HomeTab = new System.Windows.Forms.TabPage();
            this.HomeContainer = new System.Windows.Forms.Panel();
            this.HomeLinkContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.HomeLinkWebsite = new System.Windows.Forms.LinkLabel();
            this.HomeLinkWiki = new System.Windows.Forms.LinkLabel();
            this.HomeLinkGitHub = new System.Windows.Forms.LinkLabel();
            this.HomeLinkDiscord = new System.Windows.Forms.LinkLabel();
            this.HomeLogo = new System.Windows.Forms.PictureBox();
            this.ArchiveTab = new System.Windows.Forms.TabPage();
            this.GitHubButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.Container = new System.Windows.Forms.Panel();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchButtonContainer = new System.Windows.Forms.Panel();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ButtonContainer = new System.Windows.Forms.Panel();
            this.LaunchEntry = new System.Diagnostics.Process();
            this.AlternateMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.PlayContainer.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.HomeTab.SuspendLayout();
            this.HomeContainer.SuspendLayout();
            this.HomeLinkContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLogo)).BeginInit();
            this.ArchiveTab.SuspendLayout();
            this.Container.SuspendLayout();
            this.SearchButtonContainer.SuspendLayout();
            this.ButtonContainer.SuspendLayout();
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
            this.ArchiveLayout.Controls.Add(this.PlayContainer, 2, 1);
            this.ArchiveLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveLayout.Location = new System.Drawing.Point(3, 3);
            this.ArchiveLayout.Name = "ArchiveLayout";
            this.ArchiveLayout.RowCount = 2;
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.ArchiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ArchiveLayout.Size = new System.Drawing.Size(1244, 685);
            this.ArchiveLayout.TabIndex = 3;
            // 
            // ArchiveList
            // 
            this.ArchiveList.AllowColumnReorder = true;
            this.ArchiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveList.FullRowSelect = true;
            this.ArchiveList.GridLines = true;
            this.ArchiveList.LabelWrap = false;
            this.ArchiveList.Location = new System.Drawing.Point(300, 0);
            this.ArchiveList.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveList.MultiSelect = false;
            this.ArchiveList.Name = "ArchiveList";
            this.ArchiveList.Size = new System.Drawing.Size(644, 653);
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
            this.ArchiveInfoContainer.Size = new System.Drawing.Size(294, 650);
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
            this.ArchiveInfoTitle.UseMnemonic = false;
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
            this.ArchiveInfoDeveloper.UseMnemonic = false;
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
            this.ArchiveImagesLogo.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.ArchiveImages_loadCompleted);
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
            this.ArchiveImagesScreenshot.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.ArchiveImages_loadCompleted);
            this.ArchiveImagesScreenshot.Click += new System.EventHandler(this.ArchiveImages_click);
            // 
            // ArchiveRadioContainer
            // 
            this.ArchiveRadioContainer.Controls.Add(this.ArchiveRadioHeader);
            this.ArchiveRadioContainer.Controls.Add(this.DebugLabel);
            this.ArchiveRadioContainer.Location = new System.Drawing.Point(1, 3);
            this.ArchiveRadioContainer.Margin = new System.Windows.Forms.Padding(1, 3, 7, 0);
            this.ArchiveRadioContainer.Name = "ArchiveRadioContainer";
            this.ArchiveRadioContainer.Size = new System.Drawing.Size(292, 650);
            this.ArchiveRadioContainer.TabIndex = 9;
            // 
            // ArchiveRadioHeader
            // 
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioPlays);
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioFavorites);
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioAnimations);
            this.ArchiveRadioHeader.Controls.Add(this.ArchiveRadioGames);
            this.ArchiveRadioHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ArchiveRadioHeader.Location = new System.Drawing.Point(0, 0);
            this.ArchiveRadioHeader.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioHeader.Name = "ArchiveRadioHeader";
            this.ArchiveRadioHeader.Size = new System.Drawing.Size(292, 105);
            this.ArchiveRadioHeader.TabIndex = 10;
            // 
            // ArchiveRadioPlays
            // 
            this.ArchiveRadioPlays.Appearance = System.Windows.Forms.Appearance.Button;
            this.ArchiveRadioPlays.BackColor = System.Drawing.Color.Transparent;
            this.ArchiveRadioPlays.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArchiveRadioPlays.FlatAppearance.BorderSize = 0;
            this.ArchiveRadioPlays.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ArchiveRadioPlays.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ArchiveRadioPlays.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ArchiveRadioPlays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArchiveRadioPlays.Location = new System.Drawing.Point(0, 55);
            this.ArchiveRadioPlays.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioPlays.Name = "ArchiveRadioPlays";
            this.ArchiveRadioPlays.Size = new System.Drawing.Size(292, 25);
            this.ArchiveRadioPlays.TabIndex = 10;
            this.ArchiveRadioPlays.TabStop = true;
            this.ArchiveRadioPlays.Text = "Your Plays";
            this.ArchiveRadioPlays.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioPlays.UseVisualStyleBackColor = false;
            this.ArchiveRadioPlays.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
            // 
            // ArchiveRadioFavorites
            // 
            this.ArchiveRadioFavorites.Appearance = System.Windows.Forms.Appearance.Button;
            this.ArchiveRadioFavorites.BackColor = System.Drawing.Color.Transparent;
            this.ArchiveRadioFavorites.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArchiveRadioFavorites.FlatAppearance.BorderSize = 0;
            this.ArchiveRadioFavorites.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.ArchiveRadioFavorites.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.ArchiveRadioFavorites.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.ArchiveRadioFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ArchiveRadioFavorites.Location = new System.Drawing.Point(0, 80);
            this.ArchiveRadioFavorites.Margin = new System.Windows.Forms.Padding(0);
            this.ArchiveRadioFavorites.Name = "ArchiveRadioFavorites";
            this.ArchiveRadioFavorites.Size = new System.Drawing.Size(292, 25);
            this.ArchiveRadioFavorites.TabIndex = 11;
            this.ArchiveRadioFavorites.TabStop = true;
            this.ArchiveRadioFavorites.Text = "Your Favorites";
            this.ArchiveRadioFavorites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioFavorites.UseVisualStyleBackColor = false;
            this.ArchiveRadioFavorites.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
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
            this.ArchiveRadioAnimations.Size = new System.Drawing.Size(292, 25);
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
            this.ArchiveRadioGames.Size = new System.Drawing.Size(292, 25);
            this.ArchiveRadioGames.TabIndex = 9;
            this.ArchiveRadioGames.TabStop = true;
            this.ArchiveRadioGames.Text = "All Games";
            this.ArchiveRadioGames.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ArchiveRadioGames.UseVisualStyleBackColor = false;
            this.ArchiveRadioGames.CheckedChanged += new System.EventHandler(this.ArchiveRadio_checkedChanged);
            // 
            // DebugLabel
            // 
            this.DebugLabel.Location = new System.Drawing.Point(3, 105);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(286, 545);
            this.DebugLabel.TabIndex = 12;
            // 
            // ArchiveListFooter
            // 
            this.ArchiveListFooter.Controls.Add(this.RandomButton);
            this.ArchiveListFooter.Controls.Add(this.EntryCountLabel);
            this.ArchiveListFooter.Controls.Add(this.AdjustColumnsButton);
            this.ArchiveListFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArchiveListFooter.Location = new System.Drawing.Point(300, 658);
            this.ArchiveListFooter.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.ArchiveListFooter.Name = "ArchiveListFooter";
            this.ArchiveListFooter.Size = new System.Drawing.Size(644, 27);
            this.ArchiveListFooter.TabIndex = 10;
            // 
            // RandomButton
            // 
            this.RandomButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RandomButton.FlatAppearance.BorderSize = 0;
            this.RandomButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.RandomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.RandomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RandomButton.Image = global::SharpLauncher.Properties.Resources.random;
            this.RandomButton.Location = new System.Drawing.Point(308, 1);
            this.RandomButton.Margin = new System.Windows.Forms.Padding(0);
            this.RandomButton.Name = "RandomButton";
            this.RandomButton.Padding = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.RandomButton.Size = new System.Drawing.Size(25, 25);
            this.RandomButton.TabIndex = 3;
            this.RandomButton.UseVisualStyleBackColor = true;
            this.RandomButton.Click += new System.EventHandler(this.RandomButton_Click);
            // 
            // EntryCountLabel
            // 
            this.EntryCountLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.EntryCountLabel.Location = new System.Drawing.Point(444, 0);
            this.EntryCountLabel.Name = "EntryCountLabel";
            this.EntryCountLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EntryCountLabel.Size = new System.Drawing.Size(200, 27);
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
            this.AdjustColumnsButton.Location = new System.Drawing.Point(0, 1);
            this.AdjustColumnsButton.Margin = new System.Windows.Forms.Padding(0);
            this.AdjustColumnsButton.Name = "AdjustColumnsButton";
            this.AdjustColumnsButton.Size = new System.Drawing.Size(100, 25);
            this.AdjustColumnsButton.TabIndex = 1;
            this.AdjustColumnsButton.Text = "Adjust Columns";
            this.AdjustColumnsButton.UseVisualStyleBackColor = true;
            this.AdjustColumnsButton.Click += new System.EventHandler(this.AdjustColumnsButton_click);
            // 
            // PlayContainer
            // 
            this.PlayContainer.Controls.Add(this.AlternateButton);
            this.PlayContainer.Controls.Add(this.PlayButton);
            this.PlayContainer.Controls.Add(this.FavoriteButton);
            this.PlayContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayContainer.Location = new System.Drawing.Point(944, 653);
            this.PlayContainer.Margin = new System.Windows.Forms.Padding(0);
            this.PlayContainer.Name = "PlayContainer";
            this.PlayContainer.Size = new System.Drawing.Size(300, 32);
            this.PlayContainer.TabIndex = 11;
            // 
            // AlternateButton
            // 
            this.AlternateButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.AlternateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.AlternateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.AlternateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlternateButton.Location = new System.Drawing.Point(246, 6);
            this.AlternateButton.Margin = new System.Windows.Forms.Padding(0);
            this.AlternateButton.Name = "AlternateButton";
            this.AlternateButton.Size = new System.Drawing.Size(15, 25);
            this.AlternateButton.TabIndex = 10;
            this.AlternateButton.UseVisualStyleBackColor = true;
            this.AlternateButton.Click += new System.EventHandler(this.AlternateButton_click);
            // 
            // PlayButton
            // 
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.PlayButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.PlayButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Location = new System.Drawing.Point(9, 6);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(0);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(238, 25);
            this.PlayButton.TabIndex = 3;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.ArchiveList_itemAccess);
            // 
            // FavoriteButton
            // 
            this.FavoriteButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.FavoriteButton.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FavoriteButton.FlatAppearance.BorderSize = 0;
            this.FavoriteButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.FavoriteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FavoriteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FavoriteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FavoriteButton.ImageIndex = 0;
            this.FavoriteButton.ImageList = this.FavoriteButtonImages;
            this.FavoriteButton.Location = new System.Drawing.Point(269, 5);
            this.FavoriteButton.Margin = new System.Windows.Forms.Padding(0);
            this.FavoriteButton.Name = "FavoriteButton";
            this.FavoriteButton.Size = new System.Drawing.Size(25, 25);
            this.FavoriteButton.TabIndex = 9;
            this.FavoriteButton.UseVisualStyleBackColor = true;
            this.FavoriteButton.CheckedChanged += new System.EventHandler(this.FavoriteButton_checkedChanged);
            // 
            // FavoriteButtonImages
            // 
            this.FavoriteButtonImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.FavoriteButtonImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FavoriteButtonImages.ImageStream")));
            this.FavoriteButtonImages.TransparentColor = System.Drawing.Color.Transparent;
            this.FavoriteButtonImages.Images.SetKeyName(0, "unfavorite");
            this.FavoriteButtonImages.Images.SetKeyName(1, "favorite");
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
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_tabChanged);
            // 
            // HomeTab
            // 
            this.HomeTab.Controls.Add(this.HomeContainer);
            this.HomeTab.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeTab.Location = new System.Drawing.Point(4, 28);
            this.HomeTab.Margin = new System.Windows.Forms.Padding(0);
            this.HomeTab.Name = "HomeTab";
            this.HomeTab.Size = new System.Drawing.Size(1250, 691);
            this.HomeTab.TabIndex = 0;
            this.HomeTab.Text = "Home";
            this.HomeTab.UseVisualStyleBackColor = true;
            // 
            // HomeContainer
            // 
            this.HomeContainer.Controls.Add(this.HomeLinkContainer);
            this.HomeContainer.Controls.Add(this.HomeLogo);
            this.HomeContainer.Location = new System.Drawing.Point(369, 0);
            this.HomeContainer.Margin = new System.Windows.Forms.Padding(0);
            this.HomeContainer.Name = "HomeContainer";
            this.HomeContainer.Size = new System.Drawing.Size(512, 224);
            this.HomeContainer.TabIndex = 1;
            // 
            // HomeLinkContainer
            // 
            this.HomeLinkContainer.Controls.Add(this.HomeLinkWebsite);
            this.HomeLinkContainer.Controls.Add(this.HomeLinkWiki);
            this.HomeLinkContainer.Controls.Add(this.HomeLinkGitHub);
            this.HomeLinkContainer.Controls.Add(this.HomeLinkDiscord);
            this.HomeLinkContainer.Location = new System.Drawing.Point(151, 144);
            this.HomeLinkContainer.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLinkContainer.Name = "HomeLinkContainer";
            this.HomeLinkContainer.Size = new System.Drawing.Size(210, 20);
            this.HomeLinkContainer.TabIndex = 5;
            this.HomeLinkContainer.WrapContents = false;
            // 
            // HomeLinkWebsite
            // 
            this.HomeLinkWebsite.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(4)))), ((int)(((byte)(40)))));
            this.HomeLinkWebsite.AutoSize = true;
            this.HomeLinkWebsite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkWebsite.LinkArea = new System.Windows.Forms.LinkArea(0, 7);
            this.HomeLinkWebsite.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.HomeLinkWebsite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(94)))), ((int)(((byte)(221)))));
            this.HomeLinkWebsite.Location = new System.Drawing.Point(0, 0);
            this.HomeLinkWebsite.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLinkWebsite.Name = "HomeLinkWebsite";
            this.HomeLinkWebsite.Size = new System.Drawing.Size(63, 20);
            this.HomeLinkWebsite.TabIndex = 1;
            this.HomeLinkWebsite.TabStop = true;
            this.HomeLinkWebsite.Text = "Website -";
            this.HomeLinkWebsite.UseCompatibleTextRendering = true;
            this.HomeLinkWebsite.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(104)))), ((int)(((byte)(126)))));
            this.HomeLinkWebsite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLink_linkClicked);
            // 
            // HomeLinkWiki
            // 
            this.HomeLinkWiki.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(4)))), ((int)(((byte)(40)))));
            this.HomeLinkWiki.AutoSize = true;
            this.HomeLinkWiki.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkWiki.LinkArea = new System.Windows.Forms.LinkArea(0, 4);
            this.HomeLinkWiki.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.HomeLinkWiki.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(94)))), ((int)(((byte)(221)))));
            this.HomeLinkWiki.Location = new System.Drawing.Point(63, 0);
            this.HomeLinkWiki.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLinkWiki.Name = "HomeLinkWiki";
            this.HomeLinkWiki.Size = new System.Drawing.Size(41, 20);
            this.HomeLinkWiki.TabIndex = 2;
            this.HomeLinkWiki.TabStop = true;
            this.HomeLinkWiki.Text = "Wiki -";
            this.HomeLinkWiki.UseCompatibleTextRendering = true;
            this.HomeLinkWiki.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(104)))), ((int)(((byte)(126)))));
            this.HomeLinkWiki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLink_linkClicked);
            // 
            // HomeLinkGitHub
            // 
            this.HomeLinkGitHub.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(4)))), ((int)(((byte)(40)))));
            this.HomeLinkGitHub.AutoSize = true;
            this.HomeLinkGitHub.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkGitHub.LinkArea = new System.Windows.Forms.LinkArea(0, 6);
            this.HomeLinkGitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.HomeLinkGitHub.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(94)))), ((int)(((byte)(221)))));
            this.HomeLinkGitHub.Location = new System.Drawing.Point(104, 0);
            this.HomeLinkGitHub.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLinkGitHub.Name = "HomeLinkGitHub";
            this.HomeLinkGitHub.Size = new System.Drawing.Size(57, 20);
            this.HomeLinkGitHub.TabIndex = 3;
            this.HomeLinkGitHub.TabStop = true;
            this.HomeLinkGitHub.Text = "GitHub -";
            this.HomeLinkGitHub.UseCompatibleTextRendering = true;
            this.HomeLinkGitHub.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(104)))), ((int)(((byte)(126)))));
            this.HomeLinkGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLink_linkClicked);
            // 
            // HomeLinkDiscord
            // 
            this.HomeLinkDiscord.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(4)))), ((int)(((byte)(40)))));
            this.HomeLinkDiscord.AutoSize = true;
            this.HomeLinkDiscord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkDiscord.LinkArea = new System.Windows.Forms.LinkArea(0, 7);
            this.HomeLinkDiscord.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.HomeLinkDiscord.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(94)))), ((int)(((byte)(221)))));
            this.HomeLinkDiscord.Location = new System.Drawing.Point(161, 0);
            this.HomeLinkDiscord.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLinkDiscord.Name = "HomeLinkDiscord";
            this.HomeLinkDiscord.Size = new System.Drawing.Size(55, 20);
            this.HomeLinkDiscord.TabIndex = 4;
            this.HomeLinkDiscord.TabStop = true;
            this.HomeLinkDiscord.Text = "Discord ";
            this.HomeLinkDiscord.UseCompatibleTextRendering = true;
            this.HomeLinkDiscord.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(104)))), ((int)(((byte)(126)))));
            this.HomeLinkDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLink_linkClicked);
            // 
            // HomeLogo
            // 
            this.HomeLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HomeLogo.Image = ((System.Drawing.Image)(resources.GetObject("HomeLogo.Image")));
            this.HomeLogo.Location = new System.Drawing.Point(0, 0);
            this.HomeLogo.Margin = new System.Windows.Forms.Padding(0);
            this.HomeLogo.Name = "HomeLogo";
            this.HomeLogo.Size = new System.Drawing.Size(512, 144);
            this.HomeLogo.TabIndex = 0;
            this.HomeLogo.TabStop = false;
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
            // GitHubButton
            // 
            this.GitHubButton.BackColor = System.Drawing.Color.Transparent;
            this.GitHubButton.FlatAppearance.BorderSize = 0;
            this.GitHubButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.GitHubButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.GitHubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GitHubButton.Location = new System.Drawing.Point(60, -2);
            this.GitHubButton.Margin = new System.Windows.Forms.Padding(0);
            this.GitHubButton.Name = "GitHubButton";
            this.GitHubButton.Size = new System.Drawing.Size(60, 24);
            this.GitHubButton.TabIndex = 1;
            this.GitHubButton.Text = "GitHub";
            this.GitHubButton.UseVisualStyleBackColor = false;
            this.GitHubButton.Click += new System.EventHandler(this.GitHubButton_click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.BackColor = System.Drawing.Color.Transparent;
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.SettingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Location = new System.Drawing.Point(0, -2);
            this.SettingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(60, 24);
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_click);
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
            this.SearchButton.Location = new System.Drawing.Point(0, -2);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(50, 24);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_click);
            // 
            // ButtonContainer
            // 
            this.ButtonContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonContainer.Controls.Add(this.GitHubButton);
            this.ButtonContainer.Controls.Add(this.SettingsButton);
            this.ButtonContainer.Location = new System.Drawing.Point(1139, 6);
            this.ButtonContainer.Name = "ButtonContainer";
            this.ButtonContainer.Size = new System.Drawing.Size(120, 20);
            this.ButtonContainer.TabIndex = 2;
            // 
            // LaunchEntry
            // 
            this.LaunchEntry.StartInfo.Domain = "";
            this.LaunchEntry.StartInfo.LoadUserProfile = false;
            this.LaunchEntry.StartInfo.Password = null;
            this.LaunchEntry.StartInfo.StandardErrorEncoding = null;
            this.LaunchEntry.StartInfo.StandardInputEncoding = null;
            this.LaunchEntry.StartInfo.StandardOutputEncoding = null;
            this.LaunchEntry.StartInfo.UserName = "";
            this.LaunchEntry.SynchronizingObject = this;
            // 
            // AlternateMenu
            // 
            this.AlternateMenu.DropShadowEnabled = false;
            this.AlternateMenu.Name = "AlternateMenu";
            this.AlternateMenu.ShowImageMargin = false;
            this.AlternateMenu.Size = new System.Drawing.Size(36, 4);
            this.AlternateMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.AlternateMenu_itemClicked);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.Container);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "SharpLauncher";
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
            this.PlayContainer.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.HomeTab.ResumeLayout(false);
            this.HomeContainer.ResumeLayout(false);
            this.HomeLinkContainer.ResumeLayout(false);
            this.HomeLinkContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HomeLogo)).EndInit();
            this.ArchiveTab.ResumeLayout(false);
            this.Container.ResumeLayout(false);
            this.Container.PerformLayout();
            this.SearchButtonContainer.ResumeLayout(false);
            this.ButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel ArchiveLayout;
        private ListView ArchiveList;
        private TabControl TabControl;
        private TabPage HomeTab;
        private TabPage ArchiveTab;
        private Button SettingsButton;
        private Panel Container;
        private Button GitHubButton;
        private Button AdjustColumnsButton;
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
        private Button PlayButton;
        private Label DebugLabel;
        private RadioButton ArchiveRadioPlays;
        private RadioButton ArchiveRadioFavorites;
        private CheckBox FavoriteButton;
        private Panel PlayContainer;
        private ImageList FavoriteButtonImages;
        private Button AlternateButton;
        private ContextMenuStrip AlternateMenu;
        private PictureBox HomeLogo;
        private Panel HomeContainer;
        private Panel ButtonContainer;
        private LinkLabel HomeLinkWebsite;
        private FlowLayoutPanel HomeLinkContainer;
        private LinkLabel HomeLinkWiki;
        private LinkLabel HomeLinkGitHub;
        private LinkLabel HomeLinkDiscord;
        private Button RandomButton;
    }
}