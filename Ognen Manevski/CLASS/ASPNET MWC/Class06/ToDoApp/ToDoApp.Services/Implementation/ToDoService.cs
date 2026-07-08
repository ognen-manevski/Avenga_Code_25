using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Models.ViewModels;
using ToDoApp.Domain;
using ToDoApp.Mapper;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Services.Implementation;

internal class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;
    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Status> _statusRepository;

    public ToDoService(IToDoRepository toDoRepository, IRepository<Category> categoryRepository, IRepository<Status> statusRepository)
    {
        _toDoRepository = toDoRepository;
        _categoryRepository = categoryRepository;
        _statusRepository = statusRepository;
    }

    public List<ToDosVM> GetAllToDos(int? categoryId, int? statusId)
    {
        List<ToDo> todos = _toDoRepository.GetAll();

        //FILTER
        //if both are provided -> both are applied
        if (categoryId.HasValue && categoryId.Value > 0)
        {
            todos = todos.Where(t => t.CategoryId == categoryId.Value).ToList();
        }
        if (statusId.HasValue && statusId.Value > 0)
        {
            todos = todos.Where(t => t.StatusId == statusId.Value).ToList();
        }


        var result = new List<ToDosVM>();

        foreach (var t in todos)
        {

            var category = _categoryRepository.GetById(t.CategoryId);
            var status = _statusRepository.GetById(t.StatusId);

            var todoVM = OptionalMapper.MapToToDosVM(t, category?.Name, status?.Name);
            result.Add(todoVM);
        }

        return result;
    }
}
