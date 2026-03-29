namespace Homework05.Homework_Cars_Drivers.Models
{
    public class Driver
    {
        //properties
        public string Name { get; set; }
        public double Skill { get; set; }

        //constructor
        public Driver(string name, double skill)
        {
            Name = name;
            Skill = skill;
        }
    }
}
