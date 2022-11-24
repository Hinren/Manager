using ExtendedControls.Static;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExtendedControls
{
    public class ExtScrollViewer : ScrollViewer, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ScrollBarsBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ScrollBarsBackgroundBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ScrollBarsCornerBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ScrollBarsCornerBackgroundBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ThumbBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundDraggingBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ThumbBorderDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderDraggingBrush),
            typeof(Brush),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty ScrollBarHorizontalHeightProperty = DependencyProperty.Register(
            nameof(ScrollBarHorizontalHeight),
            typeof(double),
            typeof(ExtScrollViewer),
            new PropertyMetadata(StaticResources.DEFAULT_HORIZONTAL_SCROLLBAR_HEIGHT));

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ExtScrollViewer),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ThumbHorizontalMarginProperty = DependencyProperty.Register(
            nameof(ThumbHorizontalMargin),
            typeof(Thickness),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new Thickness(0,4,0,4)));

        public static readonly DependencyProperty ThumbVerticalMarginProperty = DependencyProperty.Register(
            nameof(ThumbVerticalMargin),
            typeof(Thickness),
            typeof(ExtScrollViewer),
            new PropertyMetadata(new Thickness(4,0,4,0)));

        public static readonly DependencyProperty ScrollBarVerticalWidthProperty = DependencyProperty.Register(
            nameof(ScrollBarVerticalWidth),
            typeof(double),
            typeof(ExtScrollViewer),
            new PropertyMetadata(StaticResources.DEFAULT_VERTICAL_SCROLLBAR_WIDTH));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ScrollBarsBackgroundBrush
        {
            get => (Brush)GetValue(ScrollBarsBackgroundBrushProperty);
            set
            {
                SetValue(ScrollBarsBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ScrollBarsBackgroundBrush));
            }
        }

        public Brush ScrollBarsCornerBackgroundBrush
        {
            get => (Brush)GetValue(ScrollBarsCornerBackgroundBrushProperty);
            set
            {
                SetValue(ScrollBarsCornerBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ScrollBarsCornerBackgroundBrush));
            }
        }

        public Brush ThumbBackgroundBrush
        {
            get => (Brush)GetValue(ThumbBackgroundBrushProperty);
            set
            {
                SetValue(ThumbBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBackgroundBrush));
            }
        }

        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set
            {
                SetValue(ThumbBorderBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBorderBrush));
            }
        }

        public Brush ThumbBackgroundMouseOverBrush
        {
            get => (Brush)GetValue(ThumbBackgroundMouseOverBrushProperty);
            set
            {
                SetValue(ThumbBackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBackgroundMouseOverBrush));
            }
        }

        public Brush ThumbBorderMouseOverBrush
        {
            get => (Brush)GetValue(ThumbBorderMouseOverBrushProperty);
            set
            {
                SetValue(ThumbBorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBorderMouseOverBrush));
            }
        }

        public Brush ThumbBackgroundDraggingBrush
        {
            get => (Brush)GetValue(ThumbBackgroundDraggingBrushProperty);
            set
            {
                SetValue(ThumbBackgroundDraggingBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBackgroundDraggingBrush));
            }
        }

        public Brush ThumbBorderDraggingBrush
        {
            get => (Brush)GetValue(ThumbBorderDraggingBrushProperty);
            set
            {
                SetValue(ThumbBorderDraggingBrushProperty, value);
                OnPropertyChanged(nameof(ThumbBorderDraggingBrush));
            }
        }

        #endregion Appearance Colors

        public double ScrollBarHorizontalHeight
        {
            get => (double)GetValue(ScrollBarHorizontalHeightProperty);
            set
            {
                SetValue(ScrollBarHorizontalHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ScrollBarHorizontalHeight));
            }
        }

        public Thickness ThumbBorderThickness
        {
            get => (Thickness)GetValue(ThumbBorderThicknessProperty);
            set
            {
                SetValue(ThumbBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ThumbBorderThickness));
            }
        }

        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set
            {
                SetValue(ThumbCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ThumbCornerRadius));
            }
        }

        public Thickness ThumbHorizontalMargin
        {
            get => (Thickness)GetValue(ThumbHorizontalMarginProperty);
            set
            {
                SetValue(ThumbHorizontalMarginProperty, value);
                OnPropertyChanged(nameof(ThumbHorizontalMargin));
            }
        }

        public Thickness ThumbVerticalMargin
        {
            get => (Thickness)GetValue(ThumbVerticalMarginProperty);
            set
            {
                SetValue(ThumbVerticalMarginProperty, value);
                OnPropertyChanged(nameof(ThumbVerticalMargin));
            }
        }

        public double ScrollBarVerticalWidth
        {
            get => (double)GetValue(ScrollBarVerticalWidthProperty);
            set
            {
                SetValue(ScrollBarVerticalWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ScrollBarVerticalWidth));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ExtScrollViewer static class constructor. </summary>
        static ExtScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtScrollViewer),
                new FrameworkPropertyMetadata(typeof(ExtScrollViewer)));
        }

        #endregion CLASS METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler event. </summary>
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
