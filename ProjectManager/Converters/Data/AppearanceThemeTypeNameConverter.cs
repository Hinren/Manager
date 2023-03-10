using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using ProjectManager.Data.Configuration.Static;

namespace ProjectManager.Converters.Data
{
    public class AppearanceThemeTypeNameConverter : IValueConverter
    {

        //  CONST

        private static string _unknownValue = "Unknown value";

        private static Dictionary<AppearanceThemeType, string> _namesDict = new Dictionary<AppearanceThemeType, string>()
        {
            { AppearanceThemeType.LIGHT, "Light" },
            { AppearanceThemeType.DARK, "Dark" },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var appearanceThemeType = (AppearanceThemeType)value;

            return _namesDict.TryGetValue(appearanceThemeType, out string name) ? name : _unknownValue;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
