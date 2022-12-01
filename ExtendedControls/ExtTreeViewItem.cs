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
    public class ExtTreeViewItem : TreeViewItem, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Properties

        public static readonly DependencyProperty BackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty BorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty BackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty BorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(BorderSelectedBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty ForegroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(ForegroundSelectedBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty BackgroundSelectedInactiveBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedInactiveBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        public static readonly DependencyProperty BorderSelectedInactiveBrushProperty = DependencyProperty.Register(
            nameof(BorderSelectedInactiveBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        public static readonly DependencyProperty ForegroundSelectedInactiveBrushProperty = DependencyProperty.Register(
            nameof(ForegroundSelectedInactiveBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_SELECTED_COLOR)));

        #endregion Appearance Properties

        #region Expander Icon Properties

        public static readonly DependencyProperty ExpanderIconColorBrushProperty = DependencyProperty.Register(
            nameof(ExpanderIconColorBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ExpanderIconColorMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ExpanderIconColorMouseOverBrush),
            typeof(Brush),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ExpanderIconMarginProperty = DependencyProperty.Register(
            nameof(ExpanderIconMargin),
            typeof(Thickness),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(new Thickness(0, 0, 4, 0)));

        #endregion Expander Icon Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtTreeViewItem),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  GETTERS & SETTERS

        #region Appearance

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

        public Brush BackgroundSelectedInactiveBrush
        {
            get => (Brush)GetValue(BackgroundSelectedInactiveBrushProperty);
            set
            {
                SetValue(BackgroundSelectedInactiveBrushProperty, value);
                OnPropertyChanged(nameof(BackgroundSelectedInactiveBrush));
            }
        }

        public Brush BorderSelectedInactiveBrush
        {
            get => (Brush)GetValue(BorderSelectedInactiveBrushProperty);
            set
            {
                SetValue(BorderSelectedInactiveBrushProperty, value);
                OnPropertyChanged(nameof(BorderSelectedInactiveBrush));
            }
        }

        public Brush ForegroundSelectedInactiveBrush
        {
            get => (Brush)GetValue(ForegroundSelectedInactiveBrushProperty);
            set
            {
                SetValue(ForegroundSelectedInactiveBrushProperty, value);
                OnPropertyChanged(nameof(ForegroundSelectedInactiveBrush));
            }
        }

        #endregion Appearance

        #region Expander Icon

        public Brush ExpanderIconColorBrush
        {
            get => (Brush)GetValue(ExpanderIconColorBrushProperty);
            set
            {
                SetValue(ExpanderIconColorBrushProperty, value);
                OnPropertyChanged(nameof(ExpanderIconColorBrush));
            }
        }

        public Brush ExpanderIconColorMouseOverBrush
        {
            get => (Brush)GetValue(ExpanderIconColorMouseOverBrushProperty);
            set
            {
                SetValue(ExpanderIconColorMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ExpanderIconColorMouseOverBrush));
            }
        }

        public Thickness ExpanderIconMargin
        {
            get => (Thickness)GetValue(ExpanderIconMarginProperty);
            set
            {
                SetValue(ExpanderIconMarginProperty, value);
                OnPropertyChanged(nameof(ExpanderIconMargin));
            }
        }

        #endregion Expander Icon

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
        /// <summary> ExtTreeViewItem static class constructor. </summary>
        static ExtTreeViewItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtTreeViewItem),
                new FrameworkPropertyMetadata(typeof(ExtTreeViewItem)));
        }

        #endregion CLASS METHODS

        #region ITEMS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates and returns new ExtTreeViewItem container. </summary>
        /// <returns> A new ExtTreeViewItem control. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ExtTreeViewItem();
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
