using ExtendedControls.Data;
using ExtendedControls.Static;
using Hinren.ProjectManager.Data.Settings.Static;
using Hinren.ProjectManager.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Media;

namespace Hinren.ProjectManager.Data.Settings
{
    public class UIConfiguration
    {

        //  CONST

        private Color BASE_ACCENT_COLOR = Color.FromArgb(255, 0, 120, 215);


        //  VARIABLES

        public Color AccentColor { get; set; }
        public AppearanceTheme AppearanceTheme { get; set; }
        public List<ColorPaletteItem> UsedAccentColors { get; set; }


        //  GETTERS & SETTERS

        [JsonIgnore]
        public static UIConfiguration Default
        {
            get => new UIConfiguration()
            {
                AccentColor = Colors.Red,
                AppearanceTheme = AppearanceTheme.DARK,
                UsedAccentColors = new List<ColorPaletteItem>()
                {
                    StaticColors.Blue,
                    StaticColors.Red,
                    StaticColors.GoldYellow,
                    StaticColors.Green,
                    StaticColors.DarkGray
                },
            };
        }

    }
}
