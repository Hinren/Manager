using chkam05.Tools.ControlsEx.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectManager.Utilities
{
    public static class ColorHelper
    {

        //  CONST

        private static readonly double LUMINANCE_R = 0.299;
        private static readonly double LUMINANCE_G = 0.587;
        private static readonly double LUMINANCE_B = 0.114;


        //  METHODS

        #region COLOR CONVERSION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert color to Hexadecimal color code. </summary>
        /// <param name="color"> Color object to convert. </param>
        /// <returns> Hexadecimal color code. </returns>
        public static string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Conver Hexadecimal color code to color. </summary>
        /// <param name="colorCode"> Hexadecimal color code. </param>
        /// <param name="defaultResult"> Default result color. </param>
        /// <returns> Color object. </returns>
        public static Color ColorFromHex(string colorCode, Color? defaultResult = null)
        {
            try
            {
                return (Color)ColorConverter.ConvertFromString(colorCode);
            }
            catch (Exception)
            {
                if (defaultResult.HasValue)
                    return defaultResult.Value;
                return System.Windows.Media.Colors.Transparent;
            }
        }

        #endregion COLOR CONVERSION METHODS 

        #region COLORS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Inverse color. </summary>
        /// <param name="color"> Color. </param>
        /// <returns> Inverted color. </returns>
        public static Color InverseColor(Color color)
        {
            return Color.FromArgb(
                color.A,
                (byte)(255 - color.R),
                (byte)(255 - color.G),
                (byte)(255 - color.B));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update AHSL color. </summary>
        /// <param name="ahslColor"> AHSL color to update. </param>
        /// <param name="alpha"> Alpha. </param>
        /// <param name="hue"> Hue. </param>
        /// <param name="saturation"> Saturation. </param>
        /// <param name="lightness"> Lightness. </param>
        /// <returns> Updated AHSL color. </returns>
        public static AHSLColor UpdateColor(AHSLColor ahslColor, byte? alpha = null, int? hue = null, int? saturation = null, int? lightness = null)
        {
            return new AHSLColor(
                alpha.HasValue ? alpha.Value : ahslColor.A,
                hue.HasValue ? hue.Value : ahslColor.H,
                saturation.HasValue ? saturation.Value : ahslColor.S,
                lightness.HasValue ? lightness.Value : ahslColor.L);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update RGB color. </summary>
        /// <param name="color"> RGB color to update. </param>
        /// <param name="a"> Alpha. </param>
        /// <param name="r"> Red component. </param>
        /// <param name="g"> Green component. </param>
        /// <param name="b"> Blue component. </param>
        /// <returns> Updated RGB color. </returns>
        public static Color UpdateColor(Color color, byte? a = null, byte? r = null, byte? g = null, byte? b = null)
        {
            return Color.FromArgb(
                a.HasValue ? a.Value : color.A,
                r.HasValue ? r.Value : color.R,
                g.HasValue ? g.Value : color.G,
                b.HasValue ? b.Value : color.B);
        }

        #endregion COLORS MANAGEMENT METHODS

        #region CONSTRAST METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Find color that contrasts with the input color. </summary>
        /// <param name="color"> Color. </param>
        /// <returns> Contrast color. </returns>
        public static Color GetContrastColor(Color color)
        {
            double luminance = (LUMINANCE_R * color.R + LUMINANCE_G * color.G
                + LUMINANCE_B * color.B) / 255;

            if (luminance > 0.5)
                return System.Windows.Media.Colors.Black;
            else
                return System.Windows.Media.Colors.White;
        }

        #endregion CONTRAST METHODS

    }
}
