namespace Class05.Classes.Models
{
    //create object
    public class Person //default internal
    {
        // initializing properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string[] Hobbies { get; set; }
        public bool IsStudent { get; set; }
        //rpivate property - only accessible within the class (ex changing the value from outside)
        private long SSN { get; set; } //prop <- shortcut for creating properties


        //initializing a constructor:

        //default constructor and it is parameterless
        public Person()
        {
            SSN = GenerateSSN(); // adding this because we cant set it elsewhere using this default constructor
        }

        //constructor with parameters
        public Person(string firstName, string lastName, string phoneNumber, int age, string[] hobbies, bool isStudent) //ctor <- shortcut
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Age = age;
            Hobbies = hobbies;
            IsStudent = isStudent;
            SSN = GenerateSSN();
        }


        //methods
        public void Talk(string text)
        {
            Console.WriteLine($"The human named {FirstName} ( SSN: {SSN} ) is saying: {text}");
        }

        private long GenerateSSN()
        {
            return new Random().Next(100000000, 999999999);
        }

        public long GetSSNValue()
        {
            return SSN;
        }

    }
}

