namespace Class02.Domain.Interfaces
{
    public interface ITeacher : IUser
    {
        public string Subject { get; set; }
    }
}

/*
        Interface ITeacher
        Subject
        Override PrintUser() to show subject
 */