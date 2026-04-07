using Homework09.CinemaSystem.Enums;

//===================================================
#region Requirements
//===================================================

//Requirements

//Make a class Movie.
//Make a class Cinema.
//We will provide 10 movies per cinema to put in the cinema movies list.

//Make a user interface that :

//    Lets the user choose a cinema.
//    Then choose:
//        All movies
//        By genre

//If "All movies":

//    Show all movies
//    Let user choose a movie
//    Call MoviePlaying()

//If "By genre":

//    Ask user for favorite genre
//    Show movies from that genre
//    Let user choose a movie

//If user enters wrong input:

//    Throw an exception
//    Handle all exceptions using Try/ Catch


#endregion
//===================================================

using Homework09.CinemaSystem.Models;

string hr = new string('-', 30);
string border = new string('=', 10);



//init
List<Movie> c1Movies = new List<Movie>()
{
    new Movie("The Hangover", Genre.Comedy, 1),
    new Movie("Superbad", Genre.Comedy, 4),
    new Movie("The Conjuring", Genre.Horror, 5),
    new Movie("Die Hard", Genre.Action, 3),
    new Movie("John Wick", Genre.Action, 4),
    new Movie("The Shawshank Redemption", Genre.Drama, 2),
    new Movie("Forrest Gump", Genre.Drama, 5),
    new Movie("Interstellar", Genre.SciFi, 2),
    new Movie("The Matrix", Genre.SciFi, 5),
    new Movie("Deadpool", Genre.Comedy, 4)
};

List<Movie> c2Movies = new List<Movie>()
{
    new Movie("Step Brothers", Genre.Comedy, 3),
    new Movie("A Quiet Place", Genre.Horror, 1),
    new Movie("Hereditary", Genre.Horror, 4),
    new Movie("Mad Max: Fury Road", Genre.Action, 5),
    new Movie("The Dark Knight", Genre.Action, 3),
    new Movie("The Godfather", Genre.Drama, 1),
    new Movie("Inception", Genre.SciFi, 5),
    new Movie("Blade Runner 2049", Genre.SciFi, 4),
    new Movie("Pulp Fiction", Genre.Drama, 2),
    new Movie("Tropic Thunder", Genre.Comedy, 4)
};

List<Cinema> cinemas = new List<Cinema>()
{
    new Cinema() { Name = "Cineplexx", Halls = 5, ListOfMovies = c1Movies },
    new Cinema() { Name = "Netflix", Halls = 3, ListOfMovies = c2Movies }
};

//error handling helper

int GetMinMaxChoiceNum(int min, int max)
{
    while (true)
    {
        Console.Write($"Enter a number between {min} and {max}: ");
        string input = Console.ReadLine() ?? string.Empty;
        try
        {
            int choice = int.Parse(input);
            if (choice < min || choice > max)
            {
                throw new ArgumentOutOfRangeException(nameof(choice), $"Please enter a number between {min} and {max}.");
            }
            return choice;
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

//================ UI =================

bool exit = false;

while (!exit)
{
    Console.WriteLine($"{border} Cinema System {border}");
    Console.WriteLine("Please Choose a cinema:");
    foreach (var cinema in cinemas)
    {
        Console.WriteLine($"{cinemas.IndexOf(cinema) + 1}. {cinema.Name}");
    }

    int cinemaChoice = GetMinMaxChoiceNum(1, cinemas.Count);
    Cinema selectedCinema = cinemas[cinemaChoice - 1];

    Console.WriteLine(hr);

    Console.WriteLine($"You have selected: {selectedCinema.Name}");
    Console.WriteLine(@"
Please choose how would you like to view the movies:
1. All movies
2. By genre
");

    int viewChoice = GetMinMaxChoiceNum(1, 2);

    if (viewChoice == 1)
    {
        ShowAllMovies(selectedCinema);
    }
    else
    {
        ShowMoviesByGenre(selectedCinema);
    }

    Console.WriteLine(hr);

    Console.WriteLine("Enter [Y] to go back to start or any other key to exit:");

    string exitInput = Console.ReadLine() ?? string.Empty;

    if (!exitInput.Equals("y", StringComparison.OrdinalIgnoreCase))
    {
        exit = true;
    }

}


//helpers for UI

void ShowAllMovies(Cinema cinema)
{
    Console.WriteLine($"Showing all movies for cinema: {cinema.Name}");
    Console.WriteLine(hr);
    try
    {
        if (cinema.ListOfMovies == null || cinema.ListOfMovies.Count == 0)
        {
            throw new InvalidOperationException("No movies available in this cinema.");
        }

        Console.WriteLine(hr);
        PrintMovies(cinema.ListOfMovies);

        Movie selected = SelectMovie(cinema.ListOfMovies, cinema.ListOfMovies.Count);

        cinema.MoviePlaying(selected);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while displaying movies: {ex.Message}");
    }
}

void ShowMoviesByGenre(Cinema cinema)
{
    Console.WriteLine("Please select a genre:");
    foreach (var genre in Enum.GetValues(typeof(Genre)))
    {
        Console.WriteLine($"{(int)genre}. {genre}");
    }

    int genreInput = GetMinMaxChoiceNum(1, Enum.GetNames(typeof(Genre)).Length);
    try
    {
        Genre selectedGenre = (Genre)(genreInput - 1);

        //filter
        List<Movie> moviesByGenre = cinema.ListOfMovies.Where(m => m.Genre == selectedGenre).ToList();

        if (moviesByGenre.Count == 0)
        {
            Console.WriteLine($"No movies found for genre: {selectedGenre}");
            throw new InvalidOperationException($"No movies found for genre: {selectedGenre}");
        }

        Console.WriteLine($"Showing movies for genre: {selectedGenre}");
        Console.WriteLine(hr);
        PrintMovies(moviesByGenre);

        Movie selected = SelectMovie(moviesByGenre, moviesByGenre.Count);

        cinema.MoviePlaying(selected);

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
}


Movie SelectMovie(List<Movie> movies, int max)
{
    Console.WriteLine($"Please select a movie from the list [1] to [{max}]:");
    int choice = GetMinMaxChoiceNum(1, max);
    return movies[choice - 1];
}

//helper
void PrintMovies(List<Movie> moviesList)
{
    foreach (Movie m in moviesList)
    {
        Console.WriteLine(@$"| {m.Title} | {m.Genre} | Rating: {m.Rating} | Ticket Price: ${m.TicketPrice} |");
        Console.WriteLine(hr);
    }
}