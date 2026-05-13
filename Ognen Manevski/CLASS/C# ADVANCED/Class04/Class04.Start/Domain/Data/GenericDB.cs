using Class04.Generics.Domain.Interfaces;

namespace Class04.Generics.Domain.Data;

public class GenericDB<T> : IGenericDB<T> where T : BaseEntity //T has to be a class that inherits from BaseEntity
{
    private List<T> Db;

    public GenericDB()
    {
        Db = new List<T>();
    }

    public void PrintAll()
    {
        Console.WriteLine($"\nPrinting all items in {typeof(T).Name} DB:");
        foreach (var item in Db)
        {
            Console.WriteLine(item.GetInfo()); //item.ToString() will be called implicitly!
                                               //where T : BaseEntity -> we now can call GetInfo() instead!
        }
    }

    public T GetById(int id)
    {
        T item = Db.FirstOrDefault(i => i.Id == id);
        ArgumentNullException.ThrowIfNull(item, $"Item with id {id} was not found in the {typeof(T).Name} DB");
        return item;
    }

    public T GetByIndex(int index)
    {
        return Db[index];
    }

    public void Insert(T entity)
    {
        Console.WriteLine($"Item was added in the {typeof(T).Name} DB");
        Db.Add(entity);
    }

    public void RemoveByID(int id)
    {
        T item = GetById(id);
        Db.Remove(item);
    }

}
