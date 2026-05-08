using Class02.Domain.BaseEntity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class QAEngineer : Person, IDeveloper, ITester
    {
        public List<string> TestingFrameworks { get; set; } = new List<string>();

        //ctor
        public QAEngineer
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber,
                List<string> testingFrameworks
            )
            : base(firstName, lastName, age, mobileNumber)
        {
            TestingFrameworks = testingFrameworks;
        }


        //methods
        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - Knows testing frameworks: {(TestingFrameworks.Count !=0 ? (string.Join(", ", TestingFrameworks)) : "None")}";
        }

        public void Code()
        {
            Console.WriteLine("tap tap tap...");
            Console.WriteLine("Writes automation test...");
        }

        public void TestFeature(string feature)
        {
            Console.WriteLine("Run Unit Tests...");
            Console.WriteLine("Run Automated Tests...");
            Console.WriteLine($"Tests for the {feature} feature are done!");
        }
    }
}