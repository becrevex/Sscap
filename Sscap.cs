using System;
using System.IO;
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
            String[] techniques = new String[12] {"Initial Access", "Execution", "Persistence", "Privilege Escalation", "Defense Evasion",
                        "Credential Access", "Discovery", "Lateral Movement", "Collection", "C2", "Exfiltration", "Impact"};

            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))

            using (Graphics g = Graphics.FromImage(bmpScreenCapture))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                Screen.PrimaryScreen.Bounds.Y,
                                0, 0,
                                bmpScreenCapture.Size,
                                CopyPixelOperation.SourceCopy);
                String stampedFileName = "ss" + DateTime.Now.ToString("yyyyddM-HHmmss") + ".jpg";
                if (args.Length == 1) {
                    if (args[0] == "-p") {
                        Console.Write("Tool: ");
                        String ssTool = Console.ReadLine();
                        Console.Write("Technique: ");
                        String ssTechnique = Console.ReadLine();
                        Console.Write("Note: ");
                        String ssNote = Console.ReadLine();

                        using (StreamWriter w = File.AppendText("pentest.txt")) {
                            Log(ssNote, stampedFileName, ssTool, ssTechnique, w);
                        }
                        bmpScreenCapture.Save(stampedFileName, ImageFormat.Jpeg);
                        Console.WriteLine("Screen shot captured.");
                        Console.WriteLine("Pentest log entry created.");
                        Console.WriteLine("Filename: " + stampedFileName.ToString());                        
                    }
                    if (args[0] == "-q") {
                        bmpScreenCapture.Save(stampedFileName, ImageFormat.Jpeg);
                        Console.WriteLine("Screen shot captured.");
                        Console.WriteLine("Filename: " + stampedFileName.ToString()); 
                    }
                    if ((args[0] == "--interactive") || (args[0] == "-i")) {
                        Console.WriteLine("Starting Sscap Interactive Mode.  Press ESC to quit.");
                            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
                            {
                                Console.WriteLine("");
                                bmpScreenCapture.Save(stampedFileName, ImageFormat.Jpeg);
                                Console.WriteLine("Screen shot captured.");
                                Console.WriteLine("Filename: " + stampedFileName.ToString());
                            }
                        Console.WriteLine("Interactive mode finished.  Quitting.");
                    }
                } else {
                    Console.WriteLine("\nScreen Shot Capture (Sscap) [Version 1.0.334]");
                    Console.WriteLine("(c) 2020 Cygiene Solutions.  All rights reserved.");
                    Console.WriteLine("");
                    Console.WriteLine("Usage: Sscap.exe [-q] [-p] [-i|-interactive]");
                    Console.WriteLine("     -q     Quick mode --takes a quick shot, no context.");
                    Console.WriteLine("     -p     Pentest screen shot with tracking capabilities. Writes to log file.");
                    Console.WriteLine("     -i     Interactive mode.  Waits for button press and snaps a shot.");

                }

            }            

        } 

        public static void Log(string ssNote, string fileName, string ssTool, string ssTechnique, TextWriter w)
        {
            w.Write("\r\nScreenshot Entry:    ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"Filename:            {fileName}");
            w.WriteLine($"Tool used:           {ssTool}");
            w.WriteLine();
            w.WriteLine($"Description:          \n {ssNote}");
            
            //w.WriteLine ("-------------------------------");
        }


    }

}
