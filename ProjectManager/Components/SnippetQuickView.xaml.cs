using ProjectManager.Components.Events;
using ProjectManager.Components.Statics;
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
using static ProjectManager.Delegates;

namespace ProjectManager.Components
{
    public partial class SnippetQuickView : UserControl, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event SnippetQuickViewActionEventHandler OnActionTaken;


        //  VARIABLES

        private SnippetItem _snippetItem;
        private SnippetItem _oryginalSnippetItem;


        //  GETTERS & SETTERS

        public SnippetItem SnippetItem
        {
            get => _snippetItem;
            private set
            {
                _snippetItem = value;
                OnPropertyChanged(nameof(SnippetItem));
            }
        }

        public SnippetItem OryginalSnippetItem
        {
            get => _snippetItem;
            private set
            {
                _snippetItem = value;
                OnPropertyChanged(nameof(OryginalSnippetItem));
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
        /// <summary> Set snippet item. </summary>
        /// <param name="snippetItem"> Snipept item. </param>
        public void SetSnippet(SnippetItem snippetItem)
        {
            OryginalSnippetItem = snippetItem;
            SnippetItem = (SnippetItem) snippetItem.Clone();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking advanced snippet item edit ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AdvancedEditButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnActionTaken?.Invoke(this, CreateActionTakenArgs(SnippetQuickViewAction.Edit));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking cancel ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CancelButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnActionTaken?.Invoke(this, CreateActionTakenArgs(SnippetQuickViewAction.Cancel));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking save snippet item edit ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SaveButtonEx_Click(object sender, RoutedEventArgs e)
        {
            OnActionTaken?.Invoke(this, CreateActionTakenArgs(SnippetQuickViewAction.Save));
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

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create Snippet quick view action event arguments for ActionTaken event. </summary>
        /// <param name="action"> Snippet quick view action. </param>
        /// <returns> Snippet quick view action event arguments. </returns>
        private SnippetQuickViewActionEventArgs CreateActionTakenArgs(SnippetQuickViewAction action)
        {
            return new SnippetQuickViewActionEventArgs(action, OryginalSnippetItem, SnippetItem);
        }

        #endregion UTILITY METHODS

    }
}
