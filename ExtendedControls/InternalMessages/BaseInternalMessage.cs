using ExtendedControls.Static;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using ExtendedControls.Events;
using static ExtendedControls.Events.Delegates;

namespace ExtendedControls.InternalMessages
{
    public class BaseInternalMessage<CloseEventArgs> : Page, IInternalMessage, INotifyPropertyChanged
        where CloseEventArgs : InternalMessageCloseEventArgs
    {

        //  CONST

        protected readonly static double ICON_HEIGHT = 32d;
        protected readonly static double ICON_WIDTH = 32d;
        protected readonly static double TITLE_FONT_SIZE = 20d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Colors Properties

        public static readonly DependencyProperty BorderBrushProperty = DependencyProperty.Register(
            nameof(BorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Colors Properties

        #region Appearance Buttons Colors Properties

        public static readonly DependencyProperty ButtonBackgroundBrushProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ButtonForegroundBrushProperty = DependencyProperty.Register(
            nameof(ButtonForegroundBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty ButtonBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ButtonBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderMouseOverBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ButtonForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ButtonForegroundMouseOverBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ButtonBackgroundPressedBrushProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundPressedBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ButtonBorderPressedBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderPressedBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_PRESSED_COLOR)));

        public static readonly DependencyProperty ButtonForegroundPressedBrushProperty = DependencyProperty.Register(
            nameof(ButtonForegroundPressedBrush),
            typeof(Brush),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_PRESSED_COLOR)));

        #endregion Appearance Buttons Colors Properties

        #region Buttons Properties

        public static readonly DependencyProperty ButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(ButtonBorderThickness),
            typeof(Thickness),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new Thickness(0)));

        #endregion Buttons Properties

        #region Icon Properties

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(ICON_HEIGHT));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(PackIconKind.InfoCircle));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new Thickness(0, 0, 8, 0)));

        public static readonly DependencyProperty IconMaxHeightProperty = DependencyProperty.Register(
            nameof(IconMaxHeight),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMaxWidthProperty = DependencyProperty.Register(
            nameof(IconMaxWidth),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(double.NaN));

        public static readonly DependencyProperty IconMinHeightProperty = DependencyProperty.Register(
            nameof(IconMinHeight),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconMinWidthProperty = DependencyProperty.Register(
            nameof(IconMinWidth),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(0d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(ICON_WIDTH));

        #endregion Icon Properties

        #region Title Properties

        public static readonly DependencyProperty TitleFontFamilyProperty = DependencyProperty.Register(
            nameof(TitleFontFamily),
            typeof(FontFamily),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new FontFamily()));

        public static readonly DependencyProperty TitleFontSizeProperty = DependencyProperty.Register(
            nameof(TitleFontSize),
            typeof(double),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(TITLE_FONT_SIZE));

        public static readonly DependencyProperty TitleFontStretchProperty = DependencyProperty.Register(
            nameof(TitleFontStretch),
            typeof(FontStretch),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(FontStretches.Normal));

        public static readonly DependencyProperty TitleFontStyleProperty = DependencyProperty.Register(
            nameof(TitleFontStyle),
            typeof(FontStyle),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(FontStyles.Normal));

        public static readonly DependencyProperty TitleFontWeightProperty = DependencyProperty.Register(
            nameof(TitleFontWeight),
            typeof(FontWeight),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(FontWeights.SemiBold));

        #endregion Title Properties

        public static readonly DependencyProperty BorderThicknessProperty = DependencyProperty.Register(
            nameof(BorderThickness),
            typeof(Thickness),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register(
            nameof(ContentPadding),
            typeof(Thickness),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new Thickness(8)));

        public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register(
            nameof(Padding),
            typeof(Thickness),
            typeof(BaseInternalMessage<CloseEventArgs>),
            new PropertyMetadata(new Thickness(8)));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event InternalMessageClose<CloseEventArgs> OnClose;
        public event InternalMessageHide OnHide;


        //  VARIABLES

        private bool _allowHide = false;
        internal InternalMessagesContainer _parentContainer = null;


        //  GETTERS & SETTERS

        #region Appearance Colors

        public Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set
            {
                SetValue(BorderBrushProperty, value);
                OnPropertyChanged(nameof(BorderBrush));
            }
        }

        #endregion Appearance Colors

        #region Appearance Buttons Colors

        public Brush ButtonBackgroundBrush
        {
            get => (Brush)GetValue(ButtonBackgroundBrushProperty);
            set
            {
                SetValue(ButtonBackgroundBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBackgroundBrush));
            }
        }

        public Brush ButtonBorderBrush
        {
            get => (Brush)GetValue(ButtonBorderBrushProperty);
            set
            {
                SetValue(ButtonBorderBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBorderBrush));
            }
        }

        public Brush ButtonForegroundBrush
        {
            get => (Brush)GetValue(ButtonForegroundBrushProperty);
            set
            {
                SetValue(ButtonForegroundBrushProperty, value);
                OnPropertyChanged(nameof(ButtonForegroundBrush));
            }
        }

        public Brush ButtonBackgroundMouseOverBrush
        {
            get => (Brush)GetValue(ButtonBackgroundMouseOverBrushProperty);
            set
            {
                SetValue(ButtonBackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBackgroundMouseOverBrush));
            }
        }

        public Brush ButtonBorderMouseOverBrush
        {
            get => (Brush)GetValue(ButtonBorderMouseOverBrushProperty);
            set
            {
                SetValue(ButtonBorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBorderMouseOverBrush));
            }
        }

        public Brush ButtonForegroundMouseOverBrush
        {
            get => (Brush)GetValue(ButtonForegroundMouseOverBrushProperty);
            set
            {
                SetValue(ButtonForegroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ButtonForegroundMouseOverBrush));
            }
        }

        public Brush ButtonBackgroundPressedBrush
        {
            get => (Brush)GetValue(ButtonBackgroundPressedBrushProperty);
            set
            {
                SetValue(ButtonBackgroundPressedBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBackgroundPressedBrush));
            }
        }

        public Brush ButtonBorderPressedBrush
        {
            get => (Brush)GetValue(ButtonBorderPressedBrushProperty);
            set
            {
                SetValue(ButtonBorderPressedBrushProperty, value);
                OnPropertyChanged(nameof(ButtonBorderPressedBrush));
            }
        }

        public Brush ButtonForegroundPressedBrush
        {
            get => (Brush)GetValue(ButtonForegroundPressedBrushProperty);
            set
            {
                SetValue(ButtonForegroundPressedBrushProperty, value);
                OnPropertyChanged(nameof(ButtonForegroundPressedBrush));
            }
        }

        #endregion Appearance Buttons Colors

        #region Buttons

        public Thickness ButtonBorderThickness
        {
            get => (Thickness)GetValue(ButtonBorderThicknessProperty);
            set
            {
                SetValue(ButtonBorderThicknessProperty, value);
                OnPropertyChanged(nameof(ButtonBorderThickness));
            }
        }

        #endregion Buttons

        #region Icon

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set
            {
                SetValue(IconHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconHeight));
            }
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set
            {
                SetValue(IconKindProperty, value);
                OnPropertyChanged(nameof(IconKindProperty));
            }
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set
            {
                SetValue(IconMarginProperty, value);
                OnPropertyChanged(nameof(IconMargin));
            }
        }

        public double IconMaxHeight
        {
            get => (double)GetValue(IconMaxHeightProperty);
            set
            {
                SetValue(IconMaxHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxHeight));
            }
        }

        public double IconMaxWidth
        {
            get => (double)GetValue(IconMaxWidthProperty);
            set
            {
                SetValue(IconMaxWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMaxWidth));
            }
        }

        public double IconMinHeight
        {
            get => (double)GetValue(IconMinHeightProperty);
            set
            {
                SetValue(IconMinHeightProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinHeight));
            }
        }

        public double IconMinWidth
        {
            get => (double)GetValue(IconMinWidthProperty);
            set
            {
                SetValue(IconMinWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconMinWidth));
            }
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set
            {
                SetValue(IconWidthProperty, Math.Max(0, value));
                OnPropertyChanged(nameof(IconWidth));
            }
        }

        #endregion Icon

        #region Title

        public FontFamily TitleFontFamily
        {
            get => (FontFamily)GetValue(TitleFontFamilyProperty);
            set
            {
                SetValue(TitleFontFamilyProperty, value);
                OnPropertyChanged(nameof(TitleFontFamily));
            }
        }

        public double TitleFontSize
        {
            get => (double)GetValue(TitleFontSizeProperty);
            set
            {
                SetValue(TitleFontSizeProperty, value);
                OnPropertyChanged(nameof(TitleFontSize));
            }
        }

        public FontStretch TitleFontStretch
        {
            get => (FontStretch)GetValue(TitleFontStretchProperty);
            set
            {
                SetValue(TitleFontStretchProperty, value);
                OnPropertyChanged(nameof(TitleFontStretch));
            }
        }

        public FontStyle TitleFontStyle
        {
            get => (FontStyle)GetValue(TitleFontStyleProperty);
            set
            {
                SetValue(TitleFontStyleProperty, value);
                OnPropertyChanged(nameof(TitleFontStyle));
            }
        }

        public FontWeight TitleFontWeight
        {
            get => (FontWeight)GetValue(TitleFontWeightProperty);
            set
            {
                SetValue(TitleFontWeightProperty, value);
                OnPropertyChanged(nameof(TitleFontWeight));
            }
        }

        #endregion Title

        public Thickness BorderThickness
        {
            get => (Thickness)GetValue(BorderThicknessProperty);
            set
            {
                SetValue(BorderThicknessProperty, value);
                OnPropertyChanged(nameof(BorderThickness));
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

        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set
            {
                SetValue(ContentPaddingProperty, value);
                OnPropertyChanged(nameof(ContentPadding));
            }
        }

        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set
            {
                SetValue(PaddingProperty, value);
                OnPropertyChanged(nameof(Padding));
            }
        }


        public bool AllowHide
        {
            get => _allowHide;
            set
            {
                _allowHide = value;
                OnPropertyChanged(nameof(AllowHide));

                if (IsLoadingComplete)
                    OnAllowHideUpdate(value);
            }
        }

        public bool IsHidden { get; private set; }

        public bool IsLoadingComplete { get; protected set; } = false;

        public InternalMessageResult Result { get; internal set; } = InternalMessageResult.None;


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseInternalMessage class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessages container. </param>
        public BaseInternalMessage(InternalMessagesContainer parentContainer) : base()
        {
            _parentContainer = parentContainer;
            Loaded += MessageLoaded;
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Close InternalMessage. </summary>
        public void Close()
        {
            InvokeClose(CreateCloseEventArgs());
            _parentContainer.CloseMessage(this);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create close method event arguments. </summary>
        /// <returns> Close method event arguments. </returns>
        protected virtual CloseEventArgs CreateCloseEventArgs()
        {
            return (CloseEventArgs)new InternalMessageCloseEventArgs(Result);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke close event. </summary>
        /// <param name="e"> Event arguments based on InternalMessageCloseEventArgs. </param>
        protected void InvokeClose(CloseEventArgs e)
        {
            OnClose?.Invoke(this, e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Hide InternalMessage if it is allowed. </summary>
        public void Hide()
        {
            if (AllowHide)
            {
                IsHidden = true;
                InvokeHide(new InternalMessageHideEventArgs(true));
                _parentContainer.HideMessage(this);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create hide method event arguments. </summary>
        /// <returns> Hide method event arguments. </returns>
        protected virtual InternalMessageHideEventArgs CreateHideEventArgs()
        {
            return new InternalMessageHideEventArgs(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke hide event. </summary>
        /// <param name="e"> Internal Message Hide Event Arguments. </param>
        protected void InvokeHide(InternalMessageHideEventArgs e)
        {
            OnHide?.Invoke(this, e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Show hidden InternalMessage. </summary>
        public void Show()
        {
            if (IsHidden)
            {
                IsHidden = false;
                _parentContainer.ShowMessage(this);
            }
        }

        #endregion INTERACTION METHODS

        #region MESSAGE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after loading InternalMessage into parent container. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        private void MessageLoaded(object sender, RoutedEventArgs e)
        {
            if (_parentContainer == null)
                throw new NullReferenceException($"Parent InternalMessage container has not been set.");

            IsLoadingComplete = true;
        }

        #endregion MESSAGE METHODS

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

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Click method on ExtButton. </summary>
        /// <param name="extButton"> ExtButton. </param>
        /// <param name="eventHandler"> Click method. </param>
        protected void ApplyExtButtonClickMethod(ExtButton extButton, RoutedEventHandler eventHandler)
        {
            if (extButton != null)
                extButton.Click += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ExtButton from ContentTemplate. </summary>
        /// <param name="buttonName"> ExtButton name. </param>
        /// <returns> ExtButton or null. </returns>
        protected ExtButton GetExtButton(string buttonName)
        {
            return this.Template.FindName(buttonName, this) as ExtButton;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected virtual void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetExtButton("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion TEMPLATE METHODS

    }
}
