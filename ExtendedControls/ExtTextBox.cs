using ExtendedControls.Events;
using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static ExtendedControls.Events.Delegates;

namespace ExtendedControls
{
    public class ExtTextBox : TextBox, INotifyPropertyChanged
    {

        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty BackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty BorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(BorderMouseOverBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOverBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty BackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty BorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(BorderSelectedBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ForegroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(ForegroundSelectedBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty BackgroundSelectedTextBrushProperty = DependencyProperty.Register(
            nameof(BackgroundSelectedTextBrush),
            typeof(Brush),
            typeof(ExtTextBox),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        #endregion Appearance Colors Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExtTextBox),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event TextModificationFinishedEventHandler TextModificationFinished;
        public event TextModifiedEventHandler TextModified;


        //  VARIABLES

        private bool focused = false;
        private bool textChanged = false;


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

        public Brush BackgroundSelectedTextBrush
        {
            get => (Brush)GetValue(BackgroundSelectedTextBrushProperty);
            set
            {
                SetValue(BackgroundSelectedTextBrushProperty, value);
                OnPropertyChanged(nameof(BackgroundSelectedTextBrush));
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
        /// <summary> ExtTextBox class constructor. </summary>
        public ExtTextBox()
        {
            //  Initialize events.
            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static ExtTextBox class constructor. </summary>
        static ExtTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExtTextBox),
                new FrameworkPropertyMetadata(typeof(ExtTextBox)));
        }

        #endregion CLASS METHODS

        #region COMPONENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading control. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //
        }

        #endregion COMPONENT METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when component got focused by user. </summary>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            focused = true;
            base.OnGotFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing any key when component is focused. </summary>
        /// <param name="e"> Key Event Arguments. </param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter && focused)
            {
                textChanged = false;

                TextModificationFinished?.Invoke(
                    this, new Events.TextModificationFinishedEventArgs(Text, true));
            }

            base.OnKeyDown(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked when component lost focus from user. </summary>
        /// <param name="e"> Routed Event Arguments. </param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            focused = false;

            if (textChanged)
            {
                textChanged = false;

                TextModificationFinished?.Invoke(
                    this, new Events.TextModificationFinishedEventArgs(Text, true));
            }

            base.OnLostFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after text change. </summary>
        /// <param name="e"> Text Changed Event Arguments. </param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (focused)
            {
                textChanged = true;
                TextModified?.Invoke(this, new TextModifiedEventArgs(Text, true));
            }
            else
            {
                textChanged = false;
                TextModified?.Invoke(this, new TextModifiedEventArgs(Text, false));

                TextModificationFinished?.Invoke(
                    this, new TextModificationFinishedEventArgs(Text, false));
            }

            base.OnTextChanged(e);
        }

        #endregion INTERACTION METHODS

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
