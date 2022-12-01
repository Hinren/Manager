using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedControls.Data
{
    public class InternalMessageFileType : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private string _title;
        private string[] _extensions;


        //  GETTERS & SETTERS

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string[] Extensions
        {
            get => _extensions;
            set
            {
                _extensions = value;
                OnPropertyChanged(nameof(Extensions));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> InternalMessageFileType class constructor. </summary>
        /// <param name="title"> File type/group title. </param>
        /// <param name="extensions"> Array of files extensions. </param>
        public InternalMessageFileType(string title, string[] extensions)
        {
            Title = title;

            if (extensions != null && extensions.Any())
                Extensions = extensions.Where(e => e.StartsWith("*.")).ToArray();
        }

        #endregion CLASS METHODS

        #region CHECK METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if file extension match file type extensions. </summary>
        /// <param name="fileName"> File name. </param>
        /// <returns> True - file extension matches; False - otherwise. </returns>
        public bool MatchFile(string fileName)
        {
            if (Extensions == null || Extensions.Length == 0)
                return false;

            if (Extensions.Contains("*.*"))
                return true;

            var extension = Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(extension))
                return Extensions.Any(e => e.Replace("*", "").ToLower() == extension.ToLower());

            return false;
        }

        #endregion CHECK METHODS

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

        #region PRESET INSTANCES

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for all files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for all files. </returns>
        public static InternalMessageFileType AllFiles(string title = "All Files")
            => new InternalMessageFileType(title, new string[] { "*.*" });

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for image files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for image files. </returns>
        public static InternalMessageFileType ImageFiles(string title = "Image Files")
            => new InternalMessageFileType(title, new string[] { "*.bmp", "*.gif", "*.jpg", "*.jpeg", "*.png", "*.tiff" });

        //  --------------------------------------------------------------------------------
        /// <summary> Preset InternalMessageFileType class constructor for text files. </summary>
        /// <param name="title"> Overwritable file type/group title. </param>
        /// <returns> InternalMessageFileType class instance for text files. </returns>
        public static InternalMessageFileType TextFiles(string title = "Text Files")
            => new InternalMessageFileType(title, new string[] { "*.txt" });

        #endregion PRESET INSTANCES

    }
}
