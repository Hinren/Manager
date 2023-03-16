using ProjectManager.Components;
using ProjectManager.Pages.Events;
using ProjectManager.Pages.Settings;
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

namespace ProjectManager.Pages.Base
{
    public partial class PagesManager : UserControl, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<PageLoadedEventArgs> OnPageBack;
        public event EventHandler<PageLoadedEventArgs> OnPageLoaded;


        //  VARIABLES

        private List<BasePage> _loadedPages;


        //  GETTERS & SETTERS

        public bool CanGoBack
        {
            get => _loadedPages.Any() && _loadedPages.IndexOf(LoadedPage) > 0;
        }

        public BasePage LoadedPage
        {
            get => _loadedPages.LastOrDefault();
        }

        public int PagesCount
        {
            get => _loadedPages.Count;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PagesManager class constructor. </summary>
        public PagesManager()
        {
            //  Setup Data Containers.
            _loadedPages = new List<BasePage>();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region CONTENT FRAME METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove all loaded pages from history. </summary>
        private void ClearAllContent()
        {
            _loadedPages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove currently loaded page from content frame. </summary>
        private void ClearCurrentContent()
        {
            contentFrame.Content = null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Metod invoked after loading page in frame. </summary>
        /// <param name="sender"> Object that invoked event. </param>
        /// <param name="e"> Navigated Event Arguments. </param>
        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous pages from content frame back entry.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from content fram back entry. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = contentFrame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = contentFrame.NavigationService.RemoveBackEntry();
        }

        #endregion CONTENT FRAME METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Go to previous page/pages by certain number of steps. </summary>
        /// <param name="backCount"> Number of steps back. </param>
        public void GoBack(int backCount = 1)
        {
            if (CanGoBack)
            {
                var currPageIndex = _loadedPages.IndexOf(LoadedPage);
                var destPageIndex = Math.Max(0, currPageIndex - backCount);

                //  Get previous page from list to load into content frame.
                var destPage = _loadedPages[destPageIndex];

                //  Remove other pages loaded further.
                _loadedPages.RemoveRange(destPageIndex + 1, PagesCount - (destPageIndex + 1));

                //  Load previous page and update current page index.
                contentFrame.Navigate(destPage);

                //  Invoke external event.
                var args = new PageLoadedEventArgs(destPage);
                OnPageBack?.Invoke(this, args);

                OnPropertyChanged(nameof(CanGoBack));
                OnPropertyChanged(nameof(LoadedPage));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigate to newly created page. </summary>
        /// <param name="page"> Page to load. </param>
        public void LoadPage(BasePage page)
        {
            var pageToLoad = page as Page;

            if (pageToLoad != null)
            {
                //  Add page to history.
                _loadedPages.Add(page);

                //  Load page.
                contentFrame.Navigate(pageToLoad);

                //  Invoke external event.
                var args = new PageLoadedEventArgs(page);
                OnPageLoaded?.Invoke(this, args);

                OnPropertyChanged(nameof(CanGoBack));
                OnPropertyChanged(nameof(LoadedPage));
            }
        }

        #endregion NAVIGATION METHODS

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

        #region PAGES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if page is already loaded. </summary>
        /// <param name="page"> Page to check. </param>
        /// <returns> True - pages is already loaded; False - otherwise. </returns>
        public bool HasPage(BasePage page)
        {
            return _loadedPages.Contains(page);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if page with specified type is already loaded. </summary>
        /// <param name="pageType"> Page type to check. </param>
        /// <returns> True - page with this type is already loaded; False - otherwise. </returns>
        public bool HasPage(Type pageType)
        {
            return _loadedPages.Any(p => pageType.IsAssignableFrom(((BasePage)p).GetType()));
        }

        #endregion PAGES MANAGEMENT METHODS

        #region STATIC PAGES LOADERS

        //  --------------------------------------------------------------------------------
        /// <summary> Load Settings Page (Appearance). </summary>
        /// <returns> Loaded page. </returns>
        public BasePage LoadSettingsAppearancePage()
        {
            var page = new SettingsAppearancePage(this);
            LoadPage(page);
            return page;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load Settings Page (Database). </summary>
        /// <returns> Loaded page. </returns>
        public BasePage LoadSettingsDatabasePage()
        {
            var page = new SettingsDatabasesPage(this);
            LoadPage(page);
            return page;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load Settings Page (Informations). </summary>
        /// <returns> Loaded page. </returns>
        public BasePage LoadSettingsInformationsPage()
        {
            var page = new SettingsInfoPage(this);
            LoadPage(page);
            return page;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load SettingsPage (General). </summary>
        /// <returns> Loaded page. </returns>
        public BasePage LoadSettingsMainPage()
        {
            var page = new SettingsPage(this);
            LoadPage(page);
            return page;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load and show DashboardPage. </summary>
        /// <returns> Loaded page. </returns>
        public BasePage LoadDashboardPage()
        {
            var page = new DashboardPage(this);
            LoadPage(page);
            return page;
        }

        #endregion STATIC PAGES LOADERS

    }
}
