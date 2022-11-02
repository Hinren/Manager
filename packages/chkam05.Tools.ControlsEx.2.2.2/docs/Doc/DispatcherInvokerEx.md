# DispatcherInvokerEx
Utility for safe dispatching an event or method from component.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Attributes:

| Type             | Name       | Description |
|:-----------------|:-----------|:------------|
| **Get Only**     |||
| Dispatcher       | Dispatcher | Interface component dispatcher that invokes the method. |
| Stack<Exception> | Exceptions | Stack of exceptions that Were thrown during execution of the method. |

### Constructors:

| Type       | Parameter Name | Description |
|:-----------|:---------------|:------------|
| Dispatcher | dispatcher     | Interface component dispatcher. |

### Events:

- _None_

### Methods:

- **TryInvoke**  
Invoke an event or method from another thread.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| Action | invokingMethod   | Action/method that will be invoked by dispatcher. |
