namespace Shoppy.Application.Utils;

public static class GuidUtils
{
    public static Guid ConvertStringToGuid(string input)
    {
        var isSuccess = Guid.TryParse(input, out var result);
        if (isSuccess)
            return result;
        throw new ArgumentException($"Can not convert string {input} to guid.");
    }
}