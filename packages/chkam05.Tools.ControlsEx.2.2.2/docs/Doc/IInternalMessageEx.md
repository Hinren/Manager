# IInternalMessageEx
Interface for [InternalMessageEx](BaseInternalMessageEx.md).

### Attributes:

| Type                  | Name                       | Description |
|:----------------------|:---------------------------|:------------|
| bool                  | AllowHide                  | Allow to hide internal message (it shows Hide button). |
| **Get Only**          |||
| bool                  | IsHidden                   | Check if internal message has been hidden. |
| bool                  | IsLoadingComplete          | Check if internal message has been fully loaded. |
| [InternalMessageResult](InternalMessageResult.md) | Result | Result value, depends on clicked button. |

### Methods:

- **Close**  
Manually close message.

- **Hide**  
Manually hide message.

- **Show**  
Manually show message if is hidden.
