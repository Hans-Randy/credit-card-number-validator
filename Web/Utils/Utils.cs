using System.Text.RegularExpressions;

namespace Web.Utils;

public static class Utils
{
    public static bool IsNumeric(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return input.RemoveWhiteSpace().All(char.IsNumber);
    }
    
    public static string RemoveWhiteSpace(this string input)
    {
        return Regex.Replace(input, @"\s+", "");
    }
}