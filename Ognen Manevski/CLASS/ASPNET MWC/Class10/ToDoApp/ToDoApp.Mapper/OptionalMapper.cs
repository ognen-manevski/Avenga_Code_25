
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;
using ToDoApp.Models.Dtos;

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
            StatusName = statusName ?? string.Empty,
            CategoryName = categoryName ?? string.Empty
        };
    }


    public static CategoryDto MapToCategoryDto(Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public static StatusDto MapToStatusDto(Status status)
    {
        return new StatusDto
        {
            Id = status.Id,
            Name = status.Name
        };
    }

    public static ToDo CreateTodoVMToToDo(CreateToDoVm createToDoVm)
    {
        return new ToDo
        {
            Description = createToDoVm.Description,
            DueDate = createToDoVm.DueDate,
            CategoryId = createToDoVm.CategoryId,
            StatusId = 1 // DEFAULT STATUS: OPEN
        };
    }



}
