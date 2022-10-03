using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMouseMover.WinHelper;
using AutoMouseMover.WinWrapper;

namespace XShort
{
    public partial class AutoMouse : Form
    {
        private bool exit = false;
        public AutoMouse()
        {
            InitializeComponent();
            BackgroundWorker moveCursor = new BackgroundWorker();
            moveCursor.DoWork += MoveCursor_DoWork;
            moveCursor.RunWorkerAsync();
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


        private void MoveCursor_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!exit)
            {
                if (checkBoxService.Checked)
                {
                    Thread.Sleep(2500);
                    MoveCursor(20);
                    Thread.Sleep(2500);
                    MoveCursor(-20);
                }
            }
        }

        public void CloseForm()
        {
            exit = true;
            this.Close();
        }

        private void AutoMouse_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    notifyIcon1.Icon = Properties.Resources.favicon1;
                }
                else
                {
                    checkBoxService.Checked = true;
                    notifyIcon1.Icon = Properties.Resources.favicon2;
                }
            }
        }
    }
}
