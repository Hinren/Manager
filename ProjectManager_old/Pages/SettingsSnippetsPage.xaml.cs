using ExtendedControls.Events;
using ExtendedControls.Static;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;
using Hinren.ProjectManager.Windows;
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
using static ExtendedControls.Events.Delegates;

namespace Hinren.ProjectManager.Pages
{
    public partial class SettingsSnippetsPage : BasePage
    {

        //  VARIABLES

        public ConfigurationManager ConfigurationManager { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsSnippetsPage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public SettingsSnippetsPage(PagesControl pagesController, object[] args = null) : base(pagesController, args)
        {
            ConfigurationManager = ConfigurationManager.Instance;

            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking select snippets localization button. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void SelectSnippetLocalizationPathButton_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow) Application.Current.MainWindow;

            InternalMessageClose<FilesSelectorInternalMessageCloseEventArgs> onClose = (s, e) =>
            {
                if (e.Result == InternalMessageResult.Ok)
                {
                    ConfigurationManager.UserName = e.FilePath;
                }
            };

            window.InternalMessagesController.ShowSelectDirectoryMessageBox("Choose snippet localization", onClose);
        }

        #endregion INTERACTION METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after closing page. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ConfigurationManager.SaveSettings();
        }

        #endregion PAGE METHODS

    }
}
