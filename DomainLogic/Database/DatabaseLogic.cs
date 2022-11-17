using DomainLogic.Interfaces.Database;
using DomainModel.Enums;

namespace DomainLogic.Database
{
    public class DatabaseLogic
    {
        private ISelectDatabaseStrategy _selectDatabaseStrategy;

        public DatabaseLogic()
        {
            var temporaryOption = DatabaseOption.MSSQL;
            // set strategy based on configuration file later
            switch (temporaryOption)
            {
                case DatabaseOption.MSSQL:
                    _selectDatabaseStrategy = new MSSQLStrategy();
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
    }
}
