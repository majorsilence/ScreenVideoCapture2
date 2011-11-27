using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenVideoCapture2
{
    public class Logging
    {
        private static volatile Logging instance;
        private static object syncRoot = new Object();

        private Logging() { }

        public static Logging Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Logging();
                        }
                    }
                }

                return instance;
            }
        }

        private string SavePath()
        {
            string savePath = Globals.MajorSilenceLocalAppDataDirectory;
            if (System.IO.Directory.Exists(savePath) == false)
            {
                System.IO.Directory.CreateDirectory(savePath);
            }

            savePath = System.IO.Path.Combine(savePath, "MajorSilence-ScreenVideoCapture2-Debug.txt");
            return savePath;

        }


        public void WriteLine(string msg)
        {
            WriteLine(msg, "UNKNOWN");
        }
        public void WriteLine(string msg, string category)
        {

            string filePath = SavePath();

            System.IO.File.AppendAllText(filePath, DateTime.Now.ToString() + System.Environment.NewLine);
            System.IO.File.AppendAllText(filePath, category + System.Environment.NewLine);
            System.IO.File.AppendAllText(filePath, msg + System.Environment.NewLine);
            System.IO.File.AppendAllText(filePath, System.Environment.NewLine + System.Environment.NewLine);

        }

        public void WriteLine(Exception value)
        {
            WriteLine(value, "UNKNOWN");
        }
        public void WriteLine(Exception value, string category)
        {
            WriteLine(value.Message + System.Environment.NewLine + value.StackTrace, category);
        }

    }
}
