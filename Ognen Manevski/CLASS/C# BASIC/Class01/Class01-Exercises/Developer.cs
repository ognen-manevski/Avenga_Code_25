

namespace Class01_Exercises
{
    internal class Developer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public static int NumberOfDevelopers { get; set; } = 0;


        public Developer( string firstName, string lastName, int age, int numberOfDevelopers = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            NumberOfDevelopers++;
        }

        public int GetNumberOfDevelopers()
        {
            return NumberOfDevelopers;
        }


        public static void ResetNumberOfDevelopers()
        {
            NumberOfDevelopers = 0;
        }


    }
}
