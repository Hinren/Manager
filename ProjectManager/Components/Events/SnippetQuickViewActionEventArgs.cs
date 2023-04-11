using ProjectManager.Components.Statics;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Components.Events
{
    public class SnippetQuickViewActionEventArgs : EventArgs
    {

        //  VARIABLES

        public SnippetItem OryginalSnippetItem { get; private set; }
        public SnippetItem ModifiedSnippetItem { get; private set; }
        public SnippetQuickViewAction Action { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetQuickViewActionEventArgs class constructor. </summary>
        /// <param name="action"> SnippetQuickView action. </param>
        /// <param name="oryginalSnippetItem"> Oryginal snippet item. </param>
        /// <param name="modifiedSnippetItem"> Modified snippet item. </param>
        public SnippetQuickViewActionEventArgs(SnippetQuickViewAction action,
            SnippetItem oryginalSnippetItem, SnippetItem modifiedSnippetItem)
        {
            Action = action;
            OryginalSnippetItem = oryginalSnippetItem;
            ModifiedSnippetItem = modifiedSnippetItem;
        }

        #endregion CLASS METHODS

    }
}
