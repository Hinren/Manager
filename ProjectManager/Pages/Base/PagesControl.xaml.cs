using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Hinren.ProjectManager.Pages.Base
{
    public partial class PagesControl : UserControl
    {

        //  VARIABLES

        private List<IPage> pages;


        //  GETTERS & SETTERS

        public Frame Container
        {
            get => contentFrame;
        }

        public bool CanGoBack
        {
            get => pages.Any() && LoadedPageIndex > 0;
        }

        public IPage LoadedPage
        {
            get => Container.Content as IPage;
        }

        public int LoadedPageIndex
        {
            get => LoadedPage != null ? pages.IndexOf(LoadedPage) : -1;
        }

        public int PagesCount
        {
            get => pages.Count;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PagesControl class constructor. </summary>
        public PagesControl()
        {
            pages = new List<IPage>();

            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region FRAME MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove all loaded frames from history and content frame. </summary>
        private void ClearPages()
        {
            RemoveBackEntry();

            Container.Content = null;
            pages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Metod invoked after loading page in Frame. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Navigated Event Arguments. </param>
        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous loaded pages from content frame back entry and allow custom control.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from content frame back entry. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = Container.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = Container.NavigationService.RemoveBackEntry();
        }

        #endregion FRAME MANAGEMENT METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load previously loaded page to ContentFrame. </summary>
        public void GoBack()
        {
            if (CanGoBack)
            {
                var loadedPageIndex = LoadedPageIndex;

                //  Get previous page from list to load into ContentFrame.
                var previousPage = pages[loadedPageIndex - 1];

                //  Remove other pages loaded further.
                pages.RemoveRange(loadedPageIndex, PagesCount - loadedPageIndex);

                //  Load previous page to ContentFrame.
                Container.Navigate(previousPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create and load page to content frame. </summary>
        /// <typeparam name="T"> Page type based on BasePage and IPage interface. </typeparam>
        /// <param name="args"> Arguments that will be passed to Page constructor. </param>
        public void LoadPage<T>() where T : BasePage, IPage
        {
            var page = Activator.CreateInstance(typeof(T), new object[] { this }) as IPage;

            if (page != null)
            {
                pages.Add(page);
                contentFrame.Navigate(page);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create and load page to content frame as single page removing previously loaded. </summary>
        /// <typeparam name="T"> Page type based on BasePage and IPage interface. </typeparam>
        /// <param name="args"> Arguments that will be passed to Page constructor. </param>
        public void LoadSinglePage<T>(params object[] args) where T : BasePage, IPage
        {
            var page = Activator.CreateInstance(typeof(T), new object[] { this }) as IPage;

            if (page != null)
            {
                ClearPages();

                pages.Add(page);
                contentFrame.Navigate(page);
            }
        }

        #endregion NAVIGATION METHODS

    }
}
