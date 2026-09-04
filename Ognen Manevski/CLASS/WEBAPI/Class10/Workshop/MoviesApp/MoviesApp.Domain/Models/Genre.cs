namespace MoviesApp.Domain.Models;

public class Genre : BaseEntity
{
    //Name string required, max 50, unique
    public required string Name { get; set; }
    //Movies List<Movie>
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
