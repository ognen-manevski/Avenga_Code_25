using TimeTrackingApp.DataAccess.FileHandlers;
using TimeTrackingApp.DataAccess.Interfaces;
using TimeTrackingApp.Domain.Models;

namespace TimeTrackingApp.DataAccess.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
{
    protected readonly string _filePath;
    protected List<T> _entities;

    protected BaseRepository(string fileName)
    {
        _filePath = Path.Combine(AppContext.BaseDirectory, "Data", fileName);
        JsonFileHandler.EnsureFileExists(_filePath);
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
    }

    //===============================
    #region GetBy .... Id, NextId, GetAll
    //===============================

    //Specific GET methods in separate User/Activity class

    public virtual List<T> GetAll()
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        return _entities;
    }

    public virtual T? GetById(int id)
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        return _entities.FirstOrDefault(e => e.Id == id);
    }

    public virtual int GetNextId()
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        return _entities.Any() ? _entities.Max(e => e.Id) + 1 : 1;
    }

    #endregion
    //===============================



    //===============================
    #region ADD, UPDATE, DELETE
    //===============================

    public virtual void Add(T entity)
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        entity.Id = GetNextId();
        _entities.Add(entity);
        JsonFileHandler.WriteToFile(_filePath, _entities);
    }

    public virtual void Update(T entity)
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        var existingEntity = _entities.FirstOrDefault(e => e.Id == entity.Id);

        if (existingEntity != null)
        {
            _entities.Remove(existingEntity);
            _entities.Add(entity);
            JsonFileHandler.WriteToFile(_filePath, _entities);
        }
    }

    public virtual void Delete(int id)
    {
        _entities = JsonFileHandler.ReadFromFile<T>(_filePath);
        var entity = _entities.FirstOrDefault(e => e.Id == id);

        if (entity != null)
        {
            _entities.Remove(entity);
            JsonFileHandler.WriteToFile(_filePath, _entities);
        }
    }

    #endregion
    //===============================
}
