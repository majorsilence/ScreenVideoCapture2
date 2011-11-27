using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

//http://www.geekpedia.com/tutorial146_Get-screen-cursor-coordinates.html
using System.Runtime.InteropServices;

namespace ScreenVideoCapture2
{

   


    public class MousePosition
    {
        // GetCursorPos() makes everything possible
        protected static long totalPixels = 0;
        protected static int currX;
        protected static int currY;
        protected static int diffX;
        protected static int diffY;

        private const Int32 CURSOR_SHOWING = 0x00000001;
        
        
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(ref System.Drawing.Point lpPoint);

        [DllImport("user32.dll", EntryPoint = "GetCursorInfo")]
        private static extern bool GetCursorInfo(out CURSORINFO pci);

        [DllImport("gdi32.dll")]
        private static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("user32.dll", EntryPoint = "CopyIcon")]
        private static extern IntPtr CopyIcon(IntPtr hIcon);

        [DllImport("user32.dll", EntryPoint = "GetIconInfo")]
        private static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);


        [StructLayout(LayoutKind.Sequential)]
        private struct ICONINFO
        {
            public bool fIcon;         // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies 
            public Int32 xHotspot;     // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot 
            public Int32 yHotspot;     // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot 
            public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon, 
            public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this 
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public Int32 x;
            public Int32 y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CURSORINFO
        {
            public Int32 cbSize;        // Specifies the size, in bytes, of the structure. 
            public Int32 flags;         // Specifies the cursor state. This parameter can be one of the following values:
            public IntPtr hCursor;          // Handle to the cursor. 
            public POINT ptScreenPos;       // A POINT structure that receives the screen coordinates of the cursor. 
        }



        
        private void Reset()
        {
            totalPixels = 0;
        }
        
        public System.Drawing.Point Position()
        {
            System.Drawing.Point defPnt = new System.Drawing.Point();
            GetCursorPos(ref defPnt);
            return defPnt;
        }


        public Bitmap CaptureCursor(ref int x, ref int y)
        {
            Bitmap bmp;
            IntPtr hicon;
            CURSORINFO ci = new CURSORINFO();
            ICONINFO icInfo;
            ci.cbSize = Marshal.SizeOf(ci);
            if (GetCursorInfo(out ci))
            {
                if (ci.flags == CURSOR_SHOWING)
                {
                    
                    hicon = CopyIcon(ci.hCursor);

                    if (hicon != IntPtr.Zero)
                    {
                        if (GetIconInfo(hicon, out icInfo))
                        {

                            // See: http://www.codeproject.com/KB/cs/DesktopCaptureWithMouse.aspx
                            if (icInfo.hbmMask != IntPtr.Zero)
                            {
                                DeleteObject(icInfo.hbmMask);
                            }
                            if(icInfo.hbmColor != IntPtr.Zero)
                            {
                                DeleteObject(icInfo.hbmColor);
                            }

                            x = ci.ptScreenPos.x - ((int)icInfo.xHotspot);
                            y = ci.ptScreenPos.y - ((int)icInfo.yHotspot);
                            Icon ic = Icon.FromHandle(hicon);
                            bmp = ic.ToBitmap();

                            ic.Dispose();

                            return bmp;
                        }
                    }
                }
            }
            return null;
        }

        //public Bitmap CaptureCursor2(ref int x, ref int y)
        //{

        //    Cursor c = new Cursor(

        //    x = Cursor.Current.HotSpot.X;
        //    y = Cursor.Current.HotSpot.Y;

        //    Rectangle rect = new Rectangle(
        //    Cursor.Position.X - Cursor.Current.HotSpot.X,
        //    Cursor.Position.Y - Cursor.Current.HotSpot.Y,
        //    Cursor.Current.Size.Width,
        //    Cursor.Current.Size.Height);

        //        Cursor.Current.Draw(g,rect);

        //}


    }
}
