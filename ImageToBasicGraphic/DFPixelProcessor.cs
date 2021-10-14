using System.Drawing;
using Igtampe.BasicGraphics;
using Igtampe.BasicRender;

namespace Igtampe.ImageToBasicGraphic {
    /// <summary>DrawFile Pixel Processor</summary>
    public class DFPixelProcessor: PixelProcessor {

        /// <summary>Pairs of colors from DF format to Color</summary>
        public static readonly ColorPair[] Pairs = {
            new ColorPair("00",ColorTranslator.FromHtml("#0C0C0C")),
            new ColorPair("11",ColorTranslator.FromHtml("#0037DA")),
            new ColorPair("22",ColorTranslator.FromHtml("#13A10E")),
            new ColorPair("33",ColorTranslator.FromHtml("#3A96DD")),
            new ColorPair("44",ColorTranslator.FromHtml("#C50F1F")),
            new ColorPair("55",ColorTranslator.FromHtml("#881798")),
            new ColorPair("66",ColorTranslator.FromHtml("#C19C00")),
            new ColorPair("77",ColorTranslator.FromHtml("#CCCCCC")),
            new ColorPair("88",ColorTranslator.FromHtml("#767676")),
            new ColorPair("99",ColorTranslator.FromHtml("#3B78FF")),
            new ColorPair("AA",ColorTranslator.FromHtml("#16C60C")),
            new ColorPair("BB",ColorTranslator.FromHtml("#61D6D6")),
            new ColorPair("CC",ColorTranslator.FromHtml("#E74856")),
            new ColorPair("DD",ColorTranslator.FromHtml("#B4009E")),
            new ColorPair("EE",ColorTranslator.FromHtml("#F9F1A5")),
            new ColorPair("FF",ColorTranslator.FromHtml("#F2F2F2"))
        };

        /// <summary>Empty pixel for this processor</summary>
        public override string Empty { get { return "  "; } }

        /// <summary>Creates a DrawFile pixel processor</summary>
        public DFPixelProcessor() { Name = "DrawFile Pixel Processor"; }

        protected override string Process(Color Pixel) {
            //Return if the pixel is transparent (or close enough to it)
            if (Pixel.A <= 20) { return Empty; }

            //Mira esto es lo que va a pasar
            ColorPair ClosestPair = Pairs[0];
            double Difference = ColourDistance(Pixel, Pairs[0].Color);

            foreach (ColorPair pair in Pairs) {
                double NewDifference = ColourDistance(Pixel, pair.Color);
                if (NewDifference < Difference) { ClosestPair = pair; Difference = NewDifference; }
            }

            return ClosestPair.Data;
        }

        public override string JoinArray(string[] PixelArray) {
            return string.Join("", PixelArray);
        }

        public override void DrawPixel(string ColorString) {
            BasicGraphic.DrawColorString(ColorString); 
        }

    }
}
