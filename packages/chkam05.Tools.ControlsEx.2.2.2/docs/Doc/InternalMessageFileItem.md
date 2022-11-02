# InternalMessageFileItem
Internal message file object data used in [FilesSelectorInternalMessageEx](FilesSelectorInternalMessageEx.md).

namespace: _chkam05.Tools.ControlsEx.Data_

### Attributes:

| Type         | Name        | Description |
|:-------------|:------------|:------------|
| PackIconKind | Icon        | File icon kind (see related repositories). |
| string       | Name        | File name. |
| string       | Path        | File path. |
| **Get Only** |||
| bool         | IsDirectory | Value indicating whather the item is a directory. |
| bool         | IsDrive     | Value indicating whather the item is a drive. |

### Constructors:

| Type     | Parameter Name | Description |
|:---------|:---------------|:------------|
| string   | filePath       | File path. |

### Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Methods:

- _None_

# Related repositories

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit
