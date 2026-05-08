using Class02.Domain.BaseEntity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class Tester : Person, ITester 
    {
        public int BugsFound { get; set; }


        //ctor
        public Tester
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber,
                int bugsFound
            )
            : base(firstName, lastName, age, mobileNumber)
        {
            BugsFound = bugsFound;
        }

        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - Found {BugsFound} bugs.";
        }

        public void TestFeature(string feature)
        {
            Console.WriteLine($"");
        }
    }
}
