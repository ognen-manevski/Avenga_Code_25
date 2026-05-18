namespace Class04.Generics.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    //just for testing:
    public override string ToString() //overriding the default ToString() method
    {
        return $"{Title} - {Description}";
    }

    public string GetInfo()
    {
        return $"{Id}) {Title} - {Description}";
    }
}
