namespace LinqMethods.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public int Modules { get; set; }
        public int StudentsAttending { get; set; }
        public Academy Academy { get; set; }

        public Subject(int id, string title, int modules, int students, Academy type)
        {
            Id = id;
            Title = title;
            Modules = modules;
            StudentsAttending = students;
            Academy = type;
        }

        public override string GetInfo()
        {
            return $"{Id}) {Title} of the {Academy} Academy - {StudentsAttending} attending!";
        }
    }

    public enum Academy
    {
        Programming,
        Design,
        Networks
    }
}
