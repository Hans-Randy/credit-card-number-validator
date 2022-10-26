using Web.Models;

namespace Web.Utils;

public static class Validator
{
    public static bool ValidateCardNo(string cardNo)
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

    public static bool ValidateMII(string cardNo, List<CreditCardProvider> creditCardProviders)
    {
        int actualMajorIndustryIdentifier = cardNo[0] - '0';
        return creditCardProviders.Any(x => x.MajorIndustryIdentifier == actualMajorIndustryIdentifier);
    }

    public static CreditCardProvider? GetCreditCardProvider(string cardNo, List<CreditCardProvider> creditCardProviders)
    {
        int actualMajorIndustryIdentifier = cardNo[0] - '0';
        return creditCardProviders.FirstOrDefault(x => x.MajorIndustryIdentifier == actualMajorIndustryIdentifier);
    }

    public static bool CheckIfMajorIndustryIdentifierAlreadyExists(CreditCardProvider creditCardProvider, List<CreditCardProvider> creditCardProviders)
    {
        return creditCardProviders.Any(x => x.Id != creditCardProvider.Id && x.MajorIndustryIdentifier == creditCardProvider.MajorIndustryIdentifier);
    }

    public static bool CheckIfCreditCardProviderNameAlreadyExists(CreditCardProvider creditCardProvider, List<CreditCardProvider> creditCardProviders)
    {
        return creditCardProviders.Any(x => x.Id != creditCardProvider.Id && x.Name == creditCardProvider.Name);
    }

    public static bool CheckIfCardNoAlreadyCaptured(string cardNo, List<CreditCard> creditCards)
    {
        return creditCards.Any(x => x.Number == cardNo);
    }
}