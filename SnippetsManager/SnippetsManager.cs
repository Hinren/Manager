using CoreLibs.Extensions;
using SnippetsManager.Models;
using SnippetsManager.Serializers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager
{
    public class SnippetsManager : INotifyPropertyChanged
    {

        //  CONST

        private static readonly string SNIPPET_EXTENSION = ".snippet";


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static SnippetsManager _cache;

        private ObservableCollection<SnippetCatalogItem> _catalogItems;
        private ObservableCollection<SnippetItem> _snippetItems;


        //  GETTERS & SETTERS

        public ObservableCollection<SnippetCatalogItem> CatalogItems
        {
            get => _catalogItems;
            set
            {
                _catalogItems = value;
                _catalogItems.CollectionChanged += OnCatalogItemsCollectionChanged;
                OnPropertyChanged(nameof(CatalogItems));
            }
        }

        public ObservableCollection<SnippetItem> SnippetItems
        {
            get => _snippetItems;
            set
            {
                _snippetItems = value;
                _snippetItems.CollectionChanged += OnSnippetItemsCollectionChanged;
                OnPropertyChanged(nameof(SnippetItems));
            }
        }

        public static bool HasCache
        {
            get => _cache != null;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetsManager class constructor. </summary>
        /// <param name="snippetsConfig"> Snippets configuration. </param>
        private SnippetsManager(SnippetsConfig snippetsConfig)
        {
            var catalogItems = snippetsConfig.CatalogItems;

            _catalogItems = catalogItems.IsNullOrEmpty()
                ? new ObservableCollection<SnippetCatalogItem>()
                : new ObservableCollection<SnippetCatalogItem>(catalogItems);

            OnUpdateCatalogItemsCollection();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetsManager instance creator. </summary>
        /// <param name="snippetsConfig"> Snippets configuration. </param>
        /// <returns> SnippetsManager </returns>
        public static SnippetsManager CreateInstance(SnippetsConfig snippetsConfig)
        {
            if (snippetsConfig.UseCache)
                return HasCache ? GetCache(snippetsConfig) : CreateCache(snippetsConfig);

            _cache = null;
            return new SnippetsManager(snippetsConfig);
        }

        #endregion CLASS METHODS

        #region CACHE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create cache. </summary>
        /// <param name="snippetsConfig"> Snippets configuration. </param>
        /// <returns> Newly created snippets manager cache. </returns>
        private static SnippetsManager CreateCache(SnippetsConfig snippetsConfig)
        {
            _cache = new SnippetsManager(snippetsConfig);
            return _cache;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clear cache. </summary>
        public static void ClearCache()
        {
            _cache = null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get snippets manager cache. </summary>
        /// <param name="snippetsConfig"> Snippets configuration. </param>
        /// <returns> Snippets manager cache. </returns>
        private static SnippetsManager GetCache(SnippetsConfig snippetsConfig)
        {
            //  Update cache.
            _cache.UpdateCache(snippetsConfig.CatalogItems);

            //  Return cache.
            return _cache;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get cache size in memory. </summary>
        public static long GetCacheSize()
        {
            long size = 0;

            if (_cache != null)
            {
                using (Stream s = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, _cache.CatalogItems);
                    size += s.Length;
                    s.Flush();
                    s.Close();
                }

                using (Stream s = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(s, _cache.SnippetItems);
                    size += s.Length;
                    s.Flush();
                    s.Close();
                }
            }

            return size;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update items in cache. </summary>
        /// <param name="newCatalogItems"> New catalog items list. </param>
        private void UpdateCache(List<SnippetCatalogItem> newCatalogItems)
        {
            //  Remove all catalogs if new catalog items list is empty.
            if (newCatalogItems.IsNullOrEmpty())
            {
                CatalogItems.Clear();
                return;
            }

            //  Remove old catalogs.
            CatalogItems.RemoveAll(c1 => !newCatalogItems.Any(c2 
                => c1.CatalogPath.ToLower() == c2.CatalogPath.ToLower()));

            //  Add new catalogs.
            newCatalogItems.ForEach(c1 =>
            {
                if (!CatalogItems.Any(c2 => c1.CatalogPath.ToLower() == c2.CatalogPath.ToLower()))
                    CatalogItems.Add(c1);
            });

            //  Update snippets in other catalogs.
            foreach (var catalogItem in CatalogItems)
                _cache.OnAddCatalogItem(catalogItem);
        }

        #endregion CACHE METHODS

        #region CATALOGS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after adding catalog item - to load snippets. </summary>
        /// <param name="catalogItem"> New catalog item. </param>
        private void OnAddCatalogItem(SnippetCatalogItem catalogItem)
        {
            var files = Directory.GetFiles(catalogItem.CatalogPath, "*.*")
                .Where(f => f.ToLower().EndsWith(SNIPPET_EXTENSION));

            if (!files.IsNullOrEmpty())
            {
                var serializer = new SnippetSerializer();

                foreach (var file in files)
                {
                    if (SnippetItems.Any(s => s.FilePath == file))
                        continue;

                    var snippetItem = serializer.DeserializeFromFile(file, out string _);

                    if (snippetItem != null)
                        SnippetItems.Add(snippetItem);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after removing catalog item - for unload snippets. </summary>
        /// <param name="catalogItem"> Removed catalog item. </param>
        private void OnRemoveCatalogItem(SnippetCatalogItem catalogItem)
        {
            SnippetItems.RemoveAll(s => s.FilePath.StartsWith(catalogItem.CatalogPath));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after significant changes in catalog items to load snippets. </summary>
        private void OnUpdateCatalogItemsCollection()
        {
            SnippetItems = new ObservableCollection<SnippetItem>();

            foreach (var catalogItem in CatalogItems)
                OnAddCatalogItem(catalogItem);
        }

        #endregion CATALOGS MANAGEMENT METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing catalog items collection. </summary>
        /// <param name="sender"> Object that invoked event. </param>
        /// <param name="e"> Notify Collection Changed Event Args. </param>
        private void OnCatalogItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    InvokeUpdateAction<SnippetCatalogItem>(e.NewItems, OnAddCatalogItem);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    InvokeUpdateAction<SnippetCatalogItem>(e.OldItems, OnRemoveCatalogItem);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    InvokeUpdateAction<SnippetCatalogItem>(e.OldItems, OnRemoveCatalogItem);
                    InvokeUpdateAction<SnippetCatalogItem>(e.NewItems, OnAddCatalogItem);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    OnUpdateCatalogItemsCollection();
                    break;
            }

            OnPropertyChanged(nameof(CatalogItems));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing snippet items collection. </summary>
        /// <param name="sender"> Object that invoked event. </param>
        /// <param name="e"> Notify Collection Changed Event Args. </param>
        private void OnSnippetItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SnippetItems));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region SNIPPETS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------

        #endregion SNIPPETS MANAGEMENT METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoking an action on items in list. </summary>
        /// <typeparam name="T"> Item type. </typeparam>
        /// <param name="data"> List interface with data. </param>
        /// <param name="action"> Action to invoke. </param>
        private void InvokeUpdateAction<T>(IList? data, Action<T> action)
        {
            if (data != null)
                foreach (var item in data)
                    action.Invoke((T)item);
        }

        #endregion UTILITY METHODS

    }
}
