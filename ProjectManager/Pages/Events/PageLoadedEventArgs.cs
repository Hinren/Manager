using ProjectManager.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Pages.Events
{
    public class PageLoadedEventArgs : EventArgs
    {

        //  VARIABLES

        public BasePage UnloadedPage { get; private set; }
        public BasePage LoadedPage { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PageLoadedEventArgs class constructor. </summary>
        /// <param name="unloadedPage"> Unloaded page. </param>
        /// <param name="loadedPage"> Loaded page. </param>
        public PageLoadedEventArgs(BasePage unloadedPage, BasePage loadedPage)
        {
            UnloadedPage = unloadedPage;
            LoadedPage = loadedPage;
        }

        #endregion CLASS METHODS

    }
}
