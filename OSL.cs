﻿//Code by Samantha Joy (https://github.com/SamanthaJoy)
//Additional code added by Gruntlord6
//Licensed under GPLv3, check LICENSE

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;


namespace OldSpice
{
    public partial class OSL : Form
    {
        public OSL()
        {
            InitializeComponent();
        }

        Stopwatch watch = new Stopwatch();

        WebClient webClient = new WebClient();

        public String procArch;

        public void ProcessStart(string fileName)
        {
            ProcessStart(fileName, null);
        }

        public void ProcessStart(string fileName, string args)
        {
            var psi = new ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.WorkingDirectory = Path.GetDirectoryName(fileName);
            psi.FileName = fileName;
            if (args != null && args.Length > 0) psi.Arguments = args;
            if (Environment.OSVersion.Version >= new Version(6, 2, 9200, 0))
            {
                psi.EnvironmentVariables["__COMPAT_LAYER"] += "WINXPSP2 SingleProcAffinity EmulateSlowCPU ";
                psi.UseShellExecute = false;
            }
            Process.Start(psi);
        }

        private void OSL_Load(object sender, EventArgs e)
        {
            getNewsFeed();
            getVersion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Since DisplayIcon IS the executable, we can just set that as a string to be launched.
            string fileName = getRegistryValue("DisplayIcon");
            ProcessStart(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Grabs version of local install
                string localVersionString = getRegistryValue("DisplayVersion");
                //Grabs version.txt from the server
                WebRequest request = WebRequest.Create("http://old.gruntmods.com/Support/version2.txt");
                WebResponse response = request.GetResponse();
                //Reads the text file
                System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
                //Turns the contents of the text file into a string
                string newestversion = sr.ReadToEnd();
                onlineVersion.Text = newestversion;
                //Self explanatory
                Version onlinev = new Version(newestversion);
                Version localv = new Version(localVersionString);
                //This is for allowing the Update button to be used
                if (onlinev > localv)
                {
                   kUpdateButton.Visible = true;
                   kUpdateLabel.Visible = true;
                   kUpdatedLabel.Visible = false;
                }
                //If there isn't an update
                else if (localv == onlinev)
                {
                    kUpdatedLabel.Visible = true;
                    kUpdateLabel.Visible = false;
                }
                else if (localv > onlinev)
                {
                    MessageBox.Show("Your version is newer then the one hosted online.", "Client Newer Then Server");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update version cannot be received from update server.\rPlease visit support the support page and let us know if the issue persists.\rhttps://gruntmods.com/contact-us/", "Version not found");
                Console.WriteLine(ex.Message);
            }
        }

        private void kUpdateButton_Click(object sender, EventArgs e)
        {
            //deletes update.exe just in case the update file is present from a previous update attempt
            File.Delete(@"update.exe");
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri("http://old.gruntmods.com/Support/Updates/1.6.2/update1.6.2.2.exe"), @"update.exe");
            kUpdateButton.Enabled = false;
            watch.Start();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            //Shows the progress of the download
            size.Visible = true;
            progress.Visible = true;
            percent.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
        }

        public string getRegistryValue(string value)
        {
            string localVersion;
            switch (procArch)
            { //If the processor is x86 - then remove "WOW6432Node"
                case "AMD64": localVersion = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Dune 2000: Gruntmods Edition", value, null); break;
                case "x86": localVersion = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Dune 2000: Gruntmods Edition", value, null); break;
                default: localVersion = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Dune 2000: Gruntmods Edition", value, null); break;
            }
            return localVersion;

        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            //resets stopwatch once download finishes
            watch.Reset();
            try
            {
                if (!IsProcessOpen("update"))
                {
                    //launches the update only if the download is completed
                    Process.Start("update.exe");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The update program is already running!\r Please close it before continuing", "Update already running");
                }
            }
            catch
            {
                MessageBox.Show("The update program was unable to run.\rPlease contact support.\rhttps://gruntmods.com/contact-us/");
                size.Visible = false;
                progress.Visible = false;
                percent.Visible = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //To open a link in a program thats running with elevated privileges, it needs to be launched through explorer for some stupid reason
            var startInfo = new ProcessStartInfo("explorer.exe", "http://gruntmods.com");
            Process.Start(startInfo);
        }

        public bool IsProcessOpen(string name)
        {
            //here we're going to get a list of all running processes on the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once,
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    //if the process is found to be running then we
                    //return a true
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                //Only changes the progressbar if there has been any change to the percent
                if (progress.Value != e.ProgressPercentage)
                    progress.Value = e.ProgressPercentage;

                //How much has been downloaded on the percent label
                if (percent.Text != e.ProgressPercentage.ToString() + "%")
                    percent.Text = e.ProgressPercentage.ToString() + "%";

                //How much has been downloaded on the size label
                size.Text = (Convert.ToDouble(e.TotalBytesToReceive) / 1024 / 1024).ToString("0.00") + "MB";
            }
            catch (Exception ex)
            {
                //Messagebox displays any exceptions thrown by the download
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string configureSettings = getRegistryValue("ConfigureSettings");
            ProcessStart(configureSettings);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string multiPlayer = getRegistryValue("Multiplayer");
            ProcessStart(multiPlayer);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //To open a link in a program thats running with elevated privileges, it needs to be launched through explorer for some stupid reason
            var startInfo = new ProcessStartInfo("explorer.exe", "http://forum.dune2k.com/forum/37-dune-2000-support/");
            Process.Start(startInfo);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Toolkit toolkit = new Toolkit();
            toolkit.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string RiseOfMerc = getRegistryValue("RiseOfMerc");
            Process.Start(RiseOfMerc);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string MissionLauncher = getRegistryValue("MissionLauncher");
            Process.Start(MissionLauncher);
        }

        private void RSSViewer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rssurl = RSSViewer.CurrentRow.Cells[1].Value.ToString();
            var launchRSSUrl = new ProcessStartInfo("explorer.exe", rssurl);
            Process.Start(launchRSSUrl);
        }

        private void getNewsFeed()
        {
            string url = "https://gruntmods.com/category/dune-2000-gruntmods-edition/duneupdates/feed/";

            try
            {
                using (XmlReader reader = XmlReader.Create(url))
                {
                    SyndicationFeed feed = SyndicationFeed.Load(reader);

                    RSSViewer.ColumnCount = 2;

                    RSSViewer.Columns[1].Visible = false;

                    DataGridViewColumn column1 = RSSViewer.Columns[0];
                    column1.Width = RSSViewer.Width - 20;

                    foreach (SyndicationItem item in feed.Items)
                    {
                        //RSSViewer.Rows.Add(item.Title.Text, item.Summary.Text);
                        RSSViewer.Rows.Add(item.Title.Text, item.Links[0].Uri);
                        RSSViewer.Rows.Add(item.Summary.Text, item.Links[0].Uri);
                        RSSViewer.Rows.Add("");
                    }
                    RSSViewer.Rows[0].Selected = false;
                }
            }
            catch
            {
                MessageBox.Show("Unable to fetch newsfeed.\r\nServer may be down. If not, please check your connection settings.");
            }
        }

        private void getVersion()
        {
            procArch = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            //Grabs version of local installation
            string localVersionString = getRegistryValue("DisplayVersion");
            //Pretty much some shit in case they dont have the game installed
            if (localVersionString == null)
            {
                localVersion.Text = "Not Detected";
                button1.Enabled = false;
                button1.Text = "Game not installed";
                button2.Enabled = false;
                button2.Text = "Game not installed";
                button3.Enabled = false;
                button3.Text = "Game not installed";
                button4.Enabled = false;
                button4.Text = "Game not installed";
                button5.Enabled = false;
                button5.Text = "Game not installed";
                MessageBox.Show("The game is not installed correctly, please reinstall it. If you need technical support, visit https://gruntmods.com/contact-us/");
            }
            else
            {
                //Self-explanatory
                localVersion.Text = localVersionString;
            }
        }
    }
}