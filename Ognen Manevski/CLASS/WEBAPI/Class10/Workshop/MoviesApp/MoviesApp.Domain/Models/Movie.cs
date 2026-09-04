namespace MoviesApp.Domain.Models;

public class Movie : BaseEntity
{
    //Title string required, max 200
    public required string Title { get; set; }
    //Description string? optional, max 1000
    public string? Description { get; set; } = string.Empty;
    //Year int required
    public required int Year { get; set; }
    //DurationMinutes int required
    public required int DurationMinutes { get; set; }
    //GenreId int required FK → Genre
    public required int GenreId { get; set; }
    //DirectorId  int? optional FK → Director
    public int? DirectorId { get; set; }
    //Actors  List < Actor > many - to - many
    public List<Actor> Actors { get; set; } = new List<Actor>();
}
