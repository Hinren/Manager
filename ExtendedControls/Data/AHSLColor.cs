using System;
using System.Windows.Media;

namespace ExtendedControls.Data
{
    public class AHSLColor
    {

        //  CONST

        public const int HUE_MAX = 1530;
        public const int HUE_MIN = 0;
        public const double HUE_DMAX = 1530;
        public const double HUE_DMIN = 0;
        public const int LIGHTNESS_MAX = 100;
        public const int LIGHTNESS_MIN = 0;
        public const int SATURATION_MAX = 100;
        public const int SATURATION_MIN = 0;


        //  VARIABLES

        private int hue = 0;
        private int saturation = 50;
        private int lightness = 50;

        public byte A { get; set; } = 255;


        //  GETTERS & SETTERS

        public int H
        {
            get => hue;
            set => hue = Math.Max(Math.Min(value, HUE_MAX), HUE_MIN);
        }

        public int S
        {
            get => saturation;
            set => saturation = Math.Max(Math.Min(value, SATURATION_MAX), SATURATION_MIN);
        }

        public int L
        {
            get => lightness;
            set => lightness = Math.Max(Math.Min(value, LIGHTNESS_MAX), LIGHTNESS_MIN);
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Alpha Hue Saturation Lightness color model class constructor. </summary>
        public AHSLColor()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Alpha Hue Saturation Lightness color model class constructor. </summary>
        /// <param name="hue"> Hue. </param>
        /// <param name="saturation"> Saturation. </param>
        /// <param name="lightness"> Lightness. </param>
        public AHSLColor(int hue, int saturation, int lightness)
        {
            A = 255;
            H = hue;
            S = saturation;
            L = lightness;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Alpha Hue Saturation Lightness color model class constructor. </summary>
        /// <param name="alpha"> Alpha channel. </param>
        /// <param name="hue"> Hue. </param>
        /// <param name="saturation"> Saturation. </param>
        /// <param name="lightness"> Lightness. </param>
        public AHSLColor(byte alpha, int hue, int saturation, int lightness)
        {
            A = alpha;
            H = hue;
            S = saturation;
            L = lightness;
        }

        #endregion CLASS METHODS

        #region CONVERSION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create AHLS color from basic color. </summary>
        /// <param name="color"> Color. </param>
        /// <returns> AHLS Color. </returns>
        public static AHSLColor FromColor(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            double delta = max - min;

            double l = (max + min) / 2.0;

            if (delta == 0)
            {
                return new AHSLColor(color.A, 0, (int)(l * 100), 0);
            }
            else
            {
                double s = (l <= 0.5) ? (delta / (max + min)) : (delta / (2 - max - min));

                double h;

                if (r == max)
                {
                    h = ((g - b) / 6) / delta;
                }
                else if (g == max)
                {
                    h = (1.0 / 3) + ((b - r) / 6) / delta;
                }
                else
                {
                    h = (2.0 / 3) + ((r - g) / 6) / delta;
                }

                if (h < 0)
                    h += 1;

                if (h > 1)
                    h -= 1;

                return new AHSLColor(color.A, (int)Math.Round(h * 1530), (int)(s * 100), (int)(l * 100));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert AHLS color to basic color. </summary>
        /// <returns> Color. </returns>
        public Color ToColor()
        {
            double h = H / 1530.0;
            double l = L / 100.0;
            double s = S / 100.0;

            if (s == 0)
            {
                return Color.FromArgb(A, (byte)(l * 255), (byte)(l * 255), (byte)(l * 255));
            }
            else
            {
                double v2 = (l < 0.5) ? (l * (1.0 + s)) : ((l + s) - (l * s));
                double v1 = 2 * l - v2;

                double hr = HueToRGB(v1, v2, h + (1.0 / 3.0));
                double hg = HueToRGB(v1, v2, h);
                double hb = HueToRGB(v1, v2, h - (1.0 / 3.0));

                return Color.FromArgb(A, (byte)(hr * 255), (byte)(hg * 255), (byte)(hb * 255));
            }
        }

        #endregion CONVERSION METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert HUE AHLS color component to RGB color component. </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <param name="hue"></param>
        /// <returns> RGB color component. </returns>
        private static double HueToRGB(double v1, double v2, double hue)
        {
            if (hue < 0)
                hue += 1.0;

            if (hue > 1)
                hue -= 1.0;

            if ((6.0 * hue) < 1)
                return (v1 + (v2 - v1) * 6.0 * hue);

            if ((2.0 * hue) < 1)
                return v2;

            if ((3.0 * hue) < 2)
                return (v1 + (v2 - v1) * ((2.0 / 3.0) - hue) * 6.0);

            return v1;
        }

        #endregion UTILITY METHODS

    }
}
