using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Data
{
    public class InternalMessageFileTreeItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<InternalMessageFileTreeItem> _subDirectories;
        private PackIconKind _icon = PackIconKind.Folder;
        private string _name = string.Empty;
        private string _path = string.Empty;


        //  GETTERS & SETTERS

        public ObservableCollection<InternalMessageFileTreeItem> SubDirectories
        {
            get => _subDirectories;
            private set
            {
                _subDirectories = value;
                _subDirectories.CollectionChanged += OnCollectionChanged<InternalMessageFileTreeItem>;
                OnPropertyChanged(nameof(SubDirectories));
            }
        }

        public PackIconKind Icon
        {
            get => _icon;
            private set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged(nameof(Path));
            }
        }

        public bool IsDrive
        {
            get => string.IsNullOrEmpty(System.IO.Path.GetDirectoryName(Path));
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageFileTreeItem class constructor. </summary>
        /// <param name="directoryPath"> Directory path. </param>
        public InternalMessageFileTreeItem(string directoryPath)
        {
            SubDirectories = new ObservableCollection<InternalMessageFileTreeItem>();
            Path = directoryPath;

            var isDrive = IsDrive;

            Name = isDrive ? directoryPath.Replace(":\\", "") : System.IO.Path.GetFileName(directoryPath);
            Icon = isDrive ? PackIconKind.Harddisk : PackIconKind.Folder;
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing item in collection. </summary>
        /// <typeparam name="T"> Item type. </typeparam>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnCollectionChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing property in collection item. </summary>
        /// <typeparam name="T"> Item type. </typeparam>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnCollectionItemChanged<T>(object sender, PropertyChangedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
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
