# InternalMessageEx
Extended Internal Message inherited from _[StandardInternalMessageEx](StandardInternalMessageEx.md)_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

![InternalMessageEx Alert Example (Images/InternalMessageExAlert.png)](../Images/InternalMessageExAlert.png)

![InternalMessageEx Error Example (Images/InternalMessageExError.png)](../Images/InternalMessageExError.png)

![InternalMessageEx Info Example (Images/InternalMessageExInfo.png)](../Images/InternalMessageExInfo.png)

![InternalMessageEx Question Example (Images/InternalMessageExQuestion.png)](../Images/InternalMessageExQuestion.png)

### Additional Attributes:

| Type   | Name    | Description |
|:-------|:--------|:------------|
| string | Message | Internal message message. |

### Additional Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |
| string                | title          | Internal message title. |
| string                | message        | Internal message message. |
| PackIconKind          | icon           | Internal message icon kind (see related repositories). |
| [InternalMessagesButtonsSet](InternalMessagesButtonsSet.md) | buttonsSet | Internal message buttons set configuration. |

### Additional Events:

- _None_

### Additional Methods:

- **CreateAlertMessage**  
Create internal message as alert message with preset icon and buttons set.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | title          | Internal message title. |
| string | message        | Internal message message. |

- **CreateErrorMessage**  
Create internal message as error message with preset icon and buttons set.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | title          | Internal message title. |
| string | message        | Internal message message. |

- **CreateInfoMessage**  
Create internal message as info message with preset icon and buttons set.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | title          | Internal message title. |
| string | message        | Internal message message. |

- **CreateQuestionMessage**  
Create internal message as question message with preset icon and buttons set.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | title          | Internal message title. |
| string | message        | Internal message message. |

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.

# Related repositories

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit
