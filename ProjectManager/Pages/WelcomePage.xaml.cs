using MaterialDesignThemes.Wpf;
using ProjectManager.Data.MainMenu;
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

namespace ProjectManager.Pages
{
    public partial class WelcomePage : BasePage
    {

        //  GETTERS & SETTERS

        public override List<MainMenuItem> MainMenuItems
        {
            get => new List<MainMenuItem>()
            {
                new MainMenuItem("Settings", PackIconKind.Gear, (s, e) => { _pagesManager.LoadSettingsMainPage(); }),
            };
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> WelcomePage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public WelcomePage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

    }
}
