using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace ProjectManager.Converters.UI
{
    public class BoolVisibilityConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolean = (bool)value;
            var hiddenMode = parameter as bool?;

            return boolean
                ? Visibility.Visible
                : hiddenMode.HasValue && hiddenMode.Value
                    ? Visibility.Hidden
                    : Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;

            switch (visibility)
            {
                case Visibility.Collapsed:
                    return false;

                case Visibility.Hidden:
                    return false;

                case Visibility.Visible:
                default:
                    return true;
            }
        }

    }
}
