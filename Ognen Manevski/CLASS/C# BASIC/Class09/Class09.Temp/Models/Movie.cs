namespace Class09.ErrorHandling.Models;

public class Movie
{
    public string Title { get; set; }
    public Genre Genre { get; set; }

    public int Rating { get; set; } = 0;

    public int TicketPrice { get; set; }


    public Movie(string title, Genre genre, int rating)
    {
        Title = title;
        Genre = genre;
        Rating = ValidateRating(rating);
        TicketPrice = 5 * rating;
    }

    private static int ValidateRating(int rating)
    {
        try
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentOutOfRangeException();
            }

        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("Rating must be between 1 and 5.");
        }

        catch (Exception ex)
        {
            Console.WriteLine("You must enter a number!");
        }

        return rating;
    }
}
