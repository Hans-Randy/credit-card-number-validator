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

    public static int GetNumberOfDigits(this int input)
    {
        int count = 0;

        while (input > 0)
        {
            input = input / 10;
            count++;
        }

        return count;
    }
}