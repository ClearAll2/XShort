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
            this.labelExplainBlocklist = new System.Windows.Forms.Label();
            this.notifyIconTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerAutoCursor = new System.Windows.Forms.Timer(this.components);
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.labelInfo1 = new System.Windows.Forms.Label();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.checkBoxTrayIcon = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxService
            // 
            resources.ApplyResources(this.checkBoxService, "checkBoxService");
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.UseVisualStyleBackColor = true;
            this.checkBoxService.CheckedChanged += new System.EventHandler(this.checkBoxService_CheckedChanged);
            // 
            // labelExplainBlocklist
            // 
            resources.ApplyResources(this.labelExplainBlocklist, "labelExplainBlocklist");
            this.labelExplainBlocklist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainBlocklist.Name = "labelExplainBlocklist";
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
            // labelInfo2
            // 
            resources.ApplyResources(this.labelInfo2, "labelInfo2");
            this.labelInfo2.Name = "labelInfo2";
            // 
            // checkBoxTrayIcon
            // 
            resources.ApplyResources(this.checkBoxTrayIcon, "checkBoxTrayIcon");
            this.checkBoxTrayIcon.Name = "checkBoxTrayIcon";
            this.checkBoxTrayIcon.UseVisualStyleBackColor = true;
            this.checkBoxTrayIcon.CheckedChanged += new System.EventHandler(this.checkBoxTrayIcon_CheckedChanged);
            // 
            // AutoMouse
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkBoxTrayIcon);
            this.Controls.Add(this.labelInfo2);
            this.Controls.Add(this.labelInfo1);
            this.Controls.Add(this.numericUpDownInterval);
            this.Controls.Add(this.labelExplainBlocklist);
            this.Controls.Add(this.checkBoxService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoMouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoMouse_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.Label labelExplainBlocklist;
        private System.Windows.Forms.NotifyIcon notifyIconTray;
        private System.Windows.Forms.Timer timerAutoCursor;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.Label labelInfo1;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.CheckBox checkBoxTrayIcon;
    }
}