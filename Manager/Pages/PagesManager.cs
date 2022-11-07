using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Manager.Pages
{
    public class PagesManager
    {

        //  VARIABLES

        private Frame contentFrame;
        private List<Page> pages;


        //  GETTERS & SETTERS

        public bool CanGoBack
        {
            get => pages.Any() && LoadedPageIndex > 0;
        }

        public Page LoadedPage
        {
            get => contentFrame.Content as Page;
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
        /// <summary> PagesManager class constructor. </summary>
        /// <param name="contentFrame"> Frame where pages will be loaded. </param>
        public PagesManager(Frame contentFrame)
        {
            this.contentFrame = contentFrame;
            this.contentFrame.Navigated += ContentFrame_Navigated;

            pages = new List<Page>();
        }

        #endregion CLASS METHODS

        #region FRAME MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Remove all loaded frames from PagesManager and ContentFrame. </summary>
        private void ClearPages()
        {
            RemoveBackEntry();

            contentFrame.Content = null;
            pages.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Metod invoked after loading page to the ContentFrame. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Navigated Event Arguments. </param>
        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous pages from content frame back entry.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove previous pages from ContentFrame back entry. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from ContentFrame navigation service.
            var backEntry = contentFrame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = contentFrame.NavigationService.RemoveBackEntry();
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
                contentFrame.Navigate(previousPage);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load newly created page to ContentFrame. </summary>
        /// <param name="page"> Page to load. </param>
        public void LoadPage(Page page)
        {
            if (page != null)
            {
                pages.Add(page);
                contentFrame.Navigate(page);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Load newly created page to ContentFrame as single page removing previously loaded. </summary>
        /// <param name="page"> Page to load. </param>
        public void LoadSinglePage(Page page)
        {
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
