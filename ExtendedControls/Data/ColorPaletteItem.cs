using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ExtendedControls.Data
{
    public class ColorPaletteItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Color color = System.Windows.Media.Colors.Transparent;
        private string name = "Transparent";


        //  GETTERS & SETTERS

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
                OnPropertyChanged(nameof(ColorCode));
            }
        }

        public string ColorCode
        {
            get => $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteItem class constructor. </summary>
        /// <param name="color"> Color definition. </param>
        /// <param name="colorName"> Color name. </param>
        public ColorPaletteItem(Color color, string colorName)
        {
            Color = color;
            Name = colorName;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteItem class constructor. </summary>
        /// <param name="colorCode"> Hexadecimal color code. </param>
        /// <param name="colorName"> Color name. </param>
        public ColorPaletteItem(string colorCode, string colorName)
        {
            try
            {
                Color = (Color)ColorConverter.ConvertFromString(colorCode);
            }
            catch (Exception)
            {
                Color = System.Windows.Media.Colors.Transparent;
            }

            Name = colorName;
        }

        #endregion CLASS METHODS

        #region OVERRIDED METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if ColorPaletteItems are equal. </summary>
        /// <param name="lhs"> Left side value to compare. </param>
        /// <param name="rhs"> Right side value to compare. </param>
        /// <returns> True - if values are equal; False - otherwise. </returns>
        public static bool operator ==(ColorPaletteItem lhs, ColorPaletteItem rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if ColorPaletteItems are not equal. </summary>
        /// <param name="lhs"> Left side value to compare. </param>
        /// <param name="rhs"> Right side value to compare. </param>
        /// <returns> True - if values are not equal; False - otherwise. </returns>
        public static bool operator !=(ColorPaletteItem lhs, ColorPaletteItem rhs) => !(lhs == rhs);

        //  --------------------------------------------------------------------------------
        /// <summary> Determines whether the specified object is equal to the current object. </summary>
        /// <param name="obj"> The object to compare with the current object. </param>
        /// <returns> True if the specified object is equal to the current object; False - otherwise. </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(ColorPaletteItem))
                return false;

            if (((ColorPaletteItem)obj).Color == this.Color)
                return true;

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a string that represents the current object. </summary>
        /// <returns> A string that represents the current object. </returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Name) ? ColorCode : Name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Serves as the default hash function. </summary>
        /// <returns> A hash code for the current object. </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion OVERRIDED METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
