using Class02.Domain.Interfaces;

namespace Class02.Domain.BaseEntity
{
    public abstract class Person : IPerson //abstract class cannot be instantiated, it can only be inherited by other classes!
    {

    //IPerson is an interface, it defines a contract that the Person class must implement (Id, GetInfo, GetFullName, Greet)
    public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }

        //ctor
        public Person
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber
            )
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            MobileNumber = mobileNumber;
        }

        //methods
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }


        public abstract string GetInfo();

        public void Greet(string name)
        {
            Console.WriteLine($"Hello {name}, I am {GetFullName()}!");
        }

    }
}
