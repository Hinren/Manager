# BaseIndicatorEx
Inherited from _Control_ and _INotifyPropertyChanged_.

namespace: _chkam05.Tools.ControlsEx.Indicators_

### Additional Attributes:

| Type                | Name           | Description |
|:--------------------|:---------------|:------------|
| Brush               | Fill           | Indicator fill color. |
| Brush               | Pen            | Indicator border color. |
| TimeSpan            | AnimationSpeed | Indicator animation speed. |
| CornerRadius        | CornerRadius   | Indicator corner radius. |
| Thickness           | PenThickness   | Indicator border thickness. |
| [DispatcherInvokerEx](DispatcherInvokerEx.md) | DispatcherInvoker | Dispatcher invoker for update visual state of indicator from separated thread. |
| **Virtual**         |||
| Geometry            | PathData       | Indicator drawing path. |
| **Get only**        |||
| bool                | IsPathEditable | Parameter that defines if geomatry path is editable. |

### Additional Constructors:

- _None_

### Additional Events:

| Type                          | Name                  | Description |
|:------------------------------|:----------------------|:------------|
| PropertyChangedEventHandler   | PropertyChanged       | Event invoked after changing property. |
| IndicatorAnimationEnd         | AnimationEnded        | Event invoked after stopping animation. |
| IndicatorAnimationFrameUpdate | AnimationFrameUpdated | Event invoked after updating visual indicator frame by frame. |

### Additional Methods:

- **StartAnimation**  
Start animating indicator.

- **StopAnimation**  
Stop animating indicator.
