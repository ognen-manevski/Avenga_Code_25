using Class04.Generics.Domain;

namespace Class04.Generics.Domain.Models;

public class Order : BaseEntity
{
    public string Receiver { get; set; }
    public string Address { get; set; }

    public override string GetInfo()
    {
        return $"({Id}) {Receiver} - {Address}";
    }
}
