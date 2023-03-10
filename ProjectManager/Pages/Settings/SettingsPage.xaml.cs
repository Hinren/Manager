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

namespace ProjectManager.Pages.Settings
{
    public partial class SettingsPage : BasePage
    {

        //  GETTERS & SETTERS

        public override List<MainMenuItem> MainMenuItems
        {
            get => new List<MainMenuItem>()
            {
                new MainMenuItem("Appearance", PackIconKind.Palette, (s, e) => { _pagesManager.LoadSettingsAppearancePage(); }),
                new MainMenuItem("About", PackIconKind.InfoOutline, (s, e) => { _pagesManager.LoadSettingsInformationsPage(); }),
            };
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public SettingsPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Appearance settings option button control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void AppearanceSettingsOptionButtonControl_Click(object sender, RoutedEventArgs e)
        {
            _pagesManager.LoadSettingsAppearancePage();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Info settings option button control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void InfoSettingsOptionButtonControl_Click(object sender, RoutedEventArgs e)
        {
            _pagesManager.LoadSettingsInformationsPage();
        }

        #endregion INTERACTION METHODS

    }
}
