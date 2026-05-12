using Homework02.Task01_Searchable.Interfaces;

namespace Homework02.Task01_Searchable.Models;
public class Document : ISearchable
{
    public string Title { get; set; }
    public string Content { get; set; }


    public bool Search(string word)
    {
        string searchContent = Content.ToLower();
        word = word.ToLower();

        if (searchContent.Contains(word)) return true;
        return false;
    }
}
