using System.Collections.Generic;
namespace DomainModel.Models.SettingsUserApp.DatabaseSetting
{
    public class DatabaseSetting
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public bool TrustedConnection { get; set; }
        public List<string> DatabaseYouDontWantOverwriten { get; set; }
    }
}
