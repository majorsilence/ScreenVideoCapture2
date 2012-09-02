using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

using Istrib.Sound;
using Istrib.Sound.Formats;


using System.Threading;

namespace ScreenVideoCapture2
{

    

    public partial class MainForm : Form
    {
       
        private string _saveLocation;
        
        private SolidBrush _brushOpacity;
        private int _radius;

        /// <summary>
        /// Keep track of starttime and end time and count to calculate fps.
        /// </summary>
        private DateTime _startTime;
        private DateTime _endTime;
        private int _counter;
        private System.Drawing.Size _finalSize;
        private System.Drawing.Size _screenSize;
        private string _finishedDate;




        public MainForm()
        {
            InitializeComponent();

            _finishedDate = "";

            _screenSize = new Size(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);

            _counter = 0;

            _brushOpacity = GetNewColorBrush();
            _radius = 45;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            // we only want to show the sound options if the show button is clicked.
            MakeSoundOptionsVisible(false);
            LoadAvailableDevices();

            txtLocation.Text = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "video-capture");

            cboFinalSize.SelectedIndex = 0; //default to fullscreen

        }

        public void SetStatusLabelText(string message)
        {
            toolStripStatus.Text = message;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

           
            AsyncProcess caller = new AsyncProcess(CaptureScreen);
            caller.BeginInvoke(_counter, this._screenSize, this._finalSize, chkHaloMouse.Checked, 
                chkIncludeMouse.Checked, _saveLocation, _radius, null, null);

            _counter++;

            
        }

        delegate void AsyncProcess(int imageCount, Size screenSize, Size screenfinalSize, bool haloMouse,
            bool includeMouse, string saveLocation, int radius);


        private void CaptureScreen(int imageCount, Size screenSize, Size screenfinalSize, bool haloMouse,
            bool includeMouse, string saveLocation, int radius)
        {

            //System.Drawing.Size s = new System.Drawing.Size();
            //s.Height = Screen.PrimaryScreen.Bounds.Size.Height;
            //s.Width = Screen.PrimaryScreen.Bounds.Size.Width;
            MousePosition mspos = new MousePosition();
            Bitmap bmp = new Bitmap(screenSize.Width, screenSize.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen( 0, 0, 0, 0, screenSize);

            if (haloMouse)
            {
                //g.DrawEllipse(Pens.Green, pnt.X, pnt.Y, radius, radius);
                g.FillEllipse(_brushOpacity, mspos.Position().X - (radius/2), mspos.Position().Y - (radius/2), radius, radius);
            }
            if (includeMouse)
            {
                int x=0;
                int y=0;

                //Bitmap cursorBMP = mspos.CaptureCursor(ref x, ref y);
                Bitmap cursorBMP = new Bitmap(5, 5);
                if (cursorBMP != null)
                {
                    Rectangle r = new Rectangle(x, y, cursorBMP.Width, cursorBMP.Height);

                    g.DrawImage(cursorBMP, r);
                }
            }

            g.Dispose();

            if (screenfinalSize != screenSize)
            {
                bmp = (Bitmap)ImageOperations.ResizeImage(bmp, screenfinalSize.Width, screenfinalSize.Height);
            }

            try
            {
                bmp.Save(System.IO.Path.Combine(saveLocation, "screenvideocapture_" + imageCount.ToString().PadLeft(10, '0') + ".jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
            }
            catch (IOException iex)
            {
                Logging.Instance.WriteLine(iex);
            }
        }

        private void SetFinalSize()
        {
            if (cboFinalSize.SelectedItem.ToString() == "Fullscreen")
            {
                _finalSize = new Size(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "720x480")
            {
                _finalSize = new Size(720, 480);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "704x480")
            {
                _finalSize = new Size(704, 480);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "480x480")
            {
                _finalSize = new Size(480, 480);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "352x480")
            {
                _finalSize = new Size(352, 480);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "640x480")
            {
                _finalSize = new Size(640, 480);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "640x360")
            {
                _finalSize = new Size(640, 360);
            }
            else if (cboFinalSize.SelectedItem.ToString() == "480x360")
            {
                _finalSize = new Size(480, 360);
            }
            else
            {
               _finalSize = new Size(352, 240);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this._saveLocation = txtLocation.Text.Trim();
            if (System.IO.Directory.Exists(txtLocation.Text.Trim()) == false)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(txtLocation.Text.Trim());
                    
                }
                catch(Exception ex)
                {
                    Logging.Instance.WriteLine(ex);
                    MessageBox.Show("Error creating output folder." + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (System.IO.Directory.Exists(txtLocation.Text.Trim()) == false)
            {
                MessageBox.Show("Please select an output directory", "Select Output Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }

            int waitCount = 0;
            while (waitCount <= (int)nudWait.Value)
            {
                toolStripStatus.Text = "Waiting ...  " + ((int)nudWait.Value - waitCount).ToString();
                Thread.Sleep(1000);
                waitCount++;
            }

            btnStop.Enabled = true;
            SetFinalSize();

            toolStripStatus.Text = "Recording ...";

            

            _counter = 0;

            btnStart.Enabled = false;
            chkAudio.Enabled = false;
            chkHaloMouse.Enabled = false;
            btnOutputLocation.Enabled = false;
            chkIncludeMouse.Enabled = false;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            _startTime = DateTime.Now;

            if (chkAudio.Checked)
            {
                MCIAudio.OpenNew();
                MCIAudio.Record();
            }
            timer1.Start();
            //Thread.Sleep(2000); // audio is alwasy 2 seconds off for some reason

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            
            timer1.Stop();

            // give enough time for images that are being captured to be saved.
            System.Threading.Thread.Sleep(500);
            if (chkAudio.Checked)
            {
                MCIAudio.SaveRecording(System.IO.Path.Combine(_saveLocation, "record.wav"));
                MCIAudio.Stop();
            }

            _endTime = DateTime.Now;

            bwCreateVideo.RunWorkerAsync();
        }

        private void btnOutputLocation_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = folderBrowserDialog1.SelectedPath;
                this._saveLocation = folderBrowserDialog1.SelectedPath;
                
            }
        }


        private void CreateVideo()
        {
            System.Environment.CurrentDirectory = this._saveLocation;
            string extraArgs = "";
            string fDate = "";

            while (IsFileLocked("record.wav"))
            {
                Thread.Sleep(500);
            }

            int seconds = (int)(this._endTime - this._startTime).TotalSeconds;
            string fps = (this._counter) + "/" + seconds;


            process1.StartInfo.FileName = System.IO.Path.Combine(Application.StartupPath, "mencoder.exe");
            // harddup - use this so duplicate pictures are not removed, if they are removed there will be major audio video sync problems. 
            //process1.StartInfo.Arguments = "mf://*.jpg -mf fps=" + fps + ":type=jpg -ovc lavc harddup -lavcopts vcodec=msmpeg4v2:vbitrate=800 -o output.avi";
            process1.StartInfo.Arguments = "mf://*.jpg -mf fps=" + fps + " -ovc lavc harddup -lavcopts vcodec=msmpeg4v2:mbd=2:trell";

            // mencoder mf://*.jpg -mf w=800:h=600:fps=25:type=jpg -ovc lavc -lavcopts vcodec=mpeg4:mbd=2:trell -oac copy -o output.avi

            process1.StartInfo.Arguments += " -o output.avi";
            
            process1.StartInfo.RedirectStandardOutput = false;
            //this.StartInfo.RedirectStandardError = true; // redirecting StandardError or any input output for that matter will fill the buffer and hang the program if you do not read it in and dispose of it
            process1.StartInfo.CreateNoWindow = true;
            process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process1.StartInfo.UseShellExecute = false;
            process1.Start();
            process1.WaitForExit();

            fDate = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss", CultureInfo.CurrentUICulture);
            bwCreateVideo.ReportProgress(1, fDate);
            if (chkAudio.Checked && System.IO.File.Exists("record.wav"))
            {
                // extraArgs = "-ovc copy -oac mp3lame -audiofile record.wav";
                // -vf harddup is need to keep duplicates of the video when adding the audio.  Else you are going to have a clusterfuck audio/video sync problem.
                process1.StartInfo.Arguments = "output.avi -o output-" + fDate + ".avi -vf harddup -ovc copy -oac mp3lame -audiofile record.wav";
                process1.StartInfo.RedirectStandardOutput = false;
                //this.StartInfo.RedirectStandardError = true; // redirecting StandardError or any input output for that matter will fill the buffer and hang the program
                process1.StartInfo.CreateNoWindow = true;
                process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process1.StartInfo.UseShellExecute = false;
                process1.Start();
                process1.WaitForExit();

            }
            else
            {

                process1.StartInfo.Arguments = "output.avi -o output-" + fDate + ".avi -vf harddup -ovc copy -oac mp3lame -audiofile " + System.IO.Path.Combine(Application.StartupPath, "silence.wav");
                process1.StartInfo.RedirectStandardOutput = false;
                //this.StartInfo.RedirectStandardError = true; // redirecting StandardError or any input output for that matter will fill the buffer and hang the program
                process1.StartInfo.CreateNoWindow = true;
                process1.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process1.StartInfo.UseShellExecute = false;
                process1.Start();
                process1.WaitForExit();

                //if (System.IO.File.Exists("output-"+ fDate +".avi"))
                //{
                //    System.IO.File.Delete("output-" + fDate + ".avi");
                //}
                //System.IO.File.Move("output.avi", "output-" + fDate + ".avi");
            }

            // out put flash video
//            mencoder \videos\soph1.wmv -o soph4.flv -of lavf -oac mp3lame
//-lameopts abr:br=56
// -ovc lavc -lavcopts
//vcodec=flv:vbitrate=500:mbd=2:mv0:trell:v4mv:cbp:last_pred=3 -srate
//22050

        }

        protected void CleanWorkingFolder()
        {
            string imgFolder = this._saveLocation;
            string[] imgList = System.IO.Directory.GetFiles(imgFolder, "screenvideocapture*.jpg");
            foreach (string img in imgList)
            {
                System.IO.File.Delete(img);
            }

            try
            {
                if (System.IO.File.Exists("record.wav"))
                {
                    System.IO.File.Delete("record.wav");
                }
            }
            catch (Exception ex)
            {
                Logging.Instance.WriteLine(ex);
            }

            try
            {
                if (System.IO.File.Exists("output.avi"))
                {
                    System.IO.File.Delete("output.avi");
                }
            }
            catch (Exception ex)
            {
                Logging.Instance.WriteLine(ex);
            }
        }





        private SolidBrush GetNewColorBrush()
        {
            Color c = new Color();
            c = Color.FromArgb(50, Color.Green);

            SolidBrush br = new SolidBrush(c);
            return br;
        }

        protected virtual bool IsFileLocked(string path)
        {
            System.IO.FileStream stream = null;
            System.IO.FileInfo file = new System.IO.FileInfo(path);

            if (System.IO.File.Exists(path) == false)
            {
                return false;
            }

            try
            {
                stream = file.Open(System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None);
            }
            catch (System.IO.IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            //file is not locked
            return false;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("No preferences exist yet :D", "No way", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MakeSoundOptionsVisible(bool visible)
        {
            if (visible == false)
            {
                this.Height = 225;
            }
            else
            {
                this.Height = 365;
            }
            lblDevice.Visible = visible;
            lblFinalSize.Visible = visible;
            cboFinalSize.Visible = visible;
            cmbDevices.Visible = visible;
            chkAsyncStop.Visible = visible;
            chkEditVideo.Visible = visible;
        }

        private void btnAudioSettings_Click(object sender, EventArgs e)
        {
            if (cmbDevices.Visible == false)
            {
                MakeSoundOptionsVisible(true);
            }
            else
            {
                MakeSoundOptionsVisible(false);
            }
        }


        private void LoadAvailableDevices()
        {
   

        }


        private void devicesCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
        }


        private void bwCreateVideo_DoWork(object sender, DoWorkEventArgs e)
        {
            bwCreateVideo.ReportProgress(0, "Compiling video...");
            //toolStripStatus.Text = "Compiling video...";
            

            CreateVideo();
            //toolStripStatus.Text = "Cleaning up working directory...";
            bwCreateVideo.ReportProgress(0, "Cleaning up working directory...");
            CleanWorkingFolder();

            bwCreateVideo.ReportProgress(0, "Finished...");
            //toolStripStatus.Text = "Finished...";


        }

        private void bwCreateVideo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                toolStripStatus.Text = e.UserState.ToString();
            }
            else if (e.ProgressPercentage == 1)
            {
                this._finishedDate = e.UserState.ToString();
            }

        }

        private void bwCreateVideo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            btnStart.Enabled = true;
            chkAudio.Enabled = true;
            chkHaloMouse.Enabled = true;
            btnOutputLocation.Enabled = true;
            chkIncludeMouse.Enabled = true;

            if (chkEditVideo.Checked)
            {
                string programDir = Environment.GetEnvironmentVariable("ProgramFiles").Replace("(x86)", "").Trim();
                string movieMaker = System.IO.Path.Combine(programDir, "Movie Maker");
                movieMaker = System.IO.Path.Combine(movieMaker, "MovieMk.exe");

                if (System.IO.File.Exists(movieMaker))
                {

                    processEditVideo.StartInfo.FileName = movieMaker;
                    // harddup - use this so duplicate pictures are not removed, if they are removed there will be major audio video sync problems. 
                    processEditVideo.StartInfo.Arguments = System.IO.Path.Combine(this._saveLocation, "output-" + this._finishedDate + ".avi");
                    processEditVideo.StartInfo.RedirectStandardOutput = false;
                    //this.StartInfo.RedirectStandardError = true; // redirecting StandardError or any input output for that matter will fill the buffer and hang the program if you do not read it in and dispose of it
                    processEditVideo.StartInfo.CreateNoWindow = true;
                    processEditVideo.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    processEditVideo.StartInfo.UseShellExecute = false;
                    processEditVideo.Start();
                }
            }

        }



    }

}


