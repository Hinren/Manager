using DomainModel.Attributes;
using Hinren.ProjectManager.Utilities;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Hinren.ProjectManager.Data.Settings
{
    public class ConfigurationManager : INotifyPropertyChanged
    {

        //  CONST

        private const string CONFIG_FILE_NAME = "config.json";


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static ConfigurationManager instance;

        private Configuration config;


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
                UpdateConfigurationProperties();
            }
        }

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

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
