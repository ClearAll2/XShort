﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace XShort
{
    public partial class RunForm : Form
    {
        private int suggestNum = 4;
        private int resultNum = 15;
        private int index = 0;
        private int rel = 0;
        private int clipBttIndex = 0;
        private int colorClipIndex = 1;
        private List<String> dir = new List<String>();
        private List<Shortcut> Shortcuts;
        private List<String> blockList;
        private ImageList sImage = new ImageList();
        private Queue<ClipboardItem> cB = new Queue<ClipboardItem>();
        private TimeSuggestions suggestions = new TimeSuggestions();
        private List<String> timeSuggestions = new List<string>();
        private string dataPath;
        private string suggestPath;
        private bool ggSearch = true;
        private bool csen = false;
        private bool ss = false;
        private bool sr = false;
        private bool er = false;
        private bool ui = false;
        private bool cb = false;
        private bool eu = false;
        private bool en = false;
        private bool sn = true;
        private string text = String.Empty;
        private string text1, part = String.Empty;
        private string lastcalled = String.Empty;
        private BackgroundWorker bw;
        private int originalSize;
        private List<String> indexData = new List<string>();
        private readonly BackgroundWordFilter _filter;
        private readonly BackgroundWordFilter _getdir;
        private List<String> matches = new List<string>();
        public bool loaded = false;
        public RunForm(List<Shortcut> shortcuts, List<string> blocklist, bool _gg, bool _csen, bool _ss, bool _sr, bool _er, int maxss, int maxrs, bool _ui, bool _cb, bool _eu, bool _en, bool _sn = true)
        {
            InitializeComponent();
            if (maxss >= 2 && maxss <= 8)
                suggestNum = maxss;
            else
                suggestNum = 4;
            if (suggestNum > 6)
            {
                sImage.Images.Clear();
                sImage.ColorDepth = ColorDepth.Depth32Bit;
                sImage.ImageSize = new Size(20, 20);
            }
            else
            {
                if (sImage.ImageSize.Height != 30)
                {
                    sImage.Images.Clear();
                    sImage.ColorDepth = ColorDepth.Depth32Bit;
                    sImage.ImageSize = new Size(30, 30);
                }
            }
            resultNum = maxrs;
            ggSearch = _gg;
            csen = _csen;
            sr = _sr;
            er = _er;
            ss = _ss;
            ui = _ui;
            cb = _cb;
            eu = _eu;
            en = _en;
            sn = _sn;

            Shortcuts = new List<Shortcut>(shortcuts);
            blockList = new List<string>(blocklist);
            dataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "XShort");
            suggestPath = Path.Combine(dataPath, "Suggestions Data");
            System.IO.Directory.CreateDirectory(suggestPath);
            comboBoxRun.DropDownHeight = comboBoxRun.Font.Height * 5;
            originalSize = this.Height;

            comboBoxRun.Focus();
            comboBoxRun.SelectAll();

            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerAsync();
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;

            if (ui)//reduce memory usage if not used
            {
                _filter = new BackgroundWordFilter
                (
                    items: indexData,
                    maxItemsToMatch: resultNum,
                    callback: results => this.Invoke(new Action(() =>
                    {
                        matches.Clear();
                        matches = results;
                    })),
                    imageList: imageResults => this.Invoke(new Action(() =>
                    {
                        imageList1.Images.Clear();
                        imageList1 = imageResults;
                    }))
                );
            }
            _getdir = new BackgroundWordFilter
            (
                callback: results => this.Invoke(new Action(() =>
                {
                    dir.Clear();
                    dir = results;
                })),
                imageList: imageResults => this.Invoke(new Action(() =>
                {
                    imageList2.Images.Clear();
                    imageList2 = imageResults;
                }))
            );
        }


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadSuggestions();
            MaintainSuggestions();
            comboBoxRun.Enabled = true;
            loaded = true;
        }

        private void LoadIcon()
        {
            sImage.Images.Clear();
            for (int i = 0; i < Shortcuts.Count; i++)
            {
                try
                {
                    sImage.Images.Add(Icon.ExtractAssociatedIcon(Shortcuts[i].Path));
                }
                catch
                {
                    if (Shortcuts[i].Path.Contains("http"))
                        sImage.Images.Add(Properties.Resources.internet);
                    else if (Shortcuts[i].Path.Contains("\\"))
                    {
                        if (Directory.Exists(Shortcuts[i].Path))
                            sImage.Images.Add(Properties.Resources.dir);
                        else
                            sImage.Images.Add(Properties.Resources.error);
                    }
                    else
                    {
                        sImage.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                    }

                }
                
            }
        }

        //private void LoadIcon(ImageList imageList, List<String> path)
        //{
        //    imageList.Images.Clear();
        //    for (int i = 0; i < path.Count; i++)
        //    {
        //        try
        //        {
        //            imageList.Images.Add(Icon.ExtractAssociatedIcon(path[i]));
        //        }
        //        catch
        //        {
        //            if (path[i].Contains("http"))
        //                imageList.Images.Add(Properties.Resources.internet);
        //            else if (path[i].Contains("\\"))
        //            {
        //                if (Directory.Exists(path[i]))
        //                    imageList.Images.Add(Properties.Resources.dir);
        //                else
        //                    imageList.Images.Add(Properties.Resources.error);
        //            }
        //            else
        //            {
        //                imageList.Images.Add(Properties.Resources.question_help_mark_balloon_512);
        //            }

        //        }
        //    }
        //}

        /// <summary>
        /// Check and remove invalid shortcuts from suggestions
        /// </summary>
        private void MaintainSuggestions()
        {
            for (int i = 0; i < suggestions.Time[DateTime.Now.Hour].List.Count; i++)
            {
                if (Shortcuts.FindIndex(f => f.Name == suggestions.Time[DateTime.Now.Hour].List[i].Loc) < 0 && ! SysCommand.sysCmd.Contains(suggestions.Time[DateTime.Now.Hour].List[i].Loc))
                    suggestions.Time[DateTime.Now.Hour].List.RemoveAt(i);
            }
            LoadIcon();
            ReloadSuggestions();
        }

        private void CheckClipboard()
        {
            if (cb)
            {
                try
                {
                    if (Clipboard.ContainsText())
                    {
                        string text = Clipboard.GetText();
                        if (cB.ToList().FindIndex(f => f.Text == text) < 0)
                        {
                            AddNewClipboardItem(text);
                            if (eu)
                            {
                                List<String> linkify = Linkify(text);
                                if (linkify.Count > 0)
                                {
                                    for (int i = 0; i < linkify.Count; i++)
                                    {
                                        if (cB.ToList().FindIndex(f => f.Text == linkify[i]) < 0)
                                        {
                                            AddNewClipboardItem(linkify[i]);
                                        }
                                    }
                                }
                            }
                            if (en)
                            {
                                List<int> textify = Textify(text);
                                if (textify.Count > 0)
                                {
                                    for (int i = 0; i < textify.Count; i++)
                                    {
                                        if (cB.ToList().FindIndex(f => f.Text == textify[i].ToString()) < 0)
                                        {
                                            AddNewClipboardItem(textify[i].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                { }
            }
        }

        private List<int> Textify(string text)
        {
            List<int> ret = new List<int>();
            var linkParser = new Regex(@"(\d)+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(text))
            {
                if (Int32.TryParse(m.Value, out int tmp))
                    ret.Add(tmp);
            }
            return ret;
        }

        private List<String> Linkify(string text)
        {
            List<String> ret = new List<string>();
            var linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (Match m in linkParser.Matches(text))
            {
                ret.Add(m.Value);
            }
            return ret;
        }

        private Color DifferentColorItem(int value)
        {
            switch(value)
            {
                case 1:
                    return SystemColors.InactiveBorder;
                case 2:
                    return SystemColors.Info;
                case 3:
                    return SystemColors.GradientInactiveCaption;
                default:
                    return Color.White;
            }
        }

        private void AddNewClipboardItem(string text)
        {
            int clipBttWidth = 1 + (panelClipboard.Width - 1) / 6;
            Button clipBtt = new Button
            {
                ForeColor = Color.Black,
                BackColor = DifferentColorItem(colorClipIndex),
                FlatStyle = FlatStyle.Flat
            };
            clipBtt.Left = clipBttIndex * clipBttWidth;
            clipBtt.FlatAppearance.BorderSize = 0;
            clipBtt.FlatAppearance.BorderColor = SystemColors.ControlDark;
            clipBtt.Tag = text;
            clipBtt.Text = text;
            clipBtt.AutoEllipsis = true;
            clipBtt.TabStop = false;
            clipBtt.Height = panelClipboard.Height;
            clipBtt.Width = clipBttWidth;
            clipBtt.Click += ClipBtt_Click;
            panelClipboard.Controls.Add(clipBtt);
            if (clipBttIndex < 6)
                clipBttIndex++;
            var item = new ClipboardItem
            {
                Text = text,
                Item = clipBtt
            };
            if (cB.Count >= 6)//remove the first if any new value
            {
                var top = cB.Dequeue();
                panelClipboard.Controls.Remove(top.Item);
                top.Item.Dispose();
            }
            cB.Enqueue(item);//add new value to bottom
            for ( int i = 0; i < cB.Count; i++)
            {
                cB.ElementAt(i).Item.Left = i * clipBttWidth;//move all item forward
            }
            //calculate for color
            if (colorClipIndex > 3)
                colorClipIndex = 1;
            else
                colorClipIndex++;
        }

        private void ClipBtt_Click(object sender, EventArgs e)
        {
            Button btt = (Button)sender;
            Clipboard.SetText(btt.Text);
            this.Hide();
        }

        private void timerSuggestions_Tick(object sender, EventArgs e)
        {
            SaveAndMaintainSuggestions();
        }

        public void SaveAndMaintainSuggestions()
        {
            SaveSuggestions();
            MaintainSuggestions();
        }

        /// <summary>
        /// Build shortcut suggestions from their last time, next called and order
        /// </summary>
        public void ReloadSuggestions()
        {
            if (ss)
            {
                List<String> addedSuggestions = new List<string>();
                rel = 0;
                foreach (Control c in panelSuggestions.Controls)
                {
                    c.Dispose();
                }
                panelSuggestions.Controls.Clear();
                timeSuggestions.Clear();
                for (int i = 0; i < suggestions.Time[DateTime.Now.Hour].List.Count; i++)//time-based suggestions
                {
                    if ((DateTime.Now - suggestions.Time[DateTime.Now.Hour].List[i].Lasttime).TotalDays <= 7)//stop showing items that haven't been called over 7 days
                        if (!blockList.Contains(suggestions.Time[DateTime.Now.Hour].List[i].Loc))//if it's not in blocklist
                            timeSuggestions.Add(suggestions.Time[DateTime.Now.Hour].List[i].Loc);
                }

                if (timeSuggestions.Count > 0)
                {
                    for (int i = 0; i < timeSuggestions.Count; i++)
                    {
                        if (!addedSuggestions.Contains(timeSuggestions[i]))
                        {
                            AddNewSuggestionsItems(timeSuggestions[i], Shortcuts.FindIndex(f => f.Name == timeSuggestions[i]) >= 0);
                            addedSuggestions.Add(timeSuggestions[i]);
                        }
                        if (rel >= suggestNum)
                            break;
                    }
                    
                }
                
                if (rel < suggestNum)
                {
                    int remain = suggestNum - rel;
                    if (suggestions.Time[DateTime.Now.Hour].List.Count >= remain)
                    {
                        for (int i = 0; i < suggestions.Time[DateTime.Now.Hour].List.Count; i++)
                        {
                            if (!addedSuggestions.Contains(suggestions.Time[DateTime.Now.Hour].List[i].Loc))//prevent duplicate 
                            {
                                if ((DateTime.Now - suggestions.Time[DateTime.Now.Hour].List[i].Lasttime).TotalDays <= 7)
                                {
                                    if (!blockList.Contains(suggestions.Time[DateTime.Now.Hour].List[i].Loc))//if it's not in blocklist
                                    {
                                        AddNewSuggestionsItems(suggestions.Time[DateTime.Now.Hour].List[i].Loc, Shortcuts.FindIndex(f => f.Name == suggestions.Time[DateTime.Now.Hour].List[i].Loc) >= 0);
                                        addedSuggestions.Add(suggestions.Time[DateTime.Now.Hour].List[i].Loc);
                                        if (remain > 0)
                                            remain -= 1;
                                        else
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    if (DateTime.Now.Hour < 23)
                    {
                        if (suggestions.Time[DateTime.Now.Hour + 1].List.Count >= remain)
                        {
                            for (int i = 0; i < suggestions.Time[DateTime.Now.Hour + 1].List.Count; i++)
                            {
                                if (!addedSuggestions.Contains(suggestions.Time[DateTime.Now.Hour + 1].List[i].Loc))//prevent duplicate 
                                {
                                    if (!blockList.Contains(suggestions.Time[DateTime.Now.Hour + 1].List[i].Loc))//if it's not in blocklist
                                    {
                                        AddNewSuggestionsItems(suggestions.Time[DateTime.Now.Hour + 1].List[i].Loc, Shortcuts.FindIndex(f => f.Name == suggestions.Time[DateTime.Now.Hour + 1].List[i].Loc) >= 0);
                                        addedSuggestions.Add(suggestions.Time[DateTime.Now.Hour + 1].List[i].Loc);
                                        if (remain > 0)
                                            remain -= 1;
                                        else
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    if (DateTime.Now.Hour > 0)
                    {
                        if (suggestions.Time[DateTime.Now.Hour - 1].List.Count >= remain)
                        {
                            for (int i = 0; i < suggestions.Time[DateTime.Now.Hour - 1].List.Count; i++)
                            {
                                if (!addedSuggestions.Contains(suggestions.Time[DateTime.Now.Hour - 1].List[i].Loc))//prevent duplicate 
                                {
                                    if (!blockList.Contains(suggestions.Time[DateTime.Now.Hour - 1].List[i].Loc))//if it's not in blocklist
                                    {
                                        AddNewSuggestionsItems(suggestions.Time[DateTime.Now.Hour - 1].List[i].Loc, Shortcuts.FindIndex(f => f.Name == suggestions.Time[DateTime.Now.Hour - 1].List[i].Loc) >= 0);
                                        addedSuggestions.Add(suggestions.Time[DateTime.Now.Hour - 1].List[i].Loc);
                                        if (remain > 0)
                                            remain -= 1;
                                        else
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            CheckClipboard();
        }

        /// <summary>
        /// Check if a shortcut is in suggestions list
        /// </summary>
        /// <param name="loc">suggestion loc</param>
        /// <returns></returns>
        private int CheckExistSuggestion(string loc)
        {
            for (int i = 0; i < suggestions.Time[DateTime.Now.Hour].List.Count; i++)
            {
                if (loc.Equals(suggestions.Time[DateTime.Now.Hour].List[i].Loc))
                {
                    return i;
                }
            }
            return -1;
        }


        /// <summary>
        /// Load suggestions list from file
        /// </summary>
        private void LoadSuggestions()
        {
            if (Directory.Exists(suggestPath))
            {
                for (int i = 0; i < suggestions.Time.Count; i++)
                {
                    if (File.Exists(Path.Combine(suggestPath, i.ToString())))
                    {
                        FileStream fs = new FileStream(Path.Combine(suggestPath, i.ToString()), FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        while (!sr.EndOfStream)
                        {
                            string read = sr.ReadLine();
                            string[] cut = read.Split('|');
                            suggestions.Time[i].List.Add(new Suggestions(cut[0], Int32.Parse(cut[1]), DateTime.Parse(cut[2])));
                        }
                        sr.Close();
                        fs.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Create new suggestions button on the Run box
        /// </summary>
        /// <param name="text">Display text</param>
        /// <param name="useImageList">Use built-in image list?</param>
        private void AddNewSuggestionsItems(string text, bool useImageList)
        {
            int recentWidth = 1 + (panelSuggestions.Width - 1) / suggestNum;//https://stackoverflow.com/questions/15100685/what-is-the-right-way-to-round-dividing-to-integers
            Button newsuggestion = new Button
            {
                ForeColor = SystemColors.ControlDarkDark,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            newsuggestion.FlatAppearance.BorderSize = 0;
            newsuggestion.FlatAppearance.BorderColor = Color.White;
            newsuggestion.Tag = text;
            newsuggestion.Font = new Font(newsuggestion.Font.FontFamily, 9);
            if (useImageList)
            {
                newsuggestion.ImageList = sImage;
                newsuggestion.ImageIndex = Shortcuts.FindIndex(f => f.Name == text);
                toolTip1.SetToolTip(newsuggestion, Shortcuts[newsuggestion.ImageIndex].Path);
                if (suggestNum > 6)
                    newsuggestion.Font = new Font(newsuggestion.Font.FontFamily, 7);
            }
            else
            {
                Size size = new Size(30, 30);
                if (suggestNum > 6)
                {
                    size.Height = 20;
                    size.Width = 20;
                    newsuggestion.Font = new Font(newsuggestion.Font.FontFamily, 7);
                }
                Image icon = new Bitmap(Properties.Resources.terminal, size);
                newsuggestion.Image = icon;
                toolTip1.SetToolTip(newsuggestion, text);
            }
            newsuggestion.AutoEllipsis = true;
            newsuggestion.Left = rel * recentWidth;
            if (sn)
                newsuggestion.Text = text;
            newsuggestion.TabStop = false;
            newsuggestion.ContextMenuStrip = contextMenuStrip1;
            newsuggestion.TextImageRelation = TextImageRelation.ImageBeforeText;
            newsuggestion.Width = recentWidth;
            newsuggestion.Height = panelSuggestions.Height;
            newsuggestion.Click += Newsuggestion_Click;
            newsuggestion.MouseDown += Newsuggestion_MouseDown;
            panelSuggestions.Controls.Add(newsuggestion);
            rel += 1;
        }

        /// <summary>
        /// Create new suggestions button on the Run box
        /// </summary>
        /// <param name="text">Display text</param>
        /// <param name="imageList">Image list</param>
        /// <param name="imageIndex">Image index</param>
        /// <param name="toolTip">Tooltip</param>
        private void AddNewSuggestionsItems(string text, ImageList imageList, int imageIndex, string toolTip)
        {
            int recentWidth = 1 + (panelSuggestions.Width - 1) / suggestNum;//https://stackoverflow.com/questions/15100685/what-is-the-right-way-to-round-dividing-to-integers
            Button newsuggestion = new Button
            {
                ForeColor = SystemColors.ControlDarkDark,
                BackColor = System.Drawing.Color.Transparent,
                FlatStyle = FlatStyle.Flat
            };
            newsuggestion.FlatAppearance.BorderSize = 0;
            newsuggestion.FlatAppearance.BorderColor = Color.White;
           
            newsuggestion.ImageList = imageList;
            newsuggestion.ImageIndex = imageIndex;
            toolTip1.SetToolTip(newsuggestion, toolTip);
            newsuggestion.AutoEllipsis = true;
            newsuggestion.Left = rel * recentWidth;
            newsuggestion.Tag = text;
            if (sn)
                newsuggestion.Text = text;
            newsuggestion.TabStop = false;
            newsuggestion.ContextMenuStrip = contextMenuStrip1;
            newsuggestion.TextImageRelation = TextImageRelation.ImageBeforeText;
            newsuggestion.Width = recentWidth;
            newsuggestion.Height = panelSuggestions.Height;
            newsuggestion.Click += Newsuggestion_Click;
            newsuggestion.MouseDown += Newsuggestion_MouseDown;
            panelSuggestions.Controls.Add(newsuggestion);
            rel += 1;
        }

        /// <summary>
        /// Action of middle mouse button
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Mouse</param>
        private void Newsuggestion_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            string location = toolTip1.GetToolTip(button);
            if (e.Button == MouseButtons.Middle)
            {
                try
                {
                    string argument = "/select, \"" + location + "\"";
                    Process.Start("explorer.exe", argument);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Newsuggestion_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SimpleRun(button.Tag.ToString(), Shortcuts.FindIndex(f => f.Name == button.Tag.ToString()) >= 0);
            comboBoxRun.Text = String.Empty;
            ReloadSuggestions();
        }

        /// <summary>
        /// Sort suggestions list
        /// </summary>
        private void SortSuggestions()
        {
            if (suggestions.Time[DateTime.Now.Hour].List.Count > 1)
            {
                for (int i = 0; i < suggestions.Time[DateTime.Now.Hour].List.Count - 1; i++)//sort by number for all items first
                {
                    for (int j = i + 1; j < suggestions.Time[DateTime.Now.Hour].List.Count; j++)
                    {
                        if (suggestions.Time[DateTime.Now.Hour].List[i].Amount < suggestions.Time[DateTime.Now.Hour].List[j].Amount)
                        {
                            (suggestions.Time[DateTime.Now.Hour].List[j], suggestions.Time[DateTime.Now.Hour].List[i]) = (suggestions.Time[DateTime.Now.Hour].List[i], suggestions.Time[DateTime.Now.Hour].List[j]);
                        }
                        else if (suggestions.Time[DateTime.Now.Hour].List[i].Amount == suggestions.Time[DateTime.Now.Hour].List[j].Amount)
                        {
                            if (suggestions.Time[DateTime.Now.Hour].List[i].Lasttime.CompareTo(suggestions.Time[DateTime.Now.Hour].List[j].Lasttime) < 0)
                            {
                                (suggestions.Time[DateTime.Now.Hour].List[j], suggestions.Time[DateTime.Now.Hour].List[i]) = (suggestions.Time[DateTime.Now.Hour].List[i], suggestions.Time[DateTime.Now.Hour].List[j]);
                            }
                        }
                    }
                }
                if (suggestions.Time[DateTime.Now.Hour].List.Count >= 5)//fix recent < 5
                {
                    for (int i = 0; i < 4; i++)//sort by time for 5 first items
                    {
                        for (int j = i + 1; j < 5; j++)
                        {
                            if (suggestions.Time[DateTime.Now.Hour].List[i].Lasttime.CompareTo(suggestions.Time[DateTime.Now.Hour].List[j].Lasttime) < 0)
                            {
                                (suggestions.Time[DateTime.Now.Hour].List[j], suggestions.Time[DateTime.Now.Hour].List[i]) = (suggestions.Time[DateTime.Now.Hour].List[i], suggestions.Time[DateTime.Now.Hour].List[j]);
                            }
                        }
                    }
                }
            }
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Update next called shortcut suggestions
        /// </summary>
        /// <param name="name">Shortcut name</param>
        private void UpdateSuggestions(string name)
        {
            if (suggestions.Time[DateTime.Now.Hour].List.Count > 0)
            {
                int position = CheckExistSuggestion(name);
                if (position != -1)
                {
                    suggestions.Time[DateTime.Now.Hour].List[position].Amount += 1;
                    suggestions.Time[DateTime.Now.Hour].List[position].Lasttime = DateTime.Now;
                }
                else
                {
                    suggestions.Time[DateTime.Now.Hour].List.Add(new Suggestions(name, 1, DateTime.Now));
                }
            }
            else
            {
                suggestions.Time[DateTime.Now.Hour].List.Add(new Suggestions(name, 1, DateTime.Now));
            }
            SortSuggestions();
        }

        private void SimpleRun(string s, bool isInList)
        {
            if (isInList)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (s == Shortcuts[i].Name)
                    {
                        try
                        {
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                Process.Start(Shortcuts[i].Path, Shortcuts[i].Para);
                            else
                                Process.Start(Shortcuts[i].Path);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);
                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            else
            {
                if (SysCommand.sysCmd.Contains(s))
                {
                    try
                    {
                        this.Hide();
                        ProcessStartInfo proc = new ProcessStartInfo();
                        proc.FileName = "C:\\Windows\\System32\\cmd.exe";
                        proc.WorkingDirectory = Path.GetDirectoryName("C:\\Windows\\System32\\cmd.exe");
                        proc.Arguments = "/c " + s;
                        Process.Start(proc);

                        //for suggestions
                        UpdateSuggestions(s);
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }


        public int LoadData()
        {
            //comboBoxRun.Items.Clear();
            //Shortcuts.Clear();
            //int i = 0;
            //FileStream fs;
            //StreamReader sr;
            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data1.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return 0;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcut shortcut = new Shortcut
            //    {
            //        Name = StringCipher.Decrypt(sr.ReadLine(), pass)
            //    };
            //    Shortcuts.Add(shortcut);
            //}
            //fs.Close();
            //sr.Close();


            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data2.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return -1;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcuts[i].Path = StringCipher.Decrypt(sr.ReadLine(), pass);
            //    i++;
            //}
            //fs.Close();
            //sr.Close();

            //i = 0;
            //try
            //{
            //    fs = new FileStream(Path.Combine(dataPath, "data3.data"), FileMode.Open, FileAccess.Read);
            //}
            //catch
            //{
            //    return -1;
            //}
            //sr = new StreamReader(fs);
            //while (!sr.EndOfStream)
            //{
            //    Shortcuts[i].Para = StringCipher.Decrypt(sr.ReadLine(), pass);
            //    i++;
            //}
            //fs.Close();
            //sr.Close();

            LoadIcon();
            LoadBlocklist();

            for (int j = 0; j < Shortcuts.Count; j++)
            {
                comboBoxRun.Items.Add(Shortcuts[j].Name);
            }
            LoadIndex();
            
            return 1;

        }

        public void LoadIndex()
        {
            indexData.Clear();
            FileStream fs;
            StreamReader sr;
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "folders"), FileMode.Open, FileAccess.Read);

            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                indexData.Add(sr.ReadLine());
            }
            fs.Close();
            sr.Close();

            try
            {
                fs = new FileStream(Path.Combine(dataPath, "files"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                indexData.Add(sr.ReadLine());
            }
            fs.Close();
            sr.Close();

        }

        public void LoadBlocklist()
        {
            FileStream fs;
            StreamReader sr;
            blockList.Clear();
            try
            {
                fs = new FileStream(Path.Combine(dataPath, "blocklist"), FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }
            sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine();
                if (Shortcuts.FindIndex(f => f.Name == read) >= 0 || SysCommand.sysCmd.Contains(read))//check if it's not an invalid shortcut
                    blockList.Add(read);
            }
            fs.Close();
            sr.Close();
        }

        private void Run(string tmp, bool runas)
        {
            if (comboBoxRun.Text == String.Empty) //do nothing if comboBox is empty
                return;
            if (SysCommand.sysCmd.Contains(tmp))
            {
                this.Hide();
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = "C:\\Windows\\System32\\cmd.exe";
                proc.WorkingDirectory = Path.GetDirectoryName("C:\\Windows\\System32\\cmd.exe");
                proc.Arguments = "/c " + tmp;
                if (runas)
                    proc.Verb = "runas";
                Process.Start(proc);
                //for suggestions
                UpdateSuggestions(tmp);

                return;
            }
            if (tmp.Contains("!") != true)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (tmp == Shortcuts[i].Name || tmp.ToLower() == Shortcuts[i].Name.ToLower() && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(tmp) || Shortcuts[i].Name.ToLower().Contains(tmp.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);
                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);


                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Path.Contains(tmp) || Shortcuts[i].Path.ToLower().Contains(tmp.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "None" && Shortcuts[i].Para != "Not Available")
                                proc.Arguments = Shortcuts[i].Para;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);


                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            else //if contain !
            {
                string[] pieces = tmp.Split('!');
                string tmp2 = pieces[0].Trim(' ');
                string tmp3 = pieces[1].Trim(' ');

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (tmp2 == Shortcuts[i].Name || tmp2.ToLower() == Shortcuts[i].Name.ToLower() && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                            return;
                        }
                        catch
                        {
                            return;
                        }
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(tmp2) || Shortcuts[i].Name.ToLower().Contains(tmp2.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);

                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }

                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Path.Contains(tmp2) || Shortcuts[i].Path.ToLower().Contains(tmp2.ToLower()) && !csen)
                    {
                        try
                        {
                            this.Hide();
                            ProcessStartInfo proc = new ProcessStartInfo();
                            proc.FileName = Shortcuts[i].Path;
                            proc.WorkingDirectory = Path.GetDirectoryName(Shortcuts[i].Path);
                            if (Shortcuts[i].Para != "Not Available")
                                proc.Arguments = tmp3;
                            if (runas)
                                proc.Verb = "runas";
                            Process.Start(proc);
                            //for suggestions
                            UpdateSuggestions(Shortcuts[i].Name);

                        }
                        catch
                        {
                            return;
                        }
                        return;
                    }
                }
            }
            if (tmp.Contains("\\"))
            {
                try
                {
                    this.Hide();
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = tmp;
                    proc.WorkingDirectory = Path.GetDirectoryName(tmp);
                    if (runas)
                        proc.Verb = "runas";
                    Process.Start(proc);
                    return;
                }
                catch
                {
                    ///
                }

            }
            //deprecated
            //if (tmp.Contains(">"))
            //{
            //    string[] cut = tmp.Split('>');
            //    this.Hide();
            //    if (cut[1] != String.Empty)
            //        TranslateText(cut[0], cut[1]);
            //    else
            //        TranslateText(cut[0], "en|vi");
            //    return;
            //}
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (reg.IsMatch(tmp))
            {
                //tmp = "http://" + tmp;
                try
                {
                    this.Hide();
                    Process.Start(tmp);
                    return;
                }
                catch
                {
                    ///
                }
            }
            if (ggSearch == true)
            {

                try
                {
                    this.Hide();
                    Process.Start("https://www.google.com/search?q=" + tmp);
                    return;

                }
                catch
                {
                    //
                }

            }
            MessageBox.Show("Unavailable shortcut name!?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //
        /// <summary>
        /// Deprecated
        /// </summary>
        /// <param name="input"></param>
        /// <param name="languagePair"></param>
        public void TranslateText(string input, string languagePair)
        {
            string url = String.Format("http://www.google.com/translate_t?hl=en&ie=UTF8&text={0}&langpair={1}", input, languagePair);
            Process.Start(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(false);
            tbw.RunWorkerCompleted += Tbw_RunWorkerCompleted;
        }

        private void Tbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listViewResult.Items.Clear();
            if (this.Height > listViewResult.Height)
                this.Height -= panelSuggestions.Bottom;
            ReloadSuggestions();
        }

        private void Tbw_DoWork(object sender, DoWorkEventArgs e)
        {
            bool runas = (bool)e.Argument;
            string dfl = comboBoxRun.Text;
            if (dfl.Contains("#"))
                dfl = dfl.Trim('#');//remove first # character
            if (dfl.Contains("+"))
            {
                string[] piece = dfl.Split('+');
                foreach (string s in piece)
                {
                    Run(s.Trim(), runas);
                }
            }
            else if (dfl.Contains("!") && dfl.Contains("\\") != true)
            {

                string[] pieces = dfl.Split('!');
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (pieces[1].Trim() == Shortcuts[i].Name)
                    {
                        Run(pieces[0] + "!" + Shortcuts[i].Path, runas);
                        comboBoxRun.Text = String.Empty;
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (Shortcuts[i].Name.Contains(pieces[1].Trim()))
                    {
                        Run(pieces[0] + "!" + Shortcuts[i].Path, runas);
                        comboBoxRun.Text = String.Empty;
                        return;
                    }
                }
                Run(dfl, runas);
                comboBoxRun.Text = String.Empty;
                return;
            }

            else
                Run(dfl, runas);
            comboBoxRun.Text = String.Empty;
        }

        private void SaveSuggestions()
        {
            for (int i = 0; i < suggestions.Time.Count; i++)
            {
                if (suggestions.Time[i].List.Count > 0)
                {
                    string path = Path.Combine(suggestPath, i.ToString());
                    System.IO.File.WriteAllText(path, String.Empty);
                    for (int j = 0; j < suggestions.Time[i].List.Count; j++)
                    {
                        string newline = String.Join("", suggestions.Time[i].List[j].Loc, "|", suggestions.Time[i].List[j].Amount, "|", suggestions.Time[i].List[j].Lasttime.ToString("F", new CultureInfo("en")), Environment.NewLine);
                        System.IO.File.AppendAllText(path, newline);
                    }
                    Thread.Sleep(1);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            comboBoxRun.Focus();
            comboBoxRun.SelectAll();
            CheckClipboard();
        }

        private void comboBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                if (text.Contains("#"))
                {
                    for (int i = index + 1; i <SysCommand.sysCmd.Count(); i++)
                    {
                        if (SysCommand.sysCmd[i].Contains(part) || SysCommand.sysCmd[i].ToLower().Contains(part.ToLower()) && !csen)
                        {

                            comboBoxRun.Text = text1 + SysCommand.sysCmd[i];
                            index = i;
                            //select text which not belong to "text"
                            comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                            comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                            return;

                        }
                    }

                    //reset if not 
                    comboBoxRun.Text = text;
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                    comboBoxRun.SelectionLength = 0;
                    index = -1; //-1 for index + 1 = 0 //fucking nice
                }
                if (text.Contains("\\") != true) //if not contain \
                {
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(text) || Shortcuts[i].Name.ToLower().Contains(text.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        for (int i = index + 1; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                index = i;
                                comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                comboBoxRun.SelectionLength = 0;

                                return;
                            }
                        }

                        //reset if not 
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    
                }
                else if (text.Contains("\\"))
                {
                    
                    if (text.Contains("+") != true && text.Contains("!") != true) //if not contain , and !
                    {
                        for (int i = index + 1; i < dir.Count; i++)
                        {
                            if (dir[i].Contains(text) || dir[i].ToLower().Contains(text.ToLower()) && !csen)
                            {
                                comboBoxRun.Text = dir[i];
                                index = i;
                                //select text which not belong to "text"
                                comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(text) + text.Length; //index of "text" + length => position to start selection
                                comboBoxRun.SelectionLength = comboBoxRun.Text.Length - text.Length; //length = length of combobox text - length of "text"
                                return;
                            }
                        }
                        //reset if not
                        comboBoxRun.Text = text;
                        comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                        comboBoxRun.SelectionLength = 0;
                        index = -1; //-1 for index + 1 = 0 //fucking nice
                    }
                    else if (text.Contains("+") == true && text.Contains("!") != true)
                    {
                        if (part.Contains("\\") )
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part) || dir[i].ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < Shortcuts.Count; i++)
                            {
                                if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                    index = i;
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                    comboBoxRun.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                    }
                    else if (text.Contains("+") != true && text.Contains("!") == true)
                    {
                        if (part.Contains("\\"))
                        {
                            for (int i = index + 1; i < dir.Count; i++)
                            {
                                if (dir[i].Contains(part) || dir[i].ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + dir[i];
                                    index = i;
                                    //select text which not belong to "text"
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.IndexOf(part) + part.Length; //index of "text" + length => position to start selection
                                    comboBoxRun.SelectionLength = comboBoxRun.Text.Length - part.Length; //length = length of combobox text - length of "text"
                                    return;
                                }
                            }
                            //reset if not
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                        else //if not contain \ in part
                        {
                            for (int i = index + 1; i < Shortcuts.Count; i++)
                            {
                                if (Shortcuts[i].Name.Contains(part) || Shortcuts[i].Name.ToLower().Contains(part.ToLower()) && !csen)
                                {
                                    comboBoxRun.Text = text1 + " " + Shortcuts[i].Name;
                                    index = i;
                                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                                    comboBoxRun.SelectionLength = 0;
                                    return;
                                }
                            }

                            //reset if not 
                            comboBoxRun.Text = text;
                            comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
                            comboBoxRun.SelectionLength = 0;
                            index = -1; //-1 for index + 1 = 0 //fucking nice
                        }
                    }
                    
                }
            }

        }

        private string entry = String.Empty;
        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Tab)
            {
                if (comboBoxRun.Text.Contains("#"))
                {
                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("#") + 1); //from 0 to last index of ,
                    part = text.Substring(text.LastIndexOf("#") + 1); //from last index of ,
                    part = part.Trim();
                    index = -1;                    
                }
                if (comboBoxRun.Text.Contains("+") != true && comboBoxRun.Text.Contains("!") != true)
                {
                    text = comboBoxRun.Text;
                    index = -1;
                }
                else if (comboBoxRun.Text.Contains("+") && comboBoxRun.Text.Contains("!") != true)
                {
                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("+") + 1); //from 0 to last index of ,
                    part = text.Substring(text.LastIndexOf("+") + 1); //from last index of ,
                    part = part.Trim();
                    index = -1;
                }
                else if (comboBoxRun.Text.Contains("+") != true && comboBoxRun.Text.Contains("!"))
                {
                    text = comboBoxRun.Text;
                    text1 = text.Substring(0, text.LastIndexOf("!") + 1); //from 0 to last index of !
                    part = text.Substring(text.LastIndexOf("!") + 1); //from last index of !
                    part = part.Trim();
                    index = -1;
                }
                ShowResult();
            }
            
            if (e.KeyCode == Keys.Left) //set pointer to end of text 
            {
                if (comboBoxRun.SelectionStart == 0)
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (ui)
                _filter.SetCurrentEntry(comboBoxRun.Text);
            _getdir.SetCurrentEntry(comboBoxRun.Text);
            if (comboBoxRun.Text.Length == 0)
            {
                if (this.Height > listViewResult.Height)
                    this.Height = originalSize;
                imageList1.Images.Clear();
                imageList2.Images.Clear();
                ReloadSuggestions();
            }
        }

        private void ShowResult()
        {
            if (sr)
            {
                bool ifAny = false;
                string cut = comboBoxRun.Text;
                //set to default size before another search
                if (this.Height > listViewResult.Height)
                    this.Height = originalSize;

                if (cut.Contains("\\"))
                {
                    if (dir.Count > 0)
                    {
                        listViewResult.Items.Clear();
                        listViewResult.SmallImageList = imageList2;
                        for (int i = 0; i < dir.Count; i++)
                        {
                            string item = Path.GetFileNameWithoutExtension(dir[i]);
                            listViewResult.Items.Add(new ListViewItem(item.Substring(item.LastIndexOf("\\") + 1)));
                            listViewResult.Items[i].ImageIndex = i;
                            listViewResult.Items[i].ToolTipText = dir[i];
                        }
                        if (this.Height < listViewResult.Height && listViewResult.Items.Count > 0)
                            this.Height += listViewResult.Height + listViewResult.Height / 10;//fix cutting listview
                    }

                }
                else
                {
                    if (ui)
                    {
                        if (matches.Count > 0)
                        {
                            listViewResult.Items.Clear();
                            listViewResult.SmallImageList = imageList1;
                            for (int i = 0; i < matches.Count; i++)
                            {
                                string item = Path.GetFileNameWithoutExtension(matches[i]);
                                listViewResult.Items.Add(new ListViewItem(item.Substring(item.LastIndexOf("\\") + 1)));
                                listViewResult.Items[i].ImageIndex = i;
                                listViewResult.Items[i].ToolTipText = matches[i];
                            }
                            if (this.Height < listViewResult.Height && listViewResult.Items.Count > 0)
                                this.Height += listViewResult.Height + listViewResult.Height / 10;
                        }
                    }
                }
                //shortcut suggestions
                if (cut.Length > 0 && !cut.Contains("#"))
                {
                    if (cut.Contains("!"))
                        cut = cut.Substring(cut.LastIndexOf("!") + 1);
                    else if (comboBoxRun.Text.Contains("+"))
                        cut = cut.Substring(cut.LastIndexOf("+") + 1);
                    cut = cut.Trim();
                    if (cut != String.Empty)
                    {
                        for (int i = 0; i < Shortcuts.Count; i++)
                        {
                            if (Shortcuts[i].Name.Contains(cut) || Shortcuts[i].Name.ToLower().Contains(cut.ToLower()) && !csen)
                            {
                                if (!ifAny)//prevent reload when nothing match
                                {
                                    ifAny = true;
                                    panelSuggestions.Controls.Clear();
                                    rel = 0;
                                }
                                if (rel < suggestNum)
                                {
                                    if (!er || !blockList.Contains(Shortcuts[i].Name))
                                        AddNewSuggestionsItems(Shortcuts[i].Name, sImage, i, Shortcuts[i].Path);
                                }
                                else//break if no more space => reduce loop time
                                    break;

                            }
                        }
                        if (rel < suggestNum)//add syscmd to search
                        {
                            int remain = suggestNum - rel;
                            for (int i = 0; i < SysCommand.sysCmd.Length; i++)
                            {
                                if (SysCommand.sysCmd[i].Contains(cut) || SysCommand.sysCmd[i].ToLower().Contains(cut.ToLower()) && !csen)
                                {
                                    if (!ifAny)//prevent reload when nothing match
                                    {
                                        ifAny = true;
                                        panelSuggestions.Controls.Clear();
                                        rel = 0;
                                    }
                                    if (remain > 0)
                                    {
                                        AddNewSuggestionsItems(SysCommand.sysCmd[i], false);
                                        remain -= 1;
                                    }
                                    else//break if no more space => reduce loop time
                                        break;
                                }
                            }
                        }
                        if (rel == 0)
                            ReloadSuggestions();

                    }
                }
            }
        }

        private void searchDir(string _path)
        {
            dir.Clear();
            if (Directory.Exists(_path))
            {
                var fileArray = Directory.EnumerateFileSystemEntries(_path);
                IEnumerator<string> enumerator = fileArray.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (((File.GetAttributes(enumerator.Current) & FileAttributes.Hidden) != FileAttributes.Hidden))
                        dir.Add(enumerator.Current);
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //comboBox1.DroppedDown = true;
            if (/*e.KeyCode != Keys.Back && e.KeyCode != Keys.Space && e.KeyCode != Keys.Delete*/e.KeyValue == 220)
            {
                if (comboBoxRun.SelectionLength != 0)
                {
                    comboBoxRun.SelectionStart = comboBoxRun.Text.Length;


                }

            }
            if (e.KeyCode == Keys.ControlKey)
            {
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (comboBoxRun.Text == Shortcuts[i].Name)
                    {
                        comboBoxRun.Text = Shortcuts[i].Path;
                        comboBoxRun.SelectAll();
                        Clipboard.SetText(comboBoxRun.Text);
                        return;
                    }
                }
                for (int i = 0; i < Shortcuts.Count; i++)
                {
                    if (comboBoxRun.Text == Shortcuts[i].Path)
                    {
                        comboBoxRun.Text = Shortcuts[i].Name;
                        comboBoxRun.SelectAll();

                        return;
                    }
                }
            }

            if (e.KeyCode == Keys.Alt | e.KeyCode == Keys.Enter)
            {
                openAsAdministratorToolStripMenuItem_Click(null, null);
            }

            //_getdir.SetCurrentEntry(entry);
        }

        private void RunForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
            comboBoxRun.Text = String.Empty;
            
        }

        private void RunForm_Paint(object sender, PaintEventArgs e)
        {
            Form frm = (Form)sender;
            ControlPaint.DrawBorder(e.Graphics, frm.ClientRectangle,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid,
            Color.LightBlue, 1, ButtonBorderStyle.Solid);

        }

        private void panelSuggestions_Paint(object sender, PaintEventArgs e)
        {
            if (ss)
            {
                Panel frm = (Panel)sender;
                ControlPaint.DrawBorder(e.Graphics, frm.ClientRectangle,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 0, ButtonBorderStyle.Solid,
                Color.Red, 1, ButtonBorderStyle.Solid);
            }
        }

        private void listViewResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (comboBoxRun.Text.Contains("+") != true)
            {
                try
                {
                    ProcessStartInfo proc = new ProcessStartInfo();
                    proc.FileName = listViewResult.FocusedItem.ToolTipText;
                    Process.Start(proc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listViewResult_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                if (listViewResult.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    toolTip1.Show(listViewResult.FocusedItem.ToolTipText, comboBoxRun, 2000);
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = listViewResult.FocusedItem.ToolTipText;
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openAsAdministratorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = listViewResult.FocusedItem.ToolTipText;
                proc.Verb = "runas";
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string argument = "/select, \"" + listViewResult.FocusedItem.ToolTipText + "\"";
                Process.Start("explorer.exe", argument);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openAsAdministratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    if (sourceControl != comboBoxRun)
                    {
                        Button btt = (Button)sourceControl;
                        comboBoxRun.Text = btt.Text;
                    }

                }
            }

            BackgroundWorker tbw = new BackgroundWorker();
            tbw.DoWork += Tbw_DoWork;
            tbw.RunWorkerAsync(true);
            tbw.RunWorkerCompleted += Tbw_RunWorkerCompleted;
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowFileProperties(listViewResult.FocusedItem.ToolTipText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void buttonBackToParent_Click(object sender, EventArgs e)
        //{
        //    if (!comboBoxRun.Text.Contains("+") && comboBoxRun.Text.Contains("\\"))
        //    {
        //        string currentPath = comboBoxRun.Text;
        //        string parentPath = String.Empty;
        //        if (Path.GetExtension(currentPath) != null && Path.GetExtension(currentPath) != String.Empty)// if it's a file path
        //        {
        //            currentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //            parentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //        }
        //        else//it's a directory
        //        {
        //            if (currentPath.EndsWith("\\"))
        //                currentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //            parentPath = currentPath.Substring(0, currentPath.LastIndexOf("\\"));
        //        }
        //        comboBoxRun.Text = parentPath;
        //        searchDir(parentPath);
        //        ShowResult();
        //    }
        //}


        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }
        private const int SW_SHOW = 5;
        private const uint SEE_MASK_INVOKEIDLIST = 12;

      

        public static bool ShowFileProperties(string Filename)
        {
            SHELLEXECUTEINFO info = new SHELLEXECUTEINFO();
            info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
            info.lpVerb = "properties";
            info.lpFile = Filename;
            info.nShow = SW_SHOW;
            info.fMask = SEE_MASK_INVOKEIDLIST;
            return ShellExecuteEx(ref info);
        }

    }
}
