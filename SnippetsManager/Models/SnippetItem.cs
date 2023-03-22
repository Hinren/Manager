using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Models
{
    public class SnippetItem
    {

        //  VARIABLES

        private string _filePath;


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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetItem class constructor. </summary>
        /// <param name="path"> Snippet file path. </param>
        [JsonConstructor]
        public SnippetItem(string filePath = null)
        {
            FilePath = filePath;
        }

        #endregion CLASS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate file path value. </summary>
        /// <param name="value"> File path value. </param>
        /// <returns> True - path is valid; False - otherwise. </returns>
        private bool ValidateFilePathValue(string value)
        {
            return !string.IsNullOrEmpty(value) && File.Exists(FilePath);
        }

        #endregion VALIDATION METHODS

    }
}
