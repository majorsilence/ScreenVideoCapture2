namespace ScreenVideoCapture2
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.process1 = new System.Diagnostics.Process();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAudioSettings = new System.Windows.Forms.Button();
            this.chkHaloMouse = new System.Windows.Forms.CheckBox();
            this.chkAudio = new System.Windows.Forms.CheckBox();
            this.btnOutputLocation = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudWait = new System.Windows.Forms.NumericUpDown();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkAsyncStop = new System.Windows.Forms.CheckBox();
            this.cmbBitrate = new System.Windows.Forms.ComboBox();
            this.lblMP3Bitrate = new System.Windows.Forms.Label();
            this.chkNormalize = new System.Windows.Forms.CheckBox();
            this.cmbDevices = new System.Windows.Forms.ComboBox();
            this.lblDevice = new System.Windows.Forms.Label();
            this.cmbFormats = new System.Windows.Forms.ComboBox();
            this.lblSampling = new System.Windows.Forms.Label();
            this.lblFinalSize = new System.Windows.Forms.Label();
            this.cboFinalSize = new System.Windows.Forms.ComboBox();
            this.bwCreateVideo = new System.ComponentModel.BackgroundWorker();
            this.chkEditVideo = new System.Windows.Forms.CheckBox();
            this.processEditVideo = new System.Diagnostics.Process();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkIncludeMouse = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWait)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(480, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 297);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(480, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripStatus
            // 
            this.toolStripStatus.Name = "toolStripStatus";
            this.toolStripStatus.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatus.Text = "Standby ...";
            // 
            // btnAudioSettings
            // 
            this.btnAudioSettings.FlatAppearance.BorderSize = 0;
            this.btnAudioSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAudioSettings.Location = new System.Drawing.Point(9, 141);
            this.btnAudioSettings.Name = "btnAudioSettings";
            this.btnAudioSettings.Size = new System.Drawing.Size(46, 23);
            this.btnAudioSettings.TabIndex = 35;
            this.btnAudioSettings.Text = ">>";
            this.btnAudioSettings.UseVisualStyleBackColor = true;
            this.btnAudioSettings.Click += new System.EventHandler(this.btnAudioSettings_Click);
            // 
            // chkHaloMouse
            // 
            this.chkHaloMouse.AutoSize = true;
            this.chkHaloMouse.Checked = true;
            this.chkHaloMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHaloMouse.Location = new System.Drawing.Point(101, 75);
            this.chkHaloMouse.Name = "chkHaloMouse";
            this.chkHaloMouse.Size = new System.Drawing.Size(83, 17);
            this.chkHaloMouse.TabIndex = 34;
            this.chkHaloMouse.Text = "Halo Mouse";
            this.chkHaloMouse.UseVisualStyleBackColor = true;
            // 
            // chkAudio
            // 
            this.chkAudio.AutoSize = true;
            this.chkAudio.Location = new System.Drawing.Point(9, 75);
            this.chkAudio.Name = "chkAudio";
            this.chkAudio.Size = new System.Drawing.Size(81, 17);
            this.chkAudio.TabIndex = 33;
            this.chkAudio.Text = "Record Mic";
            this.chkAudio.UseVisualStyleBackColor = true;
            // 
            // btnOutputLocation
            // 
            this.btnOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputLocation.Location = new System.Drawing.Point(373, 37);
            this.btnOutputLocation.Name = "btnOutputLocation";
            this.btnOutputLocation.Size = new System.Drawing.Size(95, 23);
            this.btnOutputLocation.TabIndex = 32;
            this.btnOutputLocation.Text = "Output Location";
            this.btnOutputLocation.UseVisualStyleBackColor = true;
            this.btnOutputLocation.Click += new System.EventHandler(this.btnOutputLocation_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocation.Location = new System.Drawing.Point(12, 39);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(355, 20);
            this.txtLocation.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "seconds";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Wait";
            // 
            // nudWait
            // 
            this.nudWait.Location = new System.Drawing.Point(46, 109);
            this.nudWait.Name = "nudWait";
            this.nudWait.Size = new System.Drawing.Size(55, 20);
            this.nudWait.TabIndex = 28;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(312, 106);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 27;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(393, 106);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 26;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkAsyncStop
            // 
            this.chkAsyncStop.AutoSize = true;
            this.chkAsyncStop.Location = new System.Drawing.Point(94, 274);
            this.chkAsyncStop.Name = "chkAsyncStop";
            this.chkAsyncStop.Size = new System.Drawing.Size(80, 17);
            this.chkAsyncStop.TabIndex = 43;
            this.chkAsyncStop.Text = "Async Stop";
            this.chkAsyncStop.UseVisualStyleBackColor = true;
            // 
            // cmbBitrate
            // 
            this.cmbBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBitrate.FormattingEnabled = true;
            this.cmbBitrate.Location = new System.Drawing.Point(85, 236);
            this.cmbBitrate.Name = "cmbBitrate";
            this.cmbBitrate.Size = new System.Drawing.Size(178, 21);
            this.cmbBitrate.TabIndex = 40;
            this.cmbBitrate.SelectedIndexChanged += new System.EventHandler(this.bitRateCmb_SelectedIndexChanged);
            // 
            // lblMP3Bitrate
            // 
            this.lblMP3Bitrate.AutoSize = true;
            this.lblMP3Bitrate.Location = new System.Drawing.Point(14, 239);
            this.lblMP3Bitrate.Name = "lblMP3Bitrate";
            this.lblMP3Bitrate.Size = new System.Drawing.Size(62, 13);
            this.lblMP3Bitrate.TabIndex = 42;
            this.lblMP3Bitrate.Text = "MP3 Bitrate";
            // 
            // chkNormalize
            // 
            this.chkNormalize.AutoSize = true;
            this.chkNormalize.Checked = true;
            this.chkNormalize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNormalize.Location = new System.Drawing.Point(16, 274);
            this.chkNormalize.Name = "chkNormalize";
            this.chkNormalize.Size = new System.Drawing.Size(72, 17);
            this.chkNormalize.TabIndex = 41;
            this.chkNormalize.Text = "Normalize";
            this.chkNormalize.UseVisualStyleBackColor = true;
            // 
            // cmbDevices
            // 
            this.cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevices.FormattingEnabled = true;
            this.cmbDevices.Location = new System.Drawing.Point(85, 181);
            this.cmbDevices.Name = "cmbDevices";
            this.cmbDevices.Size = new System.Drawing.Size(178, 21);
            this.cmbDevices.TabIndex = 37;
            this.cmbDevices.SelectedIndexChanged += new System.EventHandler(this.devicesCmb_SelectedIndexChanged);
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(14, 184);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(41, 13);
            this.lblDevice.TabIndex = 38;
            this.lblDevice.Text = "Device";
            // 
            // cmbFormats
            // 
            this.cmbFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormats.FormattingEnabled = true;
            this.cmbFormats.Location = new System.Drawing.Point(85, 208);
            this.cmbFormats.Name = "cmbFormats";
            this.cmbFormats.Size = new System.Drawing.Size(178, 21);
            this.cmbFormats.TabIndex = 39;
            this.cmbFormats.SelectedIndexChanged += new System.EventHandler(this.formatsCmb_SelectedIndexChanged);
            // 
            // lblSampling
            // 
            this.lblSampling.AutoSize = true;
            this.lblSampling.Location = new System.Drawing.Point(14, 211);
            this.lblSampling.Name = "lblSampling";
            this.lblSampling.Size = new System.Drawing.Size(50, 13);
            this.lblSampling.TabIndex = 36;
            this.lblSampling.Text = "Sampling";
            // 
            // lblFinalSize
            // 
            this.lblFinalSize.AutoSize = true;
            this.lblFinalSize.Location = new System.Drawing.Point(283, 184);
            this.lblFinalSize.Name = "lblFinalSize";
            this.lblFinalSize.Size = new System.Drawing.Size(55, 13);
            this.lblFinalSize.TabIndex = 44;
            this.lblFinalSize.Text = "Final Size:";
            // 
            // cboFinalSize
            // 
            this.cboFinalSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFinalSize.FormattingEnabled = true;
            this.cboFinalSize.Items.AddRange(new object[] {
            "Fullscreen",
            "720x480",
            "704x480",
            "640x480",
            "640x360",
            "480x360",
            "480x480",
            "352x480",
            "352x240"});
            this.cboFinalSize.Location = new System.Drawing.Point(342, 181);
            this.cboFinalSize.Name = "cboFinalSize";
            this.cboFinalSize.Size = new System.Drawing.Size(126, 21);
            this.cboFinalSize.TabIndex = 45;
            // 
            // bwCreateVideo
            // 
            this.bwCreateVideo.WorkerReportsProgress = true;
            this.bwCreateVideo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCreateVideo_DoWork);
            this.bwCreateVideo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCreateVideo_RunWorkerCompleted);
            this.bwCreateVideo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCreateVideo_ProgressChanged);
            // 
            // chkEditVideo
            // 
            this.chkEditVideo.AutoSize = true;
            this.chkEditVideo.Location = new System.Drawing.Point(180, 274);
            this.chkEditVideo.Name = "chkEditVideo";
            this.chkEditVideo.Size = new System.Drawing.Size(216, 17);
            this.chkEditVideo.TabIndex = 46;
            this.chkEditVideo.Text = "Edit with Windows Movie Maker on stop";
            this.chkEditVideo.UseVisualStyleBackColor = true;
            // 
            // processEditVideo
            // 
            this.processEditVideo.StartInfo.Domain = "";
            this.processEditVideo.StartInfo.LoadUserProfile = false;
            this.processEditVideo.StartInfo.Password = null;
            this.processEditVideo.StartInfo.StandardErrorEncoding = null;
            this.processEditVideo.StartInfo.StandardOutputEncoding = null;
            this.processEditVideo.StartInfo.UserName = "";
            this.processEditVideo.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // chkIncludeMouse
            // 
            this.chkIncludeMouse.AutoSize = true;
            this.chkIncludeMouse.Checked = true;
            this.chkIncludeMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeMouse.Location = new System.Drawing.Point(190, 75);
            this.chkIncludeMouse.Name = "chkIncludeMouse";
            this.chkIncludeMouse.Size = new System.Drawing.Size(96, 17);
            this.chkIncludeMouse.TabIndex = 47;
            this.chkIncludeMouse.Text = "Include Mouse";
            this.chkIncludeMouse.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 319);
            this.Controls.Add(this.chkIncludeMouse);
            this.Controls.Add(this.chkEditVideo);
            this.Controls.Add(this.cboFinalSize);
            this.Controls.Add(this.lblFinalSize);
            this.Controls.Add(this.chkAsyncStop);
            this.Controls.Add(this.cmbBitrate);
            this.Controls.Add(this.lblMP3Bitrate);
            this.Controls.Add(this.chkNormalize);
            this.Controls.Add(this.cmbDevices);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.cmbFormats);
            this.Controls.Add(this.lblSampling);
            this.Controls.Add(this.btnAudioSettings);
            this.Controls.Add(this.chkHaloMouse);
            this.Controls.Add(this.chkAudio);
            this.Controls.Add(this.btnOutputLocation);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudWait);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Screen Video Capture";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Diagnostics.Process process1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.CheckBox chkAsyncStop;
        private System.Windows.Forms.ComboBox cmbBitrate;
        private System.Windows.Forms.Label lblMP3Bitrate;
        private System.Windows.Forms.CheckBox chkNormalize;
        private System.Windows.Forms.ComboBox cmbDevices;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.ComboBox cmbFormats;
        private System.Windows.Forms.Label lblSampling;
        private System.Windows.Forms.Button btnAudioSettings;
        private System.Windows.Forms.CheckBox chkHaloMouse;
        private System.Windows.Forms.CheckBox chkAudio;
        private System.Windows.Forms.Button btnOutputLocation;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWait;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cboFinalSize;
        private System.Windows.Forms.Label lblFinalSize;
        private System.ComponentModel.BackgroundWorker bwCreateVideo;
        private System.Windows.Forms.CheckBox chkEditVideo;
        private System.Diagnostics.Process processEditVideo;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox chkIncludeMouse;
    }
}

