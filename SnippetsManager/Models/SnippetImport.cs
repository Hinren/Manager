using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager.Models
{
    [Serializable]
    public class SnippetImport : BaseViewModel
    {

        //  VARIABLES

        private string _namespace;


        //  GETTERS & SETTERS

        public string Namespace
        {
            get => _namespace;
            set
            {
                _namespace = value;
                OnPropertyChanged(nameof(Namespace));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetImport class constructor. </summary>
        public SnippetImport() { }

        #endregion CLASS METHODS

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public override object Clone()
        {
            return new SnippetImport()
            {
                Namespace = Namespace
            };
        }

        #endregion CLONE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public override void UpdateValues(BaseViewModel model)
        {
            if (model is SnippetImport snippetImport)
            {
                Namespace = snippetImport.Namespace;
            }
        }

        #endregion UPDATE METHODS

    }
}
