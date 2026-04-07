namespace Homework09.CinemaSystem.Models;

using Homework09.CinemaSystem.Enums;

//Movie must have:
//    Title
//    Genre
//    Rating
//    TicketPrice

//Constructor must:
//    Set Title
//    Set Genre
//    Set Rating
//    Set TicketPrice = 5 * Rating

//Rating must:
//    Be between 1 and 5
//    Throw exception if out of range
//    Handle other possible exceptions


public class Movie
{
    public string Title { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public int Rating { get; set; } = 1; //default
    public int TicketPrice { get; set; } = 0;


    public Movie(string title, Genre genre, int rating)
    {
        Title = title;
        Genre = genre;
        Rating = CheckRating(rating);
        TicketPrice = 5 * Rating;
    }

    private int CheckRating(int rating)
    {
        try
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be a number between 1 and 5.");
                //nameof(rating) -> name of the parameter that caused the exception.                
            }
            return rating;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        return 1; //default
    }

}

