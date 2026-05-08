using Class02.Domain.BaseEntity;
using Class02.Domain.Interfaces;

namespace Class02.Domain.Models
{
    public class Operations : Person, IOperations
    {

        public List<string> Projects { get; set; } = new List<string>();


        //ctor
        public Operations
            (
                string firstName,
                string lastName,
                int age,
                string mobileNumber,
                List<string> projects
            )
            : base(firstName, lastName, age, mobileNumber)
        {
            Projects = projects;
        }

        public override string GetInfo()
        {
            return $"{GetFullName()} ({Age}) - Currently working on: {string.Join(", ", Projects)} projects!";
        }

        public bool CheckInfrastructure(int status)
        {
            throw new NotImplementedException();
        }
    }
}
