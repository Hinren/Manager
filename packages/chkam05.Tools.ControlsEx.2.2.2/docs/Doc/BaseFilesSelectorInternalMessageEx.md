# BaseFilesSelectorInternalMessageEx
Extended Base Files Selector Internal Message inherited from _[BaseInternalMessageEx](BaseInternalMessageEx.md)<[FilesSelectorInternalMessageCloseEventArgs](FilesSelectorInternalMessageCloseEventArgs.md)>_.

namespace: _chkam05.Tools.ControlsEx.InternalMessages_

### Additional Attributes:

| Type         | Name                          | Description |
|:-------------|:------------------------------|:------------|
| Brush        | TextBoxMouseOverBackground    | TextBoxEx components background color when mouse is over. |
| Brush        | TextBoxMouseOverBorderBrush   | TextBoxEx components border color when mouse is over. |
| Brush        | TextBoxMouseOverForeground    | TextBoxEx components foreground color when mouse is over. |
| Brush        | TextBoxSelectedBackground     | TextBoxEx components background color when is selected. |
| Brush        | TextBoxSelectedBorderBrush    | TextBoxEx components border color when is selected. |
| Brush        | TextBoxSelectedForeground     | TextBoxEx components foreground color when is selected. |
| Brush        | TextBoxSelectedTextBackground | TextBoxEx components background color selected text. |
||||
| bool         | AllowCreate                   | Allow create file or directory (Save mode). |
| ObservableCollection<[InternalMessageFileType](InternalMessageFileType.md)> | FilesTypes | Collection of files types that will be allowed to select. |
| string       | InitialDirectory              | Start location point. |
| bool         | MultipleFiles                 | Allow to select multiple files. |
| bool         | OnlyDirectories               | Allow to select only directories. |
| bool         | UseFilesTypes                 | Use FilesTypes collection to validate selecting files. |
| **Get Only** |||
| string       | CurrentDirectory              | Currently opened directory. |
| [InternalMessageFileType](InternalMessageFileType.md) | FileType | Selected file type. |

### Constructors:

| Type                  | Parameter Name | Description |
|:----------------------|:---------------|:------------|
| [InternalMessagesExContainer](InternalMessagesExContainer.md) | parentContainer | Internal messages ex container where message will be displayed. |

### Additional Events:

- _None_

### Additional Methods:

- **CreateCloseEventArgs** (_protected virtual_)  
Create instance of close event arguments class or inheritet from it.

| Type                          | Parameter Name | Description |
|:------------------------------|:---------------|:------------|
| [CloseEventArgs](FilesSelectorInternalMessageCloseEventArgs.md) | RETURN | Instance of close event arguments class or inherited from it. |

### Related components:

- [InternalMessagesExContainer](InternalMessagesExContainer.md)  
Is default container component for InternalMessageEx components.
