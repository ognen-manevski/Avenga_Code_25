namespace Class02.Domain.Interfaces
{

    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void PrintUser();
    }
}

/*
 Interface IUser
        Id
        Name
        Username
        Password
        PrintUser() - Prints Id, Name and Username
 */