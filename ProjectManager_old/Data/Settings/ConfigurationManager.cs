using DomainModel.Attributes;
using ExtendedControls.Data;
using Hinren.ProjectManager.Data.Settings.Static;
using Hinren.ProjectManager.Utilities;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Media;

namespace Hinren.ProjectManager.Data.Settings
{
    public class ConfigurationManager : INotifyPropertyChanged
    {

        //  CONST

        private const string CONFIG_FILE_NAME = "config.json";
        private const int APPEARANCE_INACTIVE_FACTOR = 15;
        private const int APPEARANCE_MOUSE_OVER_FACTOR = 15;
        private const int APPEARANCE_PRESSED_FACTOR = 10;
        private const int APPEARANCE_SELECTED_FACTOR = 5;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static ConfigurationManager instance;

        private Configuration config;

        private bool loaded = false;

        #region Appearance Configuration

        private Brush appearanceAccentColorBrush;

        private Brush appearanceAccentForegroundBrush;

        private Brush appearanceAccentMouseOverBrush;

        private Brush appearanceAccentPressedBrush;

        private Brush appearanceAccentSelectedBrush;

        private Brush appearanceAccentSelectedInactiveBrush;

        private Brush appearanceBackgroundBrush;

        private Brush appearanceForegroundBrush;

        private Brush appearanceMenuBackgroundBrush;

        #endregion Appearance Configuration


        //  GETTERS & SETTERS

        public static ConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConfigurationManager();

                return instance;
            }
        }

        public PropertyInfo[] Properties
        {
            get => ObjectHelper.GetObjectProperties(this);
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Configuration Configuration
        {
            get => config;
            set
            {
                config = value;
                loaded = true;
                UpdateConfigurationProperties();
                UpdateAppearance();
            }
        }

        #region Appearance Properties

        [ConfigPropertyUpdateAttrib]
        public Color AppearanceAccentColor
        {
            get => config.UIConfiguration.AccentColor;
            set
            {
                config.UIConfiguration.AccentColor = value;
                OnPropertyChanged(nameof(AppearanceAccentColor));
                UpdateAppearance();
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentColorBrush
        {
            get => appearanceAccentColorBrush;
            set
            {
                appearanceAccentColorBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentColorBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentForegroundBrush
        {
            get => appearanceAccentForegroundBrush;
            set
            {
                appearanceAccentForegroundBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentForegroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentMouseOverBrush
        {
            get => appearanceAccentMouseOverBrush;
            set
            {
                appearanceAccentMouseOverBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentMouseOverBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentPressedBrush
        {
            get => appearanceAccentPressedBrush;
            set
            {
                appearanceAccentPressedBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentPressedBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentSelectedBrush
        {
            get => appearanceAccentSelectedBrush;
            set
            {
                appearanceAccentSelectedBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentSelectedBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceAccentSelectedInactiveBrush
        {
            get => appearanceAccentSelectedInactiveBrush;
            set
            {
                appearanceAccentSelectedInactiveBrush = value;
                OnPropertyChanged(nameof(AppearanceAccentSelectedInactiveBrush));
            }
        }

        [ConfigPropertyUpdateAttrib]
        public AppearanceTheme AppearanceTheme
        {
            get => config.UIConfiguration.AppearanceTheme;
            set
            {
                config.UIConfiguration.AppearanceTheme = value;
                OnPropertyChanged(nameof(AppearanceTheme));
                UpdateAppearance();
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceBackgroundBrush
        {
            get => appearanceBackgroundBrush;
            set
            {
                appearanceBackgroundBrush = value;
                OnPropertyChanged(nameof(AppearanceBackgroundBrush));
            }
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceForegroundBrush
        {
            get => appearanceForegroundBrush;
            set
            {
                appearanceForegroundBrush = value;
                OnPropertyChanged(nameof(AppearanceForegroundBrush));
            }
        }
        
        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Brush AppearanceMenuBackgroundBrush
        {
            get => appearanceMenuBackgroundBrush;
            set
            {
                appearanceMenuBackgroundBrush = value;
                OnPropertyChanged(nameof(AppearanceMenuBackgroundBrush));
            }
        }

        #endregion Appearance Properties

        #region Configuration

        [ConfigPropertyUpdateAttrib]
        public string UserName
        {
            get => Configuration.UserName;
            set
            {
                Configuration.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        #endregion Configuration


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ConfigurationManager class constructor. </summary>
        public ConfigurationManager()
        {
            LoadSettings();
        }

        #endregion CLASS METHODS

        #region APPEARANCE UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update relative appearance properties. </summary>
        private void UpdateAppearance()
        {
            if (loaded)
            {
                var accentAhslColor = AHSLColor.FromColor(AppearanceAccentColor);
                var accentForegroundColor = ColorHelper.FoundFontColorContrastingWithBackground(AppearanceAccentColor);

                var accentMouseOverColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L + APPEARANCE_MOUSE_OVER_FACTOR).ToColor();

                var accentPressedColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L - APPEARANCE_PRESSED_FACTOR).ToColor();

                var accentSelectedColor = ColorHelper.UpdateColor(
                    accentAhslColor, lightness: accentAhslColor.L - APPEARANCE_SELECTED_FACTOR).ToColor();

                var accentSelectedInactiveColor = ColorHelper.UpdateColor(
                    accentAhslColor, saturation: accentAhslColor.S - APPEARANCE_INACTIVE_FACTOR).ToColor();

                AppearanceAccentColorBrush = new SolidColorBrush(AppearanceAccentColor);
                AppearanceAccentForegroundBrush = new SolidColorBrush(accentForegroundColor);
                AppearanceAccentMouseOverBrush = new SolidColorBrush(accentMouseOverColor);
                AppearanceAccentPressedBrush = new SolidColorBrush(accentPressedColor);
                AppearanceAccentSelectedBrush = new SolidColorBrush(accentSelectedColor);
                AppearanceAccentSelectedInactiveBrush = new SolidColorBrush(accentSelectedInactiveColor);

                var backgroundColor = Colors.Black;
                var foregroundColor = Colors.White;

                switch (AppearanceTheme)
                {
                    case AppearanceTheme.LIGHT:
                        backgroundColor = Colors.White;
                        foregroundColor = Colors.Black;
                        break;
                }

                AppearanceBackgroundBrush = new SolidColorBrush(backgroundColor);
                AppearanceForegroundBrush = new SolidColorBrush(foregroundColor);
                AppearanceMenuBackgroundBrush = new SolidColorBrush(foregroundColor) { Opacity = 0.25 };
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
                Configuration configuration = JsonConvert.DeserializeObject<Configuration>(configFileContent);

                if (configuration != null)
                {
                    Configuration = configuration;
                    return;
                }
            }

            Configuration = new Configuration();
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
            if (loaded)
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
