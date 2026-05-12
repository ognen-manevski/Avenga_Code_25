/*
Task #1 - Searchable

Create an interface Searchable with a method:

bool Search(string word);

The method returns true if word appears in the object's content, false otherwise (case-insensitive).

Create two classes that implement Searchable:

    Document - has a Title and a Content field (both string). Search looks inside Content.
    WebPage - has a Url and an Html field (both string). Search looks inside Html, ignoring HTML tags (a simple Regex.Replace(html, "<.*?>", "") is enough).

In Program.cs, create one Document and one WebPage, call Search on each with a word that exists and one that doesn't, and print the results.
*/

//Task #1 - Searchable

using Homework02.Task01_Searchable.Models;

Document document = new Document { Title = "My Document", Content = "This is the content of the document." };
printHelper("content", document.Search("content"), "document content"); //true
printHelper("missing", document.Search("missing"), "document content"); //false

WebPage page = new WebPage { Url = "https://example.com", Html = "<html><body>This is a web page.</body></html>" };
printHelper("web", page.Search("web"), "HTML"); //true
printHelper("missing", page.Search("missing"), "HTML"); //false

//helper
void printHelper(string word, bool found, string where)
{
    Console.WriteLine($"The word '{word}' is {(found ? "Found" : "Not Found")} in the {where}");
}