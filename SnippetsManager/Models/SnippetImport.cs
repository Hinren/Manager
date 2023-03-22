using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager.Models
{
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

    }
}
