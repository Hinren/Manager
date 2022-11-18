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
    public class ExtComboBox : ComboBox, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty DropDownBackgroundBrushProperty = DependencyProperty.Register(
            nameof(DropDownBackgroundBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty DropDownBorderBrushProperty = DependencyProperty.Register(
            nameof(DropDownBorderBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty DropDownForegroundBrushProperty = DependencyProperty.Register(
            nameof(DropDownForegroundBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownIconBrushProperty = DependencyProperty.Register(
            nameof(DropDownIconBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownIconMouseOverBrushProperty = DependencyProperty.Register(
            nameof(DropDownIconMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty DropDownIconSelectedBrushProperty = DependencyProperty.Register(
            nameof(DropDownIconSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty BackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty BorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty BackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty BorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(BorderSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ForegroundSelectedBrushProperty = DependencyProperty.Register(
           nameof(ForegroundSelectedBrush),
           typeof(Brush),
           typeof(ExtComboBox),
           new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtComboBox),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty DropDownCornerRadiusProperty = DependencyProperty.Register(
            nameof(DropDownCornerRadius),
            typeof(CornerRadius),
            typeof(ExtComboBox),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty DropDownBorderThicknessProperty = DependencyProperty.Register(
            nameof(DropDownBorderThickness),
            typeof(Thickness),
            typeof(ExtComboBox),
            new PropertyMetadata(new Thickness(1)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private CornerRadius _buttonCornerRadius = new CornerRadius(0, 4, 4, 0);


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush DropDownBackgroundBrush
        {
            get => (Brush)GetValue(DropDownBackgroundBrushProperty);
            set
            {
                SetValue(DropDownBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(DropDownBackgroundBrush));
            }
        }

        public Brush DropDownBorderBrush
        {
            get => (Brush)GetValue(DropDownBorderBrushProperty);
            set
            {
                SetValue(DropDownBorderBrushProperty, value);
                OnPropertyChanged(nameof(DropDownBorderBrush));
            }
        }

        public Brush DropDownForegroundBrush
        {
            get => (Brush)GetValue(DropDownForegroundBrushProperty);
            set
            {
                SetValue(DropDownForegroundBrushProperty, value);
                OnPropertyChanged(nameof(DropDownForegroundBrush));
            }
        }

        public Brush DropDownIconBrush
        {
            get => (Brush)GetValue(DropDownIconBrushProperty);
            set
            {
                SetValue(DropDownIconBrushProperty, value);
                OnPropertyChanged(nameof(DropDownIconBrush));
            }
        }

        public Brush DropDownIconMouseOverBrush
        {
            get => (Brush)GetValue(DropDownIconMouseOverBrushProperty);
            set
            {
                SetValue(DropDownIconMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(DropDownIconMouseOverBrush));
            }
        }

        public Brush DropDownIconSelectedBrush
        {
            get => (Brush)GetValue(DropDownIconSelectedBrushProperty);
            set
            {
                SetValue(DropDownIconSelectedBrushProperty, value);
                OnPropertyChanged(nameof(DropDownIconSelectedBrush));
            }
        }

        public Brush BackgroundMouseOverBrush
        {
            get => (Brush)GetValue(BackgroundMouseOverBrushProperty);
            set
            {
                SetValue(BackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(BackgroundMouseOverBrush));
            }
        }

        public Brush BorderMouseOverBrush
        {
            get => (Brush)GetValue(BorderMouseOverBrushProperty);
            set
            {
                SetValue(BorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(BorderMouseOverBrush));
            }
        }

        public Brush ForegroundMouseOverBrush
        {
            get => (Brush)GetValue(ForegroundMouseOverBrushProperty);
            set
            {
                SetValue(ForegroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ForegroundMouseOverBrush));
            }
        }

        public Brush BackgroundSelectedBrush
        {
            get => (Brush)GetValue(BackgroundSelectedBrushProperty);
            set
            {
                SetValue(BackgroundSelectedBrushProperty, value);
                OnPropertyChanged(nameof(BackgroundSelectedBrush));
            }
        }

        public Brush BorderSelectedBrush
        {
            get => (Brush)GetValue(BorderSelectedBrushProperty);
            set
            {
                SetValue(BorderSelectedBrushProperty, value);
                OnPropertyChanged(nameof(BorderSelectedBrush));
            }
        }

        public Brush ForegroundSelectedBrush
        {
            get => (Brush)GetValue(ForegroundSelectedBrushProperty);
            set
            {
                SetValue(ForegroundSelectedBrushProperty, value);
                OnPropertyChanged(nameof(ForegroundSelectedBrush));
            }
        }

        #endregion Appearance Colors

        public CornerRadius ButtonCornerRadius
        {
            get => _buttonCornerRadius;
            set
            {
                _buttonCornerRadius = value;
                OnPropertyChanged(nameof(ButtonCornerRadius));
            }
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));

                ButtonCornerRadius = new CornerRadius(0, value.TopRight, value.BottomRight, 0);
            }
        }

        public CornerRadius DropDownCornerRadius
        {
            get => (CornerRadius)GetValue(DropDownCornerRadiusProperty);
            set
            {
                SetValue(DropDownCornerRadiusProperty, value);
                OnPropertyChanged(nameof(DropDownCornerRadius));
            }
        }

        public Thickness DropDownBorderThickness
        {
            get => (Thickness)GetValue(DropDownBorderThicknessProperty);
            set
            {
                SetValue(DropDownBorderThicknessProperty, value);
                OnPropertyChanged(nameof(DropDownBorderThickness));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ExtComboBox class constructor. </summary>
        static ExtComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtComboBox),
                new FrameworkPropertyMetadata(typeof(ExtComboBox)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ExtComboBoxItem container. </summary>
        /// <returns> A new ExtComboBoxItem control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ExtComboBoxItem();
        }

        #endregion ITEMS METHODS

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
