using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Events
{
    public class InternalMessageCloseEventArgs : EventArgs
    {

        //  VARIABLES

        public InternalMessageResult Result { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageCloseEventArgs class constructor. </summary>
        /// <param name="result"> Result. </param>
        public InternalMessageCloseEventArgs(InternalMessageResult result) : base()
        {
            Result = result;
        }

        #endregion CLASS METHODS

    }
}
