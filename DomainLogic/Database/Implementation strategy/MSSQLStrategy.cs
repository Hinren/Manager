using DomainLogic.Interfaces.Database;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using System.Data.SqlClient;
using System.Reflection;

namespace DomainLogic.Database
{
    public class MSSQLStrategy : ISelectDatabaseStrategy
    {
        private readonly string _getAssemlyEntry = Assembly.GetEntryAssembly().Location.Replace(@"\ProjectManager.dll", "");
        private readonly string _backupDatabaseSql = "BACKUP DATABASE {0} TO DISK = '{1}{2}_{3}.bak'";
        private readonly string _restoreDatabaseSql = @"RESTORE DATABASE [{0}] FROM  
                        DISK = N'{1}' 
                        WITH FILE = 1,
                        MOVE N'Learning' TO N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\{0}.mdf',
                        MOVE N'Learning_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\{0}_log.ldf',
                        NOUNLOAD, STATS = 5";
        private readonly DatabaseSetting _databaseSetting;

        public MSSQLStrategy(DatabaseSetting selectDatabaseConfig)
        {
            _databaseSetting = selectDatabaseConfig;
        }

        public void MakeRestoreOrginalDatabaseName(string path)
        {
            if (_databaseSetting.DatabaseYouDontWantOverwriten.Contains(_databaseSetting.DatabaseNameYouWantMakeBackup))
            {
                throw new InvalidOperationException("You want overwrite database you don't want it");
            }

            var querry = string.Format(_restoreDatabaseSql, _databaseSetting.DatabaseNameYouWantMakeBackup, path);
            ExecuteNonQueryOperation(querry);
        }

        public void MakeBackup()
        {
            var path = GetPath();
            var querry = string.Format(_backupDatabaseSql, _databaseSetting.DatabaseNameYouWantMakeBackup, path, _databaseSetting.DatabaseNameYouWantMakeBackup, DateTime.Now.ToString("yyyy_MM_dd_HH_mm"));
            ExecuteNonQueryOperation(querry);
        }

        public void MakeRestoreButNotOrginalDatabaseName(string path)
        {
            var querry = string.Format(_restoreDatabaseSql, _databaseSetting.DatabaseNameYouWantMakeRestore, path);
            ExecuteNonQueryOperation(querry);
        }

        #region Additional method

        private string GetPath()
        {
            if (_databaseSetting.UseDefaultPath)
            {
                var path = Path.Combine(_getAssemlyEntry, "Backup") + @"\";
                CreateFoldersIdDontExist(path);
                return path;
            }
            return _databaseSetting.PathDatabase;
        }

        private void CreateFoldersIdDontExist(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void ExecuteNonQueryOperation(string querry)
        {
            using (var connestion = new SqlConnection(_databaseSetting.ConnectionString))
            {
                connestion.Open();

                using var cmd = new SqlCommand(querry, connestion);
                cmd.ExecuteNonQuery();
            }
        }
        #endregion

    }
}
