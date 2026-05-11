namespace Class03.Polymorphism.Models
{
    public class Cat : Pet
    {
        public bool IsLazy { get; set; }

        public void SayHello()
        {
            Console.WriteLine($"Cat {Name} says hello!");
        }

        //runtime polymorphism - method overriding
        public override void Eat()
        {
            base.Eat(); // Nom Nom Nom
            Console.WriteLine($"The{(IsLazy? " Lazy" : "")} cat {Name} cat is eating its food.");
        }

    }
}
