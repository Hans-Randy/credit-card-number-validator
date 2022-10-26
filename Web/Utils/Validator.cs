using Web.Models;

namespace Web.Utils;

public static class CreditCardNoValidator
{
    public static bool Validate(string cardNo)
    {
        var cardNoLength = cardNo.Length;
        var sum = 0;
        var isSecondDigit = false;
    
        for (var i = cardNoLength - 1; i >= 0; i--)
        {
            var d = cardNo[i] - '0';
 
            if (isSecondDigit)
                d *= 2;
            sum += d / 10;
            sum += d % 10;
            
            isSecondDigit = !isSecondDigit;
        }
    
        return sum % 10 == 0;
    }

    public static bool ValidateMajorIndustryIdentifier(string cardNo, HashSet<CreditCardProvider> creditCardProviders)
    {
        int actualMajorIndustryIdentifier = cardNo[0] - '0';
        return creditCardProviders.Any(x => x.MajorIndustryIdentifier == actualMajorIndustryIdentifier);
    }

    public static CreditCardProvider? GetCreditCardProvider(string cardNo, HashSet<CreditCardProvider> creditCardProviders)
    {
        int actualMajorIndustryIdentifier = cardNo[0] - '0';
        return creditCardProviders.FirstOrDefault(x => x.MajorIndustryIdentifier == actualMajorIndustryIdentifier);
    }

    public static bool CheckIfMajorIndustryIdentifierAlreadyExists(CreditCardProvider creditCardProvider, HashSet<CreditCardProvider> creditCardProviders)
    {
        return creditCardProviders.Any(x => x.ID != creditCardProvider.ID && x.MajorIndustryIdentifier == creditCardProvider.MajorIndustryIdentifier);
    }
}