using ProjectManager.Pages;
using ProjectManager.Pages.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Dashboard
{
    public class DashboardRecentlyUsedItemsManager : INotifyPropertyChanged
    {

        //  CONST

        private const int MAX_ITEMS = 10;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private static DashboardRecentlyUsedItemsManager _instance;
        private static object _instanceLock = new object();

        private ObservableCollection<DashboardRecentlyUsedItem> _recentlyUsedItemsCollection;


        //  GETTERS & SETTERS

        public static DashboardRecentlyUsedItemsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DashboardRecentlyUsedItemsManager();
                            _instance.SetupData();
                        }
                    }
                }

                return _instance;
            }
        }

        public ObservableCollection<DashboardRecentlyUsedItem> RecentlyUsedItemsCollection
        {
            get => _recentlyUsedItemsCollection;
            private set
            {
                _recentlyUsedItemsCollection = value;
                _recentlyUsedItemsCollection.CollectionChanged += (s, e)
                    => { OnPropertyChanged(nameof(RecentlyUsedItemsCollection)); };
                OnPropertyChanged(nameof(RecentlyUsedItemsCollection));
            }
        }

        public int ItemsCount
        {
            get => RecentlyUsedItemsCollection != null ? RecentlyUsedItemsCollection.Count : 0;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardRecentlyUsedItemsManager constructor. </summary>
        private DashboardRecentlyUsedItemsManager()
        {
            //
        }

        #endregion CLASS METHODS

        #region ITEMS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add dashboard recently used item. </summary>
        /// <param name="item"> Dashboard recently used item. </param>
        public void AddItem(DashboardRecentlyUsedItem item)
        {
            if (ContainsItem(item))
                GetItemByKey(item.Key).IncreaseUsage();
            else if (ItemsCount < MAX_ITEMS)
                RecentlyUsedItemsCollection.Add(item);

            Update();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clear dashboard recently used items. </summary>
        public void Clear()
        {
            RecentlyUsedItemsCollection.Clear();
        }

        //  --------------------------------------------------------------------------------
        public bool ContainsItem(DashboardRecentlyUsedItem item)
        {
            return RecentlyUsedItemsCollection != null 
                && RecentlyUsedItemsCollection.Any(i => i.Key == item.Key);
        }

        //  --------------------------------------------------------------------------------
        public List<DashboardRecentlyUsedItem> GetItems()
        {
            return RecentlyUsedItemsCollection?.ToList() ?? new List<DashboardRecentlyUsedItem>();
        }

        //  --------------------------------------------------------------------------------
        public void LoadItems(List<DashboardRecentlyUsedItem> items)
        {
            if (items != null && items.Any())
                RecentlyUsedItemsCollection = new ObservableCollection<DashboardRecentlyUsedItem>(
                    items.OrderByDescending(i => i.UsageAmount).Take(10));
        }

        //  --------------------------------------------------------------------------------
        public void RemoveItem(DashboardRecentlyUsedItem item)
        {
            if (ContainsItem(item))
                RecentlyUsedItemsCollection.Remove(GetItemByKey(item.Key));
        }

        #endregion ITEMS MANAGEMENT METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler event. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data. </summary>
        private void SetupData()
        {
            RecentlyUsedItemsCollection = new ObservableCollection<DashboardRecentlyUsedItem>();
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get dashboard recently used item by key. </summary>
        /// <param name="key"> Dashboard recently used item key. </param>
        /// <returns> Dashboard recently used item. </returns>
        private DashboardRecentlyUsedItem GetItemByKey(string key)
        {
            return RecentlyUsedItemsCollection.First(i => i.Key == key);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if dashboard recently used items collection is sorted. </summary>
        /// <returns> True - sorted; False - otherwise. </returns>
        private bool IsSorted()
        {
            long max = long.MaxValue;

            foreach (var item in RecentlyUsedItemsCollection)
            {
                if (max < item.UsageAmount)
                    return false;

                max = item.UsageAmount;
            }

            return true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update dashboard recently used item collection. </summary>
        private void Update()
        {
            if (!IsSorted())
                RecentlyUsedItemsCollection = new ObservableCollection<DashboardRecentlyUsedItem>(
                    RecentlyUsedItemsCollection.OrderByDescending(o => o.UsageAmount));
        }

        #endregion UTILITY METHODS

    }
}
