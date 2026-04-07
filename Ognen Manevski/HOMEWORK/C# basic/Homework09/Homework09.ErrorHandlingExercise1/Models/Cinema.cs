namespace Homework09.CinemaSystem.Models;
//Cinema must have:
//    Name
//    Halls
//    ListOfMovies

//Cinema must have method MoviePlaying(movie) that prints:
//    Watching Movie.Title
public class Cinema
{
    public string Name { get; set; } = string.Empty;
    public int Halls { get; set; } = 1;
    public List<Movie> ListOfMovies { get; set; } = new List<Movie>();

    public void MoviePlaying(Movie movie)
    {
        Console.WriteLine($"Watching {movie.Title}");
    }
}
