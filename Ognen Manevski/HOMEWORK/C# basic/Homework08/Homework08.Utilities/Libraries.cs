namespace Homework08.Libraries;

using Homework08.Libraries.Data;
using Homework08.Libraries.Enums;
using Homework08.Libraries.Models;
using System.Xml.Linq;

public static class Libraries
{
    public static void AddSongs(Person? person, List<Song>? songsToAdd)
    {
        if (person == null)
        {
            Console.WriteLine("Person not found.");
            return;
        }
        
        if (songsToAdd == null || songsToAdd.Count == 0)
        {
            Console.WriteLine("No songs to add.");
            return;
        }

        // Add songs that aren't already in favorites
        int addedCount = 0;
        foreach (var song in songsToAdd)
        {
            if (!person.FavSongs.Any(s => s.Title == song.Title))
            {
                person.FavSongs.Add(song);
                addedCount++;
            }
        }

        // Update favorite music type based on new songs
        person.UpdateFavMusicType();

        Console.WriteLine($"Added {addedCount} new songs to {person.Fname} {person.Lname}'s favorites.");
        
        // Display their favorites
        person.GetFavSongs();
    }
}
