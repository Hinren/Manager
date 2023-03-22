using Newtonsoft.Json;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager
{
    public class SnippetsConfig
    {

        //  VARIABLES

        public List<SnippetCatalogItem> CatalogItems { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetConfig class constructor. </summary>
        /// <param name="catalogItems"> Catalog items. </param>
        [JsonConstructor]
        public SnippetsConfig(List<SnippetCatalogItem> catalogItems = null)
        {
            CatalogItems = catalogItems ?? new List<SnippetCatalogItem>();
        }

        #endregion CLASS METHODS

    }
}
