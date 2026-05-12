using Class02.Domain.Interfaces;

namespace Class02.Domain.Base_Entity
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void PrintUser()
        {
            Console.WriteLine($"| Id: {Id,3} | Name: {Name,-20} | Username: {Username,-20}|");
        }
    }
}
