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

        public BasePage Page { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PageLoadedEventArgs class constructor. </summary>
        /// <param name="page"> Loaded page. </param>
        public PageLoadedEventArgs(BasePage page)
        {
            Page = page;
        }

        #endregion CLASS METHODS

    }
}
