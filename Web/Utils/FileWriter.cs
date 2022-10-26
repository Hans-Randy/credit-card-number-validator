using System.Text;
using Web.Models;
using Web.Constants;


namespace Web.Utils;

public static class FileWriter
{
    public static void WriteToFile(this List<CreditCard> list)
    {
        using (StreamWriter writer = new StreamWriter(Constant.CREDIT_CARD_FILENAME))  
        {
            foreach (var item in list)
            {
                writer.Write($"{item.Id},{item.Number},{item.CreditCardProviderName}");   
            }
        } 
    }
    
    public static void WriteToFile(this List<CreditCardProvider> list)
    {
        using (StreamWriter writer = new StreamWriter(Constant.CREDIT_CARD_PROVIDER_FILENAME))  
        {
            foreach (var item in list)
            {
                writer.Write($"{item.Id},{item.Name},{item.MajorIndustryIdentifier}");   
            }
        } 
    }
}