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
        public void AddItem()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void Clear()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void RemoveItem()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void Update()
        {
            //
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

    }
}
