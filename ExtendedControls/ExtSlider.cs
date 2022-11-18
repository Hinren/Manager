using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ExtendedControls
{
    public class ExtSlider : Slider, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double TRACKBAR_HEIGHT = 6d;
        protected readonly static double TRACKBAR_WIDTH = 6d;
        protected readonly static double THUMB_HEIGHT = 32d;
        protected readonly static double THUMB_WIDTH = 32d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty SelectionRangeBrushProperty = DependencyProperty.Register(
            nameof(SelectionRangeBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty TicksBrushProperty = DependencyProperty.Register(
            nameof(TicksBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        #region Trackbar Properties

        public static readonly DependencyProperty TrackBarBackgroundBrushProperty = DependencyProperty.Register(
            nameof(TrackBarBackgroundBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TrackBarBorderBrushProperty = DependencyProperty.Register(
            nameof(TrackBarBorderBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty TrackBarBorderThicknessProperty = DependencyProperty.Register(
            nameof(TrackBarBorderThickness),
            typeof(Thickness),
            typeof(ExtSlider),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty TrackBarCornerRadiusProperty = DependencyProperty.Register(
            nameof(TrackBarCornerRadius),
            typeof(CornerRadius),
            typeof(ExtSlider),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty TrackBarHeightProperty = DependencyProperty.Register(
            nameof(TrackBarHeight),
            typeof(double),
            typeof(ExtSlider),
            new PropertyMetadata(TRACKBAR_HEIGHT));

        public static readonly DependencyProperty TrackBarWidthProperty = DependencyProperty.Register(
            nameof(TrackBarWidth),
            typeof(double),
            typeof(ExtSlider),
            new PropertyMetadata(TRACKBAR_WIDTH));

        #endregion Trackbar Properties

        #region Thumb Properties

        public static readonly DependencyProperty ThumbBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ThumbBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundDraggingBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ThumbBorderDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderDraggingBrush),
            typeof(Brush),
            typeof(ExtSlider),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(ExtSlider),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ExtSlider),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ThumbHeightProperty = DependencyProperty.Register(
            nameof(ThumbHeight),
            typeof(double),
            typeof(ExtSlider),
            new PropertyMetadata(THUMB_HEIGHT));

        public static readonly DependencyProperty ThumbWidthProperty = DependencyProperty.Register(
            nameof(ThumbWidth),
            typeof(double),
            typeof(ExtSlider),
            new PropertyMetadata(THUMB_WIDTH));

        #endregion Thumb Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtSlider),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush SelectionRangeBrush
        {
            get => (Brush)GetValue(SelectionRangeBrushProperty);
            set
            {
                SetValue(SelectionRangeBrushProperty, value);
                OnPropertyChanged(nameof(SelectionRangeBrush));
            }
        }

        public Brush TicksBrush
        {
            get => (Brush)GetValue(TicksBrushProperty);
            set
            {
                SetValue(TicksBrushProperty, value);
                OnPropertyChanged(nameof(TicksBrush));
            }
        }

        #endregion Appearance Colors

        #region Trackbar

        public Brush TrackBarBackgroundBrush
        {
            get => (Brush)GetValue(TrackBarBackgroundBrushProperty);
            set
            {
                SetValue(TrackBarBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(TrackBarBackgroundBrush));
            }
        }

        public Brush TrackBarBorderBrush
        {
            get => (Brush)GetValue(TrackBarBorderBrushProperty);
            set
            {
                SetValue(TrackBarBorderBrushProperty, value);
                OnPropertyChanged(nameof(TrackBarBorderBrush));
            }
        }

        public Thickness TrackBarBorderThickness
        {
            get => (Thickness)GetValue(TrackBarBorderThicknessProperty);
            set
            {
                SetValue(TrackBarBorderThicknessProperty, value);
                OnPropertyChanged(nameof(TrackBarBorderThickness));
            }
        }

        public CornerRadius TrackBarCornerRadius
        {
            get => (CornerRadius)GetValue(TrackBarCornerRadiusProperty);
            set
            {
                SetValue(TrackBarCornerRadiusProperty, value);
                OnPropertyChanged(nameof(TrackBarCornerRadius));
            }
        }

        public double TrackBarHeight
        {
            get => (double)GetValue(TrackBarHeightProperty);
            set
            {
                SetValue(TrackBarHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(TrackBarHeight));
            }
        }

        public double TrackBarWidth
        {
            get => (double)GetValue(TrackBarWidthProperty);
            set
            {
                SetValue(TrackBarWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(TrackBarWidth));
            }
        }

        #endregion Trackbar

        #region Thumb

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

        public double ThumbHeight
        {
            get => (double)GetValue(ThumbHeightProperty);
            set
            {
                SetValue(ThumbHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ThumbHeight));
            }
        }

        public double ThumbWidth
        {
            get => (double)GetValue(ThumbWidthProperty);
            set
            {
                SetValue(ThumbWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(ThumbWidth));
            }
        }

        #endregion Thumb

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
        /// <summary> Static ExtSlider class constructor. </summary>
        static ExtSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtSlider),
                new FrameworkPropertyMetadata(typeof(ExtSlider)));
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
