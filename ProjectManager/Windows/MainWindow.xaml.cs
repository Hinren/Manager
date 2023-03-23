using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.WindowsEx;
using ProjectManager.Components;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
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
using System.Windows.Threading;

namespace ProjectManager.Windows
{
    public partial class MainWindow : WindowEx
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }


        //  GETTERS & SETTERS

        public InternalMessagesExContainer InternalMessagesContainer
        {
            get => imContainer;
        }

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
            Dispatcher x;

            //  Initialize modules.
            ConfigManager = ConfigManager.Instance;

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region MAIN MENU METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load main menu items defined in page. </summary>
        /// <param name="page"> Page. </param>
        private void LoadMenuFromPage(BasePage page)
        {
            if (page?.MainMenuItems != null)
            {
                MainMenu.ClearItems();

                if (page.MainMenuItems.Any())
                    MainMenu.AddMenuItems(page.MainMenuItems);
            }
        }

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
        /// <summary> Method invoked after navigating to previous page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Page Loaded Event Arguments. </param>
        private void pagesManager_OnPageBack(object sender, Pages.Events.PageLoadedEventArgs e)
        {
            LoadMenuFromPage(e.Page);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Page Loaded Event Arguments. </param>
        private void pagesManager_OnPageLoaded(object sender, Pages.Events.PageLoadedEventArgs e)
        {
            LoadMenuFromPage(e.Page);
        }

        #endregion PAGES MANAGER METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked before closing window. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Cancel Event Arguments. </param>
        private void WindowEx_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ConfigManager.Configuration.WindowPosition = new Point(Left, Top);
            ConfigManager.Configuration.WindowSize = new Size(Width, Height);

            //  Save settings.
            ConfigManager.SaveSettings();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading window. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void WindowEx_Loaded(object sender, RoutedEventArgs e)
        {
            //  Load window size and position.
            Left = ConfigManager.Configuration.WindowPosition.X;
            Top = ConfigManager.Configuration.WindowPosition.Y;
            Height = ConfigManager.Configuration.WindowSize.Height;
            Width = ConfigManager.Configuration.WindowSize.Width;

            //  Fix position on screen.
            var screen = ApplicationHelper.GetScreenWhereIsWindow(this);

            if (screen != null)
                ApplicationHelper.AdjustWindowToScreen(this, screen);
            else
                ApplicationHelper.AdjustWindowToPrimaryScreen(this);

            //  Load start page.
            PagesManager.LoadDashboardPage();
        }

        #endregion WINDOW METHODS

    }
}
