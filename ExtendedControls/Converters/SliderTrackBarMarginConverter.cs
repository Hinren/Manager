using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace ExtendedControls.Converters
{
    public class SliderTrackBarMarginConverter : IValueConverter
    {

        //  CONST

        private static readonly string[] PROCESS_CHARS = new string[] { "+", "-", "*", "/" };
        private static readonly string[] VALUE_DESIGNATION = new string[] { "v", "value" };


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double doubleValue = (double)value;
            string[] values = parameter.ToString().Split(';');

            double left = GetValue(values, 0, doubleValue, out double leftValue) ? leftValue : 0;
            double top = GetValue(values, 1, doubleValue, out double topValue) ? topValue : left;
            double right = GetValue(values, 2, doubleValue, out double rightValue) ? rightValue : left;
            double bottom = GetValue(values, 3, doubleValue, out double bottomValue) ? bottomValue : top;

            return new Thickness(left, top, right, bottom);
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var thickness = (Thickness)value;
            string[] values = parameter.ToString().Split(';');
            return GetValue(thickness, values);
        }

        //  --------------------------------------------------------------------------------
        private double GetValue(Thickness thickness, string[] values)
        {
            int index = Array.IndexOf(values, values.FirstOrDefault(v => IsValue(v)));

            if (index > 0)
                switch (index)
                {
                    case 0:
                        return ProcessValue(values[index], thickness.Left, true);

                    case 1:
                        return ProcessValue(values[index], thickness.Top, true);

                    case 2:
                        return ProcessValue(values[index], thickness.Right, true);

                    case 3:
                        return ProcessValue(values[index], thickness.Bottom, true);
                }

            return 0;
        }

        //  --------------------------------------------------------------------------------
        private bool GetValue(string[] values, int valueIndex, double value, out double resultValue)
        {
            if (values.Length >= (valueIndex + 1))
            {
                resultValue = IsValue(values[valueIndex])
                    ? ProcessValue(values[valueIndex], value)
                    : IsDouble(values[valueIndex], out double doubleValue)
                        ? doubleValue
                        : 0;

                return true;
            }

            resultValue = 0;
            return false;
        }

        //  --------------------------------------------------------------------------------
        private bool IsDouble(string value, out double valueResult)
        {
            if (double.TryParse(value, out valueResult))
                return true;

            valueResult = 0d;
            return false;
        }

        //  --------------------------------------------------------------------------------
        private bool IsValue(string value)
        {
            return VALUE_DESIGNATION.Any(v => value.ToLower().Contains(v));
        }

        //  --------------------------------------------------------------------------------
        private double ProcessValue(string value, double doubleValue, bool reverse = false)
        {
            if (value.Any(v => PROCESS_CHARS.Any(c => c == v.ToString())))
            {
                var processChar = value
                    .Select(v => v.ToString())
                    .FirstOrDefault(v => PROCESS_CHARS.Any(c => c == v.ToString()));

                if (!string.IsNullOrEmpty(processChar))
                {
                    var processValues = value.Split(new string[] { processChar }, StringSplitOptions.None);

                    if (double.TryParse(processValues.Last(), out double processValue))
                    {
                        switch (processChar)
                        {
                            case "+":
                                return reverse ? doubleValue - processValue : doubleValue + processValue;

                            case "-":
                                return reverse ? doubleValue + processValue : doubleValue - processValue;

                            case "*":
                                return reverse ? doubleValue / (processValue == 0 ? 1 : processValue) : doubleValue * processValue;

                            case "/":
                                return reverse ? doubleValue * processValue : doubleValue / (processValue == 0 ? 1 : processValue);
                        }
                    }
                }
            }

            return doubleValue;
        }

    }
}
