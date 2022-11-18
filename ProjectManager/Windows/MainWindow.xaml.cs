using DomainModel.Models.SettingsUserApp;
using Hinren.ProjectManager.Data.MainMenu;
using Hinren.ProjectManager.Pages;
using Hinren.ProjectManager.Pages.Base;
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetupMainMenu();
        }

        #endregion CLASS METHODS

        #region MAIN MENU ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting home main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnHomeMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<HomePage>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event Arguments. </param>
        private void OnSettingsMenuItemSelect(object sender, EventArgs e)
        {
            PagesController.LoadPage<UserSettingsPage>();
        }

        #endregion MAIN MENU ITEMS METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup main menu items. </summary>
        private void SetupMainMenu()
        {
            mainMenuControl.AddMenuItem(new MainMenuItem("Home", PackIconKind.Home, OnHomeMenuItemSelect));
            mainMenuControl.AddMenuItem(new MainMenuItem("Settings", PackIconKind.GearOutline, OnSettingsMenuItemSelect));
        }

        #endregion SETUP METHODS

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
