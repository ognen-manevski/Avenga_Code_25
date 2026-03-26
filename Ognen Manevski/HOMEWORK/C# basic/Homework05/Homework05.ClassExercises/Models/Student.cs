namespace Homework05.ClassExercises.Models;

public class Student
{
    public string Name { get; set; }
    public string Academy { get; set; }
    public string Group { get; set; }

    public Student(string name, string academy, string group)
    {
        Name = name.ToLower(); // store as lowercase
        Academy = academy;
        Group = group;
    }

    public string GetInfo()
    {
        return $"| Name: {GetUppercaseName(),-5} | Academy: {Academy,-18} | Group: {Group,-2} |";
    }

    public string GetUppercaseName()
    {
        //capitalize
        string name = Name.Substring(0, 1).ToUpper() + Name.Substring(1);
        return name;
    }

}
