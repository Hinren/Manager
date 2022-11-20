using ExtendedControls.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExtendedControls
{
    public class ExtExpander : Expander, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double ARROW_HEIGHT = 28d;
        protected readonly static double ARROW_WIDTH = 28d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty HeaderBackgroundBrushProperty = DependencyProperty.Register(
            nameof(HeaderBackgroundBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty HeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(HeaderBorderBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty HeaderForegroundBrushProperty = DependencyProperty.Register(
            nameof(HeaderForegroundBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Colors Properties

        #region Arrow Properties

        public static readonly DependencyProperty ArrowBrushProperty = DependencyProperty.Register(
            nameof(ArrowBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ArrowMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ArrowMouseOverBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ArrowPressedBrushProperty = DependencyProperty.Register(
            nameof(ArrowPressedBrush),
            typeof(Brush),
            typeof(ExtExpander),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ArrowHeightProperty = DependencyProperty.Register(
            nameof(ArrowHeight),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(ARROW_HEIGHT));

        public static readonly DependencyProperty ArrowMaxHeightProperty = DependencyProperty.Register(
            nameof(ArrowMaxHeight),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(double.PositiveInfinity));

        public static readonly DependencyProperty ArrowMarginProperty = DependencyProperty.Register(
            nameof(ArrowMargin),
            typeof(Thickness),
            typeof(ExtExpander),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty ArrowMaxWidthProperty = DependencyProperty.Register(
            nameof(ArrowMaxWidth),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(double.PositiveInfinity));

        public static readonly DependencyProperty ArrowMinHeightProperty = DependencyProperty.Register(
            nameof(ArrowMinHeight),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty ArrowMinWidthProperty = DependencyProperty.Register(
            nameof(ArrowMinWidth),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty ArrowWidthProperty = DependencyProperty.Register(
            nameof(ArrowWidth),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(ARROW_WIDTH));

        #endregion Arrow Properties

        #region Header Properties

        public static readonly DependencyProperty HeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(HeaderBorderThickness),
            typeof(Thickness),
            typeof(ExtExpander),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty HeaderFontFamilyProperty = DependencyProperty.Register(
            nameof(HeaderFontFamily),
            typeof(FontFamily),
            typeof(ExtExpander),
            new PropertyMetadata(new FontFamily()));

        public static readonly DependencyProperty HeaderFontSizeProperty = DependencyProperty.Register(
            nameof(HeaderFontSize),
            typeof(double),
            typeof(ExtExpander),
            new PropertyMetadata(14d));

        public static readonly DependencyProperty HeaderFontStretchProperty = DependencyProperty.Register(
            nameof(HeaderFontStretch),
            typeof(FontStretch),
            typeof(ExtExpander),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty HeaderFontStyleProperty = DependencyProperty.Register(
            nameof(HeaderFontStyle),
            typeof(FontStyle),
            typeof(ExtExpander),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty HeaderFontWeightProperty = DependencyProperty.Register(
            nameof(HeaderFontWeight),
            typeof(FontWeight),
            typeof(ExtExpander),
            new PropertyMetadata(FontWeights.SemiBold));

        public static readonly DependencyProperty HeaderPaddingProperty = DependencyProperty.Register(
            nameof(HeaderPadding),
            typeof(Thickness),
            typeof(ExtExpander),
            new PropertyMetadata(new Thickness(0)));

        #endregion Header Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtExpander),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush HeaderBackgroundBrush
        {
            get => (Brush)GetValue(HeaderBackgroundBrushProperty);
            set
            {
                SetValue(HeaderBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(HeaderBackgroundBrush));
            }
        }

        public Brush HeaderBorderBrush
        {
            get => (Brush)GetValue(HeaderBorderBrushProperty);
            set
            {
                SetValue(HeaderBorderBrushProperty, value);
                OnPropertyChanged(nameof(HeaderBorderBrush));
            }
        }

        public Brush HeaderForegroundBrush
        {
            get => (Brush)GetValue(HeaderForegroundBrushProperty);
            set
            {
                SetValue(HeaderForegroundBrushProperty, value);
                OnPropertyChanged(nameof(HeaderForegroundBrush));
            }
        }

        #endregion Appearance Colors

        #region Arrow Properties

        public Brush ArrowBrush
        {
            get => (Brush)GetValue(ArrowBrushProperty);
            set
            {
                SetValue(ArrowBrushProperty, value);
                OnPropertyChanged(nameof(ArrowBrush));
            }
        }

        public Brush ArrowMouseOverBrush
        {
            get => (Brush)GetValue(ArrowMouseOverBrushProperty);
            set
            {
                SetValue(ArrowMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ArrowMouseOverBrush));
            }
        }

        public Brush ArrowPressedBrush
        {
            get => (Brush)GetValue(ArrowPressedBrushProperty);
            set
            {
                SetValue(ArrowPressedBrushProperty, value);
                OnPropertyChanged(nameof(ArrowPressedBrush));
            }
        }

        public double ArrowHeight
        {
            get => (double)GetValue(ArrowHeightProperty);
            set
            {
                SetValue(ArrowHeightProperty, value);
                OnPropertyChanged(nameof(ArrowHeight));
            }
        }

        public Thickness ArrowMargin
        {
            get => (Thickness)GetValue(ArrowMarginProperty);
            set
            {
                SetValue(ArrowMarginProperty, value);
                OnPropertyChanged(nameof(ArrowMargin));
            }
        }

        public double ArrowMaxHeight
        {
            get => (double)GetValue(ArrowMaxHeightProperty);
            set
            {
                SetValue(ArrowMaxHeightProperty, value);
                OnPropertyChanged(nameof(ArrowMaxHeight));
            }
        }

        public double ArrowMaxWidth
        {
            get => (double)GetValue(ArrowMaxWidthProperty);
            set
            {
                SetValue(ArrowMaxWidthProperty, value);
                OnPropertyChanged(nameof(ArrowMaxWidth));
            }
        }

        public double ArrowMinHeight
        {
            get => (double)GetValue(ArrowMinHeightProperty);
            set
            {
                SetValue(ArrowMinHeightProperty, value);
                OnPropertyChanged(nameof(ArrowMinHeight));
            }
        }

        public double ArrowMinWidth
        {
            get => (double)GetValue(ArrowMinWidthProperty);
            set
            {
                SetValue(ArrowMinWidthProperty, value);
                OnPropertyChanged(nameof(ArrowMinWidth));
            }
        }

        public double ArrowWidth
        {
            get => (double)GetValue(ArrowWidthProperty);
            set
            {
                SetValue(ArrowWidthProperty, value);
                OnPropertyChanged(nameof(ArrowWidth));
            }
        }

        #endregion Arrow Properties

        #region Header

        public Thickness HeaderBorderThickness
        {
            get => (Thickness)GetValue(HeaderBorderThicknessProperty);
            set
            {
                SetValue(HeaderBorderThicknessProperty, value);
                OnPropertyChanged(nameof(HeaderBorderThickness));
            }
        }

        public FontFamily HeaderFontFamily
        {
            get => (FontFamily)GetValue(HeaderFontFamilyProperty);
            set
            {
                SetValue(HeaderFontFamilyProperty, value);
                OnPropertyChanged(nameof(HeaderFontFamily));
            }
        }

        public double HeaderFontSize
        {
            get => (double)GetValue(HeaderFontSizeProperty);
            set
            {
                SetValue(HeaderFontSizeProperty, value);
                OnPropertyChanged(nameof(HeaderFontSize));
            }
        }

        public FontStretch HeaderFontStretch
        {
            get => (FontStretch)GetValue(HeaderFontStretchProperty);
            set
            {
                SetValue(HeaderFontStretchProperty, value);
                OnPropertyChanged(nameof(HeaderFontStretch));
            }
        }

        public FontStyle HeaderFontStyle
        {
            get => (FontStyle)GetValue(HeaderFontStyleProperty);
            set
            {
                SetValue(HeaderFontStyleProperty, value);
                OnPropertyChanged(nameof(HeaderFontStyle));
            }
        }

        public FontWeight HeaderFontWeight
        {
            get => (FontWeight)GetValue(HeaderFontWeightProperty);
            set
            {
                SetValue(HeaderFontWeightProperty, value);
                OnPropertyChanged(nameof(HeaderFontWeight));
            }
        }

        public Thickness HeaderPadding
        {
            get => (Thickness)GetValue(HeaderPaddingProperty);
            set
            {
                SetValue(HeaderPaddingProperty, value);
                OnPropertyChanged(nameof(HeaderPadding));
            }
        }

        #endregion Header

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ExtExpander class constructor. </summary>
        static ExtExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtExpander),
                new FrameworkPropertyMetadata(typeof(ExtExpander)));
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
