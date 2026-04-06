namespace Class09.ErrorHandling.Models;

public class Cinema
{
    public string Name { get; set; }
    public int Halls { get; set; }

    public List<Movie> ListOfMovies { get; set; } = new List<Movie>();

    public void MoviePlaying(Movie movie)
    {
        Console.WriteLine($"Watching {movie.Title}");
    }
}
