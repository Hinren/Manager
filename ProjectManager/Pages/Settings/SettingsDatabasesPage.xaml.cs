using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages;
using ProjectManager.Data.Configuration;
using ProjectManager.InternalMessages;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using ProjectManager.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace ProjectManager.Pages.Settings
{
    public partial class SettingsDatabasesPage : BasePage
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }
        public DatabaseProfilesManager DatabaseProfilesManager { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsDatabasesPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SettingsDatabasesPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize data containers.
            ConfigManager = ConfigManager.Instance;
            DatabaseProfilesManager = new DatabaseProfilesManager(
                Path.Combine(ApplicationHelper.GetApplicationPath(), "db.json"));

            DatabaseProfilesManager.OnEditProfileRequest += OnEditProfile;

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region PROFILES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking create database profile ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CreateDatabaseProfileButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var imContainer = ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
            var im = new DatabaseProfileEditorIM(imContainer, null);

            im.OnClose += OnProfileEditorClose;
            imContainer.ShowMessage(im);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after edit profile request. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="profile"> Database profile. </param>
        private void OnEditProfile(object sender, DatabaseProfile profile)
        {
            var imContainer = ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
            var im = new DatabaseProfileEditorIM(imContainer, profile);

            im.OnClose += OnProfileEditorClose;
            imContainer.ShowMessage(im);
        }

        //  --------------------------------------------------------------------------------
        private void OnProfileEditorClose(object sender, InternalMessageCloseEventArgs e)
        {
            var im = (sender as DatabaseProfileEditorIM);

            if (e.Result == InternalMessageResult.Ok && im != null)
            {
                DatabaseProfile profile = im.DatabaseProfile;
                DatabaseProfilesManager.UpdateProfile(profile);
            }
        }

        #endregion PROFILES MANAGEMENT METHODS

        #region SETUP METHODS


        #endregion SETUP METHODS

    }
}
