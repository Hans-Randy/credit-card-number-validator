namespace Web.Models;

public class CreditCardProvider : ICreditCardProvider
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MajorIndustryIdentifier { get; set; }
}