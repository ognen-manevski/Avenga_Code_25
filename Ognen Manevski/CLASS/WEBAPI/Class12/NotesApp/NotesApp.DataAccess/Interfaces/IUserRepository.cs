using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<bool> CheckUserNameExistsAsync(string username);
    Task<User?> GetByUsernameAsync(string username);
}
