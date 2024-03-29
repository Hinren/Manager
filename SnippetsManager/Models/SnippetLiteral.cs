﻿using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager.Models
{
    [Serializable]
    public class SnippetLiteral : SnippetDeclaration
    {

        //  VARIABLES

        private string _default;
        private string _id;
        private string _toolTip;


        //  GETTERS & SETTERS

        public string Default
        {
            get => _default;
            set
            {
                _default = value;
                OnPropertyChanged(nameof(Default));
            }
        }

        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string ToolTip
        {
            get => _toolTip;
            set
            {
                _toolTip = value;
                OnPropertyChanged(nameof(ToolTip));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetLiteral class constructor. </summary>
        public SnippetLiteral() { }

        #endregion CLASS METHODS

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public override object Clone()
        {
            var snippetLiteral = new SnippetLiteral()
            {
                Default = Default,
                ID = ID,
                ToolTip = ToolTip,
            };

            snippetLiteral.IsModified = IsModified;
            return snippetLiteral;
        }

        #endregion CLONE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public override void UpdateValues(BaseViewModel model)
        {
            if (model is SnippetLiteral snippetLiteral)
            {
                Default = snippetLiteral.Default;
                ID = snippetLiteral.ID;
                ToolTip = snippetLiteral.ToolTip;
            }
        }

        #endregion UPDATE METHODS

    }
}
