using chkam05.Tools.ControlsEx.Colors;
using chkam05.Tools.ControlsEx.Utilities;
using Newtonsoft.Json;
using ProjectManager.Data.Configuration.Attributes;
using ProjectManager.Data.Configuration.Static;
using ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ProjectManager.Data.Configuration
{
    public class ConfigManager : INotifyPropertyChanged
    {

        //  CONST

        private const string CONFIG_FILE_NAME = "config.json";


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static ConfigManager _instance;
        private static object _instanceLock = new object();
        private Config _config;
        private bool _loaded = false;

        #region Appearance

        private Brush _appearanceAccentColorBrush;
        private Brush _appearanceAccentForegroundBrush;
        private Brush _appearanceAccentMouseOverBrush;
        private Brush _appearanceAccentPressedBrush;
        private Brush _appearanceAccentSelectedBrush;
        private Brush _appearanceThemeBackgroundBrush;
        private Brush _appearanceThemeForegroundBrush;
        private Brush _appearanceThemeShadeBackgroundBrush;
        private Brush _appearanceThemeMouseOverBrush;
        private Brush _appearanceThemePressedBrush;
        private Brush _appearanceThemeSelectedBrush;

        #endregion Appearance


        //  GETTERS & SETTERS

        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigManager();
                            _instance.LoadSettings();
                        }
                    }
                }

                return _instance;
            }
        }

        public PropertyInfo[] Properties
        {
            get => ObjectHelper.GetObjectProperties(this);
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Config Configuration
        {
            get => _config;
            private set
            {
                _config = value;
                _loaded = true;
                UpdateConfigurationProperties();
                UpdateAppearance();
            }
        }


        #region Appearance

        [ConfigPropertyUpdateAttrib]
        public Color AppearanceAccentColor
        {
            get => _config.AppearanceConfig.AccentColor;
            set
            {
                _config.AppearanceConfig.AccentColor = value;
                OnPropertyChanged(nameof(AppearanceAccentColor));
                UpdateAppearance();
            }
        }

        [ConfigPropertyUpdateAttrib]
        public AppearanceThemeType AppearanceThemeType
        {
            get => _config.AppearanceConfig.AppearanceThemeType;
            set
            {
                _config.AppearanceConfig.AppearanceThemeType = value;
                OnPropertyChanged(nameof(AppearanceThemeType));
                UpdateAppearance();
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public List<AppearanceColor> AppearanceColorsList
        {
            get => _config.AppearanceConfig.AppearanceColorsList;
            set
            {
                _config.AppearanceConfig.AppearanceColorsList = value;
                OnPropertyChanged(nameof(AppearanceColorsList));
            }
        }

        //  Internal

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentColorBrush
        {
            get => _appearanceAccentColorBrush;
            set
            {
                _appearanceAccentColorBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentColorBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentForegroundBrush
        {
            get => _appearanceAccentForegroundBrush;
            set
            {
                _appearanceAccentForegroundBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentForegroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentMouseOverBrush
        {
            get => _appearanceAccentMouseOverBrush;
            set
            {
                _appearanceAccentMouseOverBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentMouseOverBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentPressedBrush
        {
            get => _appearanceAccentPressedBrush;
            set
            {
                _appearanceAccentPressedBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentPressedBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentSelectedBrush
        {
            get => _appearanceAccentSelectedBrush;
            set
            {
                _appearanceAccentSelectedBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentSelectedBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemeBackgroundBrush
        {
            get => _appearanceThemeBackgroundBrush;
            set
            {
                _appearanceThemeBackgroundBrush = value;
                OnPropertyChanged(nameof(AppearanceThemeBackgroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemeForegroundBrush
        {
            get => _appearanceThemeForegroundBrush;
            set
            {
                _appearanceThemeForegroundBrush = value;
                OnPropertyChanged(nameof(AppearanceThemeForegroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemeShadeBackgroundBrush
        {
            get => _appearanceThemeShadeBackgroundBrush;
            set
            {
                _appearanceThemeShadeBackgroundBrush = value;
                OnPropertyChanged(nameof(AppearanceThemeShadeBackgroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemeMouseOverBrush
        {
            get => _appearanceThemeMouseOverBrush;
            set
            {
                _appearanceThemeMouseOverBrush = value;
                OnPropertyChanged(nameof(AppearanceThemeMouseOverBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemePressedBrush
        {
            get => _appearanceThemePressedBrush;
            set
            {
                _appearanceThemePressedBrush = value;
                OnPropertyChanged(nameof(AppearanceThemePressedBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceThemeSelectedBrush
        {
            get => _appearanceThemeSelectedBrush;
            set
            {
                _appearanceThemeSelectedBrush = value;
                OnPropertyChanged(nameof(AppearanceThemeSelectedBrush));
            }
        }

        #endregion Appearance

        #region Dashboard

        public bool RecentlyUsedItemsEnabled
        {
            get => _config.DashboardConfig.RecentlyUsedItemsEnabled;
            set
            {
                _config.DashboardConfig.RecentlyUsedItemsEnabled = value;
                OnPropertyChanged(nameof(RecentlyUsedItemsEnabled));
            }
        }

        public bool RecentlyUsedItemsExtended
        {
            get => _config.DashboardConfig.RecentlyUsedItemsExtended;
            set
            {
                _config.DashboardConfig.RecentlyUsedItemsExtended = value;
                OnPropertyChanged(nameof(RecentlyUsedItemsExtended));
            }
        }

        public bool TipsAndTricksTabEnabled
        {
            get => _config.DashboardConfig.TipsAndTricksTabEnabled;
            set
            {
                _config.DashboardConfig.TipsAndTricksTabEnabled = value;
                OnPropertyChanged(nameof(TipsAndTricksTabEnabled));
            }
        }

        public bool TipsAndTricksTabExtended
        {
            get => _config.DashboardConfig.TipsAndTricksTabExtended;
            set
            {
                _config.DashboardConfig.TipsAndTricksTabExtended = value;
                OnPropertyChanged(nameof(TipsAndTricksTabExtended));
            }
        }

        public bool WelcomeTabEnabled
        {
            get => _config.DashboardConfig.WelcomeTabEnabled;
            set
            {
                _config.DashboardConfig.WelcomeTabEnabled = value;
                OnPropertyChanged(nameof(WelcomeTabEnabled));
            }
        }

        public bool WelcomeTabExtended
        {
            get => _config.DashboardConfig.WelcomeTabExtended;
            set
            {
                _config.DashboardConfig.WelcomeTabExtended = value;
                OnPropertyChanged(nameof(WelcomeTabExtended));
            }
        }

        #endregion Dashboard


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ConfigManager class constructor. </summary>
        public ConfigManager()
        {
            //
        }

        #endregion CLASS METHODS

        #region APPEARANCE UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update relative appearance properties. </summary>
        private void UpdateAppearance()
        {
            if (_loaded)
            {
                var accentAhslColor = AHSLColor.FromColor(AppearanceAccentColor);
                var accentForegroundColor = ColorHelper.GetContrastColor(AppearanceAccentColor);

                var accentMouseOverColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L + AppearanceConfig.APPEARANCE_MOUSE_OVER_FACTOR).ToColor();

                var accentPressedColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L - AppearanceConfig.APPEARANCE_PRESSED_FACTOR).ToColor();

                var accentSelectedColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L - AppearanceConfig.APPEARANCE_SELECTED_FACTOR).ToColor();

                AppearanceAccentColorBrush = new SolidColorBrush(AppearanceAccentColor);
                AppearanceAccentForegroundBrush = new SolidColorBrush(accentForegroundColor);
                AppearanceAccentMouseOverBrush = AppearanceAccentMouseOverBrush = new SolidColorBrush(accentMouseOverColor);
                AppearanceAccentPressedBrush = new SolidColorBrush(accentPressedColor);
                AppearanceAccentSelectedBrush = new SolidColorBrush(accentSelectedColor);

                var backgroundColor = Colors.White;
                var foregroundColor = Colors.Black;
                var shadeBackgroundColor = AppearanceConfig.BASE_LIGHT_THEME_COLOR;

                switch (AppearanceThemeType)
                {
                    case AppearanceThemeType.DARK:
                        backgroundColor = Colors.Black;
                        foregroundColor = Colors.White;
                        shadeBackgroundColor = AppearanceConfig.BASE_DARK_THEME_COLOR;
                        break;
                }

                var backgroundAhslColor = AHSLColor.FromColor(backgroundColor);

                var themeMouseOverColor = ColorHelper.UpdateColor(
                    backgroundAhslColor,
                    lightness: backgroundAhslColor.S > 50
                        ? backgroundAhslColor.S + AppearanceConfig.APPEARANCE_MOUSE_OVER_FACTOR
                        : backgroundAhslColor.L - AppearanceConfig.APPEARANCE_MOUSE_OVER_FACTOR,
                    saturation: 0).ToColor();

                var themePressedColor = ColorHelper.UpdateColor(
                    backgroundAhslColor,
                    lightness: backgroundAhslColor.S > 50
                        ? backgroundAhslColor.S - AppearanceConfig.APPEARANCE_PRESSED_FACTOR
                        : backgroundAhslColor.L + AppearanceConfig.APPEARANCE_PRESSED_FACTOR,
                    saturation: 0).ToColor();

                var themeSelectedColor = ColorHelper.UpdateColor(
                    backgroundAhslColor,
                    lightness: backgroundAhslColor.S > 50
                        ? backgroundAhslColor.S - AppearanceConfig.APPEARANCE_SELECTED_FACTOR
                        : backgroundAhslColor.L + AppearanceConfig.APPEARANCE_SELECTED_FACTOR,
                    saturation: 0).ToColor();

                AppearanceThemeBackgroundBrush = new SolidColorBrush(backgroundColor);
                AppearanceThemeForegroundBrush = new SolidColorBrush(foregroundColor);
                AppearanceThemeShadeBackgroundBrush = new SolidColorBrush(shadeBackgroundColor);
                AppearanceThemeMouseOverBrush = new SolidColorBrush(themeMouseOverColor);
                AppearanceThemePressedBrush = new SolidColorBrush(themePressedColor);
                AppearanceThemeSelectedBrush = new SolidColorBrush(themeSelectedColor);
            }
        }

        #endregion APPEARANCE UPDATE METHODS

        #region LOAD & SAVE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load settings from json file. </summary>
        public void LoadSettings()
        {
            string configFilePath = Path.Combine(ApplicationHelper.GetApplicationPath(), CONFIG_FILE_NAME);

            if (!File.Exists(configFilePath))
                File.WriteAllText(configFilePath, string.Empty);

            string configFileContent = File.ReadAllText(configFilePath);

            if (!string.IsNullOrEmpty(configFileContent))
            {
                Config configuration = JsonConvert.DeserializeObject<Config>(configFileContent);

                if (configuration != null)
                {
                    Configuration = configuration;
                    return;
                }
            }

            Configuration = new Config();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Save settings to json file. </summary>
        public void SaveSettings()
        {
            if (Configuration != null)
            {
                string configFilePath = Path.Combine(ApplicationHelper.GetApplicationPath(), CONFIG_FILE_NAME);
                string configFileContent = JsonConvert.SerializeObject(Configuration, Formatting.Indented);
                File.WriteAllText(configFilePath, configFileContent);
            }
        }

        #endregion LOAD & SAVE METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler event. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update configuration properties after loading configuration from file. </summary>
        private void UpdateConfigurationProperties()
        {
            if (_loaded)
            {
                var thisType = this.GetType();
                var properties = Properties.Where(p => p.CanWrite);

                foreach (var propInfo in properties)
                {
                    var property = thisType.GetProperty(propInfo.Name);

                    if (property != null)
                    {
                        if (ObjectHelper.HasAttribute(property, typeof(ConfigPropertyUpdateAttrib)))
                        {
                            var attribs = ObjectHelper.GetAttribute<ConfigPropertyUpdateAttrib>(property);
                            if (attribs != null && attribs.Any(a => a.AllowUpdate == false))
                                continue;
                        }

                        OnPropertyChanged(property.Name);
                    }
                }
            }
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
