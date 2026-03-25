namespace Class05.Classes.Models
{
    internal class Group
    {
        public string GroupName { get; set; }
        public int NumberOfStudents { get; set; }
        public string CurrentSubjectName { get; set; }


        public Group()
        {
            //default constructor,
            //must add this explicitly if we want to
            //initialize an object with parameterless constructor
            //because we defined a constructor with params below
        }

        public Group(string groupName, int numberOfStudents, string currentSubjectName)
        {
            GroupName = groupName;
            NumberOfStudents = numberOfStudents;
            CurrentSubjectName = currentSubjectName;
        }

        public void DisplayGroupInfo()
        {
            Console.WriteLine($"This is Group {GroupName} with {NumberOfStudents} students.");
        }


    }
}
