using Class04.Generics.Domain;

namespace Class04.Generics.Domain.Models;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public override string GetInfo()
    {
        return $"({Id}) {Title} - {Description}";
    }

    //just for testing:
    public override string ToString() //overriding the default ToString() method
    {
        return GetInfo();
    }
}
