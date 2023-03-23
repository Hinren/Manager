using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Models
{
    [Serializable]
    public class SnippetCode : BaseViewModel
    {

        //  VARIABLES

        private string _code;
        private string _language;


        //  GETTERS & SETTERS

        [XmlText]
        public string Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        [XmlAttribute]
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged(nameof(Language));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetCode class constructor. </summary>
        public SnippetCode() { }

        #endregion CLASS METHODS

    }
}
