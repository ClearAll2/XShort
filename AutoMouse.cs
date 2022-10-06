using System;
using System.Windows.Forms;
using AutoMouseMover.WinHelper;
using AutoMouseMover.WinWrapper;
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
            comboBoxKeys.DataSource = Enum.GetValues(typeof(SendInputWrapper.VirtualKeyShort));
            using (RegistryKey r = Registry.CurrentUser.OpenSubKey("SOFTWARE\\ClearAll\\XShort\\AMI", true))
            {
                if (r != null)
                {
                    if (r.GetValue("AMI") != null)
                        numericUpDownIntervalMouse.Value = (int)r.GetValue("AMI");
                    if (r.GetValue("AMIK") != null)
                        numericUpDownIntervalKey.Value = (int)r.GetValue("AMIK");
                    if (r.GetValue("AMIO") != null)
                        numericUpDownOffset.Value = (int)r.GetValue("AMIO");
                    if (r.GetValue("AMITray") != null)
                        checkBoxTrayIcon.Checked = true;
                    if (r.GetValue("AMIKey") != null)
                    {
                        string key = r.GetValue("AMIKey").ToString();
                        Enum.TryParse<SendInputWrapper.VirtualKeyShort>(key, out SendInputWrapper.VirtualKeyShort vk);
                        comboBoxKeys.SelectedItem = vk;
                    }          
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

        private void SendKey(string k)
        {
            Enum.TryParse<SendInputWrapper.ScanCodeShort>(k, out SendInputWrapper.ScanCodeShort key);
            CursorHelper.SendKey(key);
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
                r.SetValue("AMI", (int)numericUpDownIntervalMouse.Value);
                r.SetValue("AMIK", (int)numericUpDownIntervalKey.Value);
                r.SetValue("AMIO", (int)numericUpDownOffset.Value);
                if (checkBoxTrayIcon.Checked)
                    r.SetValue("AMITray", true);
                else
                    r.DeleteValue("AMITray", false);
                r.SetValue("AMIKey", comboBoxKeys.SelectedValue.ToString());
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
                if (checkBoxMoveMouseService.Checked)
                {
                    checkBoxMoveMouseService.Checked = false;
                }
                else
                {
                    checkBoxMoveMouseService.Checked = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (checkBoxSendKeyService.Checked)
                {
                    checkBoxSendKeyService.Checked = false;
                }
                else
                {
                    checkBoxSendKeyService.Checked = true;
                }
            }
            else
            {
                this.Show();
            }
        }

        private void timerAutoCursor_Tick(object sender, EventArgs e)
        {
            MoveCursor(sign * (int)numericUpDownOffset.Value);
            sign = -sign;
        }

        private void checkBoxService_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMoveMouseService.Checked)
            {
                timerAutoCursor.Interval = 1000 * (int)numericUpDownIntervalMouse.Value;
                timerAutoCursor.Start();
                notifyIconTray.Icon = Properties.Resources.favicon2;
                notifyIconTray.Text = "AIS - On\nClick to turn off";
                numericUpDownIntervalMouse.Enabled = false;
            }
            else
            {
                timerAutoCursor.Stop();
                notifyIconTray.Icon = Properties.Resources.favicon1;
                notifyIconTray.Text = "AIS - Off\nClick to turn on";
                numericUpDownIntervalMouse.Enabled = true;
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

        private void checkBoxSendKey_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSendKeyService.Checked)
            {
                timerAutoKey.Interval = 1000 * (int)numericUpDownIntervalKey.Value;
                timerAutoKey.Start();
                comboBoxKeys.Enabled = false;
            }
            else
            {
                timerAutoKey.Stop();
                comboBoxKeys.Enabled = true;
            }
        }

        private void timerAutoKey_Tick(object sender, EventArgs e)
        {
            SendKey(comboBoxKeys.SelectedValue.ToString());
        }
    }
}
