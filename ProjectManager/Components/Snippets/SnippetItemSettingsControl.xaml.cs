using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Utilities;
using ProjectManager.Data.Configuration;
using ProjectManager.Data.Storyboards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.Components.Snippets
{
    public partial class SnippetItemSettingsControl : UserControl, INotifyPropertyChanged
    {

        //  CONST

        private const double HIDE_MARGIN_SHIFT = 16d;


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private bool _controlShowed = false;
        private StoryboardMarginDataHandler _storyboardDataHandler;
        private bool _storyboardRestarted = false;

        private FontFamilyInfo _fontFamilyInfo;
        private ObservableCollection<FontFamilyInfo> _fontFamilyInfosCollection;

        public ConfigManager ConfigManager { get; private set; }


        //  GETTERS & SETTERS

        public bool ControlShowed
        {
            get => _controlShowed;
        }

        public StoryboardMarginDataHandler StoryboardDataHandler
        {
            get => _storyboardDataHandler;
            set
            {
                _storyboardDataHandler = value;
                OnPropertyChanged(nameof(StoryboardDataHandler));
            }
        }

        public FontFamilyInfo FontFamilyInfo
        {
            get => _fontFamilyInfo;
            set
            {
                _fontFamilyInfo = value;

                if (ConfigManager != null)
                    ConfigManager.SnippetFontFamilyName = _fontFamilyInfo.Name;

                OnPropertyChanged(nameof(FontFamilyInfo));
            }
        }

        public ObservableCollection<FontFamilyInfo> FontFamilyInfos
        {
            get => _fontFamilyInfosCollection;
            set
            {
                _fontFamilyInfosCollection = value;
                _fontFamilyInfosCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(FontFamilyInfos)); };
                OnPropertyChanged(nameof(FontFamilyInfos));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetItemSettingsControl class constructor. </summary>
        public SnippetItemSettingsControl()
        {
            //  Setup modules.
            ConfigManager = ConfigManager.Instance;

            //  Setup data containers.
            SetupData();

            //  Initialize interface.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region ANIMATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing showing/hiding quick view animation. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void Storyboard_Completed(object sender, EventArgs e)
        {
            if (!_storyboardRestarted)
            {
                _controlShowed = !_controlShowed;
                OnPropertyChanged(nameof(ControlShowed));
            }

            if (_storyboardRestarted)
                _storyboardRestarted = false;

            if (_controlShowed && !CompareMargins(controlBorder.Margin, StoryboardDataHandler.Margin))
            {
                _storyboardRestarted = true;
                StoryboardDataHandler.RunStoryboard();
            }
        }

        #endregion ANIMATION METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Update settings. </summary>
        private void UpdateData()
        {
            ConfigManager.SaveSettings();
        }

        #endregion DATA MANAGEMENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Hide control using animation. </summary>
        public void HideControl()
        {
            if (_controlShowed)
            {
                UpdateData();
                var left = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
                var right = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
                StoryboardDataHandler.RunStoryboard(new Thickness(left, 8, -right, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show control using animation. </summary>
        public void ShowControl()
        {
            if (!_controlShowed)
            {
                StoryboardDataHandler.RunStoryboard(new Thickness(8, 8, 16, 8));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking close button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void CloseButtonEx_Click(object sender, RoutedEventArgs e)
        {
            HideControl();
        }

        #endregion INTERACTION METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data. </summary>
        private void SetupData()
        {
            FontFamilyInfos = new ObservableCollection<FontFamilyInfo>(FontUtilities.SystemFonts);
            FontFamilyInfo = FontUtilities.FindFontByName(FontUtilities.SystemFonts, ConfigManager.SnippetFontFamilyName);
        }

        #endregion SETUP METHODS

        #region USER CONTROL METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading user control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //  Setup data.
            var storyboard = Resources["ShowHideControlStoryboard"] as Storyboard;
            var left = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
            var right = controlBorder.ActualWidth + HIDE_MARGIN_SHIFT;
            var margin = new Thickness(left, 8, -right, 8);

            controlBorder.Margin = margin;
            _controlShowed = false;

            StoryboardDataHandler = new StoryboardMarginDataHandler(storyboard)
            {
                Margin = margin
            };
        }

        #endregion USER CONTROL METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Compare two margins. </summary>
        /// <param name="m1"> Margin 1. </param>
        /// <param name="m2"> Margin 2. </param>
        /// <returns> True - margins are equal. False - otherwise. </returns>
        private bool CompareMargins(Thickness m1, Thickness m2)
        {
            return Math.Round(m1.Left) == Math.Round(m2.Left)
                && Math.Round(m1.Top) == Math.Round(m2.Top)
                && Math.Round(m1.Right) == Math.Round(m2.Right)
                && Math.Round(m1.Bottom) == Math.Round(m2.Bottom);
        }

        #endregion UTILITY METHODS

    }
}
