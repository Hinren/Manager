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

        private static Color BASE_ACCENT_COLOR = Color.FromArgb(255, 0, 120, 215);


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
                AppearanceThemeType = AppearanceThemeType.DARK
            };
        }

    }
}
