# BaseProgressInternalMessageEx
Extended Base Progress Internal Message inherited from _[BaseInternalMessageEx](BaseInternalMessageEx.md)<[InternalMessageCloseEventArgs](InternalMessageCloseEventArgs.md)>_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

### Additional Attributes:

| Type                | Name                     | Description |
|:--------------------|:-------------------------|:------------|
| Brush               | ProgressBarBackground    | Progress bar background color. |
| Brush               | ProgressBarBorderBrush   | Progress bar border color. |
| Brush               | ProgressBarProgressBrush | Progress bar progress indicator color. |
| Thickness           | ProgressMargin           | Progress bar margin. |
| double              | ProgressMax              | Progress bar max progress value (default 100.0). |
| double              | ProgressMin              | Progress bar min progress value (default 0.0). |
| double              | Progress                 | Progress bar progress value (start 0.0). |
|||
| bool                | AllowCancel              | Allow to cancel progress enabling Cancel button. |
| bool                | KeepFinishedOpen         | After finish progress keep internal message open. |
| [DispatcherInvokerEx](DispatcherInvokerEx.md) | DispatcherInvoker | Dispatcher invoker for invoke progress methods running on separate thread. |

### Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |
| InternalMessageClose<[CloseEventArgs](InternalMessageCloseEventArgs.md)> | OnClose | Event invoked after closing internal message. |
| InternalMessageHide         | OnHide           | Event invoked after hiding internal message. |

### Additional Methods:

- **InvokeFinsh**  
Finish progress manually.

| Type | Parameter Name   | Description |
|:-----|:-----------------|:------------|
| bool | finishedProperly | Result information if progress finished successfully or not. |

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.
