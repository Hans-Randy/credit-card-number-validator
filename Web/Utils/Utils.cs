using System.Text.RegularExpressions;

namespace Web.Utils;

public static class Validation
{
    public static bool IsNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return input.All(char.IsNumber);
    }
    
    private static string RemoveWhiteSpace(this string input)
    {
        return Regex.Replace(input, @"\s+", "");
    }
}