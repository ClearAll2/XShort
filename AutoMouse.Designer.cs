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
            this.checkBoxService = new System.Windows.Forms.CheckBox();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerAutoCursor = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.checkBoxTrayIcon = new System.Windows.Forms.CheckBox();
            this.checkBoxSendKey = new System.Windows.Forms.CheckBox();
            this.comboBoxKeys = new System.Windows.Forms.ComboBox();
            this.labelExplainBlocklist = new System.Windows.Forms.Label();
            this.labelOffset = new System.Windows.Forms.Label();
            this.numericUpDownOffset = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxService
            // 
            resources.ApplyResources(this.checkBoxService, "checkBoxService");
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.CheckedChanged += new System.EventHandler(this.checkBoxService_CheckedChanged);
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
            // numericUpDownInterval
            // 
            resources.ApplyResources(this.numericUpDownInterval, "numericUpDownInterval");
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // labelInfo1
            // 
            resources.ApplyResources(this.labelInfo1, "labelInfo1");
            this.labelInfo1.Name = "labelInfo1";
            // 
            // checkBoxTrayIcon
            // 
            resources.ApplyResources(this.checkBoxTrayIcon, "checkBoxTrayIcon");
            this.checkBoxTrayIcon.Name = "checkBoxTrayIcon";
            this.checkBoxTrayIcon.UseVisualStyleBackColor = true;
            this.checkBoxTrayIcon.CheckedChanged += new System.EventHandler(this.checkBoxTrayIcon_CheckedChanged);
            // 
            // checkBoxSendKey
            // 
            resources.ApplyResources(this.checkBoxSendKey, "checkBoxSendKey");
            this.checkBoxSendKey.Name = "checkBoxSendKey";
            this.checkBoxSendKey.UseVisualStyleBackColor = true;
            // 
            // comboBoxKeys
            // 
            this.comboBoxKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKeys.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxKeys, "comboBoxKeys");
            this.comboBoxKeys.Name = "comboBoxKeys";
            // 
            // labelExplainBlocklist
            // 
            resources.ApplyResources(this.labelExplainBlocklist, "labelExplainBlocklist");
            this.labelExplainBlocklist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainBlocklist.Name = "labelExplainBlocklist";
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
            300,
            0,
            0,
            0});
            this.numericUpDownOffset.Minimum = new decimal(new int[] {
            5,
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
            // AutoMouse
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.numericUpDownOffset);
            this.Controls.Add(this.labelOffset);
            this.Controls.Add(this.labelExplainBlocklist);
            this.Controls.Add(this.comboBoxKeys);
            this.Controls.Add(this.checkBoxSendKey);
            this.Controls.Add(this.checkBoxTrayIcon);
            this.Controls.Add(this.labelInfo1);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.checkBoxService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoMouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoMouse_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Timer timerAutoCursor;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.CheckBox checkBoxTrayIcon;
        private System.Windows.Forms.CheckBox checkBoxSendKey;
        private System.Windows.Forms.ComboBox comboBoxKeys;
        private System.Windows.Forms.Label labelExplainBlocklist;
        private System.Windows.Forms.Label labelOffset;
        private System.Windows.Forms.NumericUpDown numericUpDownOffset;
    }
}