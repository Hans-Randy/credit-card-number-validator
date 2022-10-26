using Web.Models;
using Web.Utils;

namespace Web.Facade;

public class CreditCardProviderManager : IEntityManager<CreditCardProvider>
{
    private Lazy<List<CreditCardProvider>> _items;
    
    public CreditCardProviderManager()
    {
        _items = new Lazy<List<CreditCardProvider>>(() =>
        {
            return FileReader.ReadCreditCardProviderFile();
        });
    }

    public List<CreditCardProvider> Items => _items.Value;
    
    public void Remove(int id)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);

        if (item != null)
        {
            Items.Remove(item);    
        }
        
        Items.WriteToFile();
    }

    public void Add(CreditCardProvider creditCardProvider)
    {
        creditCardProvider.Id = Items.Count == 0 ? 1 : Items.Max(x => x.Id) + 1;
        Items.Add(creditCardProvider);
        Items.WriteToFile();
    }
    
    public void Update(CreditCardProvider creditCardProvider)
    {
        var item = Items.FirstOrDefault(x => x.Id == creditCardProvider.Id);

        if (item != null)
        {
            item.Name = creditCardProvider.Name;
            item.MajorIndustryIdentifier = creditCardProvider.MajorIndustryIdentifier;   
        }
        
        Items.WriteToFile();
    }
}