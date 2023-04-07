using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CoreLibs.ViewModels;

namespace SnippetsManager.Models
{
    [Serializable]
    public class SnippetCatalogItem : BaseViewModel
    {

        //  VARIABLES

        private string _catalogPath;


        //  GETTERS & SETTERS

        public string CatalogPath
        {
            get => _catalogPath;
            set
            {
                if (!ValidateCatalogPathValue(value))
                    throw new ArgumentException("Directory does not exists.");

                _catalogPath = value;
                OnPropertyChanged(nameof(CatalogPath));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> CatalogItem class constructor. </summary>
        /// <param name="catalogPath"> Catalog path. </param>
        [JsonConstructor]
        public SnippetCatalogItem(string catalogPath = null)
        {
            CatalogPath = catalogPath;
            IsModified = false;
        }

        #endregion CLASS METHODS

        #region CLONE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Make object copy. </summary>
        /// <returns> Object copy. </returns>
        public override object Clone()
        {
            var catalogItem = new SnippetCatalogItem()
            {
                CatalogPath = CatalogPath,
            };

            catalogItem.IsModified = IsModified;
            return catalogItem;
        }

        #endregion CLONE METHODS

        #region UPDATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update values with values from other object instance. </summary>
        /// <param name="model"> BaseViewModel object instance. </param>
        public override void UpdateValues(BaseViewModel model)
        {
            if (model is SnippetCatalogItem snippetCatalogItem)
            {
                CatalogPath = snippetCatalogItem.CatalogPath;
            }
        }

        #endregion UPDATE METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Validate catalog path value. </summary>
        /// <param name="catalogPath"> Catalog path value. </param>
        /// <returns> True - catalog path is valid; False - otherwise. </returns>
        private bool ValidateCatalogPathValue(string catalogPath)
        {
            return !string.IsNullOrEmpty(catalogPath) && Directory.Exists(catalogPath);
        }

        #endregion VALIDATION METHODS

    }
}
