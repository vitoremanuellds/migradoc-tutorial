using PdfSharp.Fonts;

public class FontResolver : IFontResolver
{
    public byte[]? GetFont(string faceName)
    {
        string basePath = Environment.CurrentDirectory;
        string fontPath;

        switch (faceName) 
        {
            case "Roboto#bi":
                fontPath = "/Fonts/FontFiles/Roboto/Roboto-BoldItalic.ttf";
                break;
            case "Roboto#b":
                fontPath = "/Fonts/FontFiles/Roboto/Roboto-Bold.ttf";
                break;
            case "Roboto#i":
                fontPath = "/Fonts/FontFiles/Roboto/Roboto-Italic.ttf";
                break;
            case "Roboto#":
            default:
                fontPath = "/Fonts/FontFiles/Roboto/Roboto-Regular.ttf";
                break;
        }

        return File.ReadAllBytes(basePath + fontPath);
    }

    public FontResolverInfo? ResolveTypeface(string familyName, bool bold, bool italic)
    {
        if (bold && italic) {
            return new FontResolverInfo("Roboto#bi");
        } else if (bold && !italic) {
            return new FontResolverInfo("Roboto#b");
        } else if (!bold && italic) {
            return new FontResolverInfo("Roboto#i");
        } else {
            return new FontResolverInfo("Roboto#");
        }
    }
}