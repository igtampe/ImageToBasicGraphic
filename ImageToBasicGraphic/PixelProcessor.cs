using System;
using System.Drawing;

namespace Igtampe.ImageToBasicGraphic {
    public abstract class PixelProcessor {

        /// <summary>Holds a pair of DFData and Color</summary>
        public struct ColorPair {
            /// <summary>DF Data for this color</summary>
            public string Data;

            /// <summary>Color of the DF Data</summary>
            public Color color;

            public ColorPair(string ColorData,Color color) {
                Data = ColorData;
                this.color = color;
            }
        }
        
        public string Name { get; protected set; }

        /// <summary>Process a pixel and turn it into another pixel data</summary>
        /// <param name="Pixel"></param>
        /// <returns></returns>
        public abstract string Process(Color Pixel);

        /// <summary>
        /// Color Distance Calculator provided by FUBO on Stack Overflow<br></br><br></br>
        /// 
        /// See: https://stackoverflow.com/questions/3968179/compare-rgb-colors-in-c-sharp
        /// </summary>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public static double ColourDistance(Color e1,Color e2) {
            long rmean = ((long)e1.R + (long)e2.R) / 2;
            long r = (long)e1.R - (long)e2.R;
            long g = (long)e1.G - (long)e2.G;
            long b = (long)e1.B - (long)e2.B;
            return Math.Sqrt((((512 + rmean) * r * r) >> 8) + 4 * g * g + (((767 - rmean) * b * b) >> 8));
        }

    }
}