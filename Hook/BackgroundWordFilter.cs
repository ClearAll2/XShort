﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace XShort
{
    public class BackgroundWordFilter : IDisposable
    {
        private readonly List<string> _items;
        private readonly AutoResetEvent _signal = new AutoResetEvent(false);
        private readonly Thread _workerThread;
        private readonly int _maxItemsToMatch;
        private readonly Action<List<string>> _callback;
        private readonly Action<ImageList> _imageList;

        private volatile bool _shouldRun = true;
        private volatile string _currentEntry = null;

        public BackgroundWordFilter(
            List<string> items,
            int maxItemsToMatch,
            Action<List<string>> callback, Action<ImageList> imageList)
        {
            _items = items;
            _callback = callback;
            _maxItemsToMatch = maxItemsToMatch;
            _imageList = imageList;

            // start the long-lived backgroud thread
            _workerThread = new Thread(WorkerLoop)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };

            _workerThread.Start();
        }

        public BackgroundWordFilter(Action<List<string>> callback, Action<ImageList> imageList)
        {
            _callback = callback;
            _imageList = imageList;
            _workerThread = new Thread(WorkerLoop2)
            {
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };

            _workerThread.Start();
        }

        public void SetCurrentEntry(string currentEntry)
        {
            // set the current entry and signal the worker thread
            _currentEntry = currentEntry;
            _signal.Set();
        }

        private void LoadIcon(ImageList imageList, string path)
        {
            try
            {
                imageList.Images.Add(Icon.ExtractAssociatedIcon(path));
            }
            catch
            {
                if (path.Contains("http"))
                    imageList.Images.Add(Properties.Resources.internet);
                else if (path.Contains("\\"))
                {
                    if (Directory.Exists(path))
                        imageList.Images.Add(Properties.Resources.dir);
                    else
                        imageList.Images.Add(Properties.Resources.error);
                }
                else
                {
                    imageList.Images.Add(Properties.Resources.question_help_mark_balloon_512);
                }

            }
        }


        void WorkerLoop2()
        {
            while (_shouldRun)
            {
                // wait here until there is a new entry
                _signal.WaitOne();
                if (!_shouldRun)
                    return;

                var entry = _currentEntry;
                var temp = _currentEntry;
                var results = new List<string>();
                var imageList = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(30, 30)
                };

                if (temp.Contains("+") != true && temp.Contains("!") != true)
                {
                    //string text = comboBoxRun.Text;
                    if (temp.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(temp))
                            entry = temp;
                        else
                        {
                            string cut = temp.Substring(0, temp.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            if (Directory.Exists(cut))
                                entry = cut;
                            else
                            {
                                //dir.Clear();
                                entry = String.Empty;
                            }
                        }
                    }
                }
                else if (temp.Contains("+") && temp.Contains("!") != true)
                {
                    string text = temp;
                    string part = text.Substring(text.LastIndexOf("+") + 1); //from last index of ,
                    part = part.Trim();


                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(part))
                            entry = part;
                        else
                        {
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            if (Directory.Exists(cut))
                                entry = cut;
                            else
                            {
                                //dir.Clear();
                                entry = String.Empty;
                            }
                        }
                    }
                }
                else if (temp.Contains("+") != true && temp.Contains("!"))
                {
                    string text = temp;
                    string part = text.Substring(text.LastIndexOf("!") + 1); //from last index of ,
                    part = part.Trim();

                    if (part.Contains("\\")) //if input is a directory or a file
                    {
                        if (Directory.Exists(part))
                            entry = part;
                        else
                        {
                            string cut = part.Substring(0, part.LastIndexOf("\\") + 1); //cut from "text" start from 0 to last index of \ => find all directory, then compare
                            if (Directory.Exists(cut))
                                entry = cut;
                            else
                            {
                                //dir.Clear();
                                entry = String.Empty;
                            }
                        }
                    }
                }

                // if there is nothing to process,
                // return an empty list
                if (string.IsNullOrEmpty(entry))
                {
                    _callback(results);
                    _imageList(imageList);
                    continue;
                }

                try
                {
                    var fileArray = Directory.EnumerateFileSystemEntries(entry);
                    IEnumerator<string> enumerator = fileArray.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        if (((File.GetAttributes(enumerator.Current) & FileAttributes.Hidden) != FileAttributes.Hidden))
                        {
                            results.Add(enumerator.Current);
                            LoadIcon(imageList, enumerator.Current);
                        }
                        if (entry != _currentEntry)
                            break;
                    }
                    //if (results.Count > 0)
                    //    LoadIcon(imageList, results);
                }
                catch
                {
                    continue;
                }
                    
                
                if (entry == _currentEntry)
                {
                    _callback(results);
                    _imageList(imageList);
                }
            }
        }

        void WorkerLoop()
        {
            while (_shouldRun)
            {
                // wait here until there is a new entry
                _signal.WaitOne();
                if (!_shouldRun)
                    return;

                var entry = _currentEntry;
                var results = new List<string>();
                var imageList = new ImageList
                {
                    ColorDepth = ColorDepth.Depth32Bit,
                    ImageSize = new Size(30, 30)
                };

                // if there is nothing to process,
                // return an empty list
                if (string.IsNullOrEmpty(entry))
                {
                    _callback(results);
                    _imageList(imageList);
                    continue;
                }

                // do the search in a for-loop to 
                // allow early termination when current entry
                // is changed on a different thread
                foreach (var i in _items)
                {
                    // if matched, add to the list of results
                    if (i.ToLower().Contains(entry.ToLower()))
                    {
                        results.Add(i);
                        LoadIcon(imageList, i);
                    }

                    // check if the current entry was updated in the meantime,
                    // or we found enough items
                    if (entry != _currentEntry || results.Count >= _maxItemsToMatch)
                        break;
                }
                //if (results.Count > 0)
                //    LoadIcon(imageList, results);
                if (entry == _currentEntry)
                {
                    _callback(results);
                    _imageList(imageList);
                }
            }
        }

        public void Dispose()
        {
            // we are using AutoResetEvent and a background thread
            // and therefore must dispose it explicitly
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            // shutdown the thread
            if (_workerThread.IsAlive)
            {
                _shouldRun = false;
                _currentEntry = null;
                _signal.Set();
                _workerThread.Join();
            }

            // if targetting .NET 3.5 or older, we have to
            // use the explicit IDisposable implementation
            (_signal as IDisposable).Dispose();
        }
    }
}
