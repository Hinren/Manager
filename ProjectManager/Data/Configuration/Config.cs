using DomainModel.Models.SettingsUserApp;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using Newtonsoft.Json;
using ProjectManager.Data.Dashboard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectManager.Data.Configuration
{
    public class Config
    {

        //  VARIABLES

        public AppearanceConfig AppearanceConfig { get; set; }
        public Converting ConvertingConfig { get; set; }
        public DatabaseConfig DatabaseConfig { get; set; }
        public DashboardConfig DashboardConfig { get; set; }

        public string InternalMessageInitialDirectory { get; set; }
        public List<DashboardRecentlyUsedItem> RecentlyUsedItems { get; set; }

        public Point WindowPosition { get; set; }
        public Size WindowSize { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Config class constructor. </summary>
        [JsonConstructor]
        public Config(AppearanceConfig appearanceConfig = null,
            DatabaseConfig databaseConfig = null,
            DashboardConfig dashboardConfig = null,
            string internalMessageInitialDirectory = null)
        {
            AppearanceConfig = appearanceConfig ?? AppearanceConfig.Default;
            DatabaseConfig = databaseConfig ?? new DatabaseConfig();
            DashboardConfig = dashboardConfig ?? new DashboardConfig();

            InternalMessageInitialDirectory = !string.IsNullOrEmpty(internalMessageInitialDirectory)
                && Directory.Exists(internalMessageInitialDirectory)
                    ? internalMessageInitialDirectory
                    : Environment.GetEnvironmentVariable("USERPROFILE");
        }

        #endregion CLASS METHODS

    }
}
