using chkam05.Tools.ControlsEx;
using MaterialDesignThemes.Wpf;
using ProjectManager.Data.MainMenu;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
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
    public partial class DashboardPage : BasePage
    {

        //  VARIABLES

        private ExpanderEx _draggingExpander;

        private string _welcomeText;


        //  GETTERS & SETTERS

        public override List<MainMenuItem> MainMenuItems
        {
            get => new List<MainMenuItem>()
            {
                new MainMenuItem("Settings", PackIconKind.Gear, (s, e) => { _pagesManager.LoadSettingsMainPage(); }),
            };
        }

        public string WelcomeText
        {
            get => _welcomeText;
            set
            {
                _welcomeText = value;
                OnPropertyChanged(nameof(WelcomeText));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public DashboardPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Setup data.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region DASHBOARD ARRANGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing button on ExpanderEx to move. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Evnet Arguments. </param>
        private void ExpanderEx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _draggingExpander = sender as ExpanderEx;

            if (_draggingExpander != null)
                DragDrop.DoDragDrop(_draggingExpander, _draggingExpander, DragDropEffects.Move);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after dropping component on StackPanel. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Drag Event Arguments. </param>
        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if (_draggingExpander != null)
            {
                var sourceStackPanel = _draggingExpander.Parent as StackPanel;

                if (sourceStackPanel != null)
                {
                    sourceStackPanel.Children.Remove(_draggingExpander);

                    var targetStackPanel = sender as StackPanel;

                    if (targetStackPanel != null)
                        targetStackPanel.Children.Add(_draggingExpander);
                }
            }
        }

        #endregion DASHBOARD ARRANGEMENT METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data. </summary>
        private void SetupData()
        {
            var appName = ApplicationHelper.GetApplicationTitle();
            var appVersion = ApplicationHelper.GetApplicationVersion();
            var dateAndTime = DateTime.Now.ToString("dddd dd.MM.yyyy");
            var userName = Environment.GetEnvironmentVariable("USERNAME");

            WelcomeText = $"Welcome {userName.ToUpper()} in {appName}, version {appVersion}."
                + Environment.NewLine + $"Today is: {dateAndTime}";
        }

        #endregion SETUP METHODS

    }
}
