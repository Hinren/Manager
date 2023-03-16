using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManager.Converters.Data
{
    public class NullableBoolValueConverter : IValueConverter
    {

        private static readonly string None = "None";
        private static readonly string Enabled = "Enabled";
        private static readonly string Disabled = "Disabled";


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool? nBoolValue = (bool?)value;

            if (nBoolValue.HasValue)
                return nBoolValue.Value ? Enabled : Disabled;

            return None;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string)value;

            if (!string.IsNullOrEmpty(stringValue))
            {
                stringValue = stringValue.ToLower();

                if (stringValue == None.ToLower())
                    return null;

                if (stringValue == Enabled.ToLower())
                    return true;

                if (stringValue == Disabled.ToLower())
                    return false;
            }

            return null;
        }

    }
}
