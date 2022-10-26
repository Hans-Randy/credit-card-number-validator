using Web.Models;
using Web.Utils;

namespace Web.Facade;

public class CreditCardManager : IEntityManager<CreditCard>
{
    private Lazy<List<CreditCard>> _items;
    
    public CreditCardManager()
    {
        _items = new Lazy<List<CreditCard>>(() =>
        {
            return FileReader.ReadCreditCardFile();
        });
    }

    public List<CreditCard> Items => _items.Value;
    
    public void Remove(int id)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);

        if (item != null)
        {
            Items.Remove(item);    
        }
        
        Items.WriteToFile();
    }

    public void Add(CreditCard creditCard)
    {
        creditCard.Id = Items.Count == 0 ? 1 : Items.Max(x => x.Id) + 1;
        Items.Add(creditCard);
        Items.WriteToFile();
    }
    
    public void Update(CreditCard creditCard)
    {
        var item = Items.FirstOrDefault(x => x.Id == creditCard.Id);
        item.Number = creditCard.Number;
        item.CreditCardProviderName = creditCard.CreditCardProviderName;
        Items.WriteToFile();
    }
}