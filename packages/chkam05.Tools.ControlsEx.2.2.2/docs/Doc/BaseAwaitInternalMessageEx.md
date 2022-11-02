# BaseAwaitInternalMessageEx
Extended Base Await Internal Message inherited from _[BaseInternalMessageEx](BaseInternalMessageEx.md)<[InternalMessageCloseEventArgs](InternalMessageCloseEventArgs.md)>_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

### Additional Attributes:

| Type                | Name                     | Description |
|:--------------------|:-------------------------|:------------|
| TimeSpan            | IndicatorAnimationSpeed  | Indicator animation speed. |
| Brush               | IndicatorFill            | Indicator fill color. |
| Thickness           | IndicatorMargin          | Indicator margin. |
| Brush               | IndicatorPen             | Indicator border color. |
| Thickness           | IndicatorPenThickness    | Indicator border thickness. |
| [IndicatorType](IndicatorType.md) | IndicatorType | Indicator type. |
||||
| bool                | AllowCancel              | Allow to cancel progress enabling Cancel button. |
| bool                | KeepFinishedOpen         | After finish progress keep internal message open. |
| [BaseIndicatorEx](BaseIndicatorEx.md) | Indicator | Indicator object. |
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
