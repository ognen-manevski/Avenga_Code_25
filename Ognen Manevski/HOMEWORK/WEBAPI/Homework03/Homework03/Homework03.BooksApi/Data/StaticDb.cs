using Homework03.BooksApi.Models;

namespace Homework03.BooksApi.Data;

public static class StaticDb
{
    public static List<Book> Books { get; set; } = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Author = "F. Scott Fitzgerald",
            Title = "The Great Gatsby"
        },
        new Book()
        {
            Id = 2,
            Author = "Harper Lee",
            Title = "To Kill a Mockingbird"
        },
        new Book()
        {
            Id = 3,
            Author = "George Orwell",
            Title = "1984"
        }
    };


    public static void AddBook(Book book)
    {
        int id = Books.Last().Id + 1;
        book.Id = id; // overwrite
        Books.Add(book);
    }

}
