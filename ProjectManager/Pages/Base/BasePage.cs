using ProjectManager.Data.MainMenu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManager.Pages.Base
{
    public class BasePage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        protected PagesManager _pagesManager;


        //  GETTERS & SETTERS

        public virtual List<MainMenuItem> MainMenuItems { get; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BasePage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public BasePage(PagesManager pagesManager)
        {
            _pagesManager = pagesManager;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BasePage class constructor. </summary>
        static BasePage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BasePage),
                new FrameworkPropertyMetadata(typeof(BasePage)));
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
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
