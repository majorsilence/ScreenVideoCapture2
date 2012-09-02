using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace ScreenVideoCapture2
{
    

    public class MCIAudio
    {
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);

        public static void OpenNew()
        {
            mciSendString("open new type waveaudio alias recsound", null, 0, IntPtr.Zero);
        }

        public static void OpenFile(string fileName)
        {
            mciSendString(string.Format("open \"{0}\" type waveaudio alias recsound", fileName), null, 0, IntPtr.Zero);
        }

        public static void Record()
        {
            mciSendString("record recsound", null, 0, IntPtr.Zero);
        }

        public static void Play()
        {
            mciSendString("play recsound", null, 0, IntPtr.Zero);
        }

        public static void SaveRecording(string fileName)
        {
            mciSendString(string.Format("save recsound \"{0}\"", fileName), null, 0, IntPtr.Zero);
        }

        public static void Pause()
        {
            mciSendString("pause recsound", null, 0, IntPtr.Zero);
        }

        public static void Stop()
        {
            mciSendString("close recsound", null, 0, IntPtr.Zero);
        }
    }
}
