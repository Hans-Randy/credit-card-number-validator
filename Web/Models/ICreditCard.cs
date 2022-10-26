namespace Web.Models;

public interface ICreditCard
{
    public int Id { get; set; }
    public string Number { get; set; }

    public string CreditCardProviderName { get; set; }
}