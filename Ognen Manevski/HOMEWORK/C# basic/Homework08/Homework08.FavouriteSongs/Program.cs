//==========================================
#region Task Description
//==========================================

/*
EXERCISE 1

Create a class Song with:
    Title
    Length
    Genre (enum: Rock, Hip_Hop, Techno, Classical)

Create a class Person with:
    Id
    FirstName
    LastName
    Age
    FavoriteMusicType (Genre enum)
    FavoriteSongs (List of Songs)

Create a method called GetFavSongs() that:
    Prints all titles of favorite songs
    Or prints a message that the person hates music if the list is empty
*/

/*
//EXERCISE 2
//Select the person Jerry and add all the songs which start with the letter B.
//Select the person Maria and add all the songs with length longer than 6 min.
//Select the person Jane and add all the songs that are of genre Rock.
//Select the person Stefan and add all songs shorter than 3 min and of genre Hip-Hop.
//Select all persons from the persons array that have 4 or more songs.
 */


#endregion
//==========================================

using Homework08.Libraries.Data;
using Homework08.Libraries.Models;
using Homework08.Libraries.Enums;
using Homework08.Libraries;

//initializing the data lists
DataLists dataLists = new DataLists();

//dataLists.personsList[0].GetFavSongs();

//EXERCISE 2
//Select the person Jerry and add all the songs which start with the letter B.

string hr = new('-', 20);
string space = new('=', 10);

Console.WriteLine($"{space} Exercise 1 and 2 - People & Songs {space}");

//Person jerry = persons.FirstOrDefault(p => p.Fname == "Jerry");
//List<Song> songsB = songs.Where(s => s.Title.StartsWith("B")).ToList();

Console.WriteLine($"Jerry {hr}");

var jerry = dataLists.FindPersons("Jerry").FirstOrDefault();
List<Song> songsB = dataLists.FindSongs(title: "B").ToList();
Libraries.AddSongs(jerry, songsB);

//Select the person Maria and add all the songs with length longer than 6 min.

Console.WriteLine($"Maria {hr}");

var maria = dataLists.FindPersons("Maria").FirstOrDefault();
List<Song> songs6Min = dataLists.FindSongs(minLength: 6 * 60).ToList();
Libraries.AddSongs(maria, songs6Min);

//Select the person Jane and add all the songs that are of genre Rock.

Console.WriteLine($"Jane {hr}");

var jane = dataLists.FindPersons("Jane").FirstOrDefault();
List<Song> songsRock = dataLists.FindSongs(genre: Genres.Rock).ToList();
Libraries.AddSongs(jane, songsRock);

//Select the person Stefan and add all songs shorter than 3 min and of genre Hip-Hop.

Console.WriteLine($"Stefan {hr}");

var stefan = dataLists.FindPersons("Stefan").FirstOrDefault();
List<Song> songs3min = dataLists.FindSongs(maxLength: 3 * 60, genre: Genres.Hip_Hop).ToList();
Libraries.AddSongs(stefan, songs3min);

//Select all persons from the persons array that have 4 or more songs.

Console.WriteLine($"4 or More {hr}");

List<Person> persons4Plus = dataLists.personsList.Where(p => p.FavSongs.Count >= 4).ToList();

if (persons4Plus.Count == 0)
{
    Console.WriteLine("No persons found with 4 or more songs.");
}
else
{
    foreach (var person in persons4Plus)
    {
        Console.WriteLine($"{person.Fname} {person.Lname} has {person.FavSongs.Count} favorite songs.");
    }
}