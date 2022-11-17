using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Pages.Base;

namespace Hinren.ProjectManager.Pages
{
    public partial class UserSettingsPage : BasePage
    {

        //  VARIABLES

        public ConfigurationManager ConfigurationManager { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UserSettingsPage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public UserSettingsPage(PagesControl pagesController) : base(pagesController)
        {
            ConfigurationManager = ConfigurationManager.Instance;

            InitializeComponent();
        }

        #endregion CLASS METHODS

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
