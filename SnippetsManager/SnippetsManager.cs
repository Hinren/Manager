using CoreLibs.Extensions;
using SnippetsManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnippetsManager
{
    public class SnippetsManager : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<CatalogItem> _catalogItems;
        private ObservableCollection<SnippetItem> _snippetItems;


        //  GETTERS & SETTERS

        public ObservableCollection<CatalogItem> CatalogItems
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


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetsManager class constructor. </summary>
        /// <param name="catalogItems"> Catalog items list. </param>
        public SnippetsManager(List<CatalogItem> catalogItems)
        {
            _catalogItems = catalogItems.IsNullOrEmpty()
                ? new ObservableCollection<CatalogItem>()
                : new ObservableCollection<CatalogItem>(catalogItems);
        }

        #endregion CLASS METHODS

        #region CATALOGS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after adding catalog item - to load snippets. </summary>
        /// <param name="catalogItem"> New catalog item. </param>
        private void OnAddCatalogItem(CatalogItem catalogItem)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after removing catalog item - for unload snippets. </summary>
        /// <param name="catalogItem"> Removed catalog item. </param>
        private void OnRemoveCatalogItem(CatalogItem catalogItem)
        {
            SnippetItems.RemoveAll(s => s.FilePath.StartsWith(catalogItem.CatalogPath));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after significant changes in catalog items to load snippets. </summary>
        private void OnUpdateCatalogItemsCollection()
        {
            var snippetItems = new List<SnippetItem>();

            foreach (var catalogItem in CatalogItems)
            {

            }

            SnippetItems = new ObservableCollection<SnippetItem>(snippetItems);
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
                    InvokeUpdateAction<CatalogItem>(e.NewItems, OnAddCatalogItem);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    InvokeUpdateAction<CatalogItem>(e.OldItems, OnRemoveCatalogItem);
                    break;

                case NotifyCollectionChangedAction.Replace:
                    InvokeUpdateAction<CatalogItem>(e.OldItems, OnRemoveCatalogItem);
                    InvokeUpdateAction<CatalogItem>(e.NewItems, OnAddCatalogItem);
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
