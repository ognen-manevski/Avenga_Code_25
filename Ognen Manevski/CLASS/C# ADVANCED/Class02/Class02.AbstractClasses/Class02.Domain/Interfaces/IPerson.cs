namespace Class02.Domain.Interfaces
{
    public interface IPerson
    {
        int Id { get; set; }
        string GetInfo();
        string GetFullName();
        void Greet(string name);
    }
}
