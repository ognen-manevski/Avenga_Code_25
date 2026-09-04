namespace MoviesApp.Domain.Models;

public class Director : BaseEntity
{
    //FirstName string required, max 50
    public required string FirstName { get; set; }
    //LastName string required, max 50
    public required string LastName { get; set; }
    //DateOfBirth DateTime?	optional, stored as date — not datetime2
    public DateTime? DateOfBirth { get; set; }
    //Movies List<Movie>
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
