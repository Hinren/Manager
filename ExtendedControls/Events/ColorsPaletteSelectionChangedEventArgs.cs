using ExtendedControls.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Events
{
    public class ColorsPaletteSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public ColorPaletteItem SelectedColorItem { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPaletteSelectionChangedEventArgs class constructor. </summary>
        /// <param name="colorPaletteItem"> Selected color item. </param>
        public ColorsPaletteSelectionChangedEventArgs(ColorPaletteItem colorPaletteItem)
        {
            SelectedColorItem = colorPaletteItem;
        }

        #endregion CLASS METHODS

    }
}
