using Class03.Polymorphism.Models;

namespace Class03.Polymorphism.Services
{
    public class PetService
    {
        public void PrintPetInfo()
        {
            Console.WriteLine("Some pet info");
            
        }

        //compile time polymorphism - method overloading
        //we can have multiple methods with the same name but different parameters
        public void PrintPetInfo(Cat cat)
        {
            Console.WriteLine($"This cat is {(cat.IsLazy ? "lazy" : "not lazy")}");
        }

        //NOT ALLOWED - same method signature
        //public void PrintPetInfo(Cat kitty)
        //    {
        //        Console.WriteLine("");
        //}

        public void PrintPetInfo(Dog dog)
        {
            Console.WriteLine($"This dog is {(dog.IsFriendly ? "friendly" : "not friendly")}");
        }

        public void PrintPetInfo(string owner, Dog dog )
        {
            Console.WriteLine($"The owner {owner} has a dog named {dog.Name}");
        }


    }
}
