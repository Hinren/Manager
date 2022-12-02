using DomainModel.Enums;

namespace DomainModel.Models.SettingsUserApp.DatabaseSetting
{
    public class DatabaseSetting
    {
        public string DatabaseSettingName { get; set; }
        public string PathDatabase { get; set; }
        public bool UseDefaultPath { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseNameYouWantMakeBackup { get; set; }
        public string DatabaseNameYouWantMakeRestore { get; set; }
        public DatabaseOption TypeDatabase { get; set; }
        public List<string> DatabaseYouDontWantOverwriten { get; set; }
    }
}
