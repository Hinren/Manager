using ProjectManager.Pages.Base;
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

namespace ProjectManager.Pages.Settings
{
    public partial class SettingsInfoPage : BasePage
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsInfoPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SettingsInfoPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
