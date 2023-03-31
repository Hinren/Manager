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

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public virtual object Clone()
        {
            return new SnippetCode()
            {
                Code = Code,
                Language = Language
            };
        }

        #endregion CLONE METHODS

    }
}
