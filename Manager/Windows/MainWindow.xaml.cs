using chkam05.Tools.ControlsEx.InternalMessages;
using Manager.Components.MainMenu;
using Manager.Pages;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Manager.Windows
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private MainMenuManager mainMenuManager;
        private PagesManager pagesManager;


        //  GETTERS & SETTERS

        public InternalMessagesExContainer InternalMessagesContainer
        {
            get => internalMessagesContainer;
        }

        public MainMenuManager MainMenuManager
        {
            get => mainMenuManager;
            private set
            {
                mainMenuManager = value;
                OnPropertyChanged(nameof(MainMenuManager));
            }
        }

        public PagesManager PagesManager
        {
            get => pagesManager;
            private set
            {
                pagesManager = value;
                OnPropertyChanged(nameof(PagesManager));
            }
        }


        //  METHODS

        #region WINDOW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindow class constructor. </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetupMainMenu();

            PagesManager = new PagesManager(contentFrame);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading window. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PagesManager.LoadSinglePage(new HomePage());
        }

        #endregion WINDOW METHODS

        #region MAIN MENU INTERACTIONS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting home main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnMainMenuHomeSelect(object sender, EventArgs e)
        {
            PagesManager.LoadSinglePage(new HomePage());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting projects management main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnMainMenuProjectsManagementSelect(object sender, EventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting settings main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnMainMenuSettingsSelect(object sender, EventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting informations main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnMainMenuInformationsSelect(object sender, EventArgs e)
        {
            var app = (App)Application.Current;

            string messageContent = app.GetApplicationName()
                + Environment.NewLine
                + app.GetApplicationCompany()
                + Environment.NewLine
                + app.GetApplicationCopyright()
                + Environment.NewLine
                + app.GetApplicationVersion().ToString();

            var message = InternalMessageEx.CreateInfoMessage(
                InternalMessagesContainer, $"Welcome in {app.GetApplicationTitle()}", messageContent);

            message.IconKind = PackIconKind.Smiley;

            InternalMessagesContainer.ShowMessage(message);
        }

        #endregion MAIN MENU INTERACTIONS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup main menu. </summary>
        private void SetupMainMenu()
        {
            MainMenuManager = MainMenuManager.Instance;

            MainMenuManager.AddMenuItem("Home", PackIconKind.Home, OnMainMenuHomeSelect);
            MainMenuManager.AddMenuItem("Projects Management", PackIconKind.ApplicationSettings, OnMainMenuProjectsManagementSelect);
            MainMenuManager.AddMenuItem("Settings", PackIconKind.Gear, OnMainMenuSettingsSelect);
            MainMenuManager.AddMenuItem("Informations", PackIconKind.InfoCircle, OnMainMenuInformationsSelect);
        }

        #endregion SETUP METHODS

    }
}
