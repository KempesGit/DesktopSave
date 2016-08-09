namespace DesktopSave
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.hideWIndowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslIcons = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRezolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbAutoRestore = new System.Windows.Forms.ToolStripComboBox();
            this.restoreOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbRestore = new System.Windows.Forms.ToolStripComboBox();
            this.startWithWindowsToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbStartWithWindows = new System.Windows.Forms.ToolStripComboBox();
            this.doubleClickToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tscbDoubleClick = new System.Windows.Forms.ToolStripComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.btNewLayout = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btRestore = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "DesktopSave";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreToolStripMenuItem,
            this.toolStripSeparator2,
            this.hideWIndowToolStripMenuItem,
            this.showWindowToolStripMenuItem,
            this.restoreWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitApplicationToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(159, 126);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restoreToolStripMenuItem.Text = "Restore icons";
            this.restoreToolStripMenuItem.ToolTipText = "Restore icons position";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // hideWIndowToolStripMenuItem
            // 
            this.hideWIndowToolStripMenuItem.Name = "hideWIndowToolStripMenuItem";
            this.hideWIndowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.hideWIndowToolStripMenuItem.Text = "Hide window";
            this.hideWIndowToolStripMenuItem.ToolTipText = "Hide main window";
            this.hideWIndowToolStripMenuItem.Click += new System.EventHandler(this.hideWIndowToolStripMenuItem_Click);
            // 
            // showWindowToolStripMenuItem
            // 
            this.showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            this.showWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showWindowToolStripMenuItem.Text = "Show window";
            this.showWindowToolStripMenuItem.ToolTipText = "Show main window";
            this.showWindowToolStripMenuItem.Click += new System.EventHandler(this.showWindowToolStripMenuItem_Click);
            // 
            // restoreWindowToolStripMenuItem
            // 
            this.restoreWindowToolStripMenuItem.Name = "restoreWindowToolStripMenuItem";
            this.restoreWindowToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.restoreWindowToolStripMenuItem.Text = "Restore window";
            this.restoreWindowToolStripMenuItem.ToolTipText = "Restore main window position";
            this.restoreWindowToolStripMenuItem.Click += new System.EventHandler(this.restoreWindowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // exitApplicationToolStripMenuItem
            // 
            this.exitApplicationToolStripMenuItem.Name = "exitApplicationToolStripMenuItem";
            this.exitApplicationToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitApplicationToolStripMenuItem.Text = "Exit";
            this.exitApplicationToolStripMenuItem.Click += new System.EventHandler(this.exitApplicationToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslIcons,
            this.toolStripStatusLabel2,
            this.tsslRezolution});
            this.statusStrip1.Location = new System.Drawing.Point(0, 218);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(394, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel1.Text = "Icons:";
            // 
            // tsslIcons
            // 
            this.tsslIcons.Name = "tsslIcons";
            this.tsslIcons.Size = new System.Drawing.Size(13, 17);
            this.tsslIcons.Text = "0";
            this.tsslIcons.ToolTipText = "Desktop icons numer.";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel2.Text = "Rezolution:";
            // 
            // tsslRezolution
            // 
            this.tsslRezolution.Name = "tsslRezolution";
            this.tsslRezolution.Size = new System.Drawing.Size(24, 17);
            this.tsslRezolution.Text = "0x0";
            this.tsslRezolution.ToolTipText = "Desktop resolution.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(394, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(115, 20);
            this.toolStripMenuItem1.Text = "Layouts collection";
            this.toolStripMenuItem1.Visible = false;
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.ToolTipText = "Load layout collection.";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Save layout collection.";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(97, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.restoreOnStartupToolStripMenuItem,
            this.startWithWindowsToolStripMenuItem3,
            this.doubleClickToolStripMenuItem3});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem2.Text = "Settings";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbAutoRestore});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.toolStripMenuItem3.Text = "Autorestore icons";
            this.toolStripMenuItem3.ToolTipText = "Autoresore icons positions after display rezolution changed.";
            // 
            // tscbAutoRestore
            // 
            this.tscbAutoRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbAutoRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbAutoRestore.Items.AddRange(new object[] {
            "enabled",
            "disabled"});
            this.tscbAutoRestore.Name = "tscbAutoRestore";
            this.tscbAutoRestore.Size = new System.Drawing.Size(75, 23);
            this.tscbAutoRestore.SelectedIndexChanged += new System.EventHandler(this.tscbRestore_SelectedIndexChanged);
            // 
            // restoreOnStartupToolStripMenuItem
            // 
            this.restoreOnStartupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbRestore});
            this.restoreOnStartupToolStripMenuItem.Name = "restoreOnStartupToolStripMenuItem";
            this.restoreOnStartupToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.restoreOnStartupToolStripMenuItem.Text = "Restore on startup";
            this.restoreOnStartupToolStripMenuItem.ToolTipText = "After application starts restore icons position.";
            // 
            // tscbRestore
            // 
            this.tscbRestore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbRestore.Items.AddRange(new object[] {
            "enabled",
            "disabled"});
            this.tscbRestore.Name = "tscbRestore";
            this.tscbRestore.Size = new System.Drawing.Size(75, 23);
            this.tscbRestore.SelectedIndexChanged += new System.EventHandler(this.tscbRestore_SelectedIndexChanged);
            // 
            // startWithWindowsToolStripMenuItem3
            // 
            this.startWithWindowsToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbStartWithWindows});
            this.startWithWindowsToolStripMenuItem3.Name = "startWithWindowsToolStripMenuItem3";
            this.startWithWindowsToolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.startWithWindowsToolStripMenuItem3.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem3.ToolTipText = "Start application with Windows.";
            // 
            // tscbStartWithWindows
            // 
            this.tscbStartWithWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbStartWithWindows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbStartWithWindows.Items.AddRange(new object[] {
            "enabled",
            "disabled"});
            this.tscbStartWithWindows.Name = "tscbStartWithWindows";
            this.tscbStartWithWindows.Size = new System.Drawing.Size(75, 23);
            this.tscbStartWithWindows.SelectedIndexChanged += new System.EventHandler(this.tscbRestore_SelectedIndexChanged);
            // 
            // doubleClickToolStripMenuItem3
            // 
            this.doubleClickToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbDoubleClick});
            this.doubleClickToolStripMenuItem3.Name = "doubleClickToolStripMenuItem3";
            this.doubleClickToolStripMenuItem3.Size = new System.Drawing.Size(176, 22);
            this.doubleClickToolStripMenuItem3.Text = "Double click";
            this.doubleClickToolStripMenuItem3.ToolTipText = "Double click try icon action.";
            // 
            // tscbDoubleClick
            // 
            this.tscbDoubleClick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbDoubleClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tscbDoubleClick.Items.AddRange(new object[] {
            "restore icons",
            "show main window"});
            this.tscbDoubleClick.Name = "tscbDoubleClick";
            this.tscbDoubleClick.Size = new System.Drawing.Size(135, 23);
            this.tscbDoubleClick.SelectedIndexChanged += new System.EventHandler(this.tscbRestore_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiDelete,
            this.toolStripSeparator5,
            this.tsmiRestore});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(167, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(166, 22);
            this.tsmiAdd.Text = "Add a new layout";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(166, 22);
            this.tsmiDelete.Text = "Delete layout";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(163, 6);
            // 
            // tsmiRestore
            // 
            this.tsmiRestore.Name = "tsmiRestore";
            this.tsmiRestore.Size = new System.Drawing.Size(166, 22);
            this.tsmiRestore.Text = "Restore icons";
            this.tsmiRestore.Click += new System.EventHandler(this.tsmiRestore_Click);
            // 
            // btNewLayout
            // 
            this.btNewLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNewLayout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNewLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btNewLayout.Location = new System.Drawing.Point(4, 3);
            this.btNewLayout.Name = "btNewLayout";
            this.btNewLayout.Size = new System.Drawing.Size(64, 23);
            this.btNewLayout.TabIndex = 15;
            this.btNewLayout.Text = "New";
            this.btNewLayout.UseVisualStyleBackColor = true;
            this.btNewLayout.Click += new System.EventHandler(this.btAddLayout_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btDelete.Location = new System.Drawing.Point(74, 3);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(64, 23);
            this.btDelete.TabIndex = 16;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRestore
            // 
            this.btRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btRestore.Location = new System.Drawing.Point(174, 3);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(64, 23);
            this.btRestore.TabIndex = 18;
            this.btRestore.Text = "Restore";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(394, 165);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(386, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Desktop layouts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.Window;
            this.listView2.ContextMenuStrip = this.contextMenuStrip1;
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(380, 133);
            this.listView2.TabIndex = 13;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView2_ItemChecked);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(386, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Icons positions";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(380, 133);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btNewLayout);
            this.panel1.Controls.Add(this.btDelete);
            this.panel1.Controls.Add(this.btRestore);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 29);
            this.panel1.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(394, 165);
            this.panel2.TabIndex = 21;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 240);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(402, 248);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DesktopSave (ver 1.0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.fmMain_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.fmMain_LocationChanged);
            this.VisibleChanged += new System.EventHandler(this.fmMain_VisibleChanged);
            this.Resize += new System.EventHandler(this.fmMain_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideWIndowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem restoreWindowToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslIcons;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslRezolution;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem restoreOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tscbRestore;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox tscbStartWithWindows;
        private System.Windows.Forms.ToolStripMenuItem doubleClickToolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox tscbDoubleClick;
        private System.Windows.Forms.Button btNewLayout;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiRestore;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripComboBox tscbAutoRestore;
        private System.Windows.Forms.Button button1;
    }
}

