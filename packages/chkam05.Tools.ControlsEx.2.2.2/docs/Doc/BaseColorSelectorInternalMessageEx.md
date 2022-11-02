# BaseColorSelectorInternalMessageEx
Extended Base Color Selector Internal Message inherited from _[BaseInternalMessageEx](BaseInternalMessageEx.md)<[ColorSelectorInternalMessageCloseEventArgs](ColorSelectorInternalMessageCloseEventArgs.md)>_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

### Additional Attributes:

| Type   | Name              | Description |
|:-------|:------------------|:------------|
| Color  | SelectedColor     | Selected color. |
| string | SelectedColorCode | Selected color hexadecimal code as string. |
| string | SelectedColorName | Selected color name. |
| bool   | ShowColorCode     | Show color code. |

### Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |

### Additional Events:

- _None_

### Additional Methods:

- **CreateCloseEventArgs** (_protected virtual_)  
Create instance of close event arguments class or inheritet from it.

| Type                          | Parameter Name | Description |
|:------------------------------|:---------------|:------------|
| [CloseEventArgs](ColorSelectorInternalMessageCloseEventArgs.md) | RETURN | Instance of close event arguments class or inherited from it. |

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.
