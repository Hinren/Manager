using MaterialDesignThemes.Wpf;
using ProjectManager.Pages.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Dashboard
{
    public class DashboardRecentlyUsedItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private string _key;
        private string _name;
        private DashboardRecentlyUsedItemKind _kind;
        private PackIconKind _icon;
        private long _usageAmount;


        //  GETTERS & SETTERS

        public string Key
        {
            get => _key;
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public DashboardRecentlyUsedItemKind Kind
        {
            get => _kind;
            set
            {
                _kind = value;
                OnPropertyChanged(nameof(Kind));
            }
        }

        public PackIconKind Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public long UsageAmount
        {
            get => _usageAmount;
            set
            {
                _usageAmount = value;
                OnPropertyChanged(nameof(UsageAmount));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardRecentlyUsedItem constructor. </summary>
        public DashboardRecentlyUsedItem()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardRecentlyUsedItem constructor. </summary>
        /// <param name="page"> Page. </param>
        public DashboardRecentlyUsedItem(BasePage page)
        {
            Key = page.GetType().Name;
            Name = page.Title;
            Kind = DashboardRecentlyUsedItemKind.Page;
            Icon = page.IconKind;
            UsageAmount = 1;
        }

        #endregion CLASS METHODS

        #region MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Increase usage amount value. </summary>
        public void IncreaseUsage()
        {
            UsageAmount++;
        }

        #endregion MANAGEMENT METHODS

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

    }
}
