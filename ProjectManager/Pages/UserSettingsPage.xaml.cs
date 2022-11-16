using Hinren.ProjectManager.Pages.Base;
using System.Windows.Controls;

namespace Hinren.ProjectManager.Pages
{
    public partial class UserSettingsPage : BasePage
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> UserSettingsPage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public UserSettingsPage(PagesControl pagesController) : base(pagesController)
        {
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
