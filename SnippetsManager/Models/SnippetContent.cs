using CoreLibs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Models
{
    public class SnippetContent : BaseViewModel
    {

        //  VARIABLES

        private SnippetCode _code;
        private List<SnippetDeclaration> _declarations;
        private List<SnippetImport> _imports;


        //  GETTERS & SETTERS

        public SnippetCode Code
        {
            get => _code;
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
            }
        }

        [XmlArray("Declarations")]
        [XmlArrayItem("Literal", typeof(SnippetLiteral))]
        public List<SnippetDeclaration> Declarations
        {
            get => _declarations;
            set
            {
                _declarations = value;
                OnPropertyChanged(nameof(Declarations));
            }
        }

        [XmlArray("Imports")]
        [XmlArrayItem("Import")]
        public List<SnippetImport> Imports
        {
            get => _imports;
            set
            {
                _imports = value;
                OnPropertyChanged(nameof(Imports));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetContent class constructor. </summary>
        public SnippetContent() { }

        #endregion CLASS METHODS

    }
}
