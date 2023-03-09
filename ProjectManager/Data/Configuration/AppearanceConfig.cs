using ProjectManager.Data.Configuration.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectManager.Data.Configuration
{
    public class AppearanceConfig
    {

        //  CONST

        public static Color BASE_ACCENT_COLOR = Color.FromArgb(255, 0, 120, 215);
        public static Color BASE_DARK_THEME_COLOR = Color.FromArgb(255, 24, 24, 24);
        public static Color BASE_LIGHT_THEME_COLOR = Color.FromArgb(255, 243, 243, 243);
        public static int APPEARANCE_INACTIVE_FACTOR = 15;
        public static int APPEARANCE_MOUSE_OVER_FACTOR = 15;
        public static int APPEARANCE_PRESSED_FACTOR = 10;
        public static int APPEARANCE_SELECTED_FACTOR = 5;


        //  VARIABLES

        public Color AccentColor { get; set; }
        public AppearanceThemeType AppearanceThemeType { get; set; }


        //  GETTERS & SETTERS

        [JsonIgnore]
        public static AppearanceConfig Default
        {
            get => new AppearanceConfig()
            {
                AccentColor = BASE_ACCENT_COLOR,
                AppearanceThemeType = AppearanceThemeType.LIGHT
            };
        }

    }
}
