﻿using chkam05.Tools.ControlsEx.WindowsEx;
using ProjectManager.Components;
using ProjectManager.Pages.Base;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ProjectManager.Windows
{
    public partial class MainWindow : WindowEx
    {

        //  GETTERS & SETTERS

        public MainMenuUserControl MainMenu
        {
            get => mainMenu;
        }

        public PagesManager PagesManager
        {
            get => pagesManager;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MAIN MENU METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing BackButton in MainMenu. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event arguments. </param>
        private void mainMenu_OnBackItemSelect(object sender, EventArgs e)
        {
            if (PagesManager.CanGoBack)
                PagesManager.GoBack();
        }

        #endregion MAIN MENU METHODS

        #region PAGES MANAGER METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Page Loaded Event Arguments. </param>
        private void pagesManager_OnPageLoaded(object sender, Pages.Events.PageLoadedEventArgs e)
        {
            if (e.Page.MainMenuItems != null)
            {
                MainMenu.ClearItems();

                if (e.Page.MainMenuItems.Any())
                    MainMenu.AddMenuItems(e.Page.MainMenuItems);
            }
        }

        #endregion PAGES MANAGER METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading window. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void WindowEx_Loaded(object sender, RoutedEventArgs e)
        {
            PagesManager.LoadWelcomePage();
        }

        #endregion WINDOW METHODS

    }
}
