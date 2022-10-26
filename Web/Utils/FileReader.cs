using Web.Models;
using Web.Constants;

namespace Web.Utils;

public class FileReader
{
    public static List<CreditCardProvider> ReadCreditCardProviderFile()
    {
        var creditCardProviders = new List<CreditCardProvider>();
        
        foreach (string line in Read(Constant.CREDIT_CARD_PROVIDER_FILENAME))
        {
            var arr = line.Split(",");
            
            creditCardProviders.Add(new CreditCardProvider
            {
                Id = int.Parse(arr[0]),
                Name = arr[1],
                MajorIndustryIdentifier = int.Parse(arr[2])
            });
        }

        return creditCardProviders;
    }

    private static string[] Read(string filename)
    {
        return File.ReadAllLines(filename);
    }
    
    public static List<CreditCard> ReadCreditCardFile()
    {
        var creditCards = new List<CreditCard>();
        
        foreach (string line in Read(Constant.CREDIT_CARD_FILENAME))
        {
            var arr = line.Split(",");
            
            creditCards.Add(new CreditCard
            {
                Id = int.Parse(arr[0]),
                Number = arr[1],
                CreditCardProviderName = arr[2]
            });
        }

        return creditCards;
    }
}