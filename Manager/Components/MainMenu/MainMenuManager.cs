using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Components.MainMenu
{
    public class MainMenuManager : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static MainMenuManager instance;
        private ObservableCollection<MainMenuItem> menuItems;


        //  GETTERS & SETTERS

        public static MainMenuManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainMenuManager();

                return instance;
            }
        }

        public ObservableCollection<MainMenuItem> MenuItems
        {
            get => menuItems;
            set
            {
                menuItems = value;
                menuItems.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(MenuItems)); };
                OnPropertyChanged(nameof(MenuItems));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainMenuManager class constructor. </summary>
        private MainMenuManager()
        {
            MenuItems = new ObservableCollection<MainMenuItem>();
        }

        #endregion CLASS METHODS

        #region MAIN MENU METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add menu item. </summary>
        /// <param name="title"> Menu item title. </param>
        /// <param name="iconKind"> Menu item icon kind. </param>
        /// <param name="onItemSelectEvent"> On menu item select event. </param>
        public void AddMenuItem(string title, PackIconKind iconKind, EventHandler<EventArgs> onItemSelectEvent)
        {
            var menuItem = new MainMenuItem()
            {
                Title = title,
                IconKind = iconKind
            };

            if (onItemSelectEvent != null)
                menuItem.OnItemSelect += onItemSelectEvent;

            MenuItems.Add(menuItem);
        }

        #endregion MAIN MENU METHODS

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
