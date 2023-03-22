using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Models
{
    public class SnippetHeader : BaseViewModel
    {

        //  VARIABLES

        private string _author;
        private string _description;
        private List<string> _keywords;
        private string _shortcut;
        private List<string> _snippetTypes;
        private string _title;


        //  GETTERS & SETTERS

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        [XmlArray("Keywords")]
        [XmlArrayItem("Keyword")]
        public List<string> Keywords
        {
            get => _keywords;
            set
            {
                _keywords = value;
                OnPropertyChanged(nameof(Keywords));
            }
        }

        public string Shortcut
        {
            get => _shortcut;
            set
            {
                _shortcut = value;
                OnPropertyChanged(nameof(Shortcut));
            }
        }

        [XmlArray("SnippetTypes")]
        [XmlArrayItem("SnippetType")]
        public List<string> SnippetTypes
        {
            get => _snippetTypes;
            set
            {
                _snippetTypes = value;
                OnPropertyChanged(nameof(SnippetTypes));
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetHeader class constructor. </summary>
        public SnippetHeader() { }

        #endregion CLASS METHODS

    }
}
