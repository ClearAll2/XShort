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
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // checkBoxService
            // 
            this.checkBoxService.AutoSize = true;
            this.checkBoxService.Location = new System.Drawing.Point(36, 30);
            this.checkBoxService.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxService.Name = "checkBoxService";
            this.checkBoxService.Size = new System.Drawing.Size(116, 20);
            this.checkBoxService.TabIndex = 0;
            this.checkBoxService.Text = "Enable service";
            this.checkBoxService.UseVisualStyleBackColor = true;
            // 
            // labelExplainBlocklist
            // 
            this.labelExplainBlocklist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelExplainBlocklist.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelExplainBlocklist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelExplainBlocklist.Location = new System.Drawing.Point(33, 70);
            this.labelExplainBlocklist.Name = "labelExplainBlocklist";
            this.labelExplainBlocklist.Size = new System.Drawing.Size(324, 58);
            this.labelExplainBlocklist.TabIndex = 23;
            this.labelExplainBlocklist.Text = "When enabled, this service will simulate a periodical user input by automatically" +
    " moving the mouse cursor.\r\n\r\n";
            this.labelExplainBlocklist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Auto Mouse Service";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // AutoMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(395, 146);
            this.Controls.Add(this.labelExplainBlocklist);
            this.Controls.Add(this.checkBoxService);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutoMouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Mouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoMouse_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxService;
        private System.Windows.Forms.Label labelExplainBlocklist;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}