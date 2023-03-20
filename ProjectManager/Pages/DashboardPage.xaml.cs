using chkam05.Tools.ControlsEx;
using MaterialDesignThemes.Wpf;
using ProjectManager.Data.Configuration;
using ProjectManager.Data.Dashboard;
using ProjectManager.Data.MainMenu;
using ProjectManager.Pages.Base;
using ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ProjectManager.Pages
{
    public partial class DashboardPage : BasePage
    {

        //  CONST

        private const int ONE_COLUMN_WIDTH = 384;
        private const int MAX_COLUMNS = 3;


        //  VARIABLES

        private DispatcherTimer _clockTimer;
        private DashboardUIHelper _dashboardHelper;
        private ExpanderEx _draggingExpander;
        private Point _draggingStartPoint;
        private bool _isLoaded = false;

        private string _welcomeAppName;
        private string _welcomeTime;
        private string _welcomeUserName;
        private string _welcomeVersion;

        public ConfigManager ConfigManager { get; private set; }
        public DashboardRecentlyUsedItemsManager DashboardRecentlyUsedItemsManager { get; private set; }


        //  GETTERS & SETTERS

        public override List<MainMenuItem> MainMenuItems
        {
            get => new List<MainMenuItem>()
            {
                new MainMenuItem("Dasboard", PackIconKind.Home, (s, e) => { _pagesManager.LoadSettingsMainPage(); }),
                new MainMenuItem("Settings", PackIconKind.Gear, (s, e) => { _pagesManager.LoadSettingsMainPage(); }),
            };
        }

        public string WelcomeAppName
        {
            get => _welcomeAppName;
            set
            {
                _welcomeAppName = value;
                OnPropertyChanged(nameof(WelcomeAppName));
            }
        }

        public string WelcomeTime
        {
            get => _welcomeTime;
            set
            {
                _welcomeTime = value;
                OnPropertyChanged(nameof(WelcomeTime));
            }
        }

        public string WelcomeUserName
        {
            get => _welcomeUserName;
            set
            {
                _welcomeUserName = value;
                OnPropertyChanged(nameof(WelcomeUserName));
            }
        }

        public string WelcomeVersion
        {
            get => _welcomeVersion;
            set
            {
                _welcomeVersion = value;
                OnPropertyChanged(nameof(WelcomeVersion));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DashboardPage class constructor. </summary>
        /// <param name="pagesManager"> Pages Manager. </param>
        public DashboardPage(PagesManager pagesManager) : base(pagesManager)
        {
            //  Initialize modules.
            ConfigManager = ConfigManager.Instance;
            _dashboardHelper = new DashboardUIHelper();
            DashboardRecentlyUsedItemsManager = DashboardRecentlyUsedItemsManager.Instance;
            DashboardRecentlyUsedItemsManager.LoadItems(ConfigManager.Configuration.RecentlyUsedItems);
            DashboardRecentlyUsedItemsManager.PropertyChanged += OnDashboardRecentlyUsedItemsUpdate;

            //  Setup data.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
            CreateClockTimer();
        }

        #endregion CLASS METHODS

        #region CLOCK TIMER METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create clock timer. </summary>
        private void CreateClockTimer()
        {
            _clockTimer = new DispatcherTimer();
            _clockTimer.Interval = new TimeSpan(0, 0, 1);
            _clockTimer.Tick += ClockTimerTick;
            _clockTimer.Start();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoking by clock timer every tick. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event arguments. </param>
        private void ClockTimerTick(object sender, EventArgs e)
        {
            WelcomeTime = DateTime.Now.ToString("dddd dd.MM.yyyy hh:mm");
        }

        #endregion CLOCK TIMER METHODS

        #region DASHBOARD ARRANGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing mouse button on ExpanderEx to move. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Evnet Arguments. </param>
        private void DashboardComponent_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ExpanderEx expanderEx)
            {
                _draggingExpander = expanderEx;
                _draggingStartPoint = e.GetPosition(null);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after releasing mouse button from ExpanderEx after move. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Evnet Arguments. </param>
        private void DashboardComponent_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            _draggingExpander = null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked by moving cursor over ExpanderEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Evnet Arguments. </param>
        private void DashboardComponent_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_draggingExpander == null)
                return;

            Point position = e.GetPosition(null);
            Vector offset = _draggingStartPoint - position;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(offset.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(offset.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                DataObject data = new DataObject(_draggingExpander);
                DragDrop.DoDragDrop(_draggingExpander, data, DragDropEffects.Move);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after dropping component on StackPanel. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Drag Event Arguments. </param>
        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ExpanderEx)))
            {
                ExpanderEx expander = (ExpanderEx)e.Data.GetData(typeof(ExpanderEx));

                var targetStackPanel = sender as StackPanel;
                var sourceStackPanel = expander.Parent as StackPanel;

                if (sourceStackPanel != null && targetStackPanel != null)
                {
                    _dashboardHelper.MoveDashboardComponent(sourceStackPanel, targetStackPanel, expander, e);

                    ConfigManager.Configuration.DashboardConfig.ComponentsPosition = _dashboardHelper.DashboardComponents;
                    ConfigManager.SaveSettings();
                }
            }
        }

        #endregion DASHBOARD ARRANGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invked after clicking on dashboard ButtonEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arugments. </param>
        private void DashboardSettingsButtonEx_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Middle)
                return;

            if (e.ChangedButton == MouseButton.Left)
            {
                ButtonEx button = (ButtonEx)sender;
                ContextMenuEx contextMenu = (ContextMenuEx)button.ContextMenu;
                contextMenu.PlacementTarget = button;
                contextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                contextMenu.IsOpen = true;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after updating property in DashboardRecentlyUsedItemsManager. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        private void OnDashboardRecentlyUsedItemsUpdate(object sender, PropertyChangedEventArgs e)
        {
            var recentlyUsedItemsManager = sender as DashboardRecentlyUsedItemsManager;

            if (recentlyUsedItemsManager != null && e.PropertyName == nameof(recentlyUsedItemsManager.RecentlyUsedItemsCollection))
            {
                ConfigManager.Configuration.RecentlyUsedItems = recentlyUsedItemsManager.GetItems();
                ConfigManager.SaveSettings();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting item in recently used items ListViewEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Selection Changed Evnet Arguments. </param>
        private void RecentlyUsedItemsListViewEx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listViewEx = sender as ListViewEx;

            if (listViewEx != null)
            {
                var item = listViewEx.SelectedItem as DashboardRecentlyUsedItem;

                if (item != null)
                {
                    if (item.Kind == DashboardRecentlyUsedItemKind.Page)
                        _pagesManager.LoadPageByName(item.Key);

                    listViewEx.SelectedItem = null;
                };
            }
        }

        #endregion INTERACTION METHODS

        #region PAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            _dashboardHelper.InitializeHelper(dashboardGrid, ConfigManager.Configuration.DashboardConfig);
            _isLoaded = true;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after resizing page. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Size CHanged Event Arguments. </param>
        private void BasePage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_isLoaded && _dashboardHelper.IsInitialized)
                _dashboardHelper.UpdateDashboardAfterResize();
        }

        #endregion PAGE METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data. </summary>
        private void SetupData()
        {
            WelcomeAppName = ApplicationHelper.GetApplicationTitle();
            WelcomeTime = DateTime.Now.ToString("dddd dd.MM.yyyy hh:mm");
            WelcomeUserName = Environment.GetEnvironmentVariable("USERNAME")?.ToUpper();
            WelcomeVersion = ApplicationHelper.GetApplicationVersion().ToString();
        }

        #endregion SETUP METHODS

    }
}
