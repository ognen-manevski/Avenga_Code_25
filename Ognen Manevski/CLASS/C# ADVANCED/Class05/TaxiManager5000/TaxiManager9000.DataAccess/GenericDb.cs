namespace TaxiManager9000.DataAccess;

using TaxiManager9000.DataAccess.Interfaces;
using TaxiManager5000.Domain.BaseEntity;

public class GenericDb<T> : IGenericDb<T> where T : BaseEntity
{

    private List<T> _db;

    public GenericDb()
    {
        _db = new List<T>();
    }


    public int Add(T entity)
    {
        throw new NotImplementedException();
    }

    public bool Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public bool RemoveById(int id)
    {
        throw new NotImplementedException();
    }

    public bool Update(T entity)
    {
        throw new NotImplementedException();
    }
}
