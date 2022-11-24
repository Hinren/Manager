using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace ExtendedControls.Converters
{
    public class BoolVisibilityConverter : IValueConverter
    {

        //  METHODS

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visible = (bool)value;

            return visible ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility)value;

            switch (visibility)
            {
                case Visibility.Visible:
                    return true;

                case Visibility.Collapsed:
                case Visibility.Hidden:
                    return false;
            }

            return false;
        }

    }
}
