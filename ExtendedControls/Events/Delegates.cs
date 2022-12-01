using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Events
{
    public class Delegates
    {

        //  COLORS

        /// <summary> Method invoked after changing color selection in ColorsPaletteEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        public delegate void ColorsPalleteSelectionChanged(object sender, ColorsPaletteSelectionChangedEventArgs e);


        //  INTERNAL MESSAGES

        /// <summary> Method invoked after closing base InternalMessage. </summary>
        /// <typeparam name="T"> Event arguments type based on InternalMessageCloseEventArgs. </typeparam>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        public delegate void InternalMessageClose<T>(object sender, T e) where T : InternalMessageCloseEventArgs;

        /// <summary> Method invoked after hiding InternalMessage. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        public delegate void InternalMessageHide(object sender, InternalMessageHideEventArgs e);


        //  TEXT BOXES

        /// <summary> Method invoked after modifying text. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        public delegate void TextModifiedEventHandler(object sender, TextModifiedEventArgs e);

        /// <summary> Method invoked after text modification finished. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        public delegate void TextModificationFinishedEventHandler(object sender, TextModificationFinishedEventArgs e);

    }
}
