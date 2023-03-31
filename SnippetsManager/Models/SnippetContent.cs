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
    public class SnippetContent : BaseViewModel
    {

        //  VARIABLES

        private SnippetCode _code;
        private List<SnippetDeclaration> _declarations = new List<SnippetDeclaration>();
        private List<SnippetImport> _imports = new List<SnippetImport>();


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
        public List<SnippetDeclaration>? Declarations
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
        public List<SnippetImport>? Imports
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

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public override object Clone()
        {
            return new SnippetContent()
            {
                Code = (SnippetCode)Code.Clone(),

                Declarations = Declarations != null
                    ? Declarations.Select(d => (SnippetDeclaration)d.Clone()).ToList()
                    : new List<SnippetDeclaration>(),

                Imports = Imports != null
                    ? Imports.Select(i => (SnippetImport)i.Clone()).ToList()
                    : new List<SnippetImport>(),
            };
        }

        #endregion CLONE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public override void UpdateValues(BaseViewModel model)
        {
            if (model is SnippetContent snippetContent)
            {
                Code.UpdateValues(snippetContent.Code);

                Declarations = snippetContent?.Declarations != null
                    ? snippetContent.Declarations?.Select(d => (SnippetDeclaration)d.Clone()).ToList()
                    : new List<SnippetDeclaration>();

                Imports = snippetContent?.Imports != null
                    ? snippetContent.Imports?.Select(i => (SnippetImport)i.Clone()).ToList()
                    : new List<SnippetImport>();
            }
        }

        #endregion UPDATE METHODS

    }
}
