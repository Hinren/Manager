using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using chkam05.Tools.ControlsEx.Utilities;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using SnippetsManager.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Documents;


namespace ProjectManager.Pages.Snippets
{
    public partial class SnippetsEditPage : BasePage
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }

        private bool _forceClose = false;
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
        /// <summary> SnippetsEditPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SnippetsEditPage(PagesManager pagesManager, SnippetItem snippetItem) : base(pagesManager)
        {
            //  Initialize data containers.
            ConfigManager = ConfigManager.Instance;

            //  Setup data.
            OryginalSnippetItem = snippetItem;
            SnippetItem = (SnippetItem) snippetItem.Clone();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region CONTROLS MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide all controls. </summary>
        private void HideAllControls()
        {
            if (snippetItemDeclarationsControl.ControlShowed)
                snippetItemDeclarationsControl.HideControl();

            if (snippetItemImportsControl.ControlShowed)
                snippetItemImportsControl.HideControl();

            if (snippetItemPropertiesControl.ControlShowed)
                snippetItemPropertiesControl.HideControl();
        }

        #endregion CONTROLS MANAGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Declarations button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void DeclarationsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            if (!snippetItemDeclarationsControl.ControlShowed)
            {
                HideAllControls();
                snippetItemDeclarationsControl.ShowControl(SnippetItem);
            }
            else
            {
                snippetItemDeclarationsControl.HideControl();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Imports button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void ImportsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            if (!snippetItemImportsControl.ControlShowed)
            {
                HideAllControls();
                snippetItemImportsControl.ShowControl(SnippetItem);
            }
            else
            {
                snippetItemImportsControl.HideControl();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Properties button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void PropertiesButtonEx_Click(object sender, RoutedEventArgs e)
        {
            if (!snippetItemPropertiesControl.ControlShowed)
            {
                HideAllControls();
                snippetItemPropertiesControl.ShowControl(SnippetItem);
            }
            else
            {
                snippetItemPropertiesControl.HideControl();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Settings button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SettingsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Save button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SaveButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //  Hide controls to save their content;
            HideAllControls();

            SnippetItem.Snippet.Code.Code = GetCode();
            SnippetItem.ClearIsModified();

            OryginalSnippetItem.UpdateValues(SnippetItem);
            OryginalSnippetItem.ClearIsModified();
        }

        #endregion INTERACTION METHODS

        #region INTERACTIONS WITH PAGES MANAGER METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked by PagesManager when GoBack is called. </summary>
        /// <param name="previousPage"> Page to return to. </param>
        /// <returns> True - allow to go back; False - otherwise. </returns>
        public override bool OnGoBackFromPage(BasePage previousPage)
        {
            if (!CheckForChanges())
                return true;

            var imContainer = App.GetIMContainer();
            var internalMessage = InternalMessageEx.CreateQuestionMessage(imContainer,
                "Leaving editor",
                "Changes have been made." + Environment.NewLine + "Do you want to abandon them and close the editor?");

            internalMessage.OnClose += (s, e) =>
            {
                if (e.Result == InternalMessageResult.Yes)
                {
                    _forceClose = true;
                    _pagesManager.GoBack();
                }
            };

            InternalMessagesHelper.ApplyVisualStyle(internalMessage);
            imContainer.ShowMessage(internalMessage);

            return false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked by PagesManager when Load(another)Page is called. </summary>
        /// <param name="pageToLoad"> Page to load. </param>
        /// <returns> True - allow to load another page; False - otherwise. </returns>
        public override bool OnGoForwardFromPage(BasePage pageToLoad)
        {
            if (!CheckForChanges())
                return true;

            var imContainer = App.GetIMContainer();
            var internalMessage = InternalMessageEx.CreateQuestionMessage(imContainer,
                "Leaving editor",
                "Changes have been made." + Environment.NewLine + "Do you want to abandon them and close the editor?");

            internalMessage.OnClose += (s, e) =>
            {
                if (e.Result == InternalMessageResult.Yes)
                {
                    _forceClose = true;
                    _pagesManager.LoadPage(pageToLoad);
                }
            };

            InternalMessagesHelper.ApplyVisualStyle(internalMessage);
            imContainer.ShowMessage(internalMessage);

            return false;
        }

        #endregion INTERACTIONS WITH PAGES MANAGER METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invokeda after loading page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            codeRichTextBox.EasyTextManager = new EasyRichTextManager();
            CodeFormatter.LoadCSharpCode(SnippetItem.Snippet.Code.Code, codeRichTextBox);
        }

        #endregion PAGE METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if any changes has been made to the snippet. </summary>
        /// <returns> True - changes has been made to the snippet; False - otherwise. </returns>
        private bool CheckForChanges()
        {
            if (_forceClose)
                return false;

            string currentCode = GetCode();
            bool codeModified = !currentCode.Equals(SnippetItem.Snippet.Code.Code);
            bool snippetModified = SnippetItem.GetIsModified();

            return snippetModified || codeModified;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get code from code rich text box editor. </summary>
        /// <returns> Code from editor. </returns>
        private string GetCode()
        {
            TextRange textRange = new TextRange(codeRichTextBox.Document.ContentStart,
                codeRichTextBox.Document.ContentEnd);

            StringBuilder sb = new StringBuilder(textRange.Text);
            
            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }

        #endregion UTILITY METHODS

    }
}
