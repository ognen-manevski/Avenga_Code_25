using TimeTrackingApp.DataAccess.FileHandlers;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.DataAccess.Repositories;

public class UserRepository : BaseRepository<User>
{
    public UserRepository() : base("users.json") { }

    public User? GetByUsername(string username)
    {
        _entities = JsonFileHandler.ReadFromFile<User>(_filePath);
        return _entities.FirstOrDefault(u => u.Username == username);
    }
}