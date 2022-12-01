using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Events
{
    public class InternalMessageHideEventArgs : EventArgs
    {

        //  VARIABLES

        public bool Hidden { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageHideEventArgs class constructor. </summary>
        /// <param name="hidden"> InternalMessage hide state. </param>
        public InternalMessageHideEventArgs(bool hidden) : base()
        {
            Hidden = hidden;
        }

        #endregion CLASS METHODS

    }
}
