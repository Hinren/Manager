using chkam05.Tools.ControlsEx;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Manager.Components.MainMenu
{
    public partial class MainMenuControl : UserControl, INotifyPropertyChanged
    {

        //  CONST

        public static readonly double MENU_WIDTH_MIN = 48;
        public static readonly double MENU_WIDTH_MAX = 224;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private bool animationLock = false;
        private MainMenuManager mainMenuManager;
        private double menuWidth = MENU_WIDTH_MIN;


        //  GETTERS & SETTERS

        public MainMenuManager MainMenuManager
        {
            get => mainMenuManager;
            set
            {
                mainMenuManager = value;
                OnPropertyChanged(nameof(MainMenuManager));
            }
        }

        public bool MainMenuExpanded
        {
            get => menuWidth > MENU_WIDTH_MIN + (MENU_WIDTH_MAX - MENU_WIDTH_MIN) / 2;
        }

        public double MenuWidth
        {
            get => menuWidth;
            set
            {
                menuWidth = value;
                OnPropertyChanged(nameof(MenuWidth));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainMenuControl class constructor. </summary>
        public MainMenuControl()
        {
            MainMenuManager = MainMenuManager.Instance;

            InitializeComponent();

            MainMenuManager.AddMenuItem("Main Menu", PackIconKind.HamburgerMenu, OnMainMenuItemClick);
        }

        #endregion CLASS METHODS

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Run collapse main menu animation. </summary>
        private void RunCollapseAnimation()
        {
            if (animationLock)
                return;

            animationLock = true;
            MenuWidth = MENU_WIDTH_MIN;
            Storyboard storyboard = Resources["ExpandMenuStoryboard"] as Storyboard;
            storyboard?.Begin();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Run expand main menu animation. </summary>
        private void RunExpandAnimation()
        {
            if (animationLock)
                return;

            animationLock = true;
            MenuWidth = MENU_WIDTH_MAX;
            Storyboard storyboard = Resources["ExpandMenuStoryboard"] as Storyboard;
            storyboard?.Begin();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing main menu expand/collapse animation. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            animationLock = false;
        }

        #endregion ANIMATION METHODS

        #region INTERFACE INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after enter cursor into main menu grid. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Mouse event arguments. </param>
        private void mainMenuGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after leaving cursor from main menu grid. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Mouse event arguments. </param>
        private void mainMenuGrid_MouseLeave(object sender, MouseEventArgs e)
        {
            RunCollapseAnimation();
        }

        #endregion INTERFACE INTERACTION METHODS

        #region MENU INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing selection in main menu list view. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void MainMenuListViewEx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ListViewEx)sender;
            var selectedItem = listView.SelectedItem;

            if (selectedItem != null)
            {
                var menuItem = (MainMenuItem)selectedItem;

                if (menuItem != null)
                    menuItem.InvokeSelection();

                listView.SelectedItem = null;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting general main menu item. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnMainMenuItemClick(object sender, EventArgs e)
        {
            if (MainMenuExpanded)
                RunCollapseAnimation();
            else
                RunExpandAnimation();
        }

        #endregion MENU INTERACTION METHODS

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

    }
}
