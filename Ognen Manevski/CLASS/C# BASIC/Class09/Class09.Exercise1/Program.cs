using Class09.Exercise1.Models;

/*
using System.Text.RegularExpressions;

EXERCISE 1
Make a user interface that :

Lets the user choose a cinema.
Then choose:
All movies
By genre
If "All movies":

Show all movies
Let user choose a movie
Call MoviePlaying()
If "By genre":

Ask user for favorite genre
Show movies from that genre
Let user choose a movie
If user enters wrong input:

Throw an exception
Handle all exceptions using Try/ Catch
*/


string hr = new string('-', 30);
string space = new string('=', 10);

//init  movies
List<Movie> movies = new List<Movie>() {
    new Movie("The Hangover", Genre.Comedy, 4),
    new Movie("The Conjuring", Genre.Horror, 5),
    new Movie("Avengers: Endgame", Genre.Action, 5),
    new Movie("The Shawshank Redemption", Genre.Drama, 5),
    new Movie("Inception", Genre.SciFi, 4),
    new Movie("Superbad", Genre.Comedy, 3),
    new Movie("Get Out", Genre.Horror, 4),
    new Movie("Mad Max: Fury Road", Genre.Action, 4),
    new Movie("The Godfather", Genre.Drama, 5),
    new Movie("Interstellar", Genre.SciFi, 5),
    new Movie("The Hangover", Genre.Comedy, 4),
    new Movie("The Conjuring", Genre.Horror, 5),
    new Movie("Avengers: Endgame", Genre.Action, 5),
    new Movie("The Shawshank Redemption", Genre.Drama, 5),
    new Movie("Inception", Genre.SciFi, 4),
    new Movie("Superbad", Genre.Comedy, 3),
    new Movie("Get Out", Genre.Horror, 4),
    new Movie("Mad Max: Fury Road", Genre.Action, 4),
    new Movie("The Godfather", Genre.Drama, 5),
};

//init cinemas
List<Cinema> cinemas = new List<Cinema>() {
    new Cinema( "Cinema City", 5, new List<Movie>{ movies[0], movies[1], movies[2], movies[3] }),
    new Cinema( "Cineplex", 3, new List<Movie>{ movies[4], movies[5], movies[6] })
};


Console.WriteLine($"{space} Cinema Exercise {space}");

Console.WriteLine("Please choose a cinema:");

int count = 1;

foreach (Cinema c in cinemas)
{
    Console.WriteLine($"{count} {c.Name}");
}

while (true)
{
    try
    {
        int cinemaPick = Int32.Parse(Console.ReadLine());

        while (cinemaPick < 1 || cinemaPick > cinemas.Count)
        {
            Console.WriteLine("Invalid input. Please choose a valid cinema number:");
            continue;
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Please enter a number");
        continue;
    }

}

Console.WriteLine(hr);



Console.WriteLine("Please choose:");
Console.WriteLine("1. Show All Movies");
Console.WriteLine("2. Sort by Genre");
Console.WriteLine(hr);





