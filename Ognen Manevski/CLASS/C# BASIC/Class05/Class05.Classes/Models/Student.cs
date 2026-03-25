namespace Class05.Classes.Models
{
    internal class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        //we can use a class as a property type
        public Group Group { get; set; }


        public Student(string fullName, int age, Group group)
        {
            FullName = fullName;
            Age = age;           

            /*
            //group will be null if not set (we dont know it yet)
            if (group != null)
            {
                Group = group;
            }
            else
            {
                // Group = new Group(); //initialized as empty, it wont throw err but wont show anything
                Group= new Group("Unknown", 0, "Unknown"); //default values for UX
            }
            */

            Group = group ?? new Group("Unknown", 0, "Unknown"); // same shit^ ( ?? -> null coalescing operator)
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"{FullName} from group {Group.GroupName}");
        }

    }
}