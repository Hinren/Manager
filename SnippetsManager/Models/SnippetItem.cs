using CoreLibs.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Models
{
    [Serializable]
    [XmlRoot("CodeSnippet", Namespace = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet")]
    public class SnippetItem : BaseViewModel, ICloneable
    {

        //  VARIABLES

        private string _filePath;
        private SnippetHeader _header;
        private SnippetContent _snippet;


        //  GETTERS & SETTERS

        [XmlIgnore]
        public string FilePath
        {
            get => _filePath;
            set
            {
                if (!ValidateFilePathValue(value))
                    throw new ArgumentException("Snippet file does not exists.");

                _filePath = value;
            }
        }

        public SnippetHeader Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged(nameof(Header));
            }
        }

        public SnippetContent Snippet
        {
            get => _snippet;
            set
            {
                _snippet = value;
                OnPropertyChanged(nameof(Snippet));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetItem class constructor. </summary>
        public SnippetItem() { }

        #endregion CLASS METHODS

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        public object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion CLONE METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate file path value. </summary>
        /// <param name="filePath"> File path value. </param>
        /// <returns> True - path is valid; False - otherwise. </returns>
        private bool ValidateFilePathValue(string filePath)
        {
            return !string.IsNullOrEmpty(filePath) && File.Exists(filePath);
        }

        #endregion VALIDATION METHODS

    }
}
