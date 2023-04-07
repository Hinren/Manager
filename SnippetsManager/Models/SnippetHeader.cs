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

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public override object Clone()
        {
            var snippetHeader = new SnippetHeader()
            {
                Author = Author,
                Description = Description,

                Keywords = Keywords != null
                    ? new List<string>(Keywords)
                    : new List<string>(),

                Shortcut = Shortcut,

                SnippetTypes = SnippetTypes != null
                    ? new List<string>(SnippetTypes)
                    : new List<string>(),

                Title = Title
            };

            snippetHeader.IsModified = IsModified;
            return snippetHeader;
        }

        #endregion CLONE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public override void UpdateValues(BaseViewModel model)
        {
            if (model is SnippetHeader snippetHeader)
            {
                Author = snippetHeader.Author;
                Description = snippetHeader.Description;

                Keywords = snippetHeader.Keywords != null
                    ? new List<string>(snippetHeader.Keywords)
                    : new List<string>();

                Shortcut = snippetHeader.Shortcut;

                SnippetTypes = snippetHeader.SnippetTypes != null
                    ? new List<string>(snippetHeader.SnippetTypes)
                    : new List<string>();

                Title = snippetHeader.Title;
            }
        }

        #endregion UPDATE METHODS

    }
}
