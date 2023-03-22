using DomainModel.Models.SettingsUserApp;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using Newtonsoft.Json;
using ProjectManager.Data.Dashboard;
using SnippetsManager;
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
        public DashboardConfig DashboardConfig { get; set; }
        public DatabaseConfig DatabaseConfig { get; set; }
        public SnippetsConfig SnippetConfig { get; set; }

        public string InternalMessageInitialDirectory { get; set; }
        public List<DashboardRecentlyUsedItem> RecentlyUsedItems { get; set; }

        public Point WindowPosition { get; set; }
        public Size WindowSize { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Config class constructor. </summary>
        /// <param name="appearanceConfig"> Appearance configuration. </param>
        /// <param name="dashboardConfig"> Dashboard configuration. </param>
        /// <param name="databaseConfig"> Database configuration. </param>
        /// <param name="internalMessageInitialDirectory"> Internal message initial directory. </param>
        /// <param name="snippetConfig"> Snippets configuration. </param>
        [JsonConstructor]
        public Config(AppearanceConfig appearanceConfig = null,
            DashboardConfig dashboardConfig = null,
            DatabaseConfig databaseConfig = null,
            string internalMessageInitialDirectory = null,
            SnippetsConfig snippetConfig = null)
        {
            AppearanceConfig = appearanceConfig ?? AppearanceConfig.Default;
            DatabaseConfig = databaseConfig ?? new DatabaseConfig();
            DashboardConfig = dashboardConfig ?? new DashboardConfig();
            InternalMessageInitialDirectory = GetIMInitDirectory(internalMessageInitialDirectory);
            SnippetConfig = snippetConfig ?? new SnippetsConfig();
        }

        #endregion CLASS METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get InternalMessage initial directory. </summary>
        /// <param name="imInitDirectory"> Loaded internal message initial directory. </param>
        /// <returns> Internal message initial directory. </returns>
        private string GetIMInitDirectory(string imInitDirectory)
        {
            return !string.IsNullOrEmpty(imInitDirectory) && Directory.Exists(imInitDirectory)
                ? imInitDirectory
                : Environment.GetEnvironmentVariable("USERPROFILE");
        }

        #endregion UTILITY METHODS

    }
}
