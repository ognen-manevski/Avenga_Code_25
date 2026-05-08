//ctrl r+g delete unused references
using Class02.Domain.BaseEntity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models

{
    public class Developer : Person, IDeveloper
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public int Age { get; set; }
        //public string MobileNumber { get; set; }
        public List<string> ProgrammingLanguages { get; set; }
        public int YearsOfExperience { get; set; }

        //ctor
        public Developer
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber,
                List<string> programmingLanguages,
                int yearsOfExperience
            )
            : base(firstName, lastName, age, mobileNumber)
        {
            ProgrammingLanguages = programmingLanguages;
            YearsOfExperience = yearsOfExperience;
        }

        //methods
        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - {YearsOfExperience} years of experience. Knows: {string.Join(", ", ProgrammingLanguages)}";
        }

        public void Code()
        {
            Console.WriteLine("tap tap tap...");
            Console.WriteLine("Writes prompt to Claude...");
            Console.WriteLine("Ctrl C + Ctrl V");
        }
    }
}
