//Task 2

//    Make a new console application called StudentGroup
//    Make 2 arrays called studentsG1 and studentsG2 and fill them with 5 student names.
//    Get a number from the console between 1 and 2 and print the students from that group in the console.
//    Ex: studentsG1["Zdravko", "Petko", "Stanko", "Branko", "Trajko"]
//    Test Data:
//        Enter student group: (there are 1 and 2 )
//            1
//    Expected Output:
//        The Students in G1 are:
//        Zdravko
//        Petko
//        Stanko
//        Branko
//        Trajko


using Homework03.Utilities;

Console.WriteLine("================ Students Group =====================");


string[] studentsG1 = new string[] { "Zdravko", "Janko", "Stanko", "Trajko", "Petko" };
string[] studentsG2 = new string[] { "John", "Jane", "Jovan", "Jovanka", "Jovancho" };


static string getSelection()
{
    Console.WriteLine("Please select which student group do you want to view:");
    Console.WriteLine("1: [G1]");
    Console.WriteLine("2: [G2]");

    while (true)
    {
        string select = Console.ReadLine();

        if (select != "1" && select != "2")
        {
            Console.WriteLine("Please pick 1 or 2:");
            continue;
        }

        return select;
    }
}

string select = getSelection();
string[] currentGroup = select == "1" ? studentsG1 : studentsG2;

Console.Write($"The students in G{select} are: ");
for (int i = 0; i < currentGroup.Length; i++)
{
    if (i == currentGroup.Length - 1)
    {
        Console.WriteLine($"{currentGroup[i]}.");
        break;
    }
    Console.Write($"{currentGroup[i]}, ");
}
