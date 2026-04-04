using Homework08.Libraries.Enums;

namespace Homework08.Libraries.Models;

public class Song
{
    public string Title { get; set; }
    public int Length { get; set; } //seconds
    public Genres Genre { get; set; }

    public Song(string title, int length, Genres genre)
    {
        Title = title;
        Length = length;
        Genre = genre;
    }
}
