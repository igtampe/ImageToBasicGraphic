using System;
using System.IO;
using System.Drawing;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;
using ScreenTest;

namespace Igtampe.ImageToBasicGraphic {
    class Program {

        //"A:\Pictures\TestImage.png" "A:\Pictures\TestImage.DF" /DF

        private static PixelProcessor Processor;

        static void Main(string[] args) {
            if(args.Length != 3) { Help(); return; }

            switch(args[2]) {
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
                Bitmap img = new Bitmap(args[0]);
                string[] GraphicContents = new string[img.Height];

                RenderUtils.ResizeConsole(Math.Min((img.Width * 2) + 10,Console.LargestWindowWidth),Math.Min(img.Height + 5,Console.LargestWindowHeight));

                for(int y = 0; y < img.Height; y++) {
                    GraphicContents[y] = "";
                 for(int x = 0; x < img.Width; x++) { GraphicContents[y] += Processor.Process(img.GetPixel(x,y)); }
                    GraphicContents[y] = GraphicContents[y].TrimEnd('-');
                    Console.WriteLine();
                //Let's hope this works... it probably won't
            }


            File.WriteAllLines(args[1],GraphicContents);
            
        }

        /// <summary>Shows Help screen</summary>
        public static void Help() { }

        /// <summary>Recallibs the renderers</summary>
        public static void Recallib() {
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
            Bitmap bit = new Bitmap(PrintScreen.CaptureScreen());

            string Output = "";
            Output += "public static readonly ColorPair[] Pairs = {\n";

            Console.WriteLine("Callibration time");

            for(int i = 0; i < 16; i++) {
                BasicGraphic.DrawColorString(IntToHex(i));
                Output += "new ColorPair(\"" + IntToHex(i) + "\",ColorTranslator.FromHtml(\""+getConsoleCharColor(i,0,bit)+"\")),\n";
                Console.WriteLine(" " + IntToHex(i) + ": " + getConsoleCharColor(i,0,bit));
            }

            RenderUtils.Pause();

            Output += "};\n\n";
            String Output2 = "public static readonly ColorPair[] Pairs = {\n";
            C = 0;

            for(int S = 0; S < 3; S++) {
                for(int B = 0; B < 16; B++) {
                    for(int F = 0; F < 16; F++) {
                        if(!Output2.Contains(getConsoleCharColor(F,(16 * S) + B + 3,bit))) {
                            HiColorGraphic.HiColorDraw(IntToHex(B) + IntToHex(F) + IntToHex(S));
                            Output2 += "new ColorPair(\"" + IntToHex(B) + IntToHex(F) + IntToHex(S) + "\",ColorTranslator.FromHtml(\"" + getConsoleCharColor(F,(16 * S) + B + 3,bit) + "\")),\n";
                            Console.WriteLine(" " + IntToHex(B) + IntToHex(F) + IntToHex(S) + ": " + getConsoleCharColor(F,(16 * S) + B + 3,bit));
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

        private static String getConsoleCharColor(int L,int T,Bitmap Bit) {
            int R=0;
            int G=0;
            int B=0;

            L = L * 8;
            T = T * 8;


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

        public static string IntToHex(int I) { return I.ToString("X"); }


    }
}
