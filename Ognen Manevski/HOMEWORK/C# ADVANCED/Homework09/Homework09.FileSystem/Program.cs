//Class 9 Homework 📒


//Task 1

//    Create a folder named "Files".
//    Create a file name "names.txt"

using System.Diagnostics.Metrics;

const string appPath = @"..\..\..\";
const string workFolder = appPath + @"\Files";
const string namesFile = workFolder + @"\names.txt";

if (!Directory.Exists(workFolder))
{
    Directory.CreateDirectory(workFolder);
    Console.WriteLine("Directory created.");
}

if (!File.Exists(namesFile))
{
    File.Create(namesFile).Close();
    Console.WriteLine("Names File created.");
}


//Task 2

//    Read the file created in the previous task named "names.txt"
//    Ask the user to enter some names and save these names in the file that we previously created.


Console.WriteLine("Please enter a few names, press [x] to finish:");

string names = string.Empty;

while (true)
{
    string name = Console.ReadLine();

    if (name.ToLower() == "x") break;

    names += $"{name} \n";
}

Console.WriteLine("Writing down those names...");

File.WriteAllText(namesFile, names);




//Task 3

//    Read the file created in the previous task name "names.txt"
//    Go thru the file content and filter out all the names that start with A. If there are any names create a new file named "namesStartingWith_A.txt" that will contains the filtered content and if there is no names that start with A do nothing.
//    Do this for all the letters in the alphabet.


Console.WriteLine("Reading back the names from file...");

using (StreamReader sr = new StreamReader(namesFile))
{
    string content = sr.ReadToEnd();
    Console.WriteLine(content);
}




static List<string> FilterByLetter(string letter, List<string> namesList)
{
    letter = letter.ToUpper();

    List<string> filteredNames = namesList
        .Where(name => name.StartsWith(letter))
        .ToList();

    return filteredNames;
}


static void WriteNamesToFile(string letter, List<string> filteredNames)
{
    if (filteredNames.Count > 0)
    {
        string file = workFolder + $@"\namesStartingWith_{letter}.txt";

        File.WriteAllLines(file, filteredNames); //writes a line for each element in the list
        Console.WriteLine($"Created file: {file} for letter {letter}");
    }
}


static List<string> ReadNamesFromFile(string namesFile)
{
    List<string> namesFromFile = new List<string>();

    using (StreamReader sr = new StreamReader(namesFile))
    {
        string? line = sr.ReadLine();

        while (line != null)
        {
            namesFromFile.Add(line);
            line = sr.ReadLine(); // setup for next loop
        }
    }

    return namesFromFile;
}



foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
{
    string letterString = letter.ToString();

    List<string> namesFromFile = ReadNamesFromFile(namesFile);
    List<string> filteredNames = FilterByLetter(letterString, namesFromFile);

    WriteNamesToFile(letterString, filteredNames);
}



//Task 4

//    Redo Task 3 but if the file already exists add the new names in the file and keep the already existing names.



static void AddNewNamesToFile(string letter, List<string> filteredNames)
{
    string file = workFolder + $@"\namesStartingWith_{letter}.txt";

    using (StreamWriter sw = new StreamWriter(file, true))
    {
        foreach (string name in filteredNames)
        {
            sw.WriteLine(name);
        }
    }
}


foreach (char letter in "ABCDEFGHIJKLMNOPQRSTUVWXYZ")
{
    string letterString = letter.ToString();

    List<string> namesFromFile = ReadNamesFromFile(namesFile);
    List<string> filteredNames = FilterByLetter(letterString, namesFromFile);

    AddNewNamesToFile(letterString, filteredNames);
}
