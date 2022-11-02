# AHSLColor
AHLS (alpha, hue, lightness, saturation) color class. It's used in [ColorsPickerEx](ColorsPickerEx.md).

namespace: _chkam05.Tools.ControlsEx.Colors_

### Attributes:

| Type | Name | Description |
|:-----|:-----|:------------|
| int  | H    | Hue value.  |
| int  | S    | Saturation value. |
| int  | L    | Lightness value. |

### Const:

| Type   | Name           | Description |
|:-------|:---------------|:------------|
| double | HUE_MAX_D      | Max value of Hue in double. |
| double | HUE_MIN_D      | Min value of Hue in double. |
| int    | HUE_MAX        | Max value of Hue. |
| int    | HUE_MIN        | Min value of Hue. |
| int    | LIGHTNESS_MAX  | Max value of Lightness. |
| int    | LIGHTNESS_MIN  | Min value of Lightness. |
| int    | SATURATION_MAX | Max value of Saturation. |
| int    | SATURATION_MIN | Min value of Saturation. |

### Constructors:

| Type | Parameter Name | Description |
|:-----|:---------------|:------------|
| byte | a              | Alpha color value. |
| int  | h              | Hue value.  |
| int  | s              | Saturation value. |
| int  | l              | Lightness value. |

### Events:

- _None_

### Methods:

- **FromColor**  
Create instance of AHSLColor from Color.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Color | color          | Color.      |

- **ToColor**  
Convert AHSLColor to Color.

| Type  | Parameter Name | Description |
|:------|:---------------|:------------|
| Color | RETURN         | Color.      |

- **ToString**  
Return string representation of AHSLColor ("A:x H:x S:x L:x").

| Type   | Parameter Name | Description |
|:-------|:---------------|:------------|
| string | RETURN         | String representation of AHSLColor. |
