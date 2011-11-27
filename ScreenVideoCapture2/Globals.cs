using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScreenVideoCapture2
{
    class Globals
    {
        private Globals() { }

        public static string MajorSilenceLocalAppDataDirectory
        {
            get
            {
                string msDir = null;
                msDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                msDir = System.IO.Path.Combine(msDir, "MajorSilence");
                return msDir;
            }
        }


    }
}
