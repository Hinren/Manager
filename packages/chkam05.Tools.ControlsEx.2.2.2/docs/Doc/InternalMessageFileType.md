# InternalMessageFileType
Internal message file type definition used in [BaseFilesSelectorInternalMessageEx](BaseFilesSelectorInternalMessageEx.md) for filter files that will be available to select.

namespace: _chkam05.Tools.ControlsEx.Data_

### Additional Attributes:

| Type     | Name       | Description |
|:---------|:-----------|:------------|
| string   | Title      | File type definition title. |
| string[] | Extensions | Array of files extensions. |

### Constructors:

| Type     | Parameter Name | Description |
|:---------|:---------------|:------------|
| string   | Title          | File type definition title. |
| string[] | Extensions     | Array of files extensions. |

### Additional Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Additional Methods:

- **MatchFile**  
Check if file matches extension.

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| bool   | RETURN         | True if file extension is matching. |
| string | fileName       | File name with extension to check if is matching. |
