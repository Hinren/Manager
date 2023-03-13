using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManager.Converters.Data
{
    public class EnumValueConverter<T> : IValueConverter
    {

        //  VALUES

        public virtual T DefaultKey { get => default(T); }
        public virtual string DefaultValue { get => string.Empty; }
        public virtual Dictionary<T, string> ValuesDict { get => null; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int stringCase = int.TryParse(parameter as string, out int caseValue) ? caseValue : 0;

            var enumValue = (T)value;
            return (ValuesDict?.TryGetValue(enumValue, out string name) ?? false) 
                ? GetValue(name, stringCase) : GetValue(DefaultValue, stringCase);
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int stringCase = int.TryParse(parameter as string, out int caseValue) ? caseValue : 0;

            var stringValue = (string)value;
            return (ValuesDict?.Any(kvp => GetValue(kvp.Value, stringCase) == GetValue(stringValue, stringCase)) ?? false)
                ? ValuesDict.FirstOrDefault(kvp => GetValue(kvp.Value, stringCase) == GetValue(stringValue, stringCase))
                : default(T);
        }

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Get value ignoring string case variant. </summary>
        /// <param name="value"> Value. </param>
        /// <param name="stringCase"> 0 - No case, 1 - Lower case, 2 - Upper case. </param>
        /// <param name="upperCase"> Get value in upper case. </param>
        /// <returns> Value in case variant or default. </returns>
        private string GetValue(string value, int stringCase)
        {
            return stringCase == 1 ? value.ToLower()
                : stringCase == 2 ? value.ToUpper()
                : value;
        }

        #endregion UTILITIES

    }
}
