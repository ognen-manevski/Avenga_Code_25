using TaxiManager9000.DataAccess.Interfaces;
using TaxiManager9000.Domain.BaseEntity;

namespace TaxiManager9000.DataAccess
{
    public class GenericDb<T> : IGenericDb<T> where T : BaseEntity
    {
        private List<T> _db;


        private int _idCounter = 0;

        public GenericDb()
        {
            _db = new List<T>();
        }

        public List<T> GetAll()
        {
            return _db;
        }

        public T GetById(int id)
        {
            return _db.FirstOrDefault(e => e.Id == id);
        }

        public int Add(T entity)
        {
            entity.Id = ++_idCounter; //use first then increment so we start from 1, not 0.
                                      //If we did _idCounter++ then the first entity would get Id 0, which is not ideal for an Id.
            _db.Add(entity);
            return entity.Id;
        }

        public bool Update(T entity)
        {
            try
            {
                T entityDb = GetById(entity.Id);
                entityDb = entity; //will this work? No, because entityDb is a copy of the reference to the object in the list,
                                   //not the actual object in the list.
                                   //So we need to find the index of the object in the list and update it there.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveById(int id)
        {
            try
            {
                T entityDb = GetById(id);
                _db.Remove(entityDb); //this will work because entityDb is a reference to the object in the list,
                                      //so removing it will remove the object from the list.
                return true;
            }
                catch (Exception ex)
            {
                return false;
            }
        }

        public List<T> FilterBy(Func<T, bool> filter)
        {
            return _db.Where(filter).ToList();
        }
    }
}
