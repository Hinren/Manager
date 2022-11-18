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
    public class ExtComboBoxItem : ComboBoxItem, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty BackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty BorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Black)));

        public static readonly DependencyProperty BackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        public static readonly DependencyProperty BorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(BorderSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        public static readonly DependencyProperty ForegroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(ForegroundSelectedBrush),
            typeof(Brush),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Black)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtComboBoxItem),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

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
        /// <summary> Static ExtComboBoxItem class constructor. </summary>
        static ExtComboBoxItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtComboBoxItem),
                new FrameworkPropertyMetadata(typeof(ExtComboBoxItem)));
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
