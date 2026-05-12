namespace Homework03.name.Classes
{
    public static class UserDatabase
    {
        public static List<User> Users { get; set; } = new List<User>()
        {
            new User() { Id = 1, Name = "John", Age = 30 },
            new User() { Id = 2, Name = "Jane", Age = 25 },
            new User() { Id = 3, Name = "Bob", Age = 35 },
            new User() { Id = 4, Name = "Alice", Age = 28 }
        };


        public static User? Search(int id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }


        public static List<User> Search(string name)
        {
            return Users.Where(user => user.Name == name).ToList(); //returns list with all
        }

        //cant overload search() with int age because id is also int

        public static User? Search(int id, string name, int age)
        {
            return Users.FirstOrDefault(user =>
                user.Id == id &&
                user.Name == name &&
                user.Age == age);
        }

    }
}