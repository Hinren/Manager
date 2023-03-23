using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.Components
{
    public partial class SnippetQuickView : UserControl, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<SnippetItem> OnAdvancedEditClick;
        public event EventHandler<SnippetItem> OnCancelClick;
        public event EventHandler<SnippetItem> OnSaveClick;


        //  VARIABLES

        private SnippetItem _snippetItem;
        private SnippetItem _snippetItemBackup;


        //  METHODS

        public SnippetItem SnippetItem
        {
            get => _snippetItem;
            set
            {
                _snippetItem = value;
                OnPropertyChanged(nameof(SnippetItem));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetQuickView class constructor. </summary>
        public SnippetQuickView()
        {
            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        private void AdvancedEditButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnAdvancedEditClick?.Invoke(this, SnippetItem);
        }

        //  --------------------------------------------------------------------------------
        private void CancelButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnCancelClick?.Invoke(this, SnippetItem);
        }

        //  --------------------------------------------------------------------------------
        private void SaveButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnSaveClick?.Invoke(this, SnippetItem);
        }

        #endregion INTERACTION METHODS

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
