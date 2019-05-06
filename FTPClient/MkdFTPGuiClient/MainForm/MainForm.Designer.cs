namespace MkdFTPGuiClient
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem leftDeleteMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftNewDirectoryMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftDownloadMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftRefreshMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightDeleteMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightNewDirectoryMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightDownloadMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightRefreshMenuItem;
            System.Windows.Forms.ToolStripLabel leftServerLabel;
            System.Windows.Forms.ToolStripLabel leftPortLabel;
            System.Windows.Forms.ToolStripLabel leftUsernameLabel;
            System.Windows.Forms.ToolStripLabel leftPasswordLabel;
            System.Windows.Forms.ToolStripLabel rightServerLabel;
            System.Windows.Forms.ToolStripLabel rightPortLabel;
            System.Windows.Forms.ToolStripLabel rightUsernameLabel;
            System.Windows.Forms.ToolStripLabel rightPasswordLabel;
            System.Windows.Forms.ToolStripDropDownButton leftLoginLogoffDropDownButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem leftLoginMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftLogoffMenuItem;
            System.Windows.Forms.ToolStripDropDownButton rightLoginLogoffDropDownButton;
            System.Windows.Forms.ToolStripMenuItem rightLoginMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightLogoffMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftRenameMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightRenameMenuItem;
            System.Windows.Forms.ToolStripMenuItem leftNewFileMenuItem;
            System.Windows.Forms.ToolStripMenuItem rightNewFileMenuItem;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.leftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftUpSplitContainer = new System.Windows.Forms.SplitContainer();
            this.leftOutputTextBox = new System.Windows.Forms.TextBox();
            this.leftUpToolStrip = new System.Windows.Forms.ToolStrip();
            this.leftUpOneDirButton = new System.Windows.Forms.ToolStripButton();
            this.leftWorkingDirLabel = new System.Windows.Forms.ToolStripLabel();
            this.leftFilesInfo = new System.Windows.Forms.DataGridView();
            this.leftFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftPermissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftOwnerGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.leftUploadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftActionsInfo = new System.Windows.Forms.DataGridView();
            this.leftProgress = new System.Windows.Forms.DataGridViewImageColumn();
            this.leftStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leftCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.leftToolStrip = new System.Windows.Forms.ToolStrip();
            this.leftHostTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.leftPortTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.leftUsernameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.leftPasswordTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rightSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rightUpSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rightOutputTextBox = new System.Windows.Forms.TextBox();
            this.rightUpToolStrip = new System.Windows.Forms.ToolStrip();
            this.rightUpOneDirButton = new System.Windows.Forms.ToolStripButton();
            this.rightWorkingDirLabel = new System.Windows.Forms.ToolStripLabel();
            this.rightFilesInfo = new System.Windows.Forms.DataGridView();
            this.rightFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightPermissions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightLastModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightOwnerGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightUploadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightActionsInfo = new System.Windows.Forms.DataGridView();
            this.rightProgress = new System.Windows.Forms.DataGridViewImageColumn();
            this.rightStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightElapsedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.rightToolStrip = new System.Windows.Forms.ToolStrip();
            this.rightHostTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rightPortTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rightUsernameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rightPasswordTextBox = new System.Windows.Forms.ToolStripTextBox();
            leftDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftNewDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftDownloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftRefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightNewDirectoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightDownloadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightRefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftServerLabel = new System.Windows.Forms.ToolStripLabel();
            leftPortLabel = new System.Windows.Forms.ToolStripLabel();
            leftUsernameLabel = new System.Windows.Forms.ToolStripLabel();
            leftPasswordLabel = new System.Windows.Forms.ToolStripLabel();
            rightServerLabel = new System.Windows.Forms.ToolStripLabel();
            rightPortLabel = new System.Windows.Forms.ToolStripLabel();
            rightUsernameLabel = new System.Windows.Forms.ToolStripLabel();
            rightPasswordLabel = new System.Windows.Forms.ToolStripLabel();
            leftLoginLogoffDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            leftLoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftLogoffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightLoginLogoffDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            rightLoginMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightLogoffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftRenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightRenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            leftNewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rightNewFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).BeginInit();
            this.leftSplitContainer.Panel1.SuspendLayout();
            this.leftSplitContainer.Panel2.SuspendLayout();
            this.leftSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpSplitContainer)).BeginInit();
            this.leftUpSplitContainer.Panel1.SuspendLayout();
            this.leftUpSplitContainer.Panel2.SuspendLayout();
            this.leftUpSplitContainer.SuspendLayout();
            this.leftUpToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftFilesInfo)).BeginInit();
            this.leftMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftActionsInfo)).BeginInit();
            this.leftToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).BeginInit();
            this.rightSplitContainer.Panel1.SuspendLayout();
            this.rightSplitContainer.Panel2.SuspendLayout();
            this.rightSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightUpSplitContainer)).BeginInit();
            this.rightUpSplitContainer.Panel1.SuspendLayout();
            this.rightUpSplitContainer.Panel2.SuspendLayout();
            this.rightUpSplitContainer.SuspendLayout();
            this.rightUpToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightFilesInfo)).BeginInit();
            this.rightMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightActionsInfo)).BeginInit();
            this.rightToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftDeleteMenuItem
            // 
            leftDeleteMenuItem.Name = "leftDeleteMenuItem";
            leftDeleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            leftDeleteMenuItem.Size = new System.Drawing.Size(217, 22);
            leftDeleteMenuItem.Text = "Избриши ...";
            leftDeleteMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftNewDirectoryMenuItem
            // 
            leftNewDirectoryMenuItem.Name = "leftNewDirectoryMenuItem";
            leftNewDirectoryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            leftNewDirectoryMenuItem.Size = new System.Drawing.Size(217, 22);
            leftNewDirectoryMenuItem.Text = "Нов директориум ...";
            leftNewDirectoryMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftDownloadMenuItem
            // 
            leftDownloadMenuItem.Name = "leftDownloadMenuItem";
            leftDownloadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            leftDownloadMenuItem.Size = new System.Drawing.Size(217, 22);
            leftDownloadMenuItem.Text = "Симни ...";
            leftDownloadMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftRefreshMenuItem
            // 
            leftRefreshMenuItem.Name = "leftRefreshMenuItem";
            leftRefreshMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            leftRefreshMenuItem.Size = new System.Drawing.Size(217, 22);
            leftRefreshMenuItem.Text = "Освежи";
            leftRefreshMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightDeleteMenuItem
            // 
            rightDeleteMenuItem.Name = "rightDeleteMenuItem";
            rightDeleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            rightDeleteMenuItem.Size = new System.Drawing.Size(217, 22);
            rightDeleteMenuItem.Text = "Избриши ...";
            rightDeleteMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightNewDirectoryMenuItem
            // 
            rightNewDirectoryMenuItem.Name = "rightNewDirectoryMenuItem";
            rightNewDirectoryMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            rightNewDirectoryMenuItem.Size = new System.Drawing.Size(217, 22);
            rightNewDirectoryMenuItem.Text = "Нов директориум ...";
            rightNewDirectoryMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightDownloadMenuItem
            // 
            rightDownloadMenuItem.Name = "rightDownloadMenuItem";
            rightDownloadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            rightDownloadMenuItem.Size = new System.Drawing.Size(217, 22);
            rightDownloadMenuItem.Text = "Симни ...";
            rightDownloadMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightRefreshMenuItem
            // 
            rightRefreshMenuItem.Name = "rightRefreshMenuItem";
            rightRefreshMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            rightRefreshMenuItem.Size = new System.Drawing.Size(217, 22);
            rightRefreshMenuItem.Text = "Освежи";
            rightRefreshMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftServerLabel
            // 
            leftServerLabel.Name = "leftServerLabel";
            leftServerLabel.Size = new System.Drawing.Size(44, 22);
            leftServerLabel.Text = "Сервер";
            // 
            // leftPortLabel
            // 
            leftPortLabel.Name = "leftPortLabel";
            leftPortLabel.Size = new System.Drawing.Size(38, 22);
            leftPortLabel.Text = "Порта";
            // 
            // leftUsernameLabel
            // 
            leftUsernameLabel.Name = "leftUsernameLabel";
            leftUsernameLabel.Size = new System.Drawing.Size(55, 22);
            leftUsernameLabel.Text = "Корисник";
            // 
            // leftPasswordLabel
            // 
            leftPasswordLabel.Name = "leftPasswordLabel";
            leftPasswordLabel.Size = new System.Drawing.Size(49, 22);
            leftPasswordLabel.Text = "Лозинка";
            // 
            // rightServerLabel
            // 
            rightServerLabel.Name = "rightServerLabel";
            rightServerLabel.Size = new System.Drawing.Size(44, 22);
            rightServerLabel.Text = "Сервер";
            // 
            // rightPortLabel
            // 
            rightPortLabel.Name = "rightPortLabel";
            rightPortLabel.Size = new System.Drawing.Size(38, 22);
            rightPortLabel.Text = "Порта";
            // 
            // rightUsernameLabel
            // 
            rightUsernameLabel.Name = "rightUsernameLabel";
            rightUsernameLabel.Size = new System.Drawing.Size(55, 22);
            rightUsernameLabel.Text = "Корисник";
            // 
            // rightPasswordLabel
            // 
            rightPasswordLabel.Name = "rightPasswordLabel";
            rightPasswordLabel.Size = new System.Drawing.Size(49, 22);
            rightPasswordLabel.Text = "Лозинка";
            // 
            // leftLoginLogoffDropDownButton
            // 
            leftLoginLogoffDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            leftLoginLogoffDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            leftLoginMenuItem,
            leftLogoffMenuItem});
            leftLoginLogoffDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("leftLoginLogoffDropDownButton.Image")));
            leftLoginLogoffDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            leftLoginLogoffDropDownButton.Name = "leftLoginLogoffDropDownButton";
            leftLoginLogoffDropDownButton.Size = new System.Drawing.Size(13, 22);
            // 
            // leftLoginMenuItem
            // 
            leftLoginMenuItem.Name = "leftLoginMenuItem";
            leftLoginMenuItem.Size = new System.Drawing.Size(106, 22);
            leftLoginMenuItem.Text = "Логин";
            leftLoginMenuItem.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // leftLogoffMenuItem
            // 
            leftLogoffMenuItem.Name = "leftLogoffMenuItem";
            leftLogoffMenuItem.Size = new System.Drawing.Size(106, 22);
            leftLogoffMenuItem.Text = "Логоф";
            leftLogoffMenuItem.Click += new System.EventHandler(this.LogoffButton_Click);
            // 
            // rightLoginLogoffDropDownButton
            // 
            rightLoginLogoffDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            rightLoginLogoffDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            rightLoginMenuItem,
            rightLogoffMenuItem});
            rightLoginLogoffDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("rightLoginLogoffDropDownButton.Image")));
            rightLoginLogoffDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            rightLoginLogoffDropDownButton.Name = "rightLoginLogoffDropDownButton";
            rightLoginLogoffDropDownButton.Size = new System.Drawing.Size(13, 22);
            // 
            // rightLoginMenuItem
            // 
            rightLoginMenuItem.Name = "rightLoginMenuItem";
            rightLoginMenuItem.Size = new System.Drawing.Size(106, 22);
            rightLoginMenuItem.Text = "Логин";
            rightLoginMenuItem.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // rightLogoffMenuItem
            // 
            rightLogoffMenuItem.Name = "rightLogoffMenuItem";
            rightLogoffMenuItem.Size = new System.Drawing.Size(106, 22);
            rightLogoffMenuItem.Text = "Логоф";
            rightLogoffMenuItem.Click += new System.EventHandler(this.LogoffButton_Click);
            // 
            // leftRenameMenuItem
            // 
            leftRenameMenuItem.Name = "leftRenameMenuItem";
            leftRenameMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            leftRenameMenuItem.Size = new System.Drawing.Size(217, 22);
            leftRenameMenuItem.Text = "Преименувај...";
            leftRenameMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightRenameMenuItem
            // 
            rightRenameMenuItem.Name = "rightRenameMenuItem";
            rightRenameMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            rightRenameMenuItem.Size = new System.Drawing.Size(217, 22);
            rightRenameMenuItem.Text = "Преименувај...";
            rightRenameMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftNewFileMenuItem
            // 
            leftNewFileMenuItem.Name = "leftNewFileMenuItem";
            leftNewFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            leftNewFileMenuItem.Size = new System.Drawing.Size(217, 22);
            leftNewFileMenuItem.Text = "Нова датотека ...";
            leftNewFileMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightNewFileMenuItem
            // 
            rightNewFileMenuItem.Name = "rightNewFileMenuItem";
            rightNewFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            rightNewFileMenuItem.Size = new System.Drawing.Size(217, 22);
            rightNewFileMenuItem.Text = "Нова датотека ...";
            rightNewFileMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1192, 24);
            this.mainMenuStrip.TabIndex = 2;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.fileToolStripMenuItem.Text = "Датотека";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.exitToolStripMenuItem.Text = "Излез ...";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 651);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1192, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.splitContainer.Panel1.Controls.Add(this.leftSplitContainer);
            this.splitContainer.Panel1.Controls.Add(this.leftToolStrip);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.splitContainer.Panel2.Controls.Add(this.rightSplitContainer);
            this.splitContainer.Panel2.Controls.Add(this.rightToolStrip);
            this.splitContainer.Size = new System.Drawing.Size(1192, 627);
            this.splitContainer.SplitterDistance = 598;
            this.splitContainer.TabIndex = 4;
            // 
            // leftSplitContainer
            // 
            this.leftSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.leftSplitContainer.Name = "leftSplitContainer";
            this.leftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftSplitContainer.Panel1
            // 
            this.leftSplitContainer.Panel1.Controls.Add(this.leftUpSplitContainer);
            // 
            // leftSplitContainer.Panel2
            // 
            this.leftSplitContainer.Panel2.Controls.Add(this.leftActionsInfo);
            this.leftSplitContainer.Size = new System.Drawing.Size(598, 602);
            this.leftSplitContainer.SplitterDistance = 461;
            this.leftSplitContainer.TabIndex = 1;
            // 
            // leftUpSplitContainer
            // 
            this.leftUpSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftUpSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftUpSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.leftUpSplitContainer.Name = "leftUpSplitContainer";
            this.leftUpSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // leftUpSplitContainer.Panel1
            // 
            this.leftUpSplitContainer.Panel1.Controls.Add(this.leftOutputTextBox);
            // 
            // leftUpSplitContainer.Panel2
            // 
            this.leftUpSplitContainer.Panel2.Controls.Add(this.leftUpToolStrip);
            this.leftUpSplitContainer.Panel2.Controls.Add(this.leftFilesInfo);
            this.leftUpSplitContainer.Size = new System.Drawing.Size(598, 461);
            this.leftUpSplitContainer.SplitterDistance = 68;
            this.leftUpSplitContainer.TabIndex = 0;
            // 
            // leftOutputTextBox
            // 
            this.leftOutputTextBox.BackColor = System.Drawing.Color.White;
            this.leftOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftOutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.leftOutputTextBox.MaxLength = 1024;
            this.leftOutputTextBox.Multiline = true;
            this.leftOutputTextBox.Name = "leftOutputTextBox";
            this.leftOutputTextBox.ReadOnly = true;
            this.leftOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.leftOutputTextBox.Size = new System.Drawing.Size(594, 64);
            this.leftOutputTextBox.TabIndex = 0;
            // 
            // leftUpToolStrip
            // 
            this.leftUpToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftUpOneDirButton,
            this.leftWorkingDirLabel});
            this.leftUpToolStrip.Location = new System.Drawing.Point(0, 0);
            this.leftUpToolStrip.Name = "leftUpToolStrip";
            this.leftUpToolStrip.Size = new System.Drawing.Size(594, 25);
            this.leftUpToolStrip.TabIndex = 2;
            this.leftUpToolStrip.Text = "toolStrip1";
            // 
            // leftUpOneDirButton
            // 
            this.leftUpOneDirButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.leftUpOneDirButton.Image = ((System.Drawing.Image)(resources.GetObject("leftUpOneDirButton.Image")));
            this.leftUpOneDirButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftUpOneDirButton.Name = "leftUpOneDirButton";
            this.leftUpOneDirButton.Size = new System.Drawing.Size(23, 22);
            this.leftUpOneDirButton.Text = "<-";
            this.leftUpOneDirButton.Click += new System.EventHandler(this.UpOneDirButton_Click);
            // 
            // leftWorkingDirLabel
            // 
            this.leftWorkingDirLabel.Name = "leftWorkingDirLabel";
            this.leftWorkingDirLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // leftFilesInfo
            // 
            this.leftFilesInfo.AllowUserToAddRows = false;
            this.leftFilesInfo.AllowUserToDeleteRows = false;
            this.leftFilesInfo.AllowUserToOrderColumns = true;
            this.leftFilesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.leftFilesInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leftFilesInfo.BackgroundColor = System.Drawing.Color.White;
            this.leftFilesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftFilesInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leftFileName,
            this.leftFileSize,
            this.leftType,
            this.leftPermissions,
            this.leftLastModified,
            this.leftOwnerGroup});
            this.leftFilesInfo.ContextMenuStrip = this.leftMenuStrip;
            this.leftFilesInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.leftFilesInfo.Location = new System.Drawing.Point(0, 28);
            this.leftFilesInfo.MultiSelect = false;
            this.leftFilesInfo.Name = "leftFilesInfo";
            this.leftFilesInfo.ReadOnly = true;
            this.leftFilesInfo.RowHeadersVisible = false;
            this.leftFilesInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leftFilesInfo.Size = new System.Drawing.Size(594, 357);
            this.leftFilesInfo.TabIndex = 1;
            this.leftFilesInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.FilesInfo_ColumnHeaderMouseClick);
            this.leftFilesInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilesInfo_MouseDoubleClick);
            // 
            // leftFileName
            // 
            this.leftFileName.DataPropertyName = "Name";
            this.leftFileName.HeaderText = "Име";
            this.leftFileName.Name = "leftFileName";
            this.leftFileName.ReadOnly = true;
            // 
            // leftFileSize
            // 
            this.leftFileSize.DataPropertyName = "Size";
            this.leftFileSize.HeaderText = "Големина";
            this.leftFileSize.Name = "leftFileSize";
            this.leftFileSize.ReadOnly = true;
            // 
            // leftType
            // 
            this.leftType.DataPropertyName = "Type";
            this.leftType.HeaderText = "Тип";
            this.leftType.Name = "leftType";
            this.leftType.ReadOnly = true;
            // 
            // leftPermissions
            // 
            this.leftPermissions.DataPropertyName = "Permissions";
            this.leftPermissions.HeaderText = "Пермисии";
            this.leftPermissions.Name = "leftPermissions";
            this.leftPermissions.ReadOnly = true;
            // 
            // leftLastModified
            // 
            this.leftLastModified.DataPropertyName = "LastModified";
            this.leftLastModified.HeaderText = "Модификација";
            this.leftLastModified.Name = "leftLastModified";
            this.leftLastModified.ReadOnly = true;
            // 
            // leftOwnerGroup
            // 
            this.leftOwnerGroup.DataPropertyName = "OwnerGroup";
            this.leftOwnerGroup.HeaderText = "Поседувач/Група";
            this.leftOwnerGroup.Name = "leftOwnerGroup";
            this.leftOwnerGroup.ReadOnly = true;
            // 
            // leftMenuStrip
            // 
            this.leftMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            leftDeleteMenuItem,
            leftNewDirectoryMenuItem,
            leftDownloadMenuItem,
            leftRefreshMenuItem,
            this.leftUploadMenuItem,
            leftRenameMenuItem,
            leftNewFileMenuItem});
            this.leftMenuStrip.Name = "leftMenuStrip";
            this.leftMenuStrip.Size = new System.Drawing.Size(218, 158);
            this.leftMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MenuStrip_Opening);
            // 
            // leftUploadMenuItem
            // 
            this.leftUploadMenuItem.Name = "leftUploadMenuItem";
            this.leftUploadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.leftUploadMenuItem.Size = new System.Drawing.Size(217, 22);
            this.leftUploadMenuItem.Text = "Качи ...";
            this.leftUploadMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // leftActionsInfo
            // 
            this.leftActionsInfo.AllowUserToAddRows = false;
            this.leftActionsInfo.AllowUserToDeleteRows = false;
            this.leftActionsInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.leftActionsInfo.BackgroundColor = System.Drawing.Color.White;
            this.leftActionsInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftActionsInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.leftActionsInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.leftActionsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftActionsInfo.ColumnHeadersVisible = false;
            this.leftActionsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.leftProgress,
            this.leftStatus,
            this.leftSpeed,
            this.leftElapsedTime,
            this.leftCancel});
            this.leftActionsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftActionsInfo.Location = new System.Drawing.Point(0, 0);
            this.leftActionsInfo.Name = "leftActionsInfo";
            this.leftActionsInfo.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.leftActionsInfo.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.leftActionsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.leftActionsInfo.Size = new System.Drawing.Size(594, 133);
            this.leftActionsInfo.TabIndex = 2;
            this.leftActionsInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActionsInfo_CellContentClick);
            // 
            // leftProgress
            // 
            this.leftProgress.FillWeight = 110.7978F;
            this.leftProgress.HeaderText = "Прогрес";
            this.leftProgress.Name = "leftProgress";
            this.leftProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // leftStatus
            // 
            this.leftStatus.FillWeight = 214.2859F;
            this.leftStatus.HeaderText = "Статус";
            this.leftStatus.Name = "leftStatus";
            this.leftStatus.ReadOnly = true;
            // 
            // leftSpeed
            // 
            this.leftSpeed.FillWeight = 63.45104F;
            this.leftSpeed.HeaderText = "Брзина";
            this.leftSpeed.Name = "leftSpeed";
            this.leftSpeed.ReadOnly = true;
            // 
            // leftElapsedTime
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.leftElapsedTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.leftElapsedTime.FillWeight = 56.63403F;
            this.leftElapsedTime.HeaderText = "Време";
            this.leftElapsedTime.Name = "leftElapsedTime";
            this.leftElapsedTime.ReadOnly = true;
            // 
            // leftCancel
            // 
            this.leftCancel.FillWeight = 54.82551F;
            this.leftCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftCancel.HeaderText = "";
            this.leftCancel.Name = "leftCancel";
            this.leftCancel.ReadOnly = true;
            this.leftCancel.Text = "Откажи";
            // 
            // leftToolStrip
            // 
            this.leftToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            leftServerLabel,
            this.leftHostTextBox,
            leftPortLabel,
            this.leftPortTextBox,
            leftUsernameLabel,
            this.leftUsernameTextBox,
            leftPasswordLabel,
            this.leftPasswordTextBox,
            leftLoginLogoffDropDownButton});
            this.leftToolStrip.Location = new System.Drawing.Point(0, 0);
            this.leftToolStrip.Name = "leftToolStrip";
            this.leftToolStrip.Size = new System.Drawing.Size(598, 25);
            this.leftToolStrip.TabIndex = 0;
            this.leftToolStrip.Text = "toolStrip1";
            // 
            // leftHostTextBox
            // 
            this.leftHostTextBox.MaxLength = 15;
            this.leftHostTextBox.Name = "leftHostTextBox";
            this.leftHostTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // leftPortTextBox
            // 
            this.leftPortTextBox.MaxLength = 5;
            this.leftPortTextBox.Name = "leftPortTextBox";
            this.leftPortTextBox.Size = new System.Drawing.Size(40, 25);
            // 
            // leftUsernameTextBox
            // 
            this.leftUsernameTextBox.MaxLength = 50;
            this.leftUsernameTextBox.Name = "leftUsernameTextBox";
            this.leftUsernameTextBox.Size = new System.Drawing.Size(80, 25);
            // 
            // leftPasswordTextBox
            // 
            this.leftPasswordTextBox.Name = "leftPasswordTextBox";
            this.leftPasswordTextBox.Size = new System.Drawing.Size(80, 25);
            // 
            // rightSplitContainer
            // 
            this.rightSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.rightSplitContainer.Name = "rightSplitContainer";
            this.rightSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightSplitContainer.Panel1
            // 
            this.rightSplitContainer.Panel1.Controls.Add(this.rightUpSplitContainer);
            // 
            // rightSplitContainer.Panel2
            // 
            this.rightSplitContainer.Panel2.Controls.Add(this.rightActionsInfo);
            this.rightSplitContainer.Size = new System.Drawing.Size(590, 602);
            this.rightSplitContainer.SplitterDistance = 461;
            this.rightSplitContainer.TabIndex = 1;
            // 
            // rightUpSplitContainer
            // 
            this.rightUpSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightUpSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightUpSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rightUpSplitContainer.Name = "rightUpSplitContainer";
            this.rightUpSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightUpSplitContainer.Panel1
            // 
            this.rightUpSplitContainer.Panel1.Controls.Add(this.rightOutputTextBox);
            // 
            // rightUpSplitContainer.Panel2
            // 
            this.rightUpSplitContainer.Panel2.Controls.Add(this.rightUpToolStrip);
            this.rightUpSplitContainer.Panel2.Controls.Add(this.rightFilesInfo);
            this.rightUpSplitContainer.Size = new System.Drawing.Size(590, 461);
            this.rightUpSplitContainer.SplitterDistance = 68;
            this.rightUpSplitContainer.TabIndex = 0;
            // 
            // rightOutputTextBox
            // 
            this.rightOutputTextBox.BackColor = System.Drawing.Color.White;
            this.rightOutputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightOutputTextBox.Location = new System.Drawing.Point(0, 0);
            this.rightOutputTextBox.MaxLength = 1024;
            this.rightOutputTextBox.Multiline = true;
            this.rightOutputTextBox.Name = "rightOutputTextBox";
            this.rightOutputTextBox.ReadOnly = true;
            this.rightOutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.rightOutputTextBox.Size = new System.Drawing.Size(586, 64);
            this.rightOutputTextBox.TabIndex = 1;
            // 
            // rightUpToolStrip
            // 
            this.rightUpToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rightUpOneDirButton,
            this.rightWorkingDirLabel});
            this.rightUpToolStrip.Location = new System.Drawing.Point(0, 0);
            this.rightUpToolStrip.Name = "rightUpToolStrip";
            this.rightUpToolStrip.Size = new System.Drawing.Size(586, 25);
            this.rightUpToolStrip.TabIndex = 3;
            this.rightUpToolStrip.Text = "toolStrip2";
            // 
            // rightUpOneDirButton
            // 
            this.rightUpOneDirButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.rightUpOneDirButton.Image = ((System.Drawing.Image)(resources.GetObject("rightUpOneDirButton.Image")));
            this.rightUpOneDirButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightUpOneDirButton.Name = "rightUpOneDirButton";
            this.rightUpOneDirButton.Size = new System.Drawing.Size(23, 22);
            this.rightUpOneDirButton.Text = "<-";
            this.rightUpOneDirButton.Click += new System.EventHandler(this.UpOneDirButton_Click);
            // 
            // rightWorkingDirLabel
            // 
            this.rightWorkingDirLabel.Name = "rightWorkingDirLabel";
            this.rightWorkingDirLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // rightFilesInfo
            // 
            this.rightFilesInfo.AllowUserToAddRows = false;
            this.rightFilesInfo.AllowUserToDeleteRows = false;
            this.rightFilesInfo.AllowUserToOrderColumns = true;
            this.rightFilesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightFilesInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rightFilesInfo.BackgroundColor = System.Drawing.Color.White;
            this.rightFilesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightFilesInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rightFileName,
            this.rightFileSize,
            this.rightType,
            this.rightPermissions,
            this.rightLastModified,
            this.rightOwnerGroup});
            this.rightFilesInfo.ContextMenuStrip = this.rightMenuStrip;
            this.rightFilesInfo.Location = new System.Drawing.Point(0, 28);
            this.rightFilesInfo.Name = "rightFilesInfo";
            this.rightFilesInfo.ReadOnly = true;
            this.rightFilesInfo.RowHeadersVisible = false;
            this.rightFilesInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rightFilesInfo.Size = new System.Drawing.Size(586, 357);
            this.rightFilesInfo.TabIndex = 2;
            this.rightFilesInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FilesInfo_MouseDoubleClick);
            // 
            // rightFileName
            // 
            this.rightFileName.DataPropertyName = "Name";
            this.rightFileName.HeaderText = "Име";
            this.rightFileName.Name = "rightFileName";
            this.rightFileName.ReadOnly = true;
            // 
            // rightFileSize
            // 
            this.rightFileSize.DataPropertyName = "Size";
            this.rightFileSize.HeaderText = "Големина";
            this.rightFileSize.Name = "rightFileSize";
            this.rightFileSize.ReadOnly = true;
            // 
            // rightType
            // 
            this.rightType.DataPropertyName = "Type";
            this.rightType.HeaderText = "Тип";
            this.rightType.Name = "rightType";
            this.rightType.ReadOnly = true;
            // 
            // rightPermissions
            // 
            this.rightPermissions.DataPropertyName = "Permissions";
            this.rightPermissions.HeaderText = "Пермисии";
            this.rightPermissions.Name = "rightPermissions";
            this.rightPermissions.ReadOnly = true;
            // 
            // rightLastModified
            // 
            this.rightLastModified.DataPropertyName = "LastModified";
            this.rightLastModified.HeaderText = "Модификација";
            this.rightLastModified.Name = "rightLastModified";
            this.rightLastModified.ReadOnly = true;
            // 
            // rightOwnerGroup
            // 
            this.rightOwnerGroup.DataPropertyName = "OwnerGroup";
            this.rightOwnerGroup.HeaderText = "Поседувач/Група";
            this.rightOwnerGroup.Name = "rightOwnerGroup";
            this.rightOwnerGroup.ReadOnly = true;
            // 
            // rightMenuStrip
            // 
            this.rightMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            rightDeleteMenuItem,
            rightNewDirectoryMenuItem,
            rightDownloadMenuItem,
            rightRefreshMenuItem,
            this.rightUploadMenuItem,
            rightRenameMenuItem,
            rightNewFileMenuItem});
            this.rightMenuStrip.Name = "rightMenuStrip";
            this.rightMenuStrip.Size = new System.Drawing.Size(218, 180);
            this.rightMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.MenuStrip_Opening);
            // 
            // rightUploadMenuItem
            // 
            this.rightUploadMenuItem.Name = "rightUploadMenuItem";
            this.rightUploadMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.rightUploadMenuItem.Size = new System.Drawing.Size(217, 22);
            this.rightUploadMenuItem.Text = "Качи ...";
            this.rightUploadMenuItem.Click += new System.EventHandler(this.PopupMenu_Click);
            // 
            // rightActionsInfo
            // 
            this.rightActionsInfo.AllowUserToAddRows = false;
            this.rightActionsInfo.AllowUserToDeleteRows = false;
            this.rightActionsInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.rightActionsInfo.BackgroundColor = System.Drawing.Color.White;
            this.rightActionsInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rightActionsInfo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rightActionsInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.rightActionsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightActionsInfo.ColumnHeadersVisible = false;
            this.rightActionsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rightProgress,
            this.rightStatus,
            this.rightSpeed,
            this.rightElapsedTime,
            this.rightCancel});
            this.rightActionsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightActionsInfo.Location = new System.Drawing.Point(0, 0);
            this.rightActionsInfo.Name = "rightActionsInfo";
            this.rightActionsInfo.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.rightActionsInfo.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.rightActionsInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.rightActionsInfo.Size = new System.Drawing.Size(586, 133);
            this.rightActionsInfo.TabIndex = 3;
            this.rightActionsInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ActionsInfo_CellContentClick);
            // 
            // rightProgress
            // 
            this.rightProgress.FillWeight = 110.7978F;
            this.rightProgress.HeaderText = "Прогрес";
            this.rightProgress.Image = global::MkdFTPGuiClient.Properties.Resources.ProgressPic;
            this.rightProgress.Name = "rightProgress";
            this.rightProgress.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // rightStatus
            // 
            this.rightStatus.FillWeight = 214.2859F;
            this.rightStatus.HeaderText = "Статус";
            this.rightStatus.Name = "rightStatus";
            this.rightStatus.ReadOnly = true;
            // 
            // rightSpeed
            // 
            this.rightSpeed.FillWeight = 63.45104F;
            this.rightSpeed.HeaderText = "Брзина";
            this.rightSpeed.Name = "rightSpeed";
            this.rightSpeed.ReadOnly = true;
            // 
            // rightElapsedTime
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.rightElapsedTime.DefaultCellStyle = dataGridViewCellStyle5;
            this.rightElapsedTime.FillWeight = 56.63403F;
            this.rightElapsedTime.HeaderText = "Време";
            this.rightElapsedTime.Name = "rightElapsedTime";
            this.rightElapsedTime.ReadOnly = true;
            // 
            // rightCancel
            // 
            this.rightCancel.FillWeight = 54.82551F;
            this.rightCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightCancel.HeaderText = "";
            this.rightCancel.Name = "rightCancel";
            this.rightCancel.ReadOnly = true;
            this.rightCancel.Text = "Откажи";
            // 
            // rightToolStrip
            // 
            this.rightToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            rightServerLabel,
            this.rightHostTextBox,
            rightPortLabel,
            this.rightPortTextBox,
            rightUsernameLabel,
            this.rightUsernameTextBox,
            rightPasswordLabel,
            this.rightPasswordTextBox,
            rightLoginLogoffDropDownButton});
            this.rightToolStrip.Location = new System.Drawing.Point(0, 0);
            this.rightToolStrip.Name = "rightToolStrip";
            this.rightToolStrip.Size = new System.Drawing.Size(590, 25);
            this.rightToolStrip.TabIndex = 0;
            this.rightToolStrip.Text = "toolStrip2";
            // 
            // rightHostTextBox
            // 
            this.rightHostTextBox.MaxLength = 15;
            this.rightHostTextBox.Name = "rightHostTextBox";
            this.rightHostTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // rightPortTextBox
            // 
            this.rightPortTextBox.MaxLength = 5;
            this.rightPortTextBox.Name = "rightPortTextBox";
            this.rightPortTextBox.Size = new System.Drawing.Size(40, 25);
            // 
            // rightUsernameTextBox
            // 
            this.rightUsernameTextBox.MaxLength = 50;
            this.rightUsernameTextBox.Name = "rightUsernameTextBox";
            this.rightUsernameTextBox.Size = new System.Drawing.Size(80, 25);
            // 
            // rightPasswordTextBox
            // 
            this.rightPasswordTextBox.Name = "rightPasswordTextBox";
            this.rightPasswordTextBox.Size = new System.Drawing.Size(80, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 673);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MKD FTP Client";
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.leftSplitContainer.Panel1.ResumeLayout(false);
            this.leftSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftSplitContainer)).EndInit();
            this.leftSplitContainer.ResumeLayout(false);
            this.leftUpSplitContainer.Panel1.ResumeLayout(false);
            this.leftUpSplitContainer.Panel1.PerformLayout();
            this.leftUpSplitContainer.Panel2.ResumeLayout(false);
            this.leftUpSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftUpSplitContainer)).EndInit();
            this.leftUpSplitContainer.ResumeLayout(false);
            this.leftUpToolStrip.ResumeLayout(false);
            this.leftUpToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftFilesInfo)).EndInit();
            this.leftMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftActionsInfo)).EndInit();
            this.leftToolStrip.ResumeLayout(false);
            this.leftToolStrip.PerformLayout();
            this.rightSplitContainer.Panel1.ResumeLayout(false);
            this.rightSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitContainer)).EndInit();
            this.rightSplitContainer.ResumeLayout(false);
            this.rightUpSplitContainer.Panel1.ResumeLayout(false);
            this.rightUpSplitContainer.Panel1.PerformLayout();
            this.rightUpSplitContainer.Panel2.ResumeLayout(false);
            this.rightUpSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightUpSplitContainer)).EndInit();
            this.rightUpSplitContainer.ResumeLayout(false);
            this.rightUpToolStrip.ResumeLayout(false);
            this.rightUpToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightFilesInfo)).EndInit();
            this.rightMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightActionsInfo)).EndInit();
            this.rightToolStrip.ResumeLayout(false);
            this.rightToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip leftToolStrip;
        private System.Windows.Forms.ToolStrip rightToolStrip;
        private System.Windows.Forms.SplitContainer leftSplitContainer;
        private System.Windows.Forms.SplitContainer rightSplitContainer;
        private System.Windows.Forms.ToolStripTextBox leftHostTextBox;
        private System.Windows.Forms.ToolStripTextBox leftPortTextBox;
        private System.Windows.Forms.ToolStripTextBox rightHostTextBox;
        private System.Windows.Forms.ToolStripTextBox rightPortTextBox;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.SplitContainer leftUpSplitContainer;
        private System.Windows.Forms.SplitContainer rightUpSplitContainer;
        private System.Windows.Forms.TextBox leftOutputTextBox;
        private System.Windows.Forms.TextBox rightOutputTextBox;
        private System.Windows.Forms.ToolStripTextBox leftUsernameTextBox;
        private System.Windows.Forms.ToolStripTextBox leftPasswordTextBox;
        private System.Windows.Forms.ToolStripTextBox rightUsernameTextBox;
        private System.Windows.Forms.ToolStripTextBox rightPasswordTextBox;
        private System.Windows.Forms.DataGridView leftFilesInfo;
        private System.Windows.Forms.DataGridView rightFilesInfo;
        private System.Windows.Forms.ToolStrip leftUpToolStrip;
        private System.Windows.Forms.ToolStrip rightUpToolStrip;
        private System.Windows.Forms.ToolStripLabel leftWorkingDirLabel;
        private System.Windows.Forms.ToolStripLabel rightWorkingDirLabel;
        private System.Windows.Forms.ToolStripButton leftUpOneDirButton;
        private System.Windows.Forms.ToolStripButton rightUpOneDirButton;
        private System.Windows.Forms.DataGridView leftActionsInfo;
        private System.Windows.Forms.DataGridView rightActionsInfo;
        private System.Windows.Forms.ContextMenuStrip leftMenuStrip;
        private System.Windows.Forms.ContextMenuStrip rightMenuStrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightType;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightLastModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightOwnerGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftType;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftPermissions;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftLastModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftOwnerGroup;
        private System.Windows.Forms.DataGridViewImageColumn leftProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn leftElapsedTime;
        private System.Windows.Forms.DataGridViewButtonColumn leftCancel;
        private System.Windows.Forms.DataGridViewImageColumn rightProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightElapsedTime;
        private System.Windows.Forms.DataGridViewButtonColumn rightCancel;
        private System.Windows.Forms.ToolStripMenuItem leftUploadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightUploadMenuItem;
    }
}

