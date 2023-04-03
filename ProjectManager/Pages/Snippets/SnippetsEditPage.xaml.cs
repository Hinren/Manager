using chkam05.Tools.ControlsEx.Utilities;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using SnippetsManager.Models;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Documents;


namespace ProjectManager.Pages.Snippets
{
    public partial class SnippetsEditPage : BasePage
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }

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
        private void SettingsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void SaveButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void CancelButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        #endregion INTERACTION METHODS

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

    }
}
