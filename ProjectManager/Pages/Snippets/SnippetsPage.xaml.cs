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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjectManager.Pages.Snippets
{
    public partial class SnippetsPage : BasePage
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }
        public SnippetsManager.SnippetsManager SnippetsManager { get; private set; }

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
            SnippetsManager = new SnippetsManager.SnippetsManager(ConfigManager.Configuration.SnippetConfig);

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
                //
            }
        }

        #endregion COMMANDS METHODS

    }
}
