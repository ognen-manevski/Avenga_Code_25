using TimeTrackingApp.DataAccess.FileHandlers;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.DataAccess.Repositories;

public class ActivityRepository : BaseRepository<ActivityRecord>
{
    public ActivityRepository() : base("activities.json") { }

    public List<ActivityRecord> GetByUserId(int userId)
    {
        _entities = JsonFileHandler.ReadFromFile<ActivityRecord>(_filePath);
        return _entities.Where(a => a.UserId == userId).ToList();
    }
}