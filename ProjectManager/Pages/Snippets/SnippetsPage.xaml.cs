using chkam05.Tools.ControlsEx;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using CoreLibs.Extensions;
using ProjectManager.Commands;
using ProjectManager.Components.Events;
using ProjectManager.Components.Statics;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Pages.Events;
using ProjectManager.Utilities;
using ProjectManager.Windows;
using SnippetsManager;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
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

        private bool _isLoaded = false;
        private Thickness _snippetQuickViewMargin = new Thickness(8, 8, 16, 8);
        private bool _snippetQuickViewRestarted = false;
        private bool _snippetQuickViewShowed = false;

        public ConfigManager ConfigManager { get; private set; }
        public SnippetsManager.SnippetsManager Manager { get; private set; }

        public ICommand EditCommand { get; set; }
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
            Manager = SnippetsManager.SnippetsManager.CreateInstance(ConfigManager.Configuration.SnippetConfig);

            EditCommand = new RelayCommand(OnEditCommandExecute);
            ShowFileCommand = new RelayCommand(OnShowFileCommandExecute);
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide snippet quick view. </summary>
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
        /// <summary> Show snippet quick view. </summary>
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
        /// <summary> Method invoked after finishing showing/hiding quick view animation. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
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
        /// <summary> Method invoked after pressing Edit snippet item button. </summary>
        /// <param name="item"> Snippet item as object. </param>
        private void OnEditCommandExecute(object item)
        {
            if (item is SnippetItem snippetItem)
            {
                _pagesManager.OnPageBack += OnBackToPage;
                _pagesManager.LoadSnippetsEditPage(snippetItem);
            }
        }

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
                var title = "Remove snippet";
                var message = $"Do you want to remove \"{snippetItem.Header.Title}\"?"
                    + Environment.NewLine + "It will also remove snippet file.";

                var imContainer = GetIMContainer();
                var im = InternalMessageEx.CreateQuestionMessage(imContainer, title, message);

                InternalMessagesHelper.ApplyVisualStyle(im);

                im.OnClose += (s, e) =>
                {
                    if (e.Result == InternalMessageResult.Ok)
                    {
                        File.Delete(snippetItem.FilePath);
                        Manager.SnippetItems.Remove(snippetItem);
                    }
                };
                imContainer.ShowMessage(im);
            }
        }

        #endregion COMMANDS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after double clicking on snippet item in SnippetItemsListViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void SnippetItemsListViewEx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewEx listViewEx = sender as ListViewEx;

            if (listViewEx != null && listViewEx.SelectedItem != null)
            {
                var snippetItem = (SnippetItem)listViewEx.SelectedItem;

                if (snippetItem != null)
                {
                    snippetQuickView.SetSnippet(snippetItem);
                    ShowSnippetQuickView();
                }

                listViewEx.SelectedItem = null;
            }
        }

        #endregion INTERACTION METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invokeda after loading page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            var width = snippetQuickView.ActualWidth + 8;
            var margin = new Thickness(8, 8, -width, 8);

            SnippetQuickViewMargin = margin;
            snippetQuickView.Margin = margin;

            if (!_isLoaded)
            {
                CheckSnippetTitleDuplications();
                CheckSnippetShortcutsDuplications();
            }

            _isLoaded = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after back to this page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Page Loaded Event Arguments. </param>
        private void OnBackToPage(object sender, PageLoadedEventArgs e)
        {
            if (e.UnloadedPage is SnippetsEditPage snippetsEditPage)
            {
                _pagesManager.OnPageBack -= OnBackToPage;
            }
        }

        #endregion PAGE METHODS

        #region QUICK VIEW METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after action made in Snippet Quick View. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Snippet Quick View Action Evnet Arguments. </param>
        private void snippetQuickView_OnActionTaken(object sender, SnippetQuickViewActionEventArgs e)
        {
            switch (e.Action)
            {
                case SnippetQuickViewAction.Cancel:
                    HideSnippetQuickView();
                    break;

                case SnippetQuickViewAction.Save:
                    OnSnippetQuickViewSaveAction(e);
                    break;

                case SnippetQuickViewAction.Edit:
                    OnSnippetQuickViewEditAction(e);
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after triggering edit action in SnippetQuickView. </summary>
        /// <param name="e"> Snippet Quick View Action Evnet Arguments. </param>
        private void OnSnippetQuickViewEditAction(SnippetQuickViewActionEventArgs e)
        {
            _pagesManager.OnPageBack += OnBackToPage;
            _pagesManager.LoadSnippetsEditPage(e.OryginalSnippetItem);
            HideSnippetQuickView();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after triggering save action in SnippetQuickView. </summary>
        /// <param name="e"> Snippet Quick View Action Evnet Arguments. </param>
        private void OnSnippetQuickViewSaveAction(SnippetQuickViewActionEventArgs e)
        {
            string filePath = e.ModifiedSnippetItem.FilePath;
            string title = e.ModifiedSnippetItem.Header.Title;
            string shortcut = e.ModifiedSnippetItem.Header.Shortcut;

            //  Name can not be the same within one directory.
            if (Manager.HasSnippetWithTitle(title, filePath))
            {
                var imContainer = GetIMContainer();
                var im = InternalMessageEx.CreateErrorMessage(imContainer,
                    "Name duplication",
                    $"Snippets collection already contains snippet with \"{title}\" title in same directory.");

                InternalMessagesHelper.ApplyVisualStyle(im);

                imContainer.ShowMessage(im);
                return;
            }

            //  Shortcut can not be the same within all directories.
            else if (Manager.HasSnippetWithShortcut(shortcut))
            {
                var imContainer = GetIMContainer();
                var im = InternalMessageEx.CreateErrorMessage(imContainer,
                    "Shortcut duplication",
                    $"Snippets collection already contains snippet with \"{shortcut}\" shortcut.");

                InternalMessagesHelper.ApplyVisualStyle(im);

                imContainer.ShowMessage(im);
                return;
            }

            e.OryginalSnippetItem.UpdateValues(e.ModifiedSnippetItem);
            HideSnippetQuickView();
        }

        #endregion QUICK VIEW METHODS

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

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Notify if there is any snippet title duplication. </summary>
        private void CheckSnippetTitleDuplications()
        {
            var duplicates = Manager.GetDuplicatedTitles();

            if (duplicates != null)
            {
                var sb = new StringBuilder();

                sb.AppendLine("Found snippets with duplicated titles in");
                
                foreach (var dup in duplicates)
                {
                    sb.AppendLine($"[PATH]: \"{dup.Key}\".");

                    foreach (var val in dup.Value)
                    {
                        sb.AppendLine($"[TITLE] \"{val.Key}\" {val.Value} times.");
                    }
                }

                var imContainer = GetIMContainer();
                var im = InternalMessageEx.CreateErrorMessage(imContainer,
                    "Titles duplicates",
                    sb.ToString());

                InternalMessagesHelper.ApplyVisualStyle(im);

                imContainer.ShowMessage(im);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Notify if there is any snippet shortcut duplication. </summary>
        private void CheckSnippetShortcutsDuplications()
        {
            var duplicates = Manager.GetDuplicatedShortcuts();

            if (duplicates != null)
            {
                var sb = new StringBuilder();

                sb.AppendLine("Found snippets with duplicated shortcuts");

                foreach (var dup in duplicates)
                    sb.AppendLine($"[SHORTCUT]: \"{dup.Key}\" {dup.Value} times.");

                var imContainer = GetIMContainer();
                var im = InternalMessageEx.CreateErrorMessage(imContainer,
                    "Shortcuts duplicates",
                    sb.ToString());

                InternalMessagesHelper.ApplyVisualStyle(im);

                imContainer.ShowMessage(im);
            }
        }

        #endregion VALIDATION METHODS

    }
}
