using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ExtendedControls.Static
{
    public class StaticResources
    {

        //  CONST

        public static readonly Color ACCENT_COLOR = Color.FromArgb(255, 0, 120, 215);

        public static readonly Color BACKGROUND_COLOR = System.Windows.Media.Colors.White;
        public static readonly Color BACKGROUND_MOUSE_OVER_COLOR = Color.FromArgb(255, 32, 152, 247);
        public static readonly Color BACKGROUND_PRESSED_COLOR = Color.FromArgb(255, 0, 88, 183);
        public static readonly Color BACKGROUND_SELECTED_COLOR = Color.FromArgb(255, 0, 120, 215);
        public static readonly Color BACKGROUND_SELECTED_INACTIVE_COLOR = Color.FromArgb(64, 0, 120, 215);

        public static readonly Color BORDER_COLOR = Color.FromArgb(255, 0, 120, 215);

        public static readonly Color FOREGROUND_COLOR = System.Windows.Media.Colors.Black;
        public static readonly Color FOREGROUND_MOUSE_OVER_COLOR = System.Windows.Media.Colors.White;
        public static readonly Color FOREGROUND_PRESSED_COLOR = System.Windows.Media.Colors.White;
        public static readonly Color FOREGROUND_SELECTED_COLOR = System.Windows.Media.Colors.White;

        public static readonly CornerRadius DEFAULT_CORNER_RADIUS = new CornerRadius(4);
        public static readonly PackIconKind DEFAULT_ICON_KIND = PackIconKind.None;
        public static readonly double DEFAULT_LISTVIEW_COLUMN_HEADER_GRIPPER_WIDTH = 8d;
        public static readonly double DEFAULT_HORIZONTAL_SCROLLBAR_HEIGHT = 8d;
        public static readonly double DEFAULT_VERTICAL_SCROLLBAR_WIDTH = 8d;

    }
}
