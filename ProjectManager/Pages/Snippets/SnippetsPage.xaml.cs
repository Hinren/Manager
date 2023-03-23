using chkam05.Tools.ControlsEx;
using ProjectManager.Commands;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using SnippetsManager;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
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


namespace ProjectManager.Pages.Snippets
{
    public partial class SnippetsPage : BasePage
    {

        //  VARIABLES

        private Thickness _snippetQuickViewMargin = new Thickness(8, 8, 16, 8);
        private bool _snippetQuickViewRestarted = false;
        private bool _snippetQuickViewShowed = false;

        public ConfigManager ConfigManager { get; private set; }
        public SnippetsManager.SnippetsManager SnippetsManager { get; private set; }

        public ICommand ShowFileCommand { get; set; }
        public ICommand RemoveCommand { get; set; }


        //  GETTERS & SETTERS

        public Thickness SnippetQuickViewMargin
        {
            get => _snippetQuickViewMargin;
            set
            {
                _snippetQuickViewMargin = value;
                OnPropertyChanged(nameof(SnippetQuickViewMargin));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetsPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SnippetsPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize data containers.
            ConfigManager = ConfigManager.Instance;
            SnippetsManager = new SnippetsManager.SnippetsManager(ConfigManager.Configuration.SnippetConfig);

            ShowFileCommand = new RelayCommand(OnShowFileCommandExecute);
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        private void HideSnippetQuickView()
        {
            if (_snippetQuickViewShowed)
            {
                var width = snippetQuickView.ActualWidth + 8;

                SnippetQuickViewMargin = new Thickness(8, 8, -width, 8);
                Storyboard storyboard = Resources["ShowHideQuickViewStoryboard"] as Storyboard;
                storyboard?.Begin();
            }
        }

        //  --------------------------------------------------------------------------------
        private void ShowSnippetQuickView()
        {
            if (!_snippetQuickViewShowed)
            {
                SnippetQuickViewMargin = new Thickness(8, 8, 16, 8);
                Storyboard storyboard = Resources["ShowHideQuickViewStoryboard"] as Storyboard;
                storyboard?.Begin();
            }
        }

        //  --------------------------------------------------------------------------------
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (!_snippetQuickViewRestarted)
                _snippetQuickViewShowed = !_snippetQuickViewShowed;
            
            if (_snippetQuickViewRestarted)
                _snippetQuickViewRestarted = false;

            if (_snippetQuickViewShowed && !CompareMargins(snippetQuickView.Margin, SnippetQuickViewMargin))
            {
                _snippetQuickViewRestarted = true;
                Storyboard storyboard = Resources["ShowHideQuickViewStoryboard"] as Storyboard;
                storyboard?.Begin();
            }
        }

        #endregion ANIMATION METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Open in explorer snippet item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnShowFileCommandExecute(object item)
        {
            if (item is SnippetItem snippetItem)
            {
                string explorerArgs = string.Format("/e, /select, \"{0}\"", snippetItem.FilePath);

                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "explorer";
                info.Arguments = explorerArgs;
                Process.Start(info);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove snippet item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnRemoveCommandExecute(object item)
        {
            if (item is SnippetItem snippetItem)
            {
                //
            }
        }

        #endregion COMMANDS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        private void SnippetItemsListViewEx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewEx listViewEx = sender as ListViewEx;

            if (listViewEx != null && listViewEx.SelectedItem != null)
            {
                var snippetItem = (SnippetItem)listViewEx.SelectedItem;

                if (snippetItem != null)
                {
                    snippetQuickView.SnippetItem = snippetItem;
                    ShowSnippetQuickView();
                }

                listViewEx.SelectedItem = null;
            }
        }

        #endregion INTERACTION METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            var width = snippetQuickView.ActualWidth + 8;
            var margin = new Thickness(8, 8, -width, 8);

            SnippetQuickViewMargin = margin;
            snippetQuickView.Margin = margin;
        }

        #endregion PAGE METHODS

        #region QUICK VIEW METHODS

        //  --------------------------------------------------------------------------------
        private void snippetQuickView_OnAdvancedEditClick(object sender, SnippetItem e)
        {

        }

        //  --------------------------------------------------------------------------------
        private void snippetQuickView_OnCancelClick(object sender, SnippetItem e)
        {
            HideSnippetQuickView();
        }

        //  --------------------------------------------------------------------------------
        private void snippetQuickView_OnSaveClick(object sender, SnippetItem e)
        {
            HideSnippetQuickView();
        }

        #endregion QUICK VIEW METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
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
