using chkam05.Tools.ControlsEx;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
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
        /// <summary> Method invoked after pressing mouse button on create database profile ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void CreateDatabaseProfileButtonEx_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
                return;

            if (e.ChangedButton == MouseButton.Left)
            {
                ButtonEx button = (ButtonEx)sender;
                ContextMenuEx contextMenu = (ContextMenuEx)button.ContextMenu;
                contextMenu.PlacementTarget = button;
                contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                contextMenu.IsOpen = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking create database profile ContextMenuItemEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CreateDatabaseContextMenuItemEx_Click(object sender, RoutedEventArgs e)
        {
            var imContainer = ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
            var im = new DatabaseProfileEditorIM(imContainer, null);

            im.OnClose += OnProfileEditorClose;
            imContainer.ShowMessage(im);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking import db from connection string ContextMenuItemEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ImportDbFromConnectionStringContextMenuItemEx_Click(object sender, RoutedEventArgs e)
        {
            var imContainer = ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
            var imStringInput = new StringInputIM(imContainer, "Import database profile config", "ConnectionString:", PackIconKind.DatabaseImport);

            imStringInput.OnClose += (s, e) =>
            {
                if (e.Result == InternalMessageResult.Ok)
                {
                    var profile = DatabaseProfile.FromConnectionString(imStringInput.Text, out Dictionary<string, string> errors);
                    var imProfileEditor = new DatabaseProfileEditorIM(imContainer, profile);

                    imStringInput.OnClose += OnProfileEditorClose;
                    imContainer.ShowMessage(imStringInput);

                    if (errors.Any())
                    {
                        StringBuilder sbErrors = new StringBuilder();
                        
                        foreach (var error in errors)
                        {
                            sbErrors.AppendLine(error.Key);
                            sbErrors.AppendLine(error.Value);
                        }

                        var imError = InternalMessageEx.CreateErrorMessage(
                            imContainer, "Importing database profile errors", sbErrors.ToString());
                        imContainer.ShowMessage(imError);
                    }
                }
            };

            imContainer.ShowMessage(imStringInput);
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

    }
}
