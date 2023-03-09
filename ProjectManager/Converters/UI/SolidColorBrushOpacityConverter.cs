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
        /// <summary> Converts a value. </summary>
        /// <param name="value"> Value produced by the binding source. </param>
        /// <param name="targetType"> Type of the binding target property. </param>
        /// <param name="parameter"> Converter parameter to use. </param>
        /// <param name="culture"> Culture to use in the converter. </param>
        /// <returns> Converted value. If the method returns null, the valid null value is used. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = (SolidColorBrush)value;
            var opacity = double.TryParse((string)parameter, out double convResult) ? (double?)convResult : null;

            return new SolidColorBrush(brush.Color) { Opacity = GetOpacity(brush, opacity) };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Converts a value. </summary>
        /// <param name="value"> Value that is produced by the binding target. </param>
        /// <param name="targetType"> Type to convert to. </param>
        /// <param name="parameter"> Converter parameter to use. </param>
        /// <param name="culture"> Culture to use in the converter. </param>
        /// <returns> Converted value. If the method returns null, the valid null value is used. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get opacity value. </summary>
        /// <param name="brush"> Solid color brush. </param>
        /// <param name="opacity"> Opacity value. </param>
        /// <returns> Opacity value. </returns>
        private double GetOpacity(SolidColorBrush brush, double? opacity)
        {
            if (opacity.HasValue)
                return Math.Max(0d, Math.Min(1d, opacity.Value));

            return brush.Opacity;
        }

    }
}
