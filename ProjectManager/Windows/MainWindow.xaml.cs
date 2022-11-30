using Hinren.ProjectManager.Components;
using Hinren.ProjectManager.Data.MainMenu;
using Hinren.ProjectManager.Pages;
using Hinren.ProjectManager.Pages.Base;
using Hinren.ProjectManager.Pages.Events;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace Hinren.ProjectManager.Windows
{
    public partial class MainWindow : Window
    {

        //  VARIABLES

        //  GETTERS & SETTERS

        public PagesControl PagesController
        {
            get => pagesControl;
        }

        public MainMenuControl MainMenuController
        {
            get => mainMenuControl;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MAIN MENU ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting back main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnBackMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.GoBack();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting home main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnHomeMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<HomePage>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting appearance settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnSettingsAppearanceMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<SettingsAppearancePage>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting general settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnSettingsGeneralMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<SettingsGeneralPage>(new object[] { MainMenuController });
        }
        
        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting info settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnSettingsInfoMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<SettingsInfoPage>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting appearance settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnSettingsSnippetsMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<SettingsSnippetsPage>();
        }

        #endregion MAIN MENU ITEMS METHODS

        #region MAIN MENU SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup main menu items. </summary>
        private void SetupMainMenu()
        {
            MainMenuController.ClearItems();
            MainMenuController.MenuBackItemVisible = false;
            MainMenuController.AddMenuItem(new MainMenuItem("Home", PackIconKind.Home, OnHomeMenuItemSelect));
            MainMenuController.AddMenuItem(new MainMenuItem("Settings", PackIconKind.Gear, OnSettingsGeneralMenuItemSelect));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Setup settings menu items. </summary>
        private void SetupSettingsMenu()
        {
            MainMenuController.ClearItems();
            MainMenuController.MenuBackItemVisible = true;
            MainMenuController.AddMenuItem(new MainMenuItem("Appearance", PackIconKind.ColorLens, OnSettingsAppearanceMenuItemSelect));
            MainMenuController.AddMenuItem(new MainMenuItem("Snippets", PackIconKind.FileSettingsOutline, OnSettingsSnippetsMenuItemSelect));
            MainMenuController.AddMenuItem(new MainMenuItem("Informations", PackIconKind.InfoCircle, OnSettingsInfoMenuItemSelect));
        }

        #endregion MAIN MENU SETUP METHODS

        #region PAGES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading any page by pages controller. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Page Loaded Event Arguments. </param>
        private void OnPageLoaded(object sender, PageLoadedEventArgs e)
        {
            var pageType = e.Page.GetType();

            if (pageType == typeof(HomePage))
                SetupMainMenu();

            else if (pageType == typeof(SettingsGeneralPage))
                SetupSettingsMenu();
        }

        #endregion PAGES MANAGEMENT METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading window. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //  Load first page.
            PagesController.LoadPage<HomePage>();
        }

        #endregion WINDOW METHODS

    }
}
