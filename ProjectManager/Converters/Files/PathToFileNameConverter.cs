using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.IO;

namespace ProjectManager.Converters.Files
{
    public class PathToFileNameConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var strValue = (string)value;

            if (IsValidPath(strValue))
                return Path.GetFileNameWithoutExtension(strValue);

            return string.Empty;
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

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if path to file or directory is valid. </summary>
        /// <param name="path"> Path to file or directory. </param>
        /// <returns> True - path is valid; False - otherwise. </returns>
        private bool IsValidPath(string path)
        {
            return !string.IsNullOrEmpty(path) && (Directory.Exists(path) || File.Exists(path));
        }

        #endregion UTILITY METHODS

    }
}
