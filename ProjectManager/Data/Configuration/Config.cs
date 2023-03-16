using DomainModel.Models.SettingsUserApp;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using Newtonsoft.Json;
using ProjectManager.Data.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Configuration
{
    public class Config
    {

        //  VARIABLES

        public AppearanceConfig AppearanceConfig { get; set; }
        public Converting ConvertingConfig { get; set; }
        public DatabaseSetting DatabaseConfig { get; set; }
        public DashboardConfig DashboardConfig { get; set; }

        public List<DashboardRecentlyUsedItem> RecentlyUsedItems { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Config class constructor. </summary>
        [JsonConstructor]
        public Config(AppearanceConfig appearanceConfig = null, DashboardConfig dashboardConfig = null)
        {
            AppearanceConfig = appearanceConfig ?? AppearanceConfig.Default;
            DashboardConfig = dashboardConfig ?? new DashboardConfig();
        }

        #endregion CLASS METHODS

    }
}
