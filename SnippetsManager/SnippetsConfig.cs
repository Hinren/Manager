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
        public bool UseCache { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetConfig class constructor. </summary>
        /// <param name="catalogItems"> Catalog items. </param>
        /// <param name="useCache"> Use cache memory. </param>
        [JsonConstructor]
        public SnippetsConfig(List<SnippetCatalogItem> catalogItems = null, bool? useCache = null)
        {
            CatalogItems = catalogItems ?? new List<SnippetCatalogItem>();
            UseCache = useCache ?? false;
        }

        #endregion CLASS METHODS

    }
}
