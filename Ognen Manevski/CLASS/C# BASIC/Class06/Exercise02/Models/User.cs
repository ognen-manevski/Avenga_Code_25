namespace Class06.Exercise02.Models
{
    //Create a class User with the following:

    //Id - int
    //Username - string
    //Password - string
    //Messages - Array of strings
    //Create an array of users and add 3 users to it manually ( hard-coded ).
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Messages { get; set; }


        public User( int id, string username, string password, string[] msgs)
        {
            ID = id;
            Username = username;
            Password = password;
            Messages = msgs ?? new string[0];
        }



    }
}
