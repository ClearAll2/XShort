namespace XShort
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsAdministratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileLocationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkValidPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.openAtWindowsStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createShortcutOnDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cloneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonBrowseDirectory = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonAddURL = new System.Windows.Forms.Button();
            this.buttonAddDir = new System.Windows.Forms.Button();
            this.buttonAddApp = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMouseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vietnameseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openAboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelData = new System.Windows.Forms.Panel();
            this.panelEditShortcut = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOkEdit = new System.Windows.Forms.Button();
            this.buttonCancelEdit = new System.Windows.Forms.Button();
            this.checkBoxIsInBlocklist = new System.Windows.Forms.CheckBox();
            this.checkBoxRunAtWindowsStartup = new System.Windows.Forms.CheckBox();
            this.labelPara = new System.Windows.Forms.Label();
            this.textBoxPara = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelShortcutType = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBoxIsInExclusionList = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelEditShortcut.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.White;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.mainWindowToolStripMenuItem,
            this.autoMouseToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.runBoxToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainWindowToolStripMenuItem
            // 
            resources.ApplyResources(this.mainWindowToolStripMenuItem, "mainWindowToolStripMenuItem");
            this.mainWindowToolStripMenuItem.Name = "mainWindowToolStripMenuItem";
            this.mainWindowToolStripMenuItem.Click += new System.EventHandler(this.mainWindowToolStripMenuItem_Click);
            // 
            // autoMouseToolStripMenuItem
            // 
            this.autoMouseToolStripMenuItem.Name = "autoMouseToolStripMenuItem";
            resources.ApplyResources(this.autoMouseToolStripMenuItem, "autoMouseToolStripMenuItem");
            this.autoMouseToolStripMenuItem.Click += new System.EventHandler(this.autoMouseToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // runBoxToolStripMenuItem
            // 
            this.runBoxToolStripMenuItem.Name = "runBoxToolStripMenuItem";
            resources.ApplyResources(this.runBoxToolStripMenuItem, "runBoxToolStripMenuItem");
            this.runBoxToolStripMenuItem.Click += new System.EventHandler(this.runBoxToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            resources.ApplyResources(this.exitToolStripMenuItem1, "exitToolStripMenuItem1");
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.openAsAdministratorToolStripMenuItem,
            this.openFileLocationToolStripMenuItem1,
            this.toolStripSeparator3,
            this.detailsToolStripMenuItem,
            this.checkValidPathToolStripMenuItem,
            this.toolStripSeparator4,
            this.openAtWindowsStartupToolStripMenuItem,
            this.createShortcutOnDesktopToolStripMenuItem,
            this.toolStripSeparator6,
            this.cloneToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.toolStripSeparator5,
            this.propertiesToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            resources.ApplyResources(this.openToolStripMenuItem1, "openToolStripMenuItem1");
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // openAsAdministratorToolStripMenuItem
            // 
            this.openAsAdministratorToolStripMenuItem.Name = "openAsAdministratorToolStripMenuItem";
            resources.ApplyResources(this.openAsAdministratorToolStripMenuItem, "openAsAdministratorToolStripMenuItem");
            this.openAsAdministratorToolStripMenuItem.Click += new System.EventHandler(this.openAsAdministratorToolStripMenuItem_Click);
            // 
            // openFileLocationToolStripMenuItem1
            // 
            this.openFileLocationToolStripMenuItem1.Name = "openFileLocationToolStripMenuItem1";
            resources.ApplyResources(this.openFileLocationToolStripMenuItem1, "openFileLocationToolStripMenuItem1");
            this.openFileLocationToolStripMenuItem1.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            resources.ApplyResources(this.detailsToolStripMenuItem, "detailsToolStripMenuItem");
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // checkValidPathToolStripMenuItem
            // 
            this.checkValidPathToolStripMenuItem.Name = "checkValidPathToolStripMenuItem";
            resources.ApplyResources(this.checkValidPathToolStripMenuItem, "checkValidPathToolStripMenuItem");
            this.checkValidPathToolStripMenuItem.Click += new System.EventHandler(this.checkValidPathToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // openAtWindowsStartupToolStripMenuItem
            // 
            this.openAtWindowsStartupToolStripMenuItem.Name = "openAtWindowsStartupToolStripMenuItem";
            resources.ApplyResources(this.openAtWindowsStartupToolStripMenuItem, "openAtWindowsStartupToolStripMenuItem");
            this.openAtWindowsStartupToolStripMenuItem.Click += new System.EventHandler(this.openAtWindowsStartupToolStripMenuItem_Click);
            // 
            // createShortcutOnDesktopToolStripMenuItem
            // 
            this.createShortcutOnDesktopToolStripMenuItem.Name = "createShortcutOnDesktopToolStripMenuItem";
            resources.ApplyResources(this.createShortcutOnDesktopToolStripMenuItem, "createShortcutOnDesktopToolStripMenuItem");
            this.createShortcutOnDesktopToolStripMenuItem.Click += new System.EventHandler(this.createShortcutOnDesktopToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // cloneToolStripMenuItem
            // 
            this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
            resources.ApplyResources(this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
            this.cloneToolStripMenuItem.Click += new System.EventHandler(this.cloneToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            resources.ApplyResources(this.addToolStripMenuItem1, "addToolStripMenuItem1");
            this.addToolStripMenuItem1.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.White;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            resources.ApplyResources(this.propertiesToolStripMenuItem, "propertiesToolStripMenuItem");
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // buttonBrowseDirectory
            // 
            resources.ApplyResources(this.buttonBrowseDirectory, "buttonBrowseDirectory");
            this.buttonBrowseDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBrowseDirectory.FlatAppearance.BorderSize = 0;
            this.buttonBrowseDirectory.Name = "buttonBrowseDirectory";
            this.buttonBrowseDirectory.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonBrowseDirectory, resources.GetString("buttonBrowseDirectory.ToolTip"));
            this.buttonBrowseDirectory.UseVisualStyleBackColor = false;
            this.buttonBrowseDirectory.Click += new System.EventHandler(this.button13_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.ImageList = this.imageList1;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonSave, resources.GetString("buttonSave.ToolTip"));
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.saveShortcutsToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home2.png");
            this.imageList1.Images.SetKeyName(1, "info.png");
            this.imageList1.Images.SetKeyName(2, "setting.png");
            this.imageList1.Images.SetKeyName(3, "menu2.png");
            this.imageList1.Images.SetKeyName(4, "back.png");
            this.imageList1.Images.SetKeyName(5, "refresh-512.png");
            this.imageList1.Images.SetKeyName(6, "exit.png");
            this.imageList1.Images.SetKeyName(7, "Bokehlicia-Captiva-Browser-web.ico");
            this.imageList1.Images.SetKeyName(8, "folder.png");
            this.imageList1.Images.SetKeyName(9, "save.png");
            this.imageList1.Images.SetKeyName(10, "link.png");
            this.imageList1.Images.SetKeyName(11, "app.png");
            this.imageList1.Images.SetKeyName(12, "import.png");
            this.imageList1.Images.SetKeyName(13, "export.png");
            this.imageList1.Images.SetKeyName(14, "info.png");
            this.imageList1.Images.SetKeyName(15, "search.png");
            this.imageList1.Images.SetKeyName(16, "log.png");
            this.imageList1.Images.SetKeyName(17, "list.png");
            // 
            // buttonAddURL
            // 
            resources.ApplyResources(this.buttonAddURL, "buttonAddURL");
            this.buttonAddURL.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddURL.FlatAppearance.BorderSize = 0;
            this.buttonAddURL.ForeColor = System.Drawing.Color.Black;
            this.buttonAddURL.ImageList = this.imageList1;
            this.buttonAddURL.Name = "buttonAddURL";
            this.buttonAddURL.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddURL, resources.GetString("buttonAddURL.ToolTip"));
            this.buttonAddURL.UseVisualStyleBackColor = true;
            this.buttonAddURL.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // buttonAddDir
            // 
            resources.ApplyResources(this.buttonAddDir, "buttonAddDir");
            this.buttonAddDir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddDir.FlatAppearance.BorderSize = 0;
            this.buttonAddDir.ForeColor = System.Drawing.Color.Black;
            this.buttonAddDir.ImageList = this.imageList1;
            this.buttonAddDir.Name = "buttonAddDir";
            this.buttonAddDir.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddDir, resources.GetString("buttonAddDir.ToolTip"));
            this.buttonAddDir.UseVisualStyleBackColor = true;
            this.buttonAddDir.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // buttonAddApp
            // 
            resources.ApplyResources(this.buttonAddApp, "buttonAddApp");
            this.buttonAddApp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonAddApp.FlatAppearance.BorderSize = 0;
            this.buttonAddApp.ForeColor = System.Drawing.Color.Black;
            this.buttonAddApp.ImageList = this.imageList1;
            this.buttonAddApp.Name = "buttonAddApp";
            this.buttonAddApp.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonAddApp, resources.GetString("buttonAddApp.ToolTip"));
            this.buttonAddApp.UseVisualStyleBackColor = true;
            this.buttonAddApp.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlToolStripMenuItem,
            this.appToolStripMenuItem,
            this.actToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.aboutToolStripMenuItem2});
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizeHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            resources.ApplyResources(this.controlToolStripMenuItem, "controlToolStripMenuItem");
            // 
            // minimizeHideToolStripMenuItem
            // 
            this.minimizeHideToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.minimizeHideToolStripMenuItem.Name = "minimizeHideToolStripMenuItem";
            resources.ApplyResources(this.minimizeHideToolStripMenuItem, "minimizeHideToolStripMenuItem");
            this.minimizeHideToolStripMenuItem.Click += new System.EventHandler(this.button7_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // appToolStripMenuItem
            // 
            this.appToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAppToolStripMenuItem,
            this.addDirToolStripMenuItem,
            this.addUrlToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.appToolStripMenuItem.Name = "appToolStripMenuItem";
            resources.ApplyResources(this.appToolStripMenuItem, "appToolStripMenuItem");
            // 
            // addAppToolStripMenuItem
            // 
            this.addAppToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addAppToolStripMenuItem.Name = "addAppToolStripMenuItem";
            resources.ApplyResources(this.addAppToolStripMenuItem, "addAppToolStripMenuItem");
            this.addAppToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addDirToolStripMenuItem
            // 
            this.addDirToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addDirToolStripMenuItem.Name = "addDirToolStripMenuItem";
            resources.ApplyResources(this.addDirToolStripMenuItem, "addDirToolStripMenuItem");
            this.addDirToolStripMenuItem.Click += new System.EventHandler(this.addDirectoryToolStripMenuItem_Click);
            // 
            // addUrlToolStripMenuItem
            // 
            this.addUrlToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.addUrlToolStripMenuItem.Name = "addUrlToolStripMenuItem";
            resources.ApplyResources(this.addUrlToolStripMenuItem, "addUrlToolStripMenuItem");
            this.addUrlToolStripMenuItem.Click += new System.EventHandler(this.addURLToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveShortcutsToolStripMenuItem_Click);
            // 
            // actToolStripMenuItem
            // 
            this.actToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadDataToolStripMenuItem1,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.autoMouseToolStripMenuItem1,
            this.openSettingsToolStripMenuItem});
            this.actToolStripMenuItem.Name = "actToolStripMenuItem";
            resources.ApplyResources(this.actToolStripMenuItem, "actToolStripMenuItem");
            // 
            // reloadDataToolStripMenuItem1
            // 
            this.reloadDataToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.reloadDataToolStripMenuItem1.Name = "reloadDataToolStripMenuItem1";
            resources.ApplyResources(this.reloadDataToolStripMenuItem1, "reloadDataToolStripMenuItem1");
            this.reloadDataToolStripMenuItem1.Click += new System.EventHandler(this.buttonReload_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // autoMouseToolStripMenuItem1
            // 
            this.autoMouseToolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.autoMouseToolStripMenuItem1.Name = "autoMouseToolStripMenuItem1";
            resources.ApplyResources(this.autoMouseToolStripMenuItem1, "autoMouseToolStripMenuItem1");
            this.autoMouseToolStripMenuItem1.Click += new System.EventHandler(this.autoMouseToolStripMenuItem_Click);
            // 
            // openSettingsToolStripMenuItem
            // 
            this.openSettingsToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openSettingsToolStripMenuItem.Name = "openSettingsToolStripMenuItem";
            resources.ApplyResources(this.openSettingsToolStripMenuItem, "openSettingsToolStripMenuItem");
            this.openSettingsToolStripMenuItem.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.vietnameseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // vietnameseToolStripMenuItem
            // 
            this.vietnameseToolStripMenuItem.Name = "vietnameseToolStripMenuItem";
            resources.ApplyResources(this.vietnameseToolStripMenuItem, "vietnameseToolStripMenuItem");
            this.vietnameseToolStripMenuItem.Click += new System.EventHandler(this.vietnameseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAboutToolStripMenuItem});
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            resources.ApplyResources(this.aboutToolStripMenuItem2, "aboutToolStripMenuItem2");
            // 
            // openAboutToolStripMenuItem
            // 
            this.openAboutToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.openAboutToolStripMenuItem.Name = "openAboutToolStripMenuItem";
            resources.ApplyResources(this.openAboutToolStripMenuItem, "openAboutToolStripMenuItem");
            this.openAboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // listViewData
            // 
            this.listViewData.AllowDrop = true;
            this.listViewData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            resources.ApplyResources(this.listViewData, "listViewData");
            this.listViewData.FullRowSelect = true;
            this.listViewData.HideSelection = false;
            this.listViewData.MultiSelect = false;
            this.listViewData.Name = "listViewData";
            this.listViewData.ShowItemToolTips = true;
            this.listViewData.TabStop = false;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            this.listViewData.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            this.listViewData.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listViewData.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listViewData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            this.listViewData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // panelData
            // 
            resources.ApplyResources(this.panelData, "panelData");
            this.panelData.Controls.Add(this.listViewData);
            this.panelData.Name = "panelData";
            // 
            // panelEditShortcut
            // 
            resources.ApplyResources(this.panelEditShortcut, "panelEditShortcut");
            this.panelEditShortcut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEditShortcut.Controls.Add(this.tableLayoutPanel1);
            this.panelEditShortcut.Name = "panelEditShortcut";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.checkBoxRunAtWindowsStartup, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelPara, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPara, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPath, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPath, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelShortcutType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowseDirectory, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIsInBlocklist, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxIsInExclusionList, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // buttonOkEdit
            // 
            resources.ApplyResources(this.buttonOkEdit, "buttonOkEdit");
            this.buttonOkEdit.BackColor = System.Drawing.SystemColors.Control;
            this.buttonOkEdit.FlatAppearance.BorderSize = 0;
            this.buttonOkEdit.Name = "buttonOkEdit";
            this.buttonOkEdit.TabStop = false;
            this.buttonOkEdit.UseVisualStyleBackColor = false;
            this.buttonOkEdit.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // buttonCancelEdit
            // 
            resources.ApplyResources(this.buttonCancelEdit, "buttonCancelEdit");
            this.buttonCancelEdit.BackColor = System.Drawing.SystemColors.Control;
            this.buttonCancelEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelEdit.FlatAppearance.BorderSize = 0;
            this.buttonCancelEdit.Name = "buttonCancelEdit";
            this.buttonCancelEdit.TabStop = false;
            this.buttonCancelEdit.UseVisualStyleBackColor = false;
            this.buttonCancelEdit.Click += new System.EventHandler(this.button12_Click);
            // 
            // checkBoxIsInBlocklist
            // 
            resources.ApplyResources(this.checkBoxIsInBlocklist, "checkBoxIsInBlocklist");
            this.checkBoxIsInBlocklist.Name = "checkBoxIsInBlocklist";
            this.checkBoxIsInBlocklist.UseVisualStyleBackColor = true;
            // 
            // checkBoxRunAtWindowsStartup
            // 
            resources.ApplyResources(this.checkBoxRunAtWindowsStartup, "checkBoxRunAtWindowsStartup");
            this.checkBoxRunAtWindowsStartup.Name = "checkBoxRunAtWindowsStartup";
            this.checkBoxRunAtWindowsStartup.UseVisualStyleBackColor = true;
            // 
            // labelPara
            // 
            resources.ApplyResources(this.labelPara, "labelPara");
            this.labelPara.Name = "labelPara";
            // 
            // textBoxPara
            // 
            resources.ApplyResources(this.textBoxPara, "textBoxPara");
            this.textBoxPara.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPara.Name = "textBoxPara";
            this.textBoxPara.TabStop = false;
            // 
            // labelPath
            // 
            resources.ApplyResources(this.labelPath, "labelPath");
            this.labelPath.Name = "labelPath";
            // 
            // textBoxPath
            // 
            resources.ApplyResources(this.textBoxPath, "textBoxPath");
            this.textBoxPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.TabStop = false;
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.TabStop = false;
            // 
            // labelShortcutType
            // 
            resources.ApplyResources(this.labelShortcutType, "labelShortcutType");
            this.labelShortcutType.Name = "labelShortcutType";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            resources.GetString("comboBox1.Items"),
            resources.GetString("comboBox1.Items1"),
            resources.GetString("comboBox1.Items2")});
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.TabStop = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // checkBoxIsInExclusionList
            // 
            resources.ApplyResources(this.checkBoxIsInExclusionList, "checkBoxIsInExclusionList");
            this.checkBoxIsInExclusionList.Name = "checkBoxIsInExclusionList";
            this.checkBoxIsInExclusionList.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.buttonOkEdit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCancelEdit, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelEditShortcut);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAddURL);
            this.Controls.Add(this.buttonAddDir);
            this.Controls.Add(this.buttonAddApp);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelEditShortcut.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkValidPathToolStripMenuItem;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem createShortcutOnDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem appToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAtWindowsStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAsAdministratorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.Panel panelEditShortcut;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonBrowseDirectory;
        private System.Windows.Forms.Label labelPara;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPara;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonCancelEdit;
        private System.Windows.Forms.Button buttonOkEdit;
        private System.Windows.Forms.Label labelShortcutType;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem openAboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonAddURL;
        private System.Windows.Forms.Button buttonAddDir;
        private System.Windows.Forms.Button buttonAddApp;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vietnameseToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxIsInBlocklist;
        private System.Windows.Forms.ToolStripMenuItem autoMouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoMouseToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxRunAtWindowsStartup;
        private System.Windows.Forms.CheckBox checkBoxIsInExclusionList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

