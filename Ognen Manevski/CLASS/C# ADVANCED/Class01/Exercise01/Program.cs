//1.Create a console application that detect provided names in a provided text 🔹
//The application should ask for names to be entered until the user enteres x
//After that the application should ask for a text
//When that is done the application should show how many times that name was included in the text ignoring upper/lower case

//Refine:
//"without using LINQ"
//"with LINQ"
//"what are edge cases"

//Try:
//What happens if the word is part of another word(e.g. 'an' in 'banana')?

string separator = new string('=', 10);

Console.WriteLine(separator + " Please enter your names " + separator);
Console.WriteLine("Enter x to finish");


List<string> namesList = new List<string>();

bool done = false;

while (!done)
{
    string input = Console.ReadLine();

    if (input.ToLower() != "x")
    {
        namesList.Add(input);
        continue;
    }

    done = true;
}

string[] names = namesList.ToArray();

Console.WriteLine(separator + " Please paste in your text" + separator);

//string text = Console.ReadLine();

string text = @"
Far far away, behind the word mountains, far from the countries Vokalia and Consonantia, there live the blind texts. Separated they live in Bookmarksgrove right at the coast of the Semantics, a large language ocean. A small river named Duden flows by their place and supplies it with the necessary regelialia. It is a paradisematic country, in which roasted parts of sentences fly into your mouth. Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar. The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen. She packed her seven versalia, put her initial into the belt and made herself on the way. When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane. Pityful a rethoric question ran over her cheek, then
";

Console.WriteLine("Text is pasted!");

Console.WriteLine(separator + " Please paste in your text" + separator);

text = text.ToLower();

//string[] words = text.Split(' ', ',', '.', '!', '?', ';', ':'); // Split the text into words
string[] words = text.Split(' '); // Split the text into words




Console.WriteLine(separator + " Results " + separator);

foreach (string name in names)
{
    int count = 0;


    count = words.Count(word =>
    {
        char[] wordArray = word.ToCharArray().Where(char.IsLetter).ToArray();
        return new string(wordArray) == name.ToLower();
    });

    Console.WriteLine($"| {name,10} || {count,5} times |");
}


//================== with prof:

//1)
List<string> names2 = new();

while (true)
{
    string input = Console.ReadLine();

    if (input.ToLower() == "x")
        break;

    names2.Add(input);
}

//2)
string text2 = Console.ReadLine();

//3)

string[] words2 = text2.Split(' ');

Console.WriteLine("Result");

foreach (var name in names)
{
    int count = 0;

    foreach (var word in words2)
    {
        //if (word.ToLower() == name.ToLower())
        //{
        //    count++;
        //}
        if (word.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            count++;
        }
    }
    Console.WriteLine($"{name} is found {count} times");
}



