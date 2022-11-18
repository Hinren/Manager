using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ExtendedControls.Converters
{
    public class CornerRadiusSideConverter : IValueConverter
    {

        //  CONST

        public const string LeftSide = "Left";
        public const string TopSide = "Top";
        public const string RightSide = "Right";
        public const string BottomSide = "Bottom";


        //  METHODS

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cornerRadius = (CornerRadius)value;
            var side = parameter.ToString();

            switch (side)
            {
                case LeftSide:
                    return new CornerRadius(cornerRadius.TopLeft, 0, 0, cornerRadius.BottomLeft);

                case RightSide:
                    return new CornerRadius(0, cornerRadius.TopRight, cornerRadius.BottomRight, 0);

                case BottomSide:
                    return new CornerRadius(0, 0, cornerRadius.BottomRight, cornerRadius.BottomLeft);

                case TopSide:
                default:
                    return new CornerRadius(cornerRadius.TopLeft, cornerRadius.TopRight, 0, 0);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cornerRadius = (CornerRadius)value;
            var topLeft = cornerRadius.TopLeft;
            var topRight = cornerRadius.TopRight;
            var bottomRight = cornerRadius.BottomRight;
            var bottomLeft = cornerRadius.BottomLeft;
            var side = parameter.ToString();

            switch (side)
            {
                case LeftSide:
                    return new CornerRadius(topLeft, topLeft, bottomLeft, bottomLeft);

                case RightSide:
                    return new CornerRadius(topRight, topRight, bottomRight, bottomRight);

                case BottomSide:
                    return new CornerRadius(bottomLeft, bottomRight, bottomRight, bottomLeft);

                case TopSide:
                default:
                    return new CornerRadius(topLeft, topRight, topRight, topLeft);
            }
        }

    }
}
