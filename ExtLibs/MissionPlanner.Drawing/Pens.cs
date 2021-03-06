using SkiaSharp;

namespace System.Drawing
{
    public class Pens
    {
        public static Pen Transparent { get; } = new Pen() { nativePen = new SKPaint() { Color = new SKColor(0x00FFFFFF) } };
        public static Pen AliceBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0F8FF) } };
        public static Pen AntiqueWhite { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFAEBD7) } };
        public static Pen Aqua { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00FFFF) } };
        public static Pen Aquamarine { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF7FFFD4) } };
        public static Pen Azure { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0FFFF) } };
        public static Pen Beige { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF5F5DC) } };
        public static Pen Bisque { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFE4C4) } };
        public static Pen Black { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen BlanchedAlmond { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFEBCD) } };
        public static Pen Blue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF0000FF) } };
        public static Pen BlueViolet { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF8A2BE2) } };
        public static Pen Brown { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFA52A2A) } };
        public static Pen BurlyWood { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDEB887) } };
        public static Pen CadetBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF5F9EA0) } };
        public static Pen Chartreuse { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF7FFF00) } };
        public static Pen Chocolate { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFD2691E) } };
        public static Pen Coral { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF7F50) } };
        public static Pen CornflowerBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF6495ED) } };
        public static Pen Cornsilk { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFF8DC) } };
        public static Pen Crimson { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDC143C) } };
        public static Pen Cyan { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00FFFF) } };
        public static Pen DarkBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00008B) } };
        public static Pen DarkCyan { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF008B8B) } };
        public static Pen DarkGoldenrod { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB8860B) } };
        public static Pen DarkGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFA9A9A9) } };
        public static Pen DarkGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF006400) } };
        public static Pen DarkKhaki { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFBDB76B) } };
        public static Pen DarkMagenta { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF8B008B) } };
        public static Pen DarkOliveGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF556B2F) } };
        public static Pen DarkOrange { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF8C00) } };
        public static Pen DarkOrchid { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF9932CC) } };
        public static Pen DarkRed { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF8B0000) } };
        public static Pen DarkSalmon { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFE9967A) } };
        public static Pen DarkSeaGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF8FBC8B) } };
        public static Pen DarkSlateBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF483D8B) } };
        public static Pen DarkSlateGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF2F4F4F) } };
        public static Pen DarkTurquoise { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00CED1) } };
        public static Pen DarkViolet { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF9400D3) } };
        public static Pen DeepPink { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF1493) } };
        public static Pen DeepSkyBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00BFFF) } };
        public static Pen DimGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF696969) } };
        public static Pen DodgerBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF1E90FF) } };
        public static Pen Firebrick { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB22222) } };
        public static Pen FloralWhite { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFAF0) } };
        public static Pen ForestGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF228B22) } };
        public static Pen Fuchsia { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF00FF) } };
        public static Pen Gainsboro { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDCDCDC) } };
        public static Pen GhostWhite { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF8F8FF) } };
        public static Pen Gold { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFD700) } };
        public static Pen Goldenrod { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDAA520) } };
        public static Pen Gray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF808080) } };
        public static Pen Green { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF008000) } };
        public static Pen GreenYellow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFADFF2F) } };
        public static Pen Honeydew { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0FFF0) } };
        public static Pen HotPink { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF69B4) } };
        public static Pen IndianRed { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFCD5C5C) } };
        public static Pen Indigo { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF4B0082) } };
        public static Pen Ivory { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFF0) } };
        public static Pen Khaki { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0E68C) } };
        public static Pen Lavender { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFE6E6FA) } };
        public static Pen LavenderBlush { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFF0F5) } };
        public static Pen LawnGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF7CFC00) } };
        public static Pen LemonChiffon { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFACD) } };
        public static Pen LightBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFADD8E6) } };
        public static Pen LightCoral { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF08080) } };
        public static Pen LightCyan { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFE0FFFF) } };
        public static Pen LightGoldenrodYellow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFAFAD2) } };
        public static Pen LightGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF90EE90) } };
        public static Pen LightGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFD3D3D3) } };
        public static Pen LightPink { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFB6C1) } };
        public static Pen LightSalmon { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFA07A) } };
        public static Pen LightSeaGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF20B2AA) } };
        public static Pen LightSkyBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF87CEFA) } };
        public static Pen LightSlateGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF778899) } };
        public static Pen LightSteelBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB0C4DE) } };
        public static Pen LightYellow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFE0) } };
        public static Pen Lime { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00FF00) } };
        public static Pen LimeGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF32CD32) } };
        public static Pen Linen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFAF0E6) } };
        public static Pen Magenta { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF00FF) } };
        public static Pen Maroon { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF800000) } };
        public static Pen MediumAquamarine { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF66CDAA) } };
        public static Pen MediumBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF0000CD) } };
        public static Pen MediumOrchid { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFBA55D3) } };
        public static Pen MediumPurple { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF9370DB) } };
        public static Pen MediumSeaGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF3CB371) } };
        public static Pen MediumSlateBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF7B68EE) } };
        public static Pen MediumSpringGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00FA9A) } };
        public static Pen MediumTurquoise { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF48D1CC) } };
        public static Pen MediumVioletRed { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFC71585) } };
        public static Pen MidnightBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF191970) } };
        public static Pen MintCream { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF5FFFA) } };
        public static Pen MistyRose { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFE4E1) } };
        public static Pen Moccasin { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFE4B5) } };
        public static Pen NavajoWhite { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFDEAD) } };
        public static Pen Navy { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000080) } };
        public static Pen OldLace { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFDF5E6) } };
        public static Pen Olive { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF808000) } };
        public static Pen OliveDrab { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF6B8E23) } };
        public static Pen Orange { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFA500) } };
        public static Pen OrangeRed { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF4500) } };
        public static Pen Orchid { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDA70D6) } };
        public static Pen PaleGoldenrod { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFEEE8AA) } };
        public static Pen PaleGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF98FB98) } };
        public static Pen PaleTurquoise { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFAFEEEE) } };
        public static Pen PaleVioletRed { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDB7093) } };
        public static Pen PapayaWhip { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFEFD5) } };
        public static Pen PeachPuff { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFDAB9) } };
        public static Pen Peru { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFCD853F) } };
        public static Pen Pink { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFC0CB) } };
        public static Pen Plum { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFDDA0DD) } };
        public static Pen PowderBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB0E0E6) } };
        public static Pen Purple { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF800080) } };
        public static Pen Red { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF0000) } };
        public static Pen RosyBrown { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFBC8F8F) } };
        public static Pen RoyalBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF4169E1) } };
        public static Pen SaddleBrown { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF8B4513) } };
        public static Pen Salmon { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFA8072) } };
        public static Pen SandyBrown { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF4A460) } };
        public static Pen SeaGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF2E8B57) } };
        public static Pen SeaShell { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFF5EE) } };
        public static Pen Sienna { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFA0522D) } };
        public static Pen Silver { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFC0C0C0) } };
        public static Pen SkyBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF87CEEB) } };
        public static Pen SlateBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF6A5ACD) } };
        public static Pen SlateGray { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF708090) } };
        public static Pen Snow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFAFA) } };
        public static Pen SpringGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF00FF7F) } };
        public static Pen SteelBlue { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF4682B4) } };
        public static Pen Tan { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFD2B48C) } };
        public static Pen Teal { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF008080) } };
        public static Pen Thistle { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFD8BFD8) } };
        public static Pen Tomato { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFF6347) } };
        public static Pen Turquoise { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF40E0D0) } };
        public static Pen Violet { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFEE82EE) } };
        public static Pen Wheat { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF5DEB3) } };
        public static Pen White { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFFF) } };
        public static Pen WhiteSmoke { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF5F5F5) } };
        public static Pen Yellow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFF00) } };
        public static Pen YellowGreen { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF9ACD32) } };
        public static Pen ActiveBorder { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB4B4B4) } };
        public static Pen ActiveCaption { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF99B4D1) } };
        public static Pen ActiveCaptionText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen AppWorkspace { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFABABAB) } };
        public static Pen ButtonFace { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0F0F0) } };
        public static Pen ButtonHighlight { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFFF) } };
        public static Pen ButtonShadow { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFA0A0A0) } };
        public static Pen Control { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0F0F0) } };
        public static Pen ControlLightLight { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFFF) } };
        public static Pen ControlLight { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFE3E3E3) } };
        public static Pen ControlDark { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFA0A0A0) } };
        public static Pen ControlDarkDark { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF696969) } };
        public static Pen ControlText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen Desktop { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen GradientActiveCaption { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFB9D1EA) } };
        public static Pen GradientInactiveCaption { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFD7E4F2) } };
        public static Pen GrayText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF6D6D6D) } };
        public static Pen Highlight { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF0078D7) } };
        public static Pen HighlightText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFFF) } };
        public static Pen HotTrack { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF0066CC) } };
        public static Pen InactiveCaption { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFBFCDDB) } };
        public static Pen InactiveBorder { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF4F7FC) } };
        public static Pen InactiveCaptionText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen Info { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFE1) } };
        public static Pen InfoText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen Menu { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0F0F0) } };
        public static Pen MenuBar { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFF0F0F0) } };
        public static Pen MenuHighlight { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF3399FF) } };
        public static Pen MenuText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };
        public static Pen ScrollBar { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFC8C8C8) } };
        public static Pen Window { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFFFFFFFF) } };
        public static Pen WindowFrame { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF646464) } };
        public static Pen WindowText { get; } = new Pen () { nativePen = new SKPaint() { Color = new SKColor(0xFF000000) } };


    }
}