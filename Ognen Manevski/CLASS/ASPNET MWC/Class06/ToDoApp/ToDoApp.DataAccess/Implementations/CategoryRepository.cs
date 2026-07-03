using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Implementations;

public class CategoryRepository : IRepository<Category>
{
    public void Create(Category entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity), "Category cannot be null");

        entity.Id = StaticDb.Categories.Last().Id + 1;

        StaticDb.Categories.Add(entity);
    }

    public void Delete(int id)
    {
        Category? category = StaticDb.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category with that ID does not exist");
        }

        StaticDb.Categories.Remove(category);
    }

    public List<Category> GetAll()
    {
        return StaticDb.Categories;
    }

    public Category GetById(int id)
    {
        Category? category = StaticDb.Categories.FirstOrDefault(c => c.Id == id);

        if (category == null)
        {
            throw new ArgumentNullException(nameof(category), "Category with that ID does not exist");
        }

        return category;
    }

    public void Update(Category entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Category cannot be null");
        }

        Category category = GetById(entity.Id);

        int index = StaticDb.Categories.IndexOf(category);

        StaticDb.Categories[index] = entity;
    }
}

//this is copy-paste basicaly from the TaskRepository, but it is for Category entity.
//It implements the IRepository<Category> interface and provides CRUD operations for Category objects in the StaticDb.
//can we write those CRUD operations in a more generic way, so we don't have to repeat the same code for each entity type?

//Yes, we can create a more generic repository that can handle CRUD operations for any entity type.
//This can be achieved by using generics in C#. Below is an example of how you can implement a generic repository:
