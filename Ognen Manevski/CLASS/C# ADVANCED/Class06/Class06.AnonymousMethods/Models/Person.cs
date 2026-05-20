namespace Class06.AnonymousMethods.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; //doesnt have a default value, so we set it to empty string to avoid null reference exception
    public double Salary { get; set; }
    public bool IsActive { get; set; }

}
