using ExtendedControls.Data;
using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static ExtendedControls.Events.Delegates;

namespace ExtendedControls
{
    public class ColorsPalette : Control, INotifyPropertyChanged
    {

        //  CONST

        public static readonly int COLORS_HISTORY_COUNT = 5;


        //  DEPENDENCY PROPERTIES

        #region Item Appearance Properties

        public static readonly DependencyProperty ItemBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ItemBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ItemBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(ItemBorderMouseOverBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty ItemBackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(ItemBackgroundSelectedBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty ItemBorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(ItemBorderSelectedBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty ItemBackgroundSelectedInactiveBrushProperty = DependencyProperty.Register(
            nameof(ItemBackgroundSelectedInactiveBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        public static readonly DependencyProperty ItemBorderSelectedInactiveBrushProperty = DependencyProperty.Register(
            nameof(ItemBorderSelectedInactiveBrush),
            typeof(Brush),
            typeof(ColorsPalette),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_INACTIVE_COLOR)));

        #endregion Item Appearance Properties

        #region Item Properties

        public static readonly DependencyProperty ItemCornerRadiusProperty = DependencyProperty.Register(
            nameof(ItemCornerRadius),
            typeof(CornerRadius),
            typeof(ColorsPalette),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register(
            nameof(ItemHeight),
            typeof(double),
            typeof(ColorsPalette),
            new PropertyMetadata(48d));

        public static readonly DependencyProperty ItemKeepSelectedProperty = DependencyProperty.Register(
            nameof(ItemKeepSelected),
            typeof(bool),
            typeof(ColorsPalette),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ItemMarginProperty = DependencyProperty.Register(
            nameof(ItemMargin),
            typeof(Thickness),
            typeof(ColorsPalette),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ItemPaddingProperty = DependencyProperty.Register(
            nameof(ItemPadding),
            typeof(Thickness),
            typeof(ColorsPalette),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register(
            nameof(ItemWidth),
            typeof(double),
            typeof(ColorsPalette),
            new PropertyMetadata(48d));

        #endregion Item Properties

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorsPalette),
            new PropertyMetadata(StaticResources.DEFAULT_CORNER_RADIUS));

        public static readonly DependencyProperty ColorsProperty = DependencyProperty.Register(
            nameof(Colors),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(ColorsPalette),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty UsedColorsProperty = DependencyProperty.Register(
            nameof(UsedColors),
            typeof(ObservableCollection<ColorPaletteItem>),
            typeof(ColorsPalette),
            new PropertyMetadata(new ObservableCollection<ColorPaletteItem>()));

        public static readonly DependencyProperty UsedColorsTitleProperty = DependencyProperty.Register(
            nameof(UsedColorsTitle),
            typeof(string),
            typeof(ColorsPalette),
            new PropertyMetadata("Recently used colors:"));

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            nameof(Title),
            typeof(string),
            typeof(ColorsPalette),
            new PropertyMetadata("Colors palette:"));


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event ColorsPalleteSelectionChanged ColorSelectionChanged;


        //  VARIABLES

        private ColorPaletteItem _selectedColorItem;


        //  GETTERS & SETTERS

        #region Item Appearance

        public Brush ItemBackgroundMouseOverBrush
        {
            get => (Brush)GetValue(ItemBackgroundMouseOverBrushProperty);
            set
            {
                SetValue(ItemBackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ItemBackgroundMouseOverBrush));
            }
        }

        public Brush ItemBorderMouseOverBrush
        {
            get => (Brush)GetValue(ItemBorderMouseOverBrushProperty);
            set
            {
                SetValue(ItemBorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(ItemBorderMouseOverBrush));
            }
        }

        public Brush ItemBackgroundSelectedBrush
        {
            get => (Brush)GetValue(ItemBackgroundSelectedBrushProperty);
            set
            {
                SetValue(ItemBackgroundSelectedBrushProperty, value);
                OnPropertyChanged(nameof(ItemBackgroundSelectedBrush));
            }
        }

        public Brush ItemBorderSelectedBrush
        {
            get => (Brush)GetValue(ItemBorderSelectedBrushProperty);
            set
            {
                SetValue(ItemBorderSelectedBrushProperty, value);
                OnPropertyChanged(nameof(ItemBorderSelectedBrush));
            }
        }

        public Brush ItemBackgroundSelectedInactiveBrush
        {
            get => (Brush)GetValue(ItemBackgroundSelectedInactiveBrushProperty);
            set
            {
                SetValue(ItemBackgroundSelectedInactiveBrushProperty, value);
                OnPropertyChanged(nameof(ItemBackgroundSelectedInactiveBrush));
            }
        }

        public Brush ItemBorderSelectedInactiveBrush
        {
            get => (Brush)GetValue(ItemBorderSelectedInactiveBrushProperty);
            set
            {
                SetValue(ItemBorderSelectedInactiveBrushProperty, value);
                OnPropertyChanged(nameof(ItemBorderSelectedInactiveBrush));
            }
        }

        #endregion Item Appearance

        #region Item

        public CornerRadius ItemCornerRadius
        {
            get => (CornerRadius)GetValue(ItemCornerRadiusProperty);
            set
            {
                SetValue(ItemCornerRadiusProperty, value);
                OnPropertyChanged(nameof(ItemCornerRadius));
            }
        }

        public double ItemHeight
        {
            get => (double)GetValue(ItemHeightProperty);
            set
            {
                SetValue(ItemHeightProperty, value);
                OnPropertyChanged(nameof(ItemHeight));
            }
        }

        public bool ItemKeepSelected
        {
            get => (bool)GetValue(ItemKeepSelectedProperty);
            set
            {
                SetValue(ItemKeepSelectedProperty, value);
                OnPropertyChanged(nameof(ItemKeepSelected));
            }
        }

        public Thickness ItemMargin
        {
            get => (Thickness)GetValue(ItemMarginProperty);
            set
            {
                SetValue(ItemMarginProperty, value);
                OnPropertyChanged(nameof(ItemMargin));
            }
        }

        public Thickness ItemPadding
        {
            get => (Thickness)GetValue(ItemPaddingProperty);
            set
            {
                SetValue(ItemPaddingProperty, value);
                OnPropertyChanged(nameof(ItemPadding));
            }
        }

        public double ItemWidth
        {
            get => (double)GetValue(ItemWidthProperty);
            set
            {
                SetValue(ItemWidthProperty, value);
                OnPropertyChanged(nameof(ItemWidth));
            }
        }

        #endregion Item

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set
            {
                SetValue(CornerRadiusProperty, value);
                OnPropertyChanged(nameof(CornerRadius));
            }
        }

        public ObservableCollection<ColorPaletteItem> Colors
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(ColorsProperty);
            set
            {
                value.CollectionChanged += OnCollectionChanged<ColorPaletteItem>;
                SetValue(ColorsProperty, value);
                OnPropertyChanged(nameof(Colors));
            }
        }

        public ObservableCollection<ColorPaletteItem> UsedColors
        {
            get => (ObservableCollection<ColorPaletteItem>)GetValue(UsedColorsProperty);
            set
            {
                var items = value?.ToList() ?? new List<ColorPaletteItem>();
                var observableCollection = new ObservableCollection<ColorPaletteItem>(
                    items.GetRange(0, Math.Min(items.Count, COLORS_HISTORY_COUNT)));
                observableCollection.CollectionChanged += OnCollectionChanged<ColorPaletteItem>;
                SetValue(UsedColorsProperty, observableCollection);
                OnPropertyChanged(nameof(UsedColors));
            }
        }

        public string UsedColorsTitle
        {
            get => (string)GetValue(UsedColorsTitleProperty);
            set
            {
                SetValue(UsedColorsTitleProperty, value);
                OnPropertyChanged(nameof(UsedColorsTitle));
            }
        }

        public ColorPaletteItem SelectedColorItem
        {
            get
            {
                if (_selectedColorItem == null)
                    _selectedColorItem = UsedColors.FirstOrDefault();

                return _selectedColorItem;
            }
            set
            {
                _selectedColorItem = value;
                OnPropertyChanged(nameof(SelectedColorItem));
            }
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set
            {
                SetValue(TitleProperty, value);
                OnPropertyChanged(nameof(Title));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorsPalette class constructor. </summary>
        public ColorsPalette()
        {
            Colors = new ObservableCollection<ColorPaletteItem>(StaticColors.Colors);
            UsedColors = new ObservableCollection<ColorPaletteItem>()
            {
                StaticColors.Blue,
                StaticColors.Red,
                StaticColors.GoldYellow,
                StaticColors.Green,
                StaticColors.DarkGray
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static ColorsPalette class constructor. </summary>
        static ColorsPalette()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorsPalette),
                new FrameworkPropertyMetadata(typeof(ColorsPalette)));
        }

        #endregion CLASS METHODS

        #region DATA MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after selecting item in color palette items list view. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        protected void OnColorPaletteItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var listView = (ExtListView)sender;
            var currentHashCode = listView.GetHashCode();
            var historyHashCode = this.GetListView("historyColorsListView").GetHashCode();
            var hashCode = this.GetListView("colorsListView").GetHashCode();
            var selectedItem = listView.SelectedItem;

            if (selectedItem != null)
            {
                var colorPaletteItem = selectedItem as ColorPaletteItem;

                if (colorPaletteItem != null && (currentHashCode == historyHashCode || currentHashCode == hashCode))
                {
                    AddColorToHistory(colorPaletteItem);
                    SelectedColorItem = colorPaletteItem;

                    var eventArgs = new Events.ColorsPaletteSelectionChangedEventArgs(colorPaletteItem);
                    ColorSelectionChanged?.Invoke(this, eventArgs);
                }

                if (!ItemKeepSelected)
                {
                    listView.SelectedIndex = -1;
                    listView.SelectedItem = null;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Add color to Colors palette. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        public void AddColor(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent
                    && !Colors.Any(c => c == colorPaletteItem))
            {
                Colors.Add(colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Add color to Colors history. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        public void AddColorToHistory(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent)
            {
                if (UsedColors.Any(c => c == colorPaletteItem))
                {
                    var currentColors = UsedColors.Where(c => c == colorPaletteItem).ToList();
                    foreach (var color in currentColors)
                        UsedColors.Remove(color);
                }

                if (UsedColors.Count >= COLORS_HISTORY_COUNT)
                    while (UsedColors.Count >= COLORS_HISTORY_COUNT)
                        UsedColors.RemoveAt(UsedColors.Count - 1);

                UsedColors.Insert(0, colorPaletteItem);
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Insert color to Colors palette at specified index. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        /// <param name="index"> Index of place where Color palette item will be placed. </param>
        public void InsertColor(ColorPaletteItem colorPaletteItem, int index = 0)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent
                    && !Colors.Any(c => c == colorPaletteItem)
                    && index >= 0 && index < Colors.Count)
            {
                UsedColors.Insert(index, colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Insert color to Colors history at specified index. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to add. </param>
        /// <param name="index"> Index of place where Color palette item will be placed. </param>
        public void InsertColorToHistory(ColorPaletteItem colorPaletteItem, int index = 0)
        {
            if (colorPaletteItem != null
                    && colorPaletteItem.Color != System.Windows.Media.Colors.Transparent
                    && index >= 0 && index < COLORS_HISTORY_COUNT)
            {
                if (UsedColors.Any(c => c == colorPaletteItem))
                {
                    var currentColors = UsedColors.Where(c => c == colorPaletteItem).ToList();
                    foreach (var color in currentColors)
                        UsedColors.Remove(color);
                }

                if (UsedColors.Count >= COLORS_HISTORY_COUNT)
                    while (UsedColors.Count >= COLORS_HISTORY_COUNT)
                        UsedColors.RemoveAt(UsedColors.Count - 1);

                UsedColors.Insert(Math.Min(Math.Max(index, 0), UsedColors.Count - 1), colorPaletteItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Colors palette. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to remove. </param>
        public void RemoveColor(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null && Colors.Any(c => c == colorPaletteItem))
            {
                var currentColors = Colors.Where(c => c == colorPaletteItem).ToList();
                foreach (var color in currentColors)
                    Colors.Remove(color);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Colors history. </summary>
        /// <param name="colorPaletteItem"> ColorPaletteItem to remove. </param>
        public void RemoveColorFromHistory(ColorPaletteItem colorPaletteItem)
        {
            if (colorPaletteItem != null && UsedColors.Any(c => c == colorPaletteItem))
            {
                var currentColors = UsedColors.Where(c => c == colorPaletteItem).ToList();
                foreach (var color in currentColors)
                    UsedColors.Remove(color);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Color palette with specified index. </summary>
        /// <param name="index"> Index of item to remove. </param>
        public void RemoveColorAt(int index)
        {
            if (index >= 0 && index < Colors.Count)
                Colors.RemoveAt(index);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove color from Color history with specified index. </summary>
        /// <param name="index"> Index of item to remove. </param>
        public void RemoveColorFromHistoryAt(int index)
        {
            if (index >= 0 && index < COLORS_HISTORY_COUNT)
                UsedColors.RemoveAt(Math.Min(Math.Max(index, 0), UsedColors.Count - 1));
        }

        #endregion DATA MANAGEMENT METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing lyrics collection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Notify Collection Changed Event Arguments. </param>
        protected void OnCollectionChanged<T>(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (T item in e.OldItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged -= (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (T item in e.NewItems)
                    if (item is INotifyPropertyChanged)
                        ((INotifyPropertyChanged)item).PropertyChanged += (s, e1)
                            => OnCollectionItemChanged<T>(s, e1);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after chaning any value in lyrics in lyrics collection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Property Changed Event Arguments. </param>
        protected void OnCollectionItemChanged<T>(object sender, PropertyChangedEventArgs e)
        {
            //
        }

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
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplySelectMethod(GetListView("colorsListView"), OnColorPaletteItemSelected);
            ApplySelectMethod(GetListView("historyColorsListView"), OnColorPaletteItemSelected);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ListViewEx from ContentTemplate. </summary>
        /// <param name="listViewName"> ListViewEx name. </param>
        /// <returns> ListViewEx or null. </returns>
        protected ExtListView GetListView(string listViewName)
        {
            return this.Template.FindName(listViewName, this) as ExtListView;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply SelectionChanged method on ListViewEx. </summary>
        /// <param name="listViewEx"> ListViewEx. </param>
        /// <param name="eventHandler"> SelectionChanged method. </param>
        protected void ApplySelectMethod(ExtListView listViewEx, SelectionChangedEventHandler eventHandler)
        {
            if (listViewEx != null)
                listViewEx.SelectionChanged += eventHandler;
        }

        #endregion TEMPLATE METHODS

    }
}
