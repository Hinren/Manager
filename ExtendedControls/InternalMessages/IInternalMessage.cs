using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.InternalMessages
{
    public interface IInternalMessage
    {

        //  GETTERS & SETTERS

        bool AllowHide { get; set; }

        bool IsHidden { get; }

        bool IsLoadingComplete { get; }

        InternalMessageResult Result { get; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Close InternalMessage. </summary>
        void Close();

        //  --------------------------------------------------------------------------------
        /// <summary> Hide InternalMessage if it is allowed. </summary>
        void Hide();

        //  --------------------------------------------------------------------------------
        /// <summary> Show hidden InternalMessage. </summary>
        void Show();

    }
}
