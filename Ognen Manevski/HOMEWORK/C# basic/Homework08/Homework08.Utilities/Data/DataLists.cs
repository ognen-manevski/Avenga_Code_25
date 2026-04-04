namespace Homework08.Libraries.Data;

using Homework08.Libraries.Models;
using Homework08.Libraries.Enums;


public class DataLists
{
    //initialize the lists of songs and persons
    public List<Song> songsList;
    public List<Person> personsList;

    //============================
    //CTOR TO POPULATE THE LISTS WITH DEFAULT DATA
    //============================

    //constructor to populate the lists with default data
    //i will then just use [DataLists dataLists = new DataLists();] in Program.cs to initialize
    public DataLists()
    {
        songsList = new List<Song>()
        {
             new Song("Bohemian Rhapsody", 355, Genres.Rock),
             new Song("Lose Yourself", 326, Genres.Hip_Hop),
             new Song("Sandstorm", 225, Genres.Techno),
             new Song("Fur Elise", 173, Genres.Classical),
             new Song("Back in Black", 255, Genres.Rock),
             new Song("Billie Jean", 294, Genres.Hip_Hop),
             new Song("Clocks", 307, Genres.Rock),
             new Song("Canon in D", 360, Genres.Classical),
             new Song("Satisfaction", 223, Genres.Rock),
             new Song("Gangnam Style", 219, Genres.Hip_Hop),
             new Song("One More Time", 320, Genres.Techno),
             new Song("Symphony No. 5", 425, Genres.Classical),
             new Song("Stairway to Heaven", 482, Genres.Rock),
             new Song("Hey Jude", 431, Genres.Rock),
             new Song("Smells Like Teen Spirit", 301, Genres.Rock),
             new Song("Thriller", 358, Genres.Hip_Hop),
             new Song("Viva La Vida", 242, Genres.Rock),
             new Song("Clair de Lune", 300, Genres.Classical),
             new Song("Enter Sandman", 331, Genres.Rock),
             new Song("Uptown Funk", 270, Genres.Hip_Hop),
             new Song("Levels", 215, Genres.Techno),
             new Song("The Four Seasons", 2520, Genres.Classical),
             new Song("Hotel California", 390, Genres.Rock),
             new Song("Shape of You", 263, Genres.Hip_Hop),
             new Song("Don't Stop Believin'", 250, Genres.Rock),
             new Song("Swan Lake", 450, Genres.Classical),
             new Song("Born to Run", 270, Genres.Rock),
             new Song("Lose Control", 230, Genres.Hip_Hop)
        };

        personsList = new List<Person>()
        {
            //songsList[index] for easy reference to the songs in the songsList
            new Person(1, "Jerry", "Smith", 30, Genres.Rock, new List<Song>()
            {
                songsList[1], songsList[2], songsList[3], songsList[4]
            }),
            new Person(2, "Maria", "Garcia", 25, Genres.Classical, new List<Song>()
            {
                songsList[0], songsList[3], songsList[11], songsList[12]
            }),
            new Person(3, "Jane", "Doe", 28, Genres.Rock, new List<Song>()),
            new Person(4, "Stefan", "Müller", 35, Genres.Hip_Hop, new List<Song>()),
            new Person(5, "Alice", "Johnson", 22, Genres.Techno, new List<Song>()
            {
                songsList[2], songsList[10]
            }),
            new Person(6, "Bob", "Brown", 40, Genres.Hip_Hop, new List<Song>()
            {
                songsList[1], songsList[5], songsList[9], songsList[15], songsList[27]
            }),
            new Person(7, "Charlie", "Davis", 27, Genres.Classical, new List<Song>()
            {
                songsList[7]
            }),
            new Person(8, "Diana", "Miller", 32, Genres.Rock, new List<Song>()
            {
                songsList[6], songsList[14], songsList[18]
            }),
            new Person(9, "Eve", "Wilson", 29, Genres.Techno, new List<Song>()
            {
                songsList[2], songsList[20]
            }),
            new Person(10, "Frank", "Taylor", 31, Genres.Hip_Hop, new List<Song>()
            {
                songsList[1]
            }),
            new Person(11, "Grace", "Anderson", 26, Genres.Classical, new List<Song>()
            {
                songsList[3], songsList[7], songsList[11], songsList[17], songsList[21], songsList[25]
            }),
            new Person(12, "Hank", "Thomas", 33, Genres.Rock, new List<Song>()
            {
                songsList[0], songsList[12], songsList[24]
            }),
            new Person(13, "Ivy", "Moore", 24, Genres.Techno, new List<Song>()
            {
                songsList[10], songsList[20]
            }),
            new Person(14, "Jack", "Martin", 38, Genres.Hip_Hop, new List<Song>()
            {
                songsList[5], songsList[19]
            }),
            new Person(15, "Karen", "Lee", 27, Genres.Classical, new List<Song>()),
            new Person(16, "Leo", "Garcia", 29, Genres.Rock, new List<Song>()
            {
                songsList[4], songsList[8], songsList[12], songsList[16], songsList[22]
            }),
            new Person(17, "Mia", "Clark", 26, Genres.Techno, new List<Song>()
            {
                songsList[2]
            }),
            new Person(18, "Nina", "Rodriguez", 30, Genres.Hip_Hop, new List<Song>()
            {
                songsList[9], songsList[23]
            }),
            new Person(19, "Oscar", "Lewis", 34, Genres.Classical, new List<Song>()
            {
                songsList[11], songsList[17], songsList[21]
            }),
            new Person(20, "Paul", "Walker", 28, Genres.Rock, new List<Song>())
        };
    }

    //============================
    //BUILT-IN SEARCH METHODS
    //============================

    //Find all the persons whose first name starts with the given query string
    public List<Person> FindPersons(string query)
    {
        query = query.Trim().ToLower(); //trim and case

        List<Person> filtered = personsList.Where(p => (p.Fname + p.Lname).ToLower() //searc in both first and last name
        .StartsWith(query)).ToList();

        if (filtered.Count == 0 || filtered == null)
        {
            Console.WriteLine("No persons found matching the criteria.");
            return new List<Person>();
        }
        return filtered;
    }

    //search in songs list with given OPTIONAL query parameters: title, min/maxLength, genre
    public List<Song> FindSongs(string? title = null, int? minLength = null, int? maxLength = null, Genres? genre = null)
    {

        if (!string.IsNullOrEmpty(title))
        {
            title = title.Trim().ToLower(); //trim and case
        }

        if (maxLength.HasValue && minLength.HasValue && maxLength < minLength)
        {
            Console.WriteLine("Invalid length range.");
            return new List<Song>();
        }

        List<Song> filtered = songsList.Where(s =>
            (string.IsNullOrEmpty(title) || s.Title.ToLower().StartsWith(title)) && //filter title
            (!minLength.HasValue || s.Length >= minLength.Value) && //filter min length
            (!maxLength.HasValue || s.Length <= maxLength.Value) && //filter max length
            (!genre.HasValue || s.Genre == genre.Value) //filter genre
        ).ToList();

        if (filtered.Count == 0 || filtered == null)
        {
            Console.WriteLine("No songs found matching the criteria.");
            return new List<Song>();
        }
        return filtered;
    }


}

