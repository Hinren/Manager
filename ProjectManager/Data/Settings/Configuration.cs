using DomainModel.Models.SettingsUserApp;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Hinren.ProjectManager.Data.Settings
{
    public class Configuration
    {

        //  VARIABLES

        public Converting ConvertingSettings { get; set; }
        public UIConfiguration UIConfiguration { get; set; }
        public List<DatabaseSetting> DatabaseSettings { get; set; }
        public string UserName { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Configuration class constructor. </summary>
        [JsonConstructor]
        public Configuration(UIConfiguration uIConfiguration = null)
        {
            UIConfiguration = uIConfiguration ?? UIConfiguration.Default;
        }

        #endregion CLASS METHODS

    }
}
