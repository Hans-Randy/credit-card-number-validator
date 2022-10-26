namespace Web.Facade;

public interface IEntityManager<T>
{
    public void Remove(int id);

    public void Add(T creditCardProvider);

    public void Update(T creditCardProvider);
}