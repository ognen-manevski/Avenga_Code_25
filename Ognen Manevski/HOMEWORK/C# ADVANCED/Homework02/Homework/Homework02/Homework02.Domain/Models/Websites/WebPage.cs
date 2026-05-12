using Homework02.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace Homework02.Domain.Models.Websites;


public class WebPage : ISearchable
{
    public string Url { get; set; }
    public string Html { get; set; }


    public bool Search(string word)
    {

        word = word.ToLower();

        string searchHtml = Html.ToLower();

        searchHtml = Regex.Replace(searchHtml, "<.*?>", ""); // Remove HTML tags
                                                 //"<.*?>" matches any substring that starts with <,
                                                 //followed by any characters (non-greedy match)
                                                 //until the first >.
                                                 //This effectively removes all HTML tags from the string,
                                                 //leaving only the visible text content for searching.


        if (searchHtml.Contains(word)) return true;
        return false;
    }
}
