using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Data
{
    public class InternalMessageFileItem : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private PackIconKind _icon = PackIconKind.None;
        private string _name = string.Empty;
        private string _path = string.Empty;


        //  GETTERS & SETTERS

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

        public bool IsDirectory
        {
            get => Directory.Exists(Path);
        }

        public bool IsDrive
        {
            get => IsDirectory && string.IsNullOrEmpty(System.IO.Path.GetDirectoryName(Path));
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageFileItem class constructor. </summary>
        /// <param name="filePath"> File or directory path. </param>
        public InternalMessageFileItem(string filePath)
        {
            Path = filePath;

            var isDrive = IsDrive;

            Name = isDrive ? filePath.Replace(":\\", "") : System.IO.Path.GetFileName(filePath);
            Icon = isDrive ? PackIconKind.Harddisk : IsDirectory ? PackIconKind.Folder : PackIconKind.File;
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

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
