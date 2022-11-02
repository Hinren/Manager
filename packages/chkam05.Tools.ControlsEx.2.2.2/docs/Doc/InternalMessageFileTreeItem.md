# InternalMessageFileTreeItem
Internal message folder object data used in [FilesSelectorInternalMessageEx](FilesSelectorInternalMessageEx.md).

namespace: _chkam05.Tools.ControlsEx.Data_

### Attributes:

| Type         | Name        | Description |
|:-------------|:------------|:------------|
| ObservableCollection<[InternalMessageFileTreeItem](InternalMessageFileTreeItem.md)> | SubDirectories | Folders in this directoy. |
| PackIconKind | Icon        | Folder icon kind (see related repositories). |
| string       | Name        | Folder name. |
| string       | Path        | Folder path. |
| **Get Only** |||
| bool         | IsDrive     | Value indicating whather the catalog is a drive. |


### Constructors:

| Type     | Parameter Name | Description |
|:---------|:---------------|:------------|
| string   | directoryPath  | Directory path. |

### Events:

| Type                        | Name             | Description |
|:----------------------------|:-----------------|:------------|
| PropertyChangedEventHandler | PropertyChanged  | Event invoked after changing property. |

### Methods:

- _None_

# Related repositories

materialdesigninxaml (PackIconKind): https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit
