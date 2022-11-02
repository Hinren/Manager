# ColorsPaletteInternalMessageEx
Extended Colors Palette Internal Message inherited from _[BaseColorSelectorInternalMessageEx](BaseColorSelectorInternalMessageEx.md)_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

![ColorsPaletteInternalMessageEx Example (Images/ColorsPaletteInternalMessageEx.png)](../Images/ColorsPaletteInternalMessageEx.png)

### Additional Attributes:

| Type                                   | Name                 | Description |
|:---------------------------------------|:---------------------|:------------|
| ObservableCollection<[ColorPaletteItem](ColorPaletteItem.md)> | ColorsHistory | Observable collection of previously selected colors. |
| bool                                   | ColorsHistoryEnabled | Enable showing previously selected colors. |
| int                                    | ColorsHistoryCount   | Max count of previously selected colors. |
| string                                 | ColorsHistoryTitle   | Title of previously selected colors. |
| string                                 | ColorsPaletteTitle   | Title of colors palette. |

### Additional Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |
| string                | title          | Internal message title. |
| PackIconKind          | icon           | Internal message icon kind (see related repositories). |

### Additional Events:

- _None_

### Additional Methods:

- _None_

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.
