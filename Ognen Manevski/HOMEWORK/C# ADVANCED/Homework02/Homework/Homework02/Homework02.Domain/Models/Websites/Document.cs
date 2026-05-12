using Homework02.Domain.Interfaces;

namespace Homework02.Domain.Models.Websites;


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
