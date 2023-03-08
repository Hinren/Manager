using Newtonsoft.Json;
using ProjectManager.Data.Configuration.Attributes;
using ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace ProjectManager.Data.Configuration
{
    public class ConfigurationManager : INotifyPropertyChanged
    {

        //  CONST

        private const string CONFIG_FILE_NAME = "config.json";


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static ConfigurationManager instance;
        private static object instanceLock = new object();
        private Config config;
        private bool loaded = false;


        //  GETTERS & SETTERS

        public static ConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock(instanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new ConfigurationManager();
                            instance.LoadSettings();
                        }
                    }
                }

                return instance;
            }
        }

        public PropertyInfo[] Properties
        {
            get => ObjectHelper.GetObjectProperties(this);
        }

        [ConfigPropertyUpdateAttrib(AllowUpdate = false)]
        public Config Configuration
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ConfigurationManager class constructor. </summary>
        public ConfigurationManager()
        {
            //
        }

        #endregion CLASS METHODS

        #region APPEARANCE UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update relative appearance properties. </summary>
        private void UpdateAppearance()
        {
            /*if (loaded)
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
            }*/
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
