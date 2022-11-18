using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Events
{
    public class TextModifiedEventArgs : EventArgs
    {

        //  VARIABLES

        public string Text { get; private set; }
        public bool UserModified { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> TextModifiedEventArgs class constructor. </summary>
        /// <param name="text"> Text. </param>
        /// <param name="userModified"> Modification made by user. </param>
        public TextModifiedEventArgs(string text, bool userModified) : base()
        {
            Text = text;
            UserModified = userModified;
        }

        #endregion CLASS METHODS

    }
}
