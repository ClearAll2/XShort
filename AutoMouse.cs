﻿using System;
using System.ComponentModel;
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
        
        private enum TrayAction : int
        {
            NOTHING = 0,
            AUTO_MOUSE = 1,
            AUTO_KEY = 2,
            OPEN_ANTI_IDOL = 3
        }

        public AutoMouse()
        {
            InitializeComponent();
            comboBoxKeys.DataSource = Enum.GetValues(typeof(SendInputWrapper.VirtualKeyShort));
            comboBoxLeftClickTray.DataSource = Enum.GetValues(typeof(TrayAction));
            comboBoxMidClickTray.DataSource = Enum.GetValues(typeof(TrayAction));
            comboBoxRighClickTray.DataSource = Enum.GetValues(typeof(TrayAction));
            
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
                    if (r.GetValue("AMITrayLA") != null)
                    {
                        comboBoxLeftClickTray.SelectedIndex = (int)r.GetValue("AMITrayLA");
                    }
                    if (r.GetValue("AMITrayMA") != null)
                    {
                        comboBoxMidClickTray.SelectedIndex = (int)r.GetValue("AMITrayMA");
                    }
                    if (r.GetValue("AMITrayRA") != null)
                    {
                        comboBoxRighClickTray.SelectedIndex = (int)r.GetValue("AMITrayRA");
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
                r.SetValue("AMITrayLA", comboBoxLeftClickTray.SelectedIndex);
                r.SetValue("AMITrayMA", comboBoxMidClickTray.SelectedIndex);
                r.SetValue("AMITrayRA", comboBoxRighClickTray.SelectedIndex);
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
                NotifyIconClick(comboBoxLeftClickTray.SelectedIndex);
            }
            else if (e.Button == MouseButtons.Right)
            {
                NotifyIconClick(comboBoxRighClickTray.SelectedIndex);
            }
            else
            {
                NotifyIconClick(comboBoxMidClickTray.SelectedIndex);
            }
        }

        private void NotifyIconClick(int index)
        {
            if (index == 1)
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
            else if (index == 2)
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
            else if (index == 3)
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
                numericUpDownIntervalMouse.Enabled = false;
            }
            else
            {
                timerAutoCursor.Stop();
                numericUpDownIntervalMouse.Enabled = true;
            }
            UpdateStatus();
        }

        private void checkBoxTrayIcon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTrayIcon.Checked)
            {
                notifyIconTray.Visible = false;
                comboBoxLeftClickTray.Enabled = false;
                comboBoxMidClickTray.Enabled = false;
                comboBoxRighClickTray.Enabled = false;
            }
            else
            {
                notifyIconTray.Visible = true;
                comboBoxLeftClickTray.Enabled = true;
                comboBoxMidClickTray.Enabled = true;
                comboBoxRighClickTray.Enabled = true;
            }
        }

        private void checkBoxSendKey_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSendKeyService.Checked)
            {
                timerAutoKey.Interval = 1000 * (int)numericUpDownIntervalKey.Value;
                timerAutoKey.Start();
                numericUpDownIntervalKey.Enabled = false;
            }
            else
            {
                timerAutoKey.Stop();
                numericUpDownIntervalKey.Enabled = true;
            }
            UpdateStatus();
        }

        private void timerAutoKey_Tick(object sender, EventArgs e)
        {
            SendKey(comboBoxKeys.SelectedValue.ToString());
        }

        private void UpdateStatus()
        {
            bool am = checkBoxMoveMouseService.Checked;
            bool ak = checkBoxSendKeyService.Checked;
            if (am && ak)
            {
                notifyIconTray.Icon = Properties.Resources.all_running;
                notifyIconTray.Text = "Anti Idol - All services are running";
            }
            else if (am && !ak)
            {
                notifyIconTray.Icon = Properties.Resources.mouse_only;
                notifyIconTray.Text = "Anti Idol - Auto Mouse service is running";
            }
            else if (!am && ak)
            {
                notifyIconTray.Icon = Properties.Resources.keyboard_only;
                notifyIconTray.Text = "Anti Idol - Auto Key service running";
            }
            else
            {
                notifyIconTray.Icon = Properties.Resources.all_ready;
                notifyIconTray.Text = "Idol/Idle";
            }
        }
    }
}
