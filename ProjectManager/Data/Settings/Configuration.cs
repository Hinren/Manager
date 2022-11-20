using DomainModel.Models.SettingsUserApp;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;

namespace Hinren.ProjectManager.Data.Settings
{
    public class Configuration
    {
        public Converting ConvertingSettings { get; set; }
        public UIConfiguration UIConfiguration { get; set; }
        public DatabaseSetting DatabaseSetting { get; set; }
        public string UserName { get; set; }
    }
}
