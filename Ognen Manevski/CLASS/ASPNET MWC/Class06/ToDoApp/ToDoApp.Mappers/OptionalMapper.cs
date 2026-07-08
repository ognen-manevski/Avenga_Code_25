using Microsoft.VisualBasic;
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;

namespace ToDoApp.Mapper;

public static class OptionalMapper
{
    public static ToDosVM MapToToDosVM(ToDo todo, string categoryName, string statusName)
    {
        return new ToDosVM
        {
            Id = todo.Id,
            Description = todo.Description,
            DueDate = todo.DueDate,
            StatusId = todo.StatusId,
            StatusName = statusName ?? string.Empty,
            CategoryId = todo.CategoryId,
            CategoryName = categoryName ?? string.Empty
        };
    }
}
