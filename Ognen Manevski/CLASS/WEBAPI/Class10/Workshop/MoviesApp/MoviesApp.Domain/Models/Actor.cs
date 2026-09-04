namespace MoviesApp.Domain.Models;

public class Actor : BaseEntity
{
    //FirstName string required, max 50
    public required string FirstName { get; set; }
    //LastName string required, max 50
    public required string LastName { get; set; }
    //Movies List<Movie> many-to-many
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
