using ProjectManager.Commands;
using ProjectManager.Data.Configuration;
using ProjectManager.Data.Storyboards;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.Components.Snippets
{
    public partial class SnippetItemPropertiesControl : UserControl, INotifyPropertyChanged
    {

        //  CONST

        private const double HIDE_MARGIN_SHIFT = 16d;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private bool _controlShowed = false;
        private StoryboardMarginDataHandler _storyboardDataHandler;
        private bool _storyboardRestarted = false;

        private SnippetItem _snippetItem = null;
        private ObservableCollection<string> _snippetKeywordsCollection;
        private ObservableCollection<string> _snippetTypesCollection;

        public ICommand RemoveSnippetKeywordCommand { get; set; }
        public ICommand RemoveSnippetTypeCommand { get; set; }


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

        public ObservableCollection<string> SnippetKeywords
        {
            get => _snippetKeywordsCollection;
            set
            {
                _snippetKeywordsCollection = value;
                _snippetKeywordsCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SnippetKeywords)); };
                OnPropertyChanged(nameof(SnippetKeywords));
            }
        }

        public ObservableCollection<string> SnippetTypes
        {
            get => _snippetTypesCollection;
            set
            {
                _snippetTypesCollection = value;
                _snippetTypesCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SnippetTypes)); };
                OnPropertyChanged(nameof(SnippetTypes));
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
        /// <summary> SnippetItemPropertiesControl class constructor. </summary>
        public SnippetItemPropertiesControl()
        {
            RemoveSnippetKeywordCommand = new RelayCommand(OnRemoveSnippetKeywordCommandExecute);
            RemoveSnippetTypeCommand = new RelayCommand(OnRemoveSnippetTypeCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove snippet keyword item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnRemoveSnippetKeywordCommandExecute(object item)
        {
            if (item is string snippetKeyword && SnippetKeywords.Contains(snippetKeyword))
            {
                SnippetKeywords.Remove(snippetKeyword);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove snippet type item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnRemoveSnippetTypeCommandExecute(object item)
        {
            if (item is string snippetType && SnippetTypes.Contains(snippetType))
            {
                SnippetTypes.Remove(snippetType);
            }
        }

        #endregion COMMANDS METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load snippet properties. </summary>
        /// <param name="snippetItem"> Snippet item. </param>
        private void LoadSnippet(SnippetItem snippetItem)
        {
            if (SnippetItem == null)
            {
                SnippetItem = snippetItem;

                if (SnippetItem?.Header?.Keywords != null)
                    SnippetKeywords = new ObservableCollection<string>(SnippetItem.Header.Keywords);

                if (SnippetItem?.Header?.SnippetTypes != null)
                    SnippetTypes = new ObservableCollection<string>(SnippetItem.Header.SnippetTypes);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update snippet properties. </summary>
        private void UpdateSnippet()
        {
            SnippetItem.Header.Keywords = SnippetKeywords.ToList();
            SnippetItem.Header.SnippetTypes = SnippetTypes.ToList();
        }

        #endregion DATA MANAGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide control using animation. </summary>
        public void HideControl()
        {
            if (_controlShowed)
            {
                UpdateSnippet();
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
            LoadSnippet(snippetItem);

            if (!_controlShowed && SnippetItem != null)
            {
                StoryboardDataHandler.RunStoryboard(new Thickness(8, 8, 16, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking add snippet keyword button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AddSnippetKeywordButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking add snippet type button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AddSnippetTypeButtonEx_Click(object sender, RoutedEventArgs e)
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
