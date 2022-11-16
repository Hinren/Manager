using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hinren.ProjectManager.Data.MainMenu
{
    public class MainMenuItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<EventArgs> Action;


        //  VARIABLES

        private PackIconKind iconKind = PackIconKind.None;
        private string title = string.Empty;


        //  GETTERS & SETTERS

        public PackIconKind IconKind
        {
            get => iconKind;
            set
            {
                iconKind = value;
                OnPropertyChanged(nameof(IconKind));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> MainMenuItem constructor. </summary>
        public MainMenuItem()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> MainMenuItem constructor. </summary>
        /// <param name="title"> Menu item title. </param>
        /// <param name="iconKind"> Menu item icon. </param>
        /// <param name="selectAction"> Menu item select action. </param>
        public MainMenuItem(string title, PackIconKind iconKind = PackIconKind.None, EventHandler<EventArgs> selectAction = null)
        {
            Title = title;
            IconKind = iconKind;

            if (selectAction != null)
                Action += selectAction;
        }

        #endregion CLASS METHODS

        #region ACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke action method assigned to the menu item. </summary>
        public void InvokeAction()
        {
            Action?.Invoke(this, EventArgs.Empty);
        }

        #endregion ACTION METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler event. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
