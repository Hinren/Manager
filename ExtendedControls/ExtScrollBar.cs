using ExtendedControls.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ExtendedControls
{
    public class ExtScrollBar : ScrollBar, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbBackground),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ThumbBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ThumbBackgroundDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundDraggingBrush),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ThumbBorderDraggingBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderDraggingBrush),
            typeof(Brush),
            typeof(ExtScrollBar),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        #endregion Appearance Colors Properties

        #region Thumb Properties

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(ExtScrollBar),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ExtScrollBar),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        #endregion Thumb Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtScrollBar),
            new PropertyMetadata(new CornerRadius(0)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set
            {
                SetValue(ThumbBackgroundProperty, value);
                OnPropertyChanged(nameof(ThumbBackground));
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

        #region Thumb

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
        /// <summary> ExtScrollBar static class constructor. </summary>
        static ExtScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtScrollBar),
                new FrameworkPropertyMetadata(typeof(ExtScrollBar)));
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
