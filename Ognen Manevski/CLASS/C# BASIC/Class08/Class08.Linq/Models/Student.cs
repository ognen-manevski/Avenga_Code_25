namespace Class08.Linq.Models;

public class Student
{
    public int Id { get; set; }
    public string Fname { get; set; }
    public string Lname { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public Academy Academy { get; set; }
    public List<string> Subjects { get; set; }

    public Student(
        int id,
        string fname,
        string lname,
        int age,
        string group,
        Academy academy,
        List<string> subjects
        )
    {
        Id = id;
        Fname = fname;
        Lname = lname;
        Age = age;
        Group = group;
        Academy = academy;
        Subjects = subjects ?? new List<string>();
    }



}
