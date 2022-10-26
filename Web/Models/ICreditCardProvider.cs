namespace Web.Models;

public interface ICreditCardProvider
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MajorIndustryIdentifier { get; set; }
}