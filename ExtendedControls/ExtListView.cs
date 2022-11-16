using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExtendedControls
{
    public class ExtListView : ListView, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty ColumnHeaderBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderForegroundBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBackgroundPressedBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundPressedBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ColumnHeaderBorderPressedBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderPressedBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ColumnHeaderForegroundPressedBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundPressedBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ColumnHeaderEmptyBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderEmptyBackgroundBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_COLOR)));

        public static readonly DependencyProperty ColumnHeaderEmptyBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderEmptyBorderBrush),
            typeof(Brush),
            typeof(ExtListView),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty ColumnHeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderThickness),
            typeof(Thickness),
            typeof(ExtListView),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnHeaderCornerRadiusProperty = DependencyProperty.Register(
            nameof(ColumnHeaderCornerRadius),
            typeof(CornerRadius),
            typeof(ExtListView),
            new PropertyMetadata(new CornerRadius(0)));

        public static readonly DependencyProperty ColumnHeaderGripperWidthProperty = DependencyProperty.Register(
            nameof(ColumnHeaderGripperWidth),
            typeof(double),
            typeof(ExtListView),
            new PropertyMetadata(StaticResources.DEFAULT_LISTVIEW_COLUMN_HEADER_GRIPPER_WIDTH));

        public static readonly DependencyProperty ColumnHeaderMarginProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMargin),
            typeof(Thickness),
            typeof(ExtListView),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ColumnHeaderPaddingProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPadding),
            typeof(Thickness),
            typeof(ExtListView),
            new PropertyMetadata(new Thickness(8, 2, 8, 2)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtListView),
            new PropertyMetadata(new CornerRadius(0)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush ColumnHeaderBackgroundBrush
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundBrushProperty);
            set
            {
                SetValue(ColumnHeaderBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBackgroundBrush));
            }
        }

        public Brush ColumnHeaderBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderBrush));
            }
        }

        public Brush ColumnHeaderForegroundBrush
        {
            get => (Brush)GetValue(ColumnHeaderForegroundBrushProperty);
            set
            {
                SetValue(ColumnHeaderForegroundBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderForegroundBrush));
            }
        }

        public Brush ColumnHeaderBackgroundMouseOverBrush
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundMouseOverBrushProperty);
            set
            {
                SetValue(ColumnHeaderBackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBackgroundMouseOverBrush));
            }
        }

        public Brush ColumnHeaderBorderMouseOverBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderMouseOverBrushProperty);
            set
            {
                SetValue(ColumnHeaderBorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderMouseOverBrush));
            }
        }

        public Brush ColumnHeaderForegroundMouseOverBrush
        {
            get => (Brush)GetValue(ColumnHeaderForegroundMouseOverBrushProperty);
            set
            {
                SetValue(ColumnHeaderForegroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderForegroundMouseOverBrush));
            }
        }

        public Brush ColumnHeaderBackgroundPressedBrush
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundPressedBrushProperty);
            set
            {
                SetValue(ColumnHeaderBackgroundPressedBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBackgroundPressedBrush));
            }
        }

        public Brush ColumnHeaderBorderPressedBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderPressedBrushProperty);
            set
            {
                SetValue(ColumnHeaderBorderPressedBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderPressedBrush));
            }
        }

        public Brush ColumnHeaderForegroundPressedBrush
        {
            get => (Brush)GetValue(ColumnHeaderForegroundPressedBrushProperty);
            set
            {
                SetValue(ColumnHeaderForegroundPressedBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderForegroundPressedBrush));
            }
        }

        public Brush ColumnHeaderEmptyBackgroundBrush
        {
            get => (Brush)GetValue(ColumnHeaderEmptyBackgroundBrushProperty);
            set
            {
                SetValue(ColumnHeaderEmptyBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderEmptyBackgroundBrush));
            }
        }

        public Brush ColumnHeaderEmptyBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderEmptyBorderBrushProperty);
            set
            {
                SetValue(ColumnHeaderEmptyBorderBrushProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderEmptyBorderBrush));
            }
        }

        #endregion Appearance Colors

        public Thickness ColumnHeaderBorderThickness
        {
            get => (Thickness)GetValue(ColumnHeaderBorderThicknessProperty);
            set
            {
                SetValue(ColumnHeaderBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderBorderThickness));
            }
        }

        public CornerRadius ColumnHeaderCornerRadius
        {
            get => (CornerRadius)GetValue(ColumnHeaderCornerRadiusProperty);
            set
            {
                SetValue(ColumnHeaderCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderCornerRadius));
            }
        }

        public double ColumnHeaderGripperWidth
        {
            get => (double)GetValue(ColumnHeaderGripperWidthProperty);
            set
            {
                SetValue(ColumnHeaderGripperWidthProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderGripperWidth));
            }
        }

        public Thickness ColumnHeaderMargin
        {
            get => (Thickness)GetValue(ColumnHeaderMarginProperty);
            set
            {
                SetValue(ColumnHeaderMarginProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderMargin));
            }
        }

        public Thickness ColumnHeaderPadding
        {
            get => (Thickness)GetValue(ColumnHeaderPaddingProperty);
            set
            {
                SetValue(ColumnHeaderPaddingProperty, value);
                OnPropertyChanged(nameof(ColumnHeaderPadding));
            }
        }

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
        /// <summary> ExtListView static class constructor. </summary>
        static ExtListView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtListView),
                new FrameworkPropertyMetadata(typeof(ExtListView)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ExtListViewItem container. </summary>
        /// <returns> A new ExtListViewItem control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ExtListViewItem();
        }

        #endregion ITEMS METHODS

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
