# ColorPaletteItem
Class for handling and presenting color in [ColorsPaletteEx](ColorsPaletteEx.md) component inherited from _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.Colors_

### Attributes:

| Type   | Name      | Description |
|:-------|:----------|:------------|
| Color  | Color     | Color. |
| string | ColorCode | Hexadecimal color code as string. |
| string | Name      | Custom color name. |

### Constructors:

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| Color  | color          | Color. |
| string | colorName      | Custom color name. |

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | colorCode      | Hexadecimal color code as string. |
| string | colorName      | Custom color name. |

### Events:

| Type                          | Name             | Description |
|:------------------------------|:-----------------|:------------|
| PropertyChangedEventHandler   | PropertyChanged  | Event invoked after changing property. |

### Overrided methods and operators:

| Name               | Description |
|:-------------------|:------------|
| ==                 | Allow to compare colors by Color attribute. |
| !=                 | Allow to compare colors by Color attribute. |
| Equals(object obj) | Allow to compare colors by Color attribute. |
| ToString()         | Returns the color name first, if missing, color code. |

### Methods:

- _None_
