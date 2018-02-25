//Code by Takeru Lunsford (Steam: TakeruL | Skype: TakeruL)
//
//Source not to be released publicly.
//
//I know it's a major clusterfuck, but meh, whatever get's the job done, right?
//Also, I tried accounting for a lot of stuff, but this was a rushed job.

//Additional code added by Gruntlord6

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Data.OleDb;
using System.Configuration;


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
        public String procArch;
        private void OSL_Load(object sender, EventArgs e)
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
            About abert = new About();
            abert.Show();
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
            catch (Exception ex)
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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}