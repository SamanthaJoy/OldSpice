namespace OldSpice
{
    partial class OSL
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
            System.Windows.Forms.LinkLabel linkLabel1;
            System.Windows.Forms.LinkLabel linkLabel3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OSL));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.onlineVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.localVersion = new System.Windows.Forms.TextBox();
            this.kUpdateLabel = new System.Windows.Forms.Label();
            this.kUpdateButton = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.percent = new System.Windows.Forms.Label();
            this.size = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.kUpdatedLabel = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = System.Drawing.Color.Transparent;
            linkLabel1.Location = new System.Drawing.Point(721, 603);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(96, 13);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Gruntmods Studios";
            linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.BackColor = System.Drawing.Color.Transparent;
            linkLabel3.Location = new System.Drawing.Point(856, 603);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new System.Drawing.Size(44, 13);
            linkLabel3.TabIndex = 20;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Support";
            linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(835, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Check for updates";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 486);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Launch Campaign";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(949, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Online version";
            // 
            // onlineVersion
            // 
            this.onlineVersion.Location = new System.Drawing.Point(941, 565);
            this.onlineVersion.Name = "onlineVersion";
            this.onlineVersion.ReadOnly = true;
            this.onlineVersion.Size = new System.Drawing.Size(90, 20);
            this.onlineVersion.TabIndex = 8;
            this.onlineVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(856, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Local version";
            // 
            // localVersion
            // 
            this.localVersion.Location = new System.Drawing.Point(845, 565);
            this.localVersion.Name = "localVersion";
            this.localVersion.ReadOnly = true;
            this.localVersion.Size = new System.Drawing.Size(90, 20);
            this.localVersion.TabIndex = 6;
            this.localVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kUpdateLabel
            // 
            this.kUpdateLabel.AutoSize = true;
            this.kUpdateLabel.BackColor = System.Drawing.Color.Transparent;
            this.kUpdateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kUpdateLabel.ForeColor = System.Drawing.Color.Red;
            this.kUpdateLabel.Location = new System.Drawing.Point(652, 565);
            this.kUpdateLabel.Name = "kUpdateLabel";
            this.kUpdateLabel.Size = new System.Drawing.Size(181, 25);
            this.kUpdateLabel.TabIndex = 10;
            this.kUpdateLabel.Text = "Update Available!";
            this.kUpdateLabel.Visible = false;
            // 
            // kUpdateButton
            // 
            this.kUpdateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.kUpdateButton.Location = new System.Drawing.Point(835, 518);
            this.kUpdateButton.Name = "kUpdateButton";
            this.kUpdateButton.Size = new System.Drawing.Size(196, 26);
            this.kUpdateButton.TabIndex = 11;
            this.kUpdateButton.Text = "Download Update";
            this.kUpdateButton.UseVisualStyleBackColor = true;
            this.kUpdateButton.Visible = false;
            this.kUpdateButton.Click += new System.EventHandler(this.kUpdateButton_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(943, 603);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(106, 13);
            this.linkLabel2.TabIndex = 13;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "www.gruntmods.com";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(693, 521);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(128, 23);
            this.progress.TabIndex = 14;
            this.progress.Visible = false;
            // 
            // percent
            // 
            this.percent.AutoSize = true;
            this.percent.Location = new System.Drawing.Point(693, 505);
            this.percent.Name = "percent";
            this.percent.Size = new System.Drawing.Size(15, 13);
            this.percent.TabIndex = 15;
            this.percent.Text = "%";
            this.percent.Visible = false;
            // 
            // size
            // 
            this.size.AutoSize = true;
            this.size.Location = new System.Drawing.Point(786, 505);
            this.size.Name = "size";
            this.size.Size = new System.Drawing.Size(25, 13);
            this.size.TabIndex = 16;
            this.size.Text = "size";
            this.size.Visible = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(12, 549);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 26);
            this.button3.TabIndex = 17;
            this.button3.Text = "Configure Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(12, 518);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 26);
            this.button4.TabIndex = 18;
            this.button4.Text = "Launch Multiplayer";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(12, 580);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(151, 26);
            this.button5.TabIndex = 21;
            this.button5.Text = "D2K+ Toolkit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(169, 486);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(246, 26);
            this.button6.TabIndex = 22;
            this.button6.Text = "Launch Rise Of The Mercenaries";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(169, 518);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(197, 26);
            this.button7.TabIndex = 23;
            this.button7.Text = "Mission Select Launcher";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // kUpdatedLabel
            // 
            this.kUpdatedLabel.AutoSize = true;
            this.kUpdatedLabel.BackColor = System.Drawing.Color.Transparent;
            this.kUpdatedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kUpdatedLabel.ForeColor = System.Drawing.Color.ForestGreen;
            this.kUpdatedLabel.Location = new System.Drawing.Point(652, 565);
            this.kUpdatedLabel.Name = "kUpdatedLabel";
            this.kUpdatedLabel.Size = new System.Drawing.Size(187, 25);
            this.kUpdatedLabel.TabIndex = 24;
            this.kUpdatedLabel.Text = "Version up to date";
            this.kUpdatedLabel.Visible = false;
            this.kUpdatedLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // OSL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1063, 618);
            this.Controls.Add(this.kUpdatedLabel);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(linkLabel3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.size);
            this.Controls.Add(this.percent);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(linkLabel1);
            this.Controls.Add(this.kUpdateButton);
            this.Controls.Add(this.kUpdateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.onlineVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.localVersion);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1079, 657);
            this.MinimumSize = new System.Drawing.Size(1079, 657);
            this.Name = "OSL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Old Spice (Dune 2000 Launcher/Updater)";
            this.Load += new System.EventHandler(this.OSL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox onlineVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox localVersion;
        private System.Windows.Forms.Label kUpdateLabel;
        private System.Windows.Forms.Button kUpdateButton;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label percent;
        private System.Windows.Forms.Label size;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label kUpdatedLabel;
    }
}

