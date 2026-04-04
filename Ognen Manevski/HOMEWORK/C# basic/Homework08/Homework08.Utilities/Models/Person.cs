using Homework08.Libraries.Enums;
using System.ComponentModel.DataAnnotations;

namespace Homework08.Libraries.Models;

public class Person
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")] //for form validation
    public string Fname { get; set; } = "";
    public string Lname { get; set; } = "";
    public int Age { get; set; } = 0;
    public Genres? FavMusicType { get; set; }
    public List<Song>? FavSongs { get; set; }

    

    //ctor with all params for homework
    public Person(int id, string fName, string lName, int age, Genres favMusicType, List<Song> favSongs)
    {
        Id = id;
        Fname = fName;
        Lname = lName;
        Age = age;
        FavMusicType = favMusicType;
        FavSongs = favSongs ?? new List<Song>();
    }

    static int idCounter = 1;

    //ctor with optional params for blazor form
    public Person(string fName, string? lName, int age = 0, List<Song>? favSongs = null)
    {
        Id = idCounter++; //auto
        Fname = fName; //mandatory
        Lname = lName;
        Age = age;
        FavSongs = favSongs ?? new List<Song>();

        //always runs atleast once per initiation
        UpdateFavMusicType();
    }

    public void GetFavSongs()
    {
        if (FavSongs == null || FavSongs.Count == 0)
        {
            Console.WriteLine($"{Fname} {Lname} hates music.");
            return;
        }
        string hr = new string('-', 50);

        Console.WriteLine(hr);
        Console.WriteLine($"| {Fname} {Lname}'s favorite songs:".PadRight(49) + "|");
        Console.WriteLine(hr);
        foreach (var song in FavSongs)
        {
            Console.WriteLine($"| {song.Title.PadRight(20)} |" +
                $" {FormatSeconds(song.Length).PadRight(10)} |" +
                $" {song.Genre.ToString().PadRight(10)} |");
        }
        Console.WriteLine(hr);
    }

    //display helper
    public static string FormatSeconds(int sec)
    {
        return $"{sec / 60}:{(sec % 60).ToString("D2")}"; // Converts seconds to a "minutes:seconds" format
    }

    //gets the most common genre in fav songs if any
    public void UpdateFavMusicType()
    {
        if (FavSongs == null || FavSongs.Count == 0)
        {
            Console.WriteLine($"{Fname} {Lname} has no favorite songs to determine a favorite music genre.");
            //FavMusicType = null; // Default genre
            return;
        }


        var genreCounts = new Dictionary<Genres, int>();

        foreach (var song in FavSongs)
        {
            if (genreCounts.ContainsKey(song.Genre))
            {
                genreCounts[song.Genre]++;
            }
            else
            {
                genreCounts[song.Genre] = 1; //default
            }
        }

        FavMusicType = genreCounts.OrderByDescending(g => g.Value).First().Key;
    }
}