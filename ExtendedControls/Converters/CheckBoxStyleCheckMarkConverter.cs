using ExtendedControls.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ExtendedControls.Converters
{
    public class CheckBoxStyleCheckMarkConverter
    {

        //  CONST

        public static readonly Dictionary<CheckBoxStyle, PackIconKind> BlankMapping = new Dictionary<CheckBoxStyle, PackIconKind>()
        {
            { CheckBoxStyle.BORDERED, PackIconKind.CheckBoxOutlineBlank },
            { CheckBoxStyle.CIRCLE_BORDERED, PackIconKind.CheckboxBlankCircleOutline },
            { CheckBoxStyle.CIRCLE_FILLED, PackIconKind.CheckboxBlankCircle },
            { CheckBoxStyle.FILLED, PackIconKind.CheckboxBlank },
            { CheckBoxStyle.MIXED, PackIconKind.CheckboxBlank },
            { CheckBoxStyle.MIXED_CIRCLE, PackIconKind.CheckboxBlankCircle },
            { CheckBoxStyle.MIXED_CIRCLE_REVERSE, PackIconKind.CheckboxBlankCircleOutline },
            { CheckBoxStyle.MIXED_REVERSE, PackIconKind.CheckBoxOutlineBlank }
        };

        public static readonly Dictionary<CheckBoxStyle, PackIconKind> CheckedMapping = new Dictionary<CheckBoxStyle, PackIconKind>()
        {
            { CheckBoxStyle.BORDERED, PackIconKind.CheckboxOutline },
            { CheckBoxStyle.CIRCLE_BORDERED, PackIconKind.CheckboxMarkedCircleOutline },
            { CheckBoxStyle.CIRCLE_FILLED, PackIconKind.CheckboxMarkedCircle },
            { CheckBoxStyle.FILLED, PackIconKind.CheckboxMarked },
            { CheckBoxStyle.MIXED, PackIconKind.CheckboxOutline },
            { CheckBoxStyle.MIXED_CIRCLE, PackIconKind.CheckboxMarkedCircleOutline },
            { CheckBoxStyle.MIXED_CIRCLE_REVERSE, PackIconKind.CheckboxMarkedCircle },
            { CheckBoxStyle.MIXED_REVERSE, PackIconKind.CheckboxMarked }
        };


        //  METHODS

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var checkBoxStyle = (CheckBoxStyle)value;
            bool isChecked = false;
            bool.TryParse($"{parameter}", out isChecked);

            return isChecked ? CheckedMapping[checkBoxStyle] : BlankMapping[checkBoxStyle];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var packIconKind = (PackIconKind)value;

            if (CheckedMapping.Any(kvp => kvp.Value == packIconKind))
                return true;

            return false;
        }

    }
}
