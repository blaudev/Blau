using System.Text.RegularExpressions;

namespace System;

public static partial class StringExtensions
{
    public static string ToSlug(this string str, char separator = '=')
    {
        var separatorString = separator.ToString();

        str = str.ToLower();

        ARegex().Replace(str, "a");
        ERegex().Replace(str, "e");
        IRegex().Replace(str, "i");
        ORegex().Replace(str, "o");
        URegex().Replace(str, "u");

        str = str.Replace("ñ", "n");
        str = str.Replace("ç", "c");

        SpacesRegex().Replace(str, separatorString);
        str = str.Trim(separator);

        return str;
    }

    [GeneratedRegex(@"[\s-_]+")]
    private static partial Regex SpacesRegex();

    [GeneratedRegex(@"[àá]")]
    private static partial Regex ARegex();

    [GeneratedRegex(@"[èé]")]
    private static partial Regex ERegex();

    [GeneratedRegex(@"[ìí]")]
    private static partial Regex IRegex();

    [GeneratedRegex(@"[òó]")]
    private static partial Regex ORegex();

    [GeneratedRegex(@"[ùú]")]
    private static partial Regex URegex();
}
