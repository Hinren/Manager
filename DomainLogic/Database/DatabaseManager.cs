using DomainLogic.Interfaces.Database;
using DomainModel.Enums;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;

namespace DomainLogic.Database
{
    public class DatabaseManager
    {
        private ISelectDatabaseStrategy _selectDatabaseStrategy;
        private DatabaseSetting _databaseSetting;

        public DatabaseManager(DatabaseSetting selectDatabaseConfig)
        {
            _databaseSetting = selectDatabaseConfig;

            switch (selectDatabaseConfig.TypeDatabase)
            {
                case DatabaseOption.MSSQL:
                    _selectDatabaseStrategy = new MSSQLStrategy(_databaseSetting);
                    break;
                case DatabaseOption.POSTGRESS:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
        public void MakeBackup()
        {
            _selectDatabaseStrategy.MakeBackup();
        }
        public void MakeRestoreForDifferentName(string path)
        {
            _selectDatabaseStrategy.RestoreDatatabaseButUnderDifferentName(path);
        }
    }
}
