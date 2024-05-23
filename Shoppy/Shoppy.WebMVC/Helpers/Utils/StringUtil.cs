namespace Shoppy.WebMVC.Helpers.Utils;

public static class StringUtil
{
    public static string FormatProductName(string? input, int maxLength = 60, int trimLength = 57)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "";
        }

        return input.Length > maxLength ? string.Concat(input.AsSpan(0, trimLength), "...") : input;
    }
}