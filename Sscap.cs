using System;
using System.Runtime.InteropServices;
using System.Drawing;
using static System.Drawing.Graphics;
using static System.Drawing.Bitmap;
using System.Drawing.Imaging;
using System.Windows.Forms;
using static System.DateTime;


namespace ScreenShot
{
    class Sscap {
        
        // Main Method 
        static public void Main(String[] args) 
        { 

            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, 
                                                        Screen.PrimaryScreen.Bounds.Height))

            using (Graphics g = Graphics.FromImage(bmpScreenCapture))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0, 0,
                                bmpScreenCapture.Size,
                                CopyPixelOperation.SourceCopy);
                String stampedFileName = "ss" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".jpg";
                bmpScreenCapture.Save(stampedFileName, ImageFormat.Jpeg);
            }            

        } 
    }

}
