namespace Class03.Polymorphism.Models
{
    public class Dog : Pet
    {
        public bool IsFriendly { get; set; }

        public override void Eat()
        {
            base.Eat(); // Nom Nom Nom
            Console.WriteLine($"The{(IsFriendly ? " Friendly" : "")} dog {Name} is eating its food.");
        }

    }
}
