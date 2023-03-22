using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager.Models
{
    public class CatalogItem
    {

        //  VARIABLES

        private string _path;


        //  GETTERS & SETTERS

        [JsonIgnore]
        public string Name
        {
            get => System.IO.Path.GetFileName(Path);
        }

        public string Path
        {
            get => _path;
            set
            {
                if (!ValidatePathValue(value))
                    throw new ArgumentException("Directory does not exists.");

                _path = value;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> CatalogItem class constructor. </summary>
        /// <param name="path"> Catalog path. </param>
        [JsonConstructor]
        public CatalogItem(string path = null)
        {
            Path = path;
        }

        #endregion CLASS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate path value. </summary>
        /// <param name="value"> Path value. </param>
        /// <returns> True - path is valid; False - otherwise. </returns>
        private bool ValidatePathValue(string value)
        {
            return !string.IsNullOrEmpty(value) && Directory.Exists(Path);
        }

        #endregion VALIDATION METHODS

    }
}
