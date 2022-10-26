using System.ComponentModel.DataAnnotations;

namespace Web.Models;

public class CreditCard : ICreditCard
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string CreditCardProviderName { get; set; } = string.Empty;
}