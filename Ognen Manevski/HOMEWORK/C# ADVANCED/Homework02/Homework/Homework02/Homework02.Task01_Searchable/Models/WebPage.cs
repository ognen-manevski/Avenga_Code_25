using Homework02.Task01_Searchable.Interfaces;
using System.Text.RegularExpressions; //required for regex

namespace Homework02.Task01_Searchable.Models;

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
