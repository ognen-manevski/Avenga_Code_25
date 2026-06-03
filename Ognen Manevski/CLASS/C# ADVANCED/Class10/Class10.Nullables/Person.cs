namespace Class10.Nullables;

internal class Person
{
    public int Id { get; set; }
    public int? Score { get; set; }
    public string Name { get; set; } //string is a reference type, it can be null
    public bool IsEmployed { get; set; }
    public bool HasPet { get; set; }
    public List<int> Grades { get; set; } = new List<int>(); //we can initialize it to an empty list, so it won't be null





}
