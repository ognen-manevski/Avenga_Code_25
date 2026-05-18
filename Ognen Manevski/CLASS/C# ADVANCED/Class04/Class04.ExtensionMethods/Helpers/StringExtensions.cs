namespace Class04.ExtensionMethods.Helpers;

public static class StringExtensions
{
    public static string Truncate(this string word, int length)
    {
        if (string.IsNullOrWhiteSpace(word) || word.Length <= length)
        {
            return word;
        }

        string result = word.Substring(0, length) + "...";

        return result;
    }


    public static string Quote(this string word)
    {
        return $"\"{word}\"";
    }


}
