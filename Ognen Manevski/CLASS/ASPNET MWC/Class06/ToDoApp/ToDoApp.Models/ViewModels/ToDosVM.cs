namespace ToDoApp.Models.ViewModels;

public class ToDosVM
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int StatusId { get; set; }
    public string StatusName { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
