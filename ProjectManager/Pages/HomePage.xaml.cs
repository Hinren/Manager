using DomainLogic.Database;
using DomainLogic.Interfaces.Snippet;
using DomainLogic.Snippet;
using DomainModel.Enums;
using DomainModel.Models.SettingsUserApp.DatabaseSetting;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using System.Collections.Generic;
using System.Linq;

namespace Hinren.ProjectManager.Pages
{
    public partial class HomePage : BasePage
    {

        //  METHODS
        //private ISnippetSaver snippetSaver = new SnippetSaver();
        //private ISnippetReader snippetReader = new SnippetReader();

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> HomePage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public HomePage(PagesControl pagesController, object[] args = null) : base(pagesController, args)
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var config = ConfigurationManager.Instance;

            //Database test logic

            //if (config.Configuration.DatabaseSettings == null)
            //{
            //    config.Configuration.DatabaseSettings = new List<DatabaseSetting>();
            //}

            //config.Configuration.DatabaseSettings.Add(
            //    new DatabaseSetting() 
            //    {
            //        DatabaseSettingName = "Desktop_PW",
            //        PathDatabase = @"D:\A backup",
            //        UseDefaultPath = true,
            //        ConnectionString = @"Data Source=DESKTOP-RCI92SN\SQLEXPRESS;Initial Catalog=Learning;Integrated Security=true;", 
            //        DatabaseNameYouWantMakeBackup = "Learning", 
            //        DatabaseNameYouWantMakeRestore = "Learning_PW", 
            //        DatabaseYouDontWantOverwriten = new List<string>() { "Learning" }, 
            //        TypeDatabase = DatabaseOption.MSSQL 
            //    });

            //var selectDatabaseConfig = config.Configuration.DatabaseSettings.First(x => x.DatabaseSettingName == "Desktop_PW");
            //DatabaseManager databaseManager = new DatabaseManager(selectDatabaseConfig);

            //databaseManager.MakeBackup();
            //var databaseBackup = @"D:\REPOSITORY\Manager\ProjectManager\bin\Debug\net6.0-windows\Backup\Learning_2022_12_02_15_12.bak";
            //databaseManager.MakeRestoreOrginalDatabaseName(databaseBackup);
            //databaseManager.MakeRestoreButNotOrginalDatabaseName(databaseBackup);

            //Test snippet saver
            //snippetSaver.SaveSnippetsOnLocalPath(@"D:\REPOSITORY\Snippets");
            //snippetSaver.SaveSnippetsOnVisualStudioPath();
        }
    }
}
