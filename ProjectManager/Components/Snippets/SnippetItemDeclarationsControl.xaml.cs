using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using ProjectManager.Commands;
using ProjectManager.Data.Storyboards;
using ProjectManager.InternalMessages.Snippets;
using ProjectManager.InternalMessages;
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
using chkam05.Tools.ControlsEx;
using MaterialDesignThemes.Wpf;

namespace ProjectManager.Components.Snippets
{
    public partial class SnippetItemDeclarationsControl : UserControl, INotifyPropertyChanged
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
        private ObservableCollection<SnippetDeclaration> _snippetDeclarationsCollection;

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

        public ObservableCollection<SnippetDeclaration> SnippetDeclarations
        {
            get => _snippetDeclarationsCollection;
            set
            {
                _snippetDeclarationsCollection = value;
                _snippetDeclarationsCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SnippetDeclarations)); };
                OnPropertyChanged(nameof(SnippetDeclarations));
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
        /// <summary> SnippetItemDeclarationsControl class constructor. </summary>
        public SnippetItemDeclarationsControl()
        {
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove snippet declaration item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnRemoveCommandExecute(object item)
        {
            if (item is SnippetDeclaration snippetDeclaration && SnippetDeclarations.Contains(snippetDeclaration))
            {
                SnippetDeclarations.Remove(snippetDeclaration);
            }
        }

        #endregion COMMANDS METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load snippet declarations. </summary>
        /// <param name="snippetItem"> Snippet item. </param>
        private void LoadDeclarations(SnippetItem snippetItem)
        {
            if (SnippetItem == null)
            {
                SnippetItem = snippetItem;

                if (SnippetItem?.Snippet?.Imports != null)
                    SnippetDeclarations = new ObservableCollection<SnippetDeclaration>(SnippetItem.Snippet.Declarations);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update snippet declarations. </summary>
        private void UpdateDeclarations()
        {
            SnippetItem.Snippet.Declarations = SnippetDeclarations.ToList();
        }

        #endregion DATA MANAGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide control using animation. </summary>
        public void HideControl()
        {
            if (_controlShowed)
            {
                UpdateDeclarations();
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
            LoadDeclarations(snippetItem);

            if (!_controlShowed && SnippetItem != null)
            {
                StoryboardDataHandler.RunStoryboard(new Thickness(8, 8, 16, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing mouse button in add declaration button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void AddDeclarationButtonEx_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
                return;

            if (e.ChangedButton == MouseButton.Left)
            {
                ButtonEx button = (ButtonEx)sender;
                ContextMenuEx contextMenu = (ContextMenuEx)button.ContextMenu;
                contextMenu.PlacementTarget = button;
                contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                contextMenu.IsOpen = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking add declaration literal button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AddDeclarationLiteralContextMenuItemEx_Click(object sender, RoutedEventArgs e)
        {
            var imContainer = App.GetIMContainer();
            var imSnippetDeclaration = new SnippetDeclarationItemIM(imContainer, "Add literal", PackIconKind.CubeOutline,
                new SnippetLiteral(), SnippetDeclarations.ToList());

            imSnippetDeclaration.OnClose += OnAddDeclarationIMClose;
            imContainer.ShowMessage(imSnippetDeclaration);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after double clicking on snippet declaration item. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void SnippetDeclarationsListViewEx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewEx listViewEx = sender as ListViewEx;

            if (listViewEx != null && listViewEx.SelectedItem != null)
            {
                var snippetDeclaration = (SnippetDeclaration)listViewEx.SelectedItem;

                if (snippetDeclaration != null)
                {
                    var snippetDeclarations = SnippetDeclarations.ToList();
                    snippetDeclarations.Remove(snippetDeclaration);

                    var imContainer = App.GetIMContainer();
                    var imSnippetDeclaration = new SnippetDeclarationItemIM(imContainer, "Edit declaration", PackIconKind.CubeOutline,
                        snippetDeclaration, snippetDeclarations);

                    imSnippetDeclaration.OnClose += OnEditDeclarationIMClose;
                    imContainer.ShowMessage(imSnippetDeclaration);
                }

                listViewEx.SelectedItem = null;
            }
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

        #region INTERNAL MESSAGES

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing add declaration item internal message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnAddDeclarationIMClose(object sender, InternalMessageCloseEventArgs e)
        {
            var im = (sender as SnippetDeclarationItemIM);

            if (e.Result == InternalMessageResult.Ok && im != null)
                SnippetDeclarations.Add(im.SnippetDeclaration);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing edit declaration item internal message. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Internal Message Close Event Arguments. </param>
        private void OnEditDeclarationIMClose(object sender, InternalMessageCloseEventArgs e)
        {
            var im = (sender as SnippetDeclarationItemIM);

            if (e.Result == InternalMessageResult.Ok && im != null)
                OnPropertyChanged(nameof(SnippetDeclaration));
        }

        #endregion INTERNAL MESSAGES

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
