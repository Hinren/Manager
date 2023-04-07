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
        public string FontFamilyName { get; set; }
        public double FontSize { get; set; }
        public bool UseCache { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetConfig class constructor. </summary>
        /// <param name="catalogItems"> Catalog items. </param>
        /// <param name="useCache"> Use cache memory. </param>
        [JsonConstructor]
        public SnippetsConfig(List<SnippetCatalogItem> catalogItems = null,
            string? fontFamilyName = null,
            double? fontSize = null,
            bool? useCache = null)
        {
            CatalogItems = catalogItems ?? new List<SnippetCatalogItem>();
            FontFamilyName = !string.IsNullOrEmpty(fontFamilyName) ? fontFamilyName : "Consolas";
            FontSize = fontSize ?? 14d;
            UseCache = useCache ?? false;
        }

        #endregion CLASS METHODS

    }
}
