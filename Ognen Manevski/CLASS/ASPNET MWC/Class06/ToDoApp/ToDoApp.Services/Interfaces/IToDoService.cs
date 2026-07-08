using ToDoApp.Models.ViewModels;

namespace ToDoApp.Services.Interfaces;

public interface IToDoService
{
    List<ToDosVM> GetAllToDos(int? categoryId, int? statusId);
}
