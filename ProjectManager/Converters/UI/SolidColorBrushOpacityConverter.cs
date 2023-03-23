using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media;

namespace ProjectManager.Converters.UI
{
    public class SolidColorBrushOpacityConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = (SolidColorBrush)value;
            var opacityValue = ((string)parameter) ?? string.Empty;
            var opacity = double.TryParse(opacityValue, out double convResult1) ? (double?)convResult1 : null;

            if (opacity == null || opacity > 1)
            {
                if (opacityValue.Contains(','))
                    opacityValue = opacityValue.Replace(',', '.');
                else if (opacityValue.Contains('.'))
                    opacityValue = opacityValue.Replace('.', ',');

                opacity = double.TryParse(opacityValue, out double convResult2) ? (double?)convResult2 : null;
            }

            return new SolidColorBrush(GetAlphaColor(brush.Color, opacity));
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get opacity value. </summary>
        /// <param name="brush"> Solid color brush. </param>
        /// <param name="opacity"> Opacity value. </param>
        /// <returns> Opacity value. </returns>
        private Color GetAlphaColor(Color color, double? opacity)
        {
            byte alpha = color.A;

            if (opacity.HasValue)
                alpha = (byte)(Math.Max(0d, Math.Min(1d, opacity.Value)) * 255);

            return Color.FromArgb(alpha, color.R, color.G, color.B);
        }

    }
}
