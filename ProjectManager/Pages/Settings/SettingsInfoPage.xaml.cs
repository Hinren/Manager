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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.Pages.Settings
{
    public partial class SettingsInfoPage : BasePage
    {

        //  VARIABLES

        private string _appCompany;
        private string _appCopyright;
        private string _appDescription;
        private string _appLocation;
        private string _appName;
        private string _appPath;
        private string _appTitle;
        private string _appVersion;


        //  GETTERS & SETTERS

        public string AppCompany
        {
            get => _appCompany;
            set
            {
                _appCompany = value;
                OnPropertyChanged(nameof(AppCompany));
            }
        }

        public string AppCopyright
        {
            get => _appCopyright;
            set
            {
                _appCopyright = value;
                OnPropertyChanged(nameof(AppCopyright));
            }
        }

        public string AppDescription
        {
            get => _appDescription;
            set
            {
                _appDescription = value;
                OnPropertyChanged(nameof(AppDescription));
            }
        }

        public string AppLocation
        {
            get => _appLocation;
            set
            {
                _appLocation = value;
                OnPropertyChanged(nameof(AppLocation));
            }
        }

        public string AppName
        {
            get => _appName;
            set
            {
                _appName = value;
                OnPropertyChanged(nameof(AppName));
            }
        }

        public string AppPath
        {
            get => _appPath;
            set
            {
                _appPath = value;
                OnPropertyChanged(nameof(AppPath));
            }
        }

        public string AppTitle
        {
            get => _appTitle;
            set
            {
                _appTitle = value;
                OnPropertyChanged(nameof(AppTitle));
            }
        }

        public string AppVersion
        {
            get => _appVersion;
            set
            {
                _appVersion = value;
                OnPropertyChanged(nameof(AppVersion));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsInfoPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SettingsInfoPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Setup data.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data. </summary>
        private void SetupData()
        {
            AppCompany = ApplicationHelper.GetApplicationCompany();
            AppCopyright = ApplicationHelper.GetApplicationCopyright();
            AppDescription = ApplicationHelper.GetApplicationDescription();
            AppLocation = ApplicationHelper.GetApplicationLocation();
            AppName = ApplicationHelper.GetApplicationName();
            AppPath = ApplicationHelper.GetApplicationPath();
            AppTitle = ApplicationHelper.GetApplicationTitle();
            AppVersion = ApplicationHelper.GetApplicationVersion().ToString();
        }

        #endregion SETUP METHODS

    }
}
