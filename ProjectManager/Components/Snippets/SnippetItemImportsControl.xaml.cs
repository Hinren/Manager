using chkam05.Tools.ControlsEx.InternalMessages;
using ProjectManager.Commands;
using ProjectManager.Data.Storyboards;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.Components.Snippets
{
    public partial class SnippetItemImportsControl : UserControl, INotifyPropertyChanged
    {

        //  CONST

        private const double HIDE_MARGIN_SHIFT = 32d;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private bool _controlShowed = false;
        private StoryboardMarginDataHandler _storyboardDataHandler;
        private bool _storyboardRestarted = false;

        private SnippetItem _snippetItem = null;
        private ObservableCollection<SnippetImport> _snippetImportsCollection;

        public ICommand RemoveCommand { get; set; }


        //  GETTERS & SETTERS

        public bool ControlShowed
        {
            get => _controlShowed;
        }

        public SnippetItem SnippetItem
        {
            get => _snippetItem;
            set
            {
                _snippetItem = value;
                OnPropertyChanged(nameof(SnippetItem));
            }
        }

        public ObservableCollection<SnippetImport> SnippetImports
        {
            get => _snippetImportsCollection;
            set
            {
                _snippetImportsCollection = value;
                _snippetImportsCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SnippetImports)); };
                OnPropertyChanged(nameof(SnippetImports));
            }
        }

        public StoryboardMarginDataHandler StoryboardDataHandler
        {
            get => _storyboardDataHandler;
            set
            {
                _storyboardDataHandler = value;
                OnPropertyChanged(nameof(StoryboardDataHandler));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetItemImportsControl class constructor. </summary>
        public SnippetItemImportsControl()
        {
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove snippet import item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnRemoveCommandExecute(object item)
        {
            if (item is SnippetImport snippetImport && SnippetImports.Contains(snippetImport))
            {
                SnippetImports.Remove(snippetImport);
            }
        }

        #endregion COMMANDS METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load snippet imports. </summary>
        /// <param name="snippetItem"> Snippet item. </param>
        private void LoadImports(SnippetItem snippetItem)
        {
            if (SnippetItem == null)
            {
                SnippetItem = snippetItem;

                if (SnippetItem?.Snippet?.Imports != null)
                    SnippetImports = new ObservableCollection<SnippetImport>(SnippetItem.Snippet.Imports);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update snippet imports. </summary>
        private void UpdateImports()
        {
            SnippetItem.Snippet.Imports = SnippetImports.ToList();
        }

        #endregion DATA MANAGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide control using animation. </summary>
        public void HideControl()
        {
            if (_controlShowed)
            {
                UpdateImports();

                var left = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
                var right = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
                StoryboardDataHandler.RunStoryboard(new Thickness(left, 8, -right, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show control using animation. </summary>
        /// <param name="snippetItem"> Snippet item. </param>
        public void ShowControl(SnippetItem snippetItem = null)
        {
            LoadImports(snippetItem);

            if (!_controlShowed && SnippetItem != null)
            {
                StoryboardDataHandler.RunStoryboard(new Thickness(8, 8, 16, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking add import button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AddImportButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking close button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CloseButtonEx_Click(object sender, RoutedEventArgs e)
        {
            HideControl();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing showing/hiding quick view animation. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (!_storyboardRestarted)
            {
                _controlShowed = !_controlShowed;
                OnPropertyChanged(nameof(ControlShowed));
            }

            if (_storyboardRestarted)
                _storyboardRestarted = false;

            if (_controlShowed && !CompareMargins(controlBorder.Margin, StoryboardDataHandler.Margin))
            {
                _storyboardRestarted = true;
                StoryboardDataHandler.RunStoryboard();
            }
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

        #region USER CONTROL METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading user control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //  Setup data.
            var storyboard = Resources["ShowHideControlStoryboard"] as Storyboard;
            var left = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
            var right = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
            var margin = new Thickness(left, 8, -right, 8);

            controlBorder.Margin = margin;
            _controlShowed = false;

            StoryboardDataHandler = new StoryboardMarginDataHandler(storyboard)
            {
                Margin = margin
            };
        }

        #endregion USER CONTROL METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Compare two margins. </summary>
        /// <param name="m1"> Margin 1. </param>
        /// <param name="m2"> Margin 2. </param>
        /// <returns> True - margins are equal. False - otherwise. </returns>
        private bool CompareMargins(Thickness m1, Thickness m2)
        {
            return Math.Round(m1.Left) == Math.Round(m2.Left)
                && Math.Round(m1.Top) == Math.Round(m2.Top)
                && Math.Round(m1.Right) == Math.Round(m2.Right)
                && Math.Round(m1.Bottom) == Math.Round(m2.Bottom);
        }

        #endregion UTILITY METHODS

    }
}
