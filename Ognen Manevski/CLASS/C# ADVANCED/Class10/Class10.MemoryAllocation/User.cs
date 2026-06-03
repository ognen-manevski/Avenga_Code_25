namespace Class10.MemoryAllocation;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public User()
    {
        
    }

    public User(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;

        Console.WriteLine($"User object {FirstName} created. [{DateTime.Now}]");
    }


    // Finalizer (destructor) - called when the object is being garbage collected
    ~User()
    {
        Console.WriteLine($"User object {FirstName} is being finalized. [{DateTime.Now}]");
    }


    public void PrintInfo()
    {
        Console.WriteLine($"INFO: {FirstName} {LastName}, Age: {Age}");
    }



}
