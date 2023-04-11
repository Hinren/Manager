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

        public ConfigManager ConfigManager { get; private set; }
        public SnippetsManager.SnippetsManager Manager { get; private set; }

        public ICommand ShowFileCommand { get; set; }
        public ICommand RemoveCommand { get; set; }


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

            ShowFileCommand = new RelayCommand(OnShowFileCommandExecute);
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

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
                var title = "Remove snippet";
                var message = $"Do you want to remove \"{snippetItem.Header.Title}\"?"
                    + Environment.NewLine + "It will also remove snippet file.";

                var imContainer = App.GetIMContainer();
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
                    _pagesManager.OnPageBack += OnBackToPage;
                    _pagesManager.LoadSnippetsEditPage(snippetItem);
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

                var imContainer = App.GetIMContainer();
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

                var imContainer = App.GetIMContainer();
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
