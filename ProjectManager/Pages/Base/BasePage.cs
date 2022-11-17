using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Hinren.ProjectManager.Pages.Base
{
    public class BasePage : Page, IPage, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        public PagesControl PagesController { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BasePage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public BasePage(PagesControl pagesController) : base()
        {
            PagesController = pagesController;
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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();
        }

        #endregion TEMPLATE METHODS

    }
}
