# ColorsUtilities
Static utility for color management.

namespace: _chkam05.Tools.ControlsEx.Utilities_

### Methods:

- **ColorToHex**  
Create hexadecimal code representation of Color as string.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| string | RETURN           | Hexadecimal code representation of Color as string. |
| Color  | color            | Color.      |

- **ColorFromHex**  
Create color object from hexadecimal color code representation.

| Type   | Parameter Name   | Description |
|:-------|:-----------------|:------------|
| Color  | RETURN           | Color.      |
| string | colorCode        | Hexadecimal code representation of Color as string. |

- **InverseColor**  
Inverse RGB color.

| Type  | Parameter Name   | Description |
|:------|:-----------------|:------------|
| Color | RETURN           | Inverted color. |
| Color | color            | Color.      |

- **UpdateColor**  
Update [AHSLColor](AHSLColor.md) color with new values.

| Type  | Parameter Name   | Description |
|:------|:-----------------|:------------|
| [AHSLColor](AHSLColor.md) | RETURN | Updated AHLS color. |
| [AHSLColor](AHSLColor.md) | ahslColor | AHLS color to update. |
| byte? | alpha            | New alpha value. |
| int?  | hue              | New hue value. |
| int?  | saturation       | New saturation value. |
| int?  | lightness        | New lightness value. |

- **UpdateColor**  
Update Color with new values.

| Type  | Parameter Name   | Description |
|:------|:-----------------|:------------|
| Color | RETURN           | Updated Color. |
| Color | color            | Color to update. |
| byte? | a                | New alpha value. |
| int?  | r                | New red value. |
| int?  | g                | New green value. |
| int?  | b                | New blue value. |

- **FoundFontColorContrastingWithBackground**  
Finds font color that contrasts with the background color.

| Type  | Parameter Name   | Description |
|:------|:-----------------|:------------|
| Color | RETURN           | Color contrasting to background color. |
| Color | backgroundColor  | Background color. |
