namespace XShort
{
    partial class AutoMouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoMouse));
            this.checkBoxMoveMouseService = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerAutoCursor = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownIntervalMouse = new System.Windows.Forms.NumericUpDown();
            this.labelIntervalMouse = new System.Windows.Forms.Label();
            this.checkBoxTrayIcon = new System.Windows.Forms.CheckBox();
            this.checkBoxSendKeyService = new System.Windows.Forms.CheckBox();
            this.comboBoxKeys = new System.Windows.Forms.ComboBox();
            this.labelExplainAutoMouse = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.numericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            this.labelExplainAutoKey = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownIntervalKey = new System.Windows.Forms.NumericUpDown();
            this.labelKey2Press = new System.Windows.Forms.Label();
            this.labelIntervalKey = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboBoxMidClickTray = new System.Windows.Forms.ComboBox();
            this.comboBoxRighClickTray = new System.Windows.Forms.ComboBox();
            this.comboBoxLeftClickTray = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRightClickTray = new System.Windows.Forms.Label();
            this.labelLeftClickTray = new System.Windows.Forms.Label();
            this.timerAutoKey = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalKey)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxMoveMouseService
            // 
            resources.ApplyResources(this.checkBoxMoveMouseService, "checkBoxMoveMouseService");
            this.checkBoxMoveMouseService.Name = "checkBoxMoveMouseService";
            this.checkBoxMoveMouseService.UseVisualStyleBackColor = true;
            this.checkBoxMoveMouseService.CheckedChanged += new System.EventHandler(this.checkBoxService_CheckedChanged);
            // 
            // notifyIconTray
            // 
            resources.ApplyResources(this.notifyIconTray, "notifyIconTray");
            this.notifyIconTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // timerAutoCursor
            // 
            this.timerAutoCursor.Interval = 5000;
            this.timerAutoCursor.Tick += new System.EventHandler(this.timerAutoCursor_Tick);
            // 
            // numericUpDownIntervalMouse
            // 
            resources.ApplyResources(this.numericUpDownIntervalMouse, "numericUpDownIntervalMouse");
            this.numericUpDownIntervalMouse.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownIntervalMouse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIntervalMouse.Name = "numericUpDownIntervalMouse";
            this.numericUpDownIntervalMouse.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelIntervalMouse
            // 
            resources.ApplyResources(this.labelIntervalMouse, "labelIntervalMouse");
            this.labelIntervalMouse.Name = "labelIntervalMouse";
            // 
            // checkBoxTrayIcon
            // 
            resources.ApplyResources(this.checkBoxTrayIcon, "checkBoxTrayIcon");
            this.checkBoxTrayIcon.Name = "checkBoxTrayIcon";
            this.checkBoxTrayIcon.UseVisualStyleBackColor = true;
            this.checkBoxTrayIcon.CheckedChanged += new System.EventHandler(this.checkBoxTrayIcon_CheckedChanged);
            // 
            // checkBoxSendKeyService
            // 
            resources.ApplyResources(this.checkBoxSendKeyService, "checkBoxSendKeyService");
            this.checkBoxSendKeyService.Name = "checkBoxSendKeyService";
            this.checkBoxSendKeyService.UseVisualStyleBackColor = true;
            this.checkBoxSendKeyService.CheckedChanged += new System.EventHandler(this.checkBoxSendKey_CheckedChanged);
            // 
            // comboBoxKeys
            // 
            this.comboBoxKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKeys.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxKeys, "comboBoxKeys");
            this.comboBoxKeys.Name = "comboBoxKeys";
            // 
            // labelExplainAutoMouse
            // 
            resources.ApplyResources(this.labelExplainAutoMouse, "labelExplainAutoMouse");
            this.labelExplainAutoMouse.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainAutoMouse.Name = "labelExplainAutoMouse";
            // 
            // labelOffset
            // 
            resources.ApplyResources(this.labelOffset, "labelOffset");
            this.labelOffset.Name = "labelOffset";
            // 
            // numericUpDownOffset
            // 
            resources.ApplyResources(this.numericUpDownOffset, "numericUpDownOffset");
            this.numericUpDownOffset.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownOffset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownOffset.Name = "numericUpDownOffset";
            this.numericUpDownOffset.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelExplainAutoKey
            // 
            resources.ApplyResources(this.labelExplainAutoKey, "labelExplainAutoKey");
            this.labelExplainAutoKey.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainAutoKey.Name = "labelExplainAutoKey";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelExplainAutoMouse);
            this.groupBox1.Controls.Add(this.checkBoxMoveMouseService);
            this.groupBox1.Controls.Add(this.numericUpDownOffset);
            this.groupBox1.Controls.Add(this.numericUpDownIntervalMouse);
            this.groupBox1.Controls.Add(this.labelOffset);
            this.groupBox1.Controls.Add(this.labelIntervalMouse);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDownIntervalKey);
            this.groupBox2.Controls.Add(this.labelKey2Press);
            this.groupBox2.Controls.Add(this.labelIntervalKey);
            this.groupBox2.Controls.Add(this.labelExplainAutoKey);
            this.groupBox2.Controls.Add(this.comboBoxKeys);
            this.groupBox2.Controls.Add(this.checkBoxSendKeyService);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numericUpDownIntervalKey
            // 
            resources.ApplyResources(this.numericUpDownIntervalKey, "numericUpDownIntervalKey");
            this.numericUpDownIntervalKey.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownIntervalKey.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownIntervalKey.Name = "numericUpDownIntervalKey";
            this.numericUpDownIntervalKey.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelKey2Press
            // 
            resources.ApplyResources(this.labelKey2Press, "labelKey2Press");
            this.labelKey2Press.Name = "labelKey2Press";
            // 
            // labelIntervalKey
            // 
            resources.ApplyResources(this.labelIntervalKey, "labelIntervalKey");
            this.labelIntervalKey.Name = "labelIntervalKey";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxMidClickTray);
            this.groupBox3.Controls.Add(this.comboBoxRighClickTray);
            this.groupBox3.Controls.Add(this.comboBoxLeftClickTray);
            this.groupBox3.Controls.Add(this.checkBoxTrayIcon);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.labelRightClickTray);
            this.groupBox3.Controls.Add(this.labelLeftClickTray);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // comboBoxMidClickTray
            // 
            this.comboBoxMidClickTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMidClickTray.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxMidClickTray, "comboBoxMidClickTray");
            this.comboBoxMidClickTray.Name = "comboBoxMidClickTray";
            // 
            // comboBoxRighClickTray
            // 
            this.comboBoxRighClickTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRighClickTray.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxRighClickTray, "comboBoxRighClickTray");
            this.comboBoxRighClickTray.Name = "comboBoxRighClickTray";
            // 
            // comboBoxLeftClickTray
            // 
            this.comboBoxLeftClickTray.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLeftClickTray.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxLeftClickTray, "comboBoxLeftClickTray");
            this.comboBoxLeftClickTray.Name = "comboBoxLeftClickTray";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelRightClickTray
            // 
            resources.ApplyResources(this.labelRightClickTray, "labelRightClickTray");
            this.labelRightClickTray.Name = "labelRightClickTray";
            // 
            // labelLeftClickTray
            // 
            resources.ApplyResources(this.labelLeftClickTray, "labelLeftClickTray");
            this.labelLeftClickTray.Name = "labelLeftClickTray";
            // 
            // timerAutoKey
            // 
            this.timerAutoKey.Interval = 5000;
            this.timerAutoKey.Tick += new System.EventHandler(this.timerAutoKey_Tick);
            // 
            // AutoMouse
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoMouse";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoMouse_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalKey)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxMoveMouseService;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Timer timerAutoCursor;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalMouse;
        private System.Windows.Forms.Label labelIntervalMouse;
        private System.Windows.Forms.CheckBox checkBoxTrayIcon;
        private System.Windows.Forms.CheckBox checkBoxSendKeyService;
        private System.Windows.Forms.ComboBox comboBoxKeys;
        private System.Windows.Forms.Label labelExplainAutoMouse;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownOffset;
        private System.Windows.Forms.Label labelExplainAutoKey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalKey;
        private System.Windows.Forms.Label labelKey2Press;
        private System.Windows.Forms.Label labelIntervalKey;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timerAutoKey;
        private System.Windows.Forms.ComboBox comboBoxMidClickTray;
        private System.Windows.Forms.ComboBox comboBoxRighClickTray;
        private System.Windows.Forms.ComboBox comboBoxLeftClickTray;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRightClickTray;
        private System.Windows.Forms.Label labelLeftClickTray;
    }
}