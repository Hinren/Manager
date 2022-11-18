using ExtendedControls.Static;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExtendedControls
{
    public class ExtCheckBox : CheckBox, INotifyPropertyChanged
    {

        //  CONST

        protected readonly static double CHECK_MARK_HEIGHT = 28d;
        protected readonly static double CHECK_MARK_WIDTH = 28d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty CheckMarkBrushProperty = DependencyProperty.Register(
            nameof(CheckMarkBrush),
            typeof(Brush),
            typeof(ExtCheckBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty CheckMarkMouseOverBrushProperty = DependencyProperty.Register(
            nameof(CheckMarkMouseOverBrush),
            typeof(Brush),
            typeof(ExtCheckBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty CheckMarkPressedBrushProperty = DependencyProperty.Register(
            nameof(CheckMarkPressedBrush),
            typeof(Brush),
            typeof(ExtCheckBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CheckBoxStyleProperty = DependencyProperty.Register(
            nameof(CheckBoxStyle),
            typeof(CheckBoxStyle),
            typeof(ExtCheckBox),
            new PropertyMetadata(CheckBoxStyle.MIXED));

        public static readonly DependencyProperty CheckMarkHeightProperty = DependencyProperty.Register(
            nameof(CheckMarkHeight),
            typeof(double),
            typeof(ExtCheckBox),
            new PropertyMetadata(CHECK_MARK_HEIGHT));

        public static readonly DependencyProperty CheckMarkWidthProperty = DependencyProperty.Register(
            nameof(CheckMarkWidth),
            typeof(double),
            typeof(ExtCheckBox),
            new PropertyMetadata(CHECK_MARK_WIDTH));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush CheckMarkBrush
        {
            get => (Brush)GetValue(CheckMarkBrushProperty);
            set
            {
                SetValue(CheckMarkBrushProperty, value);
                OnPropertyChanged(nameof(CheckMarkBrush));
            }
        }

        public Brush CheckMarkMouseOverBrush
        {
            get => (Brush)GetValue(CheckMarkMouseOverBrushProperty);
            set
            {
                SetValue(CheckMarkMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(CheckMarkMouseOverBrush));
            }
        }

        public Brush CheckMarkPressedBrush
        {
            get => (Brush)GetValue(CheckMarkPressedBrushProperty);
            set
            {
                SetValue(CheckMarkPressedBrushProperty, value);
                OnPropertyChanged(nameof(CheckMarkPressedBrush));
            }
        }

        #endregion Appearance Colors

        public CheckBoxStyle CheckBoxStyle
        {
            get => (CheckBoxStyle)GetValue(CheckBoxStyleProperty);
            set
            {
                SetValue(CheckBoxStyleProperty, value);
                OnPropertyChanged(nameof(CheckBoxStyle));
            }
        }

        public double CheckMarkHeight
        {
            get => (double)GetValue(CheckMarkHeightProperty);
            set
            {
                SetValue(CheckMarkHeightProperty, value);
                OnPropertyChanged(nameof(CheckMarkHeight));
            }
        }

        public double CheckMarkWidth
        {
            get => (double)GetValue(CheckMarkWidthProperty);
            set
            {
                SetValue(CheckMarkWidthProperty, value);
                OnPropertyChanged(nameof(CheckMarkWidth));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ExtCheckBox class constructor. </summary>
        static ExtCheckBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtCheckBox),
                new FrameworkPropertyMetadata(typeof(ExtCheckBox)));
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
