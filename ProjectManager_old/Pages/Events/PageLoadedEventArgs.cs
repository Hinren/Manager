using Hinren.ProjectManager.Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hinren.ProjectManager.Pages.Events
{
    public class PageLoadedEventArgs : EventArgs
    {

        //  VARIABLES

        public IPage Page { get; private set; }
        public bool Returned { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> PageLoadedEventArgs class constructor. </summary>
        /// <param name="page"> Interface of loaded page. </param>
        /// <param name="returned"> Page has been loaded by moving back. </param>
        public PageLoadedEventArgs(IPage page, bool returned = false) : base()
        {
            Page = page;
            Returned = returned;
        }

        #endregion CLASS METHODS

    }
}
