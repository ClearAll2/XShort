using System;
using System.Windows.Forms;
using AutoMouseMover.WinHelper;
using Microsoft.Win32;

namespace XShort
{
    public partial class AutoMouse : Form
    {
        private bool exit = false;
        private int sign = 1;
        public AutoMouse()
        {
            InitializeComponent();
            using (RegistryKey r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\AMI", true))
            {
                if (r != null)
                {
                    numericUpDownInterval.Value = (int)r.GetValue("AMI");
                    if (r.GetValue("AMITray") != null)
                        checkBoxTrayIcon.Checked = true;
                }
                else
                    Registry.CurrentUser.CreateSubKey("SOFTWARE\\ClearAll\\XShort\\AMI");
            }
        }

        private void MoveCursor(int offset)
        {
            // If mouse is outside screen, move it to the center
            // In case of multiple screens are used, the mouse will be moved to the center of the main screen
            // This has never been a problem to me, but you can modify the code to support multiple screens

            if (!CursorHelper.CheckRelativePosition(offset, offset))
            {
                var res_info = DesktopHelper.GetResolution();
                var center_screen_pos = new CursorPosition(res_info.Width / 2, res_info.Height / 2);
                CursorHelper.SetPositionAbsolute(center_screen_pos);
            }
            else
            {
                CursorHelper.SetPositionRelative(offset, offset);
            }
        }


        public void CloseForm()
        {
            exit = true;
            timerAutoCursor.Stop();
            this.Close();
        }

        private void AutoMouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (RegistryKey r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\AMI", true))
            {
                r.SetValue("AMI", (int)numericUpDownInterval.Value);
                if (checkBoxTrayIcon.Checked)
                    r.SetValue("AMITray", true);
                else
                    r.DeleteValue("AMITray", false);
            }
            if (!exit)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (checkBoxService.Checked)
                {
                    checkBoxService.Checked = false;
                }
                else
                {
                    checkBoxService.Checked = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Show();
            }
        }

        private void timerAutoCursor_Tick(object sender, EventArgs e)
        {
            MoveCursor(sign * 20);
            sign = -sign;
        }

        private void checkBoxService_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxService.Checked)
            {
                timerAutoCursor.Interval = 1000 * (int)numericUpDownInterval.Value;
                timerAutoCursor.Start();
                notifyIconTray.Icon = Properties.Resources.favicon2;
                notifyIconTray.Text = "Auto Mouse Service - On\nClick to turn off";
                numericUpDownInterval.Enabled = false;
            }
            else
            {
                timerAutoCursor.Stop();
                notifyIconTray.Icon = Properties.Resources.favicon1;
                notifyIconTray.Text = "Auto Mouse Service - Off\nClick to turn on";
                numericUpDownInterval.Enabled = true;
            }
        }

        private void checkBoxTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrayIcon.Checked)
            {
                notifyIconTray.Visible = false;
            }
            else
            {
                notifyIconTray.Visible = true;
            }
        }
    }
}
