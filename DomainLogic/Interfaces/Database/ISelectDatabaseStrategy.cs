namespace DomainLogic.Interfaces.Database
{
    public interface ISelectDatabaseStrategy
    {
        /// <summary>
        /// Allow make backup for every database we want locally in our disk
        /// </summary>
        public void MakeBackup();

        /// <summary>
        /// This method allow to restore database when for some reason is deleted.
        /// </summary>
        public void RestoreDatabase(string path);
        /// <summary>
        /// This method allow to restore database but under different name.
        /// </summary>
        public void RestoreDatatabaseButUnderDifferentName(string path);
    }
}
