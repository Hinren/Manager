# InternalMessagesExContainer
Internal Messages Ex Container Control inherited from _Control_ and _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

### Additional Attributes:

| Type               | Name                | Description |
|:-------------------|:--------------------|:------------|
| bool               | CanGoBack           | Returns True if any internal message was loaded previously. |
| [IInternalMessageEx](IInternalMessageEx.md) | CurrentMessage | Current loaded internal message. |
| int                | CurrentMessageIndex | Index of current loaded internal message. |
| bool               | HasHidden           | Returns True if any internal message is hidden. |

### Additional Constructors:

- _None_

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Additional Methods:

- **ShowLastHiddenMessage**  
Show last message that has been hidden.

- **ShowMessage<T>**  
Load and show new message.

| Type                          | Parameter Name | Description |
|:------------------------------|:---------------|:------------|
| [InternalMessageCloseEventArgs](InternalMessageCloseEventArgs.md) | T | Internal message close event arguments object. |
| BaseInternalMessageEx<T>      | message        | Newly created internal message. |
