namespace Class02.Domain.Interfaces
{

    public interface IStudent : IUser
    {
        public List<string> Grades { get; set; }
    }
}

/*
    Interface IStudent
        Grades
        Override PrintUser() to show grades
 */