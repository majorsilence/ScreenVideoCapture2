using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using Istrib.Sound;
using Istrib.Sound.Formats;

namespace ScreenVideoCapture2
{
    enum RecordType
    {
        mp3,
        pcm,
        wav
    }

    class Sound2
    {
        private object device;
        private object format;
        private object bitrate;
        private bool normalize;
        private RecordType rType;
        private Mp3SoundCapture sndCapture;
        private string saveLocation;
        private bool async;

        public Sound2(object device, object format, object bitrate, string path, bool normalize, bool async, RecordType rType)
        {
            this.device = device;
            this.format = format;
            this.bitrate = bitrate;
            this.normalize = normalize;
            this.rType = rType;
            this.saveLocation = path;
            this.async = async;

            sndCapture = new Mp3SoundCapture();
        }

        public void RecordFromMic()
        {
            try
            {
                sndCapture.CaptureDevice = (SoundCaptureDevice)this.device;
                sndCapture.NormalizeVolume = this.normalize;
                if (rType == RecordType.pcm)
                {
                    sndCapture.OutputType = Mp3SoundCapture.Outputs.RawPcm;
                }
                else if (rType == RecordType.mp3)
                {
                    sndCapture.OutputType = Mp3SoundCapture.Outputs.Mp3;
                }
                else
                {
                    sndCapture.OutputType = Mp3SoundCapture.Outputs.Wav;
                }

                sndCapture.WaveFormat = (PcmSoundFormat)this.format;
                if (this.rType == RecordType.mp3)
                {
                    sndCapture.Mp3BitRate = (Mp3BitRate)this.bitrate;
                }
                sndCapture.WaitOnStop = !this.async;
                sndCapture.Start(System.IO.Path.Combine(this.saveLocation, "record.wav"));

            }
            catch (Exception ex)
            {
                Logging.Instance.WriteLine(ex);
                MessageBox.Show(ex.Message, "Not so easy...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void StopAndSave()
        {
            sndCapture.Stop();
        }
    }

    class Sound
    {
        //[DllImport("winmm.dll")]
        //private static extern long mciSendString(
        //    string strCommand,
        //    StringBuilder strReturn,
        //    int iReturnLength,
        //    IntPtr oCallback);
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private string saveDir;
        

        public Sound(string saveDir)
        {
            this.saveDir = saveDir;
        }

        public void RecordFromMic()
        {
            //mciSendString(PlayCommand, null, 0, IntPtr.Zero);
            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);
        }

        public void StopAndSave()
        {
            mciSendString("save recsound " + System.IO.Path.Combine(this.saveDir, "record.wav"), "", 0, 0);
            mciSendString("close recsound ", "", 0, 0);
            mciSendString("Close MediaFile ", "", 0, 0);

            //Computer c = new Computer();
            //c.Audio.Stop();
        }

    }
}
