using ExtendedControls.Data;
using ExtendedControls.Events;
using Hinren.ProjectManager.Data.Settings;
using Hinren.ProjectManager.Data.Settings.Static;
using Hinren.ProjectManager.Pages.Base;
using Hinren.ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hinren.ProjectManager.Pages
{
    public partial class SettingsAppearancePage : BasePage
    {

        //  VARIABLES

        private ObservableCollection<ColorPaletteItem> accentUsedColors;
        private ObservableCollection<AppearanceTheme> appearanceThemes;

        public ConfigurationManager ConfigurationManager { get; private set; }


        //  GETTERS & SETTERS

        public ObservableCollection<ColorPaletteItem> AccentUsedColors
        {
            get => accentUsedColors;
            set
            {
                accentUsedColors = value;
                OnPropertyChanged(nameof(AccentUsedColors));
            }
        }

        public ObservableCollection<AppearanceTheme> AppearanceThemes
        {
            get => appearanceThemes;
            set
            {
                appearanceThemes = value;
                OnPropertyChanged(nameof(AppearanceThemes));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SettingsAppearancePage class constructor. </summary>
        /// <param name="pagesController"> Parent pages controller. </param>
        public SettingsAppearancePage(PagesControl pagesController) : base(pagesController)
        {
            ConfigurationManager = ConfigurationManager.Instance;

            AccentUsedColors = new ObservableCollection<ColorPaletteItem>(
                ConfigurationManager.Configuration.UIConfiguration.UsedAccentColors ?? 
                    UIConfiguration.Default.UsedAccentColors);

            AppearanceThemes = new ObservableCollection<AppearanceTheme>(EnumHelper.ListOf<AppearanceTheme>());

            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing color selection in accent colors palette. </summary>
        /// <param name="sender"> Object from which method has been invoked. </param>
        /// <param name="e"> Colors Palette Selection Changed Event Arguments. </param>
        private void ColorsPalette_ColorSelectionChanged(object sender, ColorsPaletteSelectionChangedEventArgs e)
        {
            if (e.SelectedColorItem != null)
                ConfigurationManager.AppearanceAccentColor = e.SelectedColorItem.Color;
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
            ConfigurationManager.Configuration.UIConfiguration.UsedAccentColors = AccentUsedColors.Select(i => i).ToList();
            ConfigurationManager.SaveSettings();
        }

        #endregion PAGE METHODS

    }
}
