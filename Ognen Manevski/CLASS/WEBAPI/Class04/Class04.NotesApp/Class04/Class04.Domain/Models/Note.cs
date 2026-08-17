using Class04.Domain.Enums;

namespace Class04.Domain.Models;

public class Note : BaseEntity
{
    public string Text { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.Medium;
    public int? UserId { get; set; }
    public User? User {  get; set; }
    public List<Tag> Tags { get; set; } = [];

}
