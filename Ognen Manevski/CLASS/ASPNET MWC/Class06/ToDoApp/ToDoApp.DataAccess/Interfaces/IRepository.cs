using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces;

//CRUD methods for the repository pattern (for accesing the db)
public interface IRepository<T> where T : BaseEntity
{
    //CRUD
    List<T> GetAll(); //Read all
    T GetById(int id); //Read by id
    void Create(T entity); //Create
    void Update(T entity); //Update
    void Delete(int id); //Delete by id
}
