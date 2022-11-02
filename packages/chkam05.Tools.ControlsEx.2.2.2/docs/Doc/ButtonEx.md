# ButtonEx
Extended Button Control inherited from _Button_ and _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx_

![ButtonEx Examples (Images/ButtonEx.png)](../Images/ButtonEx.png)

### Additional Attributes:

| Type         | Name                 | Description |
|:-------------|:---------------------|:------------|
| Brush        | MouseOverBackground  | Button background color when cursor is over. |
| Brush        | MouseOverBorderBrush | Button border color when cursor is over. |
| Brush        | MouseOverForeground  | Button foreground color when cursor is over. |
| Brush        | PressedBackground    | Button background color when is pressed. |
| Brush        | PressedBorderBrush   | Button border color when is pressed. |
| Brush        | PressedForeground    | Button foreground color when is pressed. |
|||
| double       | IconHeight           | Icon height. |
| PackIconKind | IconKind             | Icon kind (see related repositories). |
| Thickness    | IconMargin           | Icon margin. |
| double       | IconMaxHeight        | Icon max height. |
| double       | IconMaxWidth         | Icon max width. |
| double       | IconMinHeight        | Icon min height. |
| double       | IconMinWidth         | Icon min width. |
| double       | IconWidth            | Icon width. |
|||
| CornerRadius | CornerRadius         | Button corner radius. |
| [ContentSide](ContentSide.md) | ContentSide | Button content side in relation of Icon. |

### Additional Constructors:

- _None_

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Additional Methods:

- _None_

# Related repositories

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit
