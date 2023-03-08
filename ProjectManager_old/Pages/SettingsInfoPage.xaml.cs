using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using Hinren.ProjectManager.Utilities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hinren.ProjectManager.Pages
{
    public partial class SettingsInfoPage : BasePage, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        public ConfigurationManager ConfigurationManager { get; private set; }

        private string applicationCompany;
        private string applicationCopyright;
        private string applicationName;
        private string applicationTitle;
        private string applicationVersion;


        //  GETTERS & SETTERS

        public string ApplicationCompany
        {
            get => applicationCompany;
            set
            {
                applicationCompany = value;
                OnPropertyChanged(nameof(ApplicationCompany));
            }
        }

        public string ApplicationCopyright
        {
            get => applicationCopyright;
            set
            {
                applicationCopyright = value;
                OnPropertyChanged(nameof(ApplicationCopyright));
            }
        }

        public string ApplicationName
        {
            get => applicationName;
            set
            {
                applicationName = value;
                OnPropertyChanged(nameof(ApplicationName));
            }
        }

        public string ApplicationTitle
        {
            get => applicationTitle;
            set
            {
                applicationTitle = value;
                OnPropertyChanged(nameof(ApplicationTitle));
            }
        }

        public string ApplicationVersion
        {
            get => applicationVersion;
            set
            {
                applicationVersion = value;
                OnPropertyChanged(nameof(ApplicationVersion));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsInfoPage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public SettingsInfoPage(PagesControl pagesController, object[] args = null) : base(pagesController, args)
        {
            ConfigurationManager = ConfigurationManager.Instance;

            InitializeComponent();
        }

        #endregion CLASS METHODS

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

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ApplicationCompany = ApplicationHelper.GetApplicationCompany();
            ApplicationCopyright = ApplicationHelper.GetApplicationCopyright();
            ApplicationName = ApplicationHelper.GetApplicationName();
            ApplicationTitle = ApplicationHelper.GetApplicationTitle();
            ApplicationVersion = ApplicationHelper.GetApplicationVersion().ToString();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ConfigurationManager.SaveSettings();
        }

        #endregion PAGE METHODS

    }
}
