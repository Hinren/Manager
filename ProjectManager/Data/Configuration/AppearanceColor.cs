using chkam05.Tools.ControlsEx.Colors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Configuration
{
    public class AppearanceColor
    {

        //  VARIABLES

        public string ColorCode { get; set; }
        public string ColorName { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> AppearanceColor class constructor. </summary>
        [JsonConstructor]
        public AppearanceColor()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> AppearanceColor class constructor. </summary>
        /// <param name="colorCode"> Hexadecimal color code. </param>
        /// <param name="colorName"> Color name. </param>
        public AppearanceColor(string colorCode, string colorName)
        {
            ColorCode = colorCode;
            ColorName = colorName;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> AppearanceColor class constructor. </summary>
        /// <param name="colorPalleteItem"> Color palette item. </param>
        public AppearanceColor(ColorPaletteItem colorPalleteItem)
        {
            ColorCode = colorPalleteItem.ColorCode;
            ColorName = colorPalleteItem.Name;
        }

        #endregion CLASS METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert to color palette utem. </summary>
        /// <returns> Color palette item. </returns>
        public ColorPaletteItem ToColorPaletteItem()
        {
            return new ColorPaletteItem(ColorCode, ColorName);
        }

        #endregion UTILITY METHODS

    }
}
