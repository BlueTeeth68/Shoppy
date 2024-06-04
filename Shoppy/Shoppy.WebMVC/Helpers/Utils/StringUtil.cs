using System.Text;

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
    
    public static string BuildQueryString(object request)
    {
        var queryStringBuilder = new StringBuilder();

        foreach (var property in request.GetType().GetProperties())
        {
            var value = property.GetValue(request);
            if (value == null) continue;

            if (queryStringBuilder.Length > 0)
            {
                queryStringBuilder.Append('&');
            }

            queryStringBuilder.Append(property.Name);
            queryStringBuilder.Append('=');
            queryStringBuilder.Append(Uri.EscapeDataString(value.ToString() ?? string.Empty));
        }

        return queryStringBuilder.ToString();
    }
}