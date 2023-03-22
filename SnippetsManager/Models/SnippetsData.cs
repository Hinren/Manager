using CoreLibs.Extensions;
using Newtonsoft.Json;
using SnippetsManager.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager.Models
{
    public class SnippetsData
    {

        //  CONST

        private static readonly string SNIPPET_EXTENSION = "";


        //  VARIABLES

        public List<CatalogItem> CatalogItems { get; set; }

        [JsonIgnore]
        public List<SnippetItem> SnippetItems { get; set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetsData class constructor. </summary>
        [JsonConstructor]
        public SnippetsData(List<CatalogItem> catalogItems = null)
        {
            CatalogItems = catalogItems != null ? catalogItems : new List<CatalogItem>();

            UpdateSnippetItems();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add snippets catalog. </summary>
        /// <param name="catalogPath"> Snippets catalog path. </param>
        public void AddCatalogItem(string catalogPath)
        {
            var catalogItem = new CatalogItem(catalogPath);

            CatalogItems.Add(catalogItem);
            LoadSnippetItems(catalogItem);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove snippets catalog. </summary>
        /// <param name="catalogItem"> Snippets catalog item. </param>
        public void RemoveCatalogItem(CatalogItem catalogItem)
        {
            if (CatalogItems.Contains(catalogItem))
            {
                UnloadSnippetItems(catalogItem);
                CatalogItems.Remove(catalogItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove snippets catalog. </summary>
        /// <param name="catalogItemIndex"> Snippets catalog item index. </param>
        public void RemoveCatalogItem(int catalogItemIndex)
        {
            if (catalogItemIndex >= 0 && catalogItemIndex < CatalogItems.Count)
                RemoveCatalogItem(CatalogItems[catalogItemIndex]);
        }

        #endregion INTERACTION METHODS

        #region LOAD METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load snippets from catalog. </summary>
        /// <param name="catalogItem"> Snippets catalog item. </param>
        private void LoadSnippetItems(CatalogItem catalogItem)
        {
            var files = Directory.GetFiles(catalogItem.Path, "*.*")
                .Where(f => f.ToLower().EndsWith(SNIPPET_EXTENSION));

            if (!files.IsNullOrEmpty())
            {
                var serializer = new SnippetSerializer();

                foreach (var file in files)
                {
                    serializer.DeserializeFromFile(file);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Unload snippets from catalog. </summary>
        /// <param name="catalogItem"> Snippets catalog item. </param>
        private void UnloadSnippetItems(CatalogItem catalogItem)
        {
            SnippetItems.RemoveAll(s => s.FilePath.StartsWith(catalogItem.Path));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Reload snippets items. </summary>
        private void UpdateSnippetItems()
        {
            SnippetItems = new List<SnippetItem>();

            foreach (var catalogItem in CatalogItems)
                LoadSnippetItems(catalogItem);
        }

        #endregion LOAD METHODS

    }
}
