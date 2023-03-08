using ExtendedControls;
using Hinren.ProjectManager.Components;
using Hinren.ProjectManager.Data.MainMenu;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Hinren.ProjectManager.Pages
{
    public partial class SettingsGeneralPage : BasePage
    {

        //  VARIABLES

        private MainMenuControl mainMenuController;

        public ConfigurationManager ConfigurationManager { get; private set; }


        //  GETTERS & SETTERS

        public MainMenuControl MainMenuController
        {
            get => mainMenuController;
            private set
            {
                mainMenuController = value;
                OnPropertyChanged(nameof(MainMenuController));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UserSettingsPage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public SettingsGeneralPage(PagesControl pagesController, object[] args = null) : base(pagesController, args)
        {
            ConfigurationManager = ConfigurationManager.Instance;

            if (args != null && args.Any(a => a.GetType() == typeof(MainMenuControl)))
                MainMenuController = (MainMenuControl) args.First(a => a.GetType() == typeof(MainMenuControl));

            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MENU ITEMS INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ExtListView)sender;
            var selectedItem = listView.SelectedItem;

            if (selectedItem != null)
            {
                var menuItem = (MainMenuItem)selectedItem;

                if (menuItem != null)
                    menuItem.InvokeAction();

                listView.SelectedItem = null;
            }
        }

        #endregion MENU ITEMS INTERACTION METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ConfigurationManager.SaveSettings();
        }

        #endregion PAGE METHODS

    }
}
