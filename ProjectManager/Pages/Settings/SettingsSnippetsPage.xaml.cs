using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.InternalMessages;
using ProjectManager.Commands;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using ProjectManager.Windows;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace ProjectManager.Pages.Settings
{
    public partial class SettingsSnippetsPage : BasePage
    {

        //  VARIABLES

        public ConfigManager ConfigManager { get; private set; }

        private ObservableCollection<SnippetCatalogItem> _snippetCatalogItems;

        public ICommand RemoveCommand { get; set; }


        //  GETTERS & SETTERS

        public ObservableCollection<SnippetCatalogItem> SnippetCatalogItems
        {
            get => _snippetCatalogItems;
            set
            {
                _snippetCatalogItems = value;
                _snippetCatalogItems.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SnippetCatalogItems)); };
                OnPropertyChanged(nameof(SnippetCatalogItems));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsSnippetsPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SettingsSnippetsPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize modules.
            ConfigManager = ConfigManager.Instance;

            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            //  Setup data containers.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove database profile button. </summary>
        /// <param name="profile"> Database profile as object. </param>
        private void OnRemoveCommandExecute(object profile)
        {
            if (profile is SnippetCatalogItem catalogItem)
            {
                if (SnippetCatalogItems.Contains(catalogItem))
                    SnippetCatalogItems.Remove(catalogItem);

                if (ConfigManager.SnippetCatalogItems.Contains(catalogItem))
                    ConfigManager.SnippetCatalogItems.Add(catalogItem);

                ConfigManager.SaveSettings();
            }
        }

        #endregion COMMANDS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking on add snippet catalog item ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AddCatalogButtonEx_Click(object sender, RoutedEventArgs e)
        {
            var imContainer = GetIMContainer();
            var im = FilesSelectorInternalMessageEx.CreateOpenFileInternalMessageEx(imContainer, "Add snippets catalog.");

            im.AllowCreate = true;
            im.InitialDirectory = ConfigManager.InternalMessageInitialDirectory;
            im.OnlyDirectories = true;

            InternalMessagesHelper.ApplyVisualStyle(im);

            im.OnClose += OnAddSnippetsCatalogClose;
            imContainer.ShowMessage(im);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing FilesSelectorInternalMessageEx for adding snippets catalog. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Files Selector Internal Message Close Event Arguments. </param>
        private void OnAddSnippetsCatalogClose(object sender, FilesSelectorInternalMessageCloseEventArgs e)
        {
            var filesSelectorIM = (FilesSelectorInternalMessageEx)sender;

            if (e.Result == InternalMessageResult.Ok)
            {
                var directoryPath = e.FilePath;

                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                try
                {
                    var catalogItem = new SnippetCatalogItem(directoryPath);

                    if (SnippetCatalogItems.Any(c => c.CatalogPath == catalogItem.CatalogPath))
                        throw new ArgumentException("Directory has already been added.");

                    SnippetCatalogItems.Add(catalogItem);
                    ConfigManager.SnippetCatalogItems.Add(catalogItem);
                }
                catch (Exception exc)
                {
                    var imContainer = GetIMContainer();
                    var im = InternalMessageEx.CreateErrorMessage(imContainer, "Adding catalog failed", exc.Message);

                    imContainer.ShowMessage(im);
                }
            }

            ConfigManager.InternalMessageInitialDirectory = filesSelectorIM.CurrentDirectory;
            ConfigManager.SaveSettings();
        }

        #endregion INTERACTION METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data containers. </summary>
        private void SetupData()
        {
            SnippetCatalogItems = new ObservableCollection<SnippetCatalogItem>(ConfigManager.SnippetCatalogItems);
        }

        #endregion SETUP METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get internal messages ex container from main window. </summary>
        /// <returns> Internal messages ex container. </returns>
        public InternalMessagesExContainer GetIMContainer()
        {
            return ((MainWindow)((App)Application.Current).MainWindow).InternalMessagesContainer;
        }

        #endregion UTILITY METHODS

    }
}
