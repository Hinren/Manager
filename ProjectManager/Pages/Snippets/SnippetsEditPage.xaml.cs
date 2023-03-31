using ProjectManager.Commands;
using ProjectManager.Components;
using ProjectManager.Data.Configuration;
using ProjectManager.Pages.Base;
using ProjectManager.Pages.Events;
using SnippetsManager.Models;
using System;
using System.Collections.Generic;
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

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        private void DeclarationsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void ImportsButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void PropertiesButtonEx_Click(object sender, RoutedEventArgs e)
        {
            //
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
            //
        }

        #endregion PAGE METHODS

    }
}
