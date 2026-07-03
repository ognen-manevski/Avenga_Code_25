//EXAMPLE

using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;

namespace ToDoApp.DataAccess.Interfaces;

public interface IToDoRepository : IRepository<ToDo>
{

}
