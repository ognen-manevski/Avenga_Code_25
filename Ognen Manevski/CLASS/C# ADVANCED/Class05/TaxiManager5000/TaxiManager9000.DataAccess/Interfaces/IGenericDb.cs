namespace TaxiManager9000.DataAccess.Interfaces;

using TaxiManager5000.Domain.BaseEntity;

public interface IGenericDb<T> where T : BaseEntity
{
    int Add(T entity);
    bool Update(T entity);
    bool Delete(T entity);
    bool RemoveById(int id);
    List<T> GetAll();
    T GetById(int id);

}
