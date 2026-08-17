using Class04.DataAccess.Interfaces;
using Class04.Domain.Models;

namespace Class04.DataAccess.Implementations;

public class UserRepository : IUserRepository
{
    public void Add(Note entity)
    {
        throw new NotImplementedException();
    }

    public void Add(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Note entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }

    public List<Note> GetAll()
    {
        throw new NotImplementedException();
    }

    public Note? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Note entity)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    List<User> IRepository<User>.GetAll()
    {
        throw new NotImplementedException();
    }

    User? IRepository<User>.GetById(int id)
    {
        throw new NotImplementedException();
    }
}
