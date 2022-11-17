using DomainLogic.Interfaces.Database;
using System.Data.SqlClient;

namespace DomainLogic.Database
{
    public class MSSQLStrategy : ISelectDatabaseStrategy
    {
        // 0 - Set databaseName to restore/clone/backup 
        // 1 - choose path (later should work with global seeting for app)
        private readonly string _backupDatabaseSql = @$"BACKUP DATABASE {0} TO DISK = '{1}'";
        private readonly string _restoreDatabaseSql = @$"RESTORE DATABASE {0} FROM DISK = '{1}'";
        private string connectionString;

        public MSSQLStrategy()
        {
            this.connectionString = @"Server=localhost\SQLEXPRESS;Database=testdb;Trusted_Connection=True;";
        }

        public void RestoreDatabase()
        {
            var querry = string.Format(_restoreDatabaseSql, "", @"D:\test\dump1.bak");
            ExecuteNonQueryOperation(querry);
        }

        public void MakeBackup()
        {
            var querry = string.Format(_backupDatabaseSql, "", @"D:\test\dump1.bak");
            ExecuteNonQueryOperation(querry);
        }

        public void RestoreDatatabaseButUnderDifferentName(string newDatabaseName)
        {
            var querry = string.Format(_backupDatabaseSql, newDatabaseName, @"D:\test\dump1.bak");
            ExecuteNonQueryOperation(querry);
        }

        private void ExecuteNonQueryOperation(string querry)
        {
            using (var connestion = new SqlConnection(connectionString))
            {
                connestion.Open();

                using var cmd = new SqlCommand(querry, connestion);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
