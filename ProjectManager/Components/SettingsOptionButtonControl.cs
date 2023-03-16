using chkam05.Tools.ControlsEx;
using chkam05.Tools.ControlsEx.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProjectManager.Components
{
    public class SettingsOptionButtonControl : Button, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Properties

        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register(
            nameof(MouseOverBackground),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverBorderBrushProperty = DependencyProperty.Register(
            nameof(MouseOverBorderBrush),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_MOUSE_OVER)));

        public static readonly DependencyProperty MouseOverForegroundProperty = DependencyProperty.Register(
            nameof(MouseOverForeground),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register(
            nameof(PressedBackground),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty PressedBorderBrushProperty = DependencyProperty.Register(
            nameof(PressedBorderBrush),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR_PRESSED)));

        public static readonly DependencyProperty PressedForegroundProperty = DependencyProperty.Register(
            nameof(PressedForeground),
            typeof(Brush),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Properties

        #region Font Dependency Properties

        //  Title

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register(
            nameof(TitleFontFamily),
            typeof(FontFamily),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new FontFamily("Seoge UI")));

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register(
            nameof(TitleFontSize),
            typeof(double),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(14d));

        public static readonly DependencyProperty TitleFontStretchProperty = DependencyProperty.Register(
            nameof(TitleFontStretch),
            typeof(FontStretch),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register(
            nameof(TitleFontStyle),
            typeof(FontStyle),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(
            nameof(TitleFontWeight),
            typeof(FontWeight),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontWeights.SemiBold));

        //  Description

        public static readonly DependencyProperty DescriptionFontFamilyProperty = DependencyProperty.Register(
            nameof(DescriptionFontFamily),
            typeof(FontFamily),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new FontFamily("Seoge UI")));

        public static readonly DependencyProperty DescriptionFontSizeProperty = DependencyProperty.Register(
            nameof(DescriptionFontSize),
            typeof(double),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(12d));

        public static readonly DependencyProperty DescriptionFontStretchProperty = DependencyProperty.Register(
            nameof(DescriptionFontStretch),
            typeof(FontStretch),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty DescriptionFontStyleProperty = DependencyProperty.Register(
            nameof(DescriptionFontStyle),
            typeof(FontStyle),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty DescriptionFontWeightProperty = DependencyProperty.Register(
            nameof(DescriptionFontWeight),
            typeof(FontWeight),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(FontWeights.Normal));

        #endregion Font Dependency Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new CornerRadius(4d)));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(PackIconKind.None));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(new Thickness(0, 0, 4, 0)));

        public static readonly DependencyProperty IconSizeProperty = DependencyProperty.Register(
            nameof(IconSize),
            typeof(double),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(28d));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(SettingsOptionButtonControl),
            new PropertyMetadata(string.Empty));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance

        public Brush MouseOverBackground
        {
            get => (Brush)GetValue(MouseOverBackgroundProperty);
            set
            {
                SetValue(MouseOverBackgroundProperty, value);
                OnPropertyChanged(nameof(MouseOverBackground));
            }
        }

        public Brush MouseOverBorderBrush
        {
            get => (Brush)GetValue(MouseOverBorderBrushProperty);
            set
            {
                SetValue(MouseOverBorderBrushProperty, value);
                OnPropertyChanged(nameof(MouseOverBorderBrush));
            }
        }

        public Brush MouseOverForeground
        {
            get => (Brush)GetValue(MouseOverForegroundProperty);
            set
            {
                SetValue(MouseOverForegroundProperty, value);
                OnPropertyChanged(nameof(MouseOverForeground));
            }
        }

        public Brush PressedBackground
        {
            get => (Brush)GetValue(PressedBackgroundProperty);
            set
            {
                SetValue(PressedBackgroundProperty, value);
                OnPropertyChanged(nameof(PressedBackground));
            }
        }

        public Brush PressedBorderBrush
        {
            get => (Brush)GetValue(PressedBorderBrushProperty);
            set
            {
                SetValue(PressedBorderBrushProperty, value);
                OnPropertyChanged(nameof(PressedBorderBrush));
            }
        }

        public Brush PressedForeground
        {
            get => (Brush)GetValue(PressedForegroundProperty);
            set
            {
                SetValue(PressedForegroundProperty, value);
                OnPropertyChanged(nameof(PressedForeground));
            }
        }

        #endregion Appearance

        #region Font

        //  Title

        public FontFamily TitleFontFamily
        {
            get => (FontFamily)GetValue(TitleFontFamilyProperty);
            set
            {
                SetValue(TitleFontFamilyProperty, value);
                OnPropertyChanged(nameof(TitleFontFamily));
            }
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set
            {
                SetValue(TitleFontSizeProperty, value);
                OnPropertyChanged(nameof(TitleFontSize));
            }
        }

        public FontStretch TitleFontStretch
        {
            get => (FontStretch)GetValue(TitleFontStretchProperty);
            set
            {
                SetValue(TitleFontStretchProperty, value);
                OnPropertyChanged(nameof(TitleFontStretch));
            }
        }

        public FontStyle TitleFontStyle
        {
            get => (FontStyle)GetValue(TitleFontStyleProperty);
            set
            {
                SetValue(TitleFontStyleProperty, value);
                OnPropertyChanged(nameof(TitleFontStyle));
            }
        }

        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set
            {
                SetValue(TitleFontWeightProperty, value);
                OnPropertyChanged(nameof(TitleFontWeight));
            }
        }

        //  Description

        public FontFamily DescriptionFontFamily
        {
            get => (FontFamily)GetValue(DescriptionFontFamilyProperty);
            set
            {
                SetValue(DescriptionFontFamilyProperty, value);
                OnPropertyChanged(nameof(DescriptionFontFamily));
            }
        }

        public double DescriptionFontSize
        {
            get => (double)GetValue(DescriptionFontSizeProperty);
            set
            {
                SetValue(DescriptionFontSizeProperty, value);
                OnPropertyChanged(nameof(DescriptionFontSize));
            }
        }

        public FontStretch DescriptionFontStretch
        {
            get => (FontStretch)GetValue(DescriptionFontStretchProperty);
            set
            {
                SetValue(DescriptionFontStretchProperty, value);
                OnPropertyChanged(nameof(DescriptionFontStretch));
            }
        }

        public FontStyle DescriptionFontStyle
        {
            get => (FontStyle)GetValue(DescriptionFontStyleProperty);
            set
            {
                SetValue(DescriptionFontStyleProperty, value);
                OnPropertyChanged(nameof(DescriptionFontStyle));
            }
        }

        public FontWeight DescriptionFontWeight
        {
            get => (FontWeight)GetValue(DescriptionFontWeightProperty);
            set
            {
                SetValue(DescriptionFontWeightProperty, value);
                OnPropertyChanged(nameof(DescriptionFontWeight));
            }
        }

        #endregion Font

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set
            {
                SetValue(IconMarginProperty, value);
                OnPropertyChanged(nameof(IconMargin));
            }
        }

        public double IconSize
        {
            get => (double)GetValue(IconSizeProperty);
            set
            {
                SetValue(IconSizeProperty, value);
                OnPropertyChanged(nameof(IconSize));
            }
        }

        public string Title
        {
            get => (string)GetValue(DescriptionProperty);
            set
            {
                SetValue(DescriptionProperty, value);
                OnPropertyChanged(nameof(Title));
            }
        }

        public string Description
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
                OnPropertyChanged(nameof(Description));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static SettingsOptionButtonControl class constructor. </summary>
        static SettingsOptionButtonControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SettingsOptionButtonControl),
                new FrameworkPropertyMetadata(typeof(SettingsOptionButtonControl)));
        }

        #endregion CLASS METHODS

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

    }
}
