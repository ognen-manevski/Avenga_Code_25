namespace Class04.Generics.Domain.Interfaces
{
    public interface IGenericDB<T>
    {
        public void PrintAll();
        public T GetById(int id);
        public T GetByIndex(int index);
        public void Insert(T entity);
        public void RemoveByID(int id);
    }
}
