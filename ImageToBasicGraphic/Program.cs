using System;
using System.IO;
using System.Drawing;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using ScreenTest;
using System.Diagnostics;
using Igtampe.BasicWindows;

namespace Igtampe.ImageToBasicGraphic {
    class Program {

        //"A:\Pictures\TestImage.png" "A:\Pictures\TestImage.DF" /DF

        private static PixelProcessor Processor;

        static void Main(string[] args) {try {DoIt(args);} catch(Exception E) {GuruMeditationErrorScreen.Show(E,false);}}

        /// <summary>Actually executes ITBG</summary>
        /// <param name="args"></param>
        public static void DoIt(string[] args) {

            if(args.Length == 2) {
                if(args[1].ToUpper()=="/BOTH") {

                    string Location = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("dll","exe");

                    //Launch DF on the other
                    Process.Start("CMD","/c start \"\" \"" + Location + "\" " + args[0] + " \"\" /DF");

                    //Do HC on this one
                    args = new string[] { args[0],"","/HC" };
                }
            }

            //Determine if the arguements are an acceptable length
            if(args.Length == 1) {
                //Assume it's a filename only. Create a new acceptable args array
                string Filename = args[0];
                args = new string[] {Filename,"","/HC"};
            }

            //Determine if the arguements are acceptable, if not display Help
            if(args.Length < 3) { Help(); return; }

            //Determine conversion mode.
            switch(args[2].ToUpper()) {
                case "/DF":
                    //DF mode
                    Processor = new DFPixelProcessor();
                    break;
                case "/HC":
                    //HiColor Mode
                    Processor = new HiColorPixelProcessor();
                    break;
                default:
                    Help();
                    return;
            }

            //ok lets open the de-esta cosa
            Bitmap img = new(args[0]);
            string[] GraphicContents = new string[img.Height];

            int Pixels = img.Width * img.Height;

            bool Proceed = false ;

            //Try to resize the console to fit the image
            if(args.Length == 4) { if(args[3].ToUpper() == "/NORESIZE") { Proceed = true; } } 
            else { Proceed = TryResize((img.Width * 2) + 1,img.Height + 1); }

            while(!Proceed) {
                switch(DialogBox.ShowDialogBox(BasicWindows.WindowElements.Icon.IconType.EXCLAMATION,DialogBox.DialogBoxButtons.AbortRetryIgnore,"The image is too big to be displayed at this console font size.")) {
                    case DialogBox.DialogBoxResult.Retry:
                        Proceed = TryResize((img.Width * 2) + 1,img.Height + 1);
                        break;
                    case DialogBox.DialogBoxResult.Ignore:
                        Proceed = true;
                        break;
                    case DialogBox.DialogBoxResult.Nothing:
                    case DialogBox.DialogBoxResult.OK:
                    case DialogBox.DialogBoxResult.Cancel:
                    case DialogBox.DialogBoxResult.Yes:
                    case DialogBox.DialogBoxResult.No:
                    case DialogBox.DialogBoxResult.Abort:
                    default:
                        return;
                }
            }

            RenderUtils.SetPos(0,0);

            //Start a stopwatch for time measurement
            Stopwatch S = new();
            S.Start();

            //Do the process
            for(int y = 0; y < img.Height; y++) {
                GraphicContents[y] = "";
                for(int x = 0; x < img.Width; x++) {
                    //Define a few things for the console title progress thing
                    int CurrentPixel = (img.Width * y) + x;
                    int Percentage = Convert.ToInt32(((CurrentPixel + 0.0) / Pixels) * 100);
                    Console.Title = "ItBG [V 1.0]:  Converting " + args[0].Split("\\")[^1] + " to " + args[1].Split("\\")[^1] + ", (" + img.Width + "x" + img.Height + ") " + Percentage + "% (" + CurrentPixel + "/" + Pixels + ") Complete, Using " + Processor.Name + Spinner();
                    
                    //Process the pixel
                    GraphicContents[y] += Processor.Process(img.GetPixel(x,y));
                }
                GraphicContents[y] = GraphicContents[y].TrimEnd('-');
                Console.WriteLine();
            }

            //Stop the stopwatch
            S.Stop();

            //Dispose of the image
            img.Dispose();

            //time per pixel
            double TimePerPixel = S.ElapsedMilliseconds / (Pixels + 0.0);
            Console.Title = "ItBG [V 1.0]:  Done! Approximately " + Convert.ToInt32(S.Elapsed.TotalSeconds) + " Second(s) (" + TimePerPixel + " ms/pixel). Press a key to close";

            if(!string.IsNullOrWhiteSpace(args[1])) { File.WriteAllLines(args[1],GraphicContents); }

            RenderUtils.Pause();
          


        }

        /// <summary>Tries to resize the screen to the speciifed size.</summary>
        /// <param name="Width">Width (In Characters)</param>
        /// <param name="Height">Height (In Characters)</param>
        /// <returns>True if done, false otherwise</returns>
        public static bool TryResize(int Width, int Height) {
            Width = Math.Max(Width,60);
            Height = Math.Max(Height,30);
            if(Width > Console.LargestWindowWidth) { return false; }
            if(Height > Console.LargestWindowHeight) { return false; }
            try {
                RenderUtils.ResizeConsole(Width,Height);
                return true;
            } catch(Exception) {return false;}
        }


        /// <summary>Shows Help screen</summary>
        public static void Help() {

            Console.WriteLine("Image To BasicGraphic File Converter [Version 1.0]\n" +
                "(C)2020 Igtampe, No Rights reserved.\n" +
                "\n" +
                "Usage: [Image] [Export] [Mode]\n" +
                "\n" +
                "Image  : Filename of the Image you wish to convert\n" +
                "Export : Filename to which the image will be saved to once converted\n" +
                "Mode   : Mode to convert. /DF for DrawFile and /HC HiColor Graphic");

        }

        /// <summary>Recallibs the renderers. This was used during the first run of ITBG. It is no longer used.</summary>
        private static void Recallib() {
            RenderUtils.Echo("Image To Basic Graphic Recallibration Screen\n\nPlease maximize this window and set font size to 8x8");
            RenderUtils.Pause();
            Console.Clear();

            //draw everything
            for(int i = 0; i < 16; i++) {BasicGraphic.DrawColorString(IntToHex(i));}
            RenderUtils.Echo("\n 16 colors \n\n");

            int C=0;
            for(int S = 0; S < 3; S++) {
                for(int B = 0; B < 16; B++) {
                    for(int F = 0; F < 16; F++) {
                        HiColorGraphic.HiColorDraw(IntToHex(B) + IntToHex(F) + IntToHex(S));
                        C++; //haha 
                    }
                    Console.WriteLine();
                }
            }


            RenderUtils.Echo("\n " + C + " Colors");

            //Now time for calibration
            Bitmap bit = new(PrintScreen.CaptureScreen());

            string Output = "";
            Output += "public static readonly ColorPair[] Pairs = {\n";

            Console.WriteLine("Callibration time");

            for(int i = 0; i < 16; i++) {
                BasicGraphic.DrawColorString(IntToHex(i));
                Output += "new ColorPair(\"" + IntToHex(i) + "\",ColorTranslator.FromHtml(\""+GetConsoleCharColor(i,0,bit)+"\")),\n";
                Console.WriteLine(" " + IntToHex(i) + ": " + GetConsoleCharColor(i,0,bit));
            }

            RenderUtils.Pause();

            Output += "};\n\n";
            String Output2 = "public static readonly ColorPair[] Pairs = {\n";
            C = 0;

            for(int S = 0; S < 3; S++) {
                for(int B = 0; B < 16; B++) {
                    for(int F = 0; F < 16; F++) {
                        if(!Output2.Contains(GetConsoleCharColor(F,(16 * S) + B + 3,bit))) {
                            HiColorGraphic.HiColorDraw(IntToHex(B) + IntToHex(F) + IntToHex(S));
                            Output2 += "new ColorPair(\"" + IntToHex(B) + IntToHex(F) + IntToHex(S) + "\",ColorTranslator.FromHtml(\"" + GetConsoleCharColor(F,(16 * S) + B + 3,bit) + "\")),\n";
                            Console.WriteLine(" " + IntToHex(B) + IntToHex(F) + IntToHex(S) + ": " + GetConsoleCharColor(F,(16 * S) + B + 3,bit));
                            C++; //haha 
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n\n" + C + " Colors");
            Output2 += "};\n\n";

            File.WriteAllLines("DFCallibData.txt",Output.Split('\n'));
            File.WriteAllLines("HCCallibData.txt",Output2.Split('\n'));
        }

        /// <summary>Gets a console char for Callibration</summary>
        /// <param name="L">Left coord</param>
        /// <param name="T">Top coord</param>
        /// <param name="Bit">Image</param>
        /// <returns></returns>
        private static String GetConsoleCharColor(int L,int T,Bitmap Bit) {
            int R=0;
            int G=0;
            int B=0;

            L *= 8;
            T *= 8;


            //Add everything
            for(int x = L; x < 8+L; x++) {
                for(int y = T+23; y < 8+T+23; y++) {
                    R += Bit.GetPixel(x,y).R;
                    G += Bit.GetPixel(x,y).G;
                    B += Bit.GetPixel(x,y).B;
                }
            }

            return ColorTranslator.ToHtml(Color.FromArgb(R / 64,G / 64,B / 64)) ;

        }

        /// <summary>Turns int to a hexadecimal numbe</summary>
        /// <param name="I"></param>
        /// <returns></returns>
        public static string IntToHex(int I) { return I.ToString("X"); }

        /// <summary>Spin variable for the spinner which is now three dots</summary>
        private static int spin=-1;

        /// <summary>Function to get current spinner sprite</summary>
        /// <returns>Spinner sprite</returns>
        public static string Spinner() {
            spin++;

            switch(spin) {
                case 0:
                    return ".";
                case 1:
                    return "..";
                case 2:
                    return "...";
                default:
                    spin = -1;
                    return "....";
            }
        }

    }
}
