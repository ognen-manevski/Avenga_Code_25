using AcademyManagement.Domain.Enums;
using AcademyManagement.Domain.Models;

namespace AcademyManagement.Domain
{
    public class DataAccess
    {
        private Database _db; // this means field is private

        public DataAccess()
        {
            _db = new Database();
        }

        public Admin? GetAdmin(string username, string pw)
        {
            Admin? adminFromDb = _db.Admins.FirstOrDefault(x => x.Username == username && x.Password == pw);
            return adminFromDb;
        }

        public Trainer? GetTrainer(string username, string pw)
        {
            Trainer? trainerFromDb = _db.Trainers.FirstOrDefault(x => x.Username == username && x.Password == pw);
            return trainerFromDb;
        }

        public Student? GetStudent(string username, string pw)
        {
            Student? studentFromDb = _db.Students.FirstOrDefault(x => x.Username == username && x.Password == pw);
            return studentFromDb;
        }

        public bool CheckIfUserExists(string username, Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    return _db.Admins.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                case Role.Trainer:
                    return _db.Trainers.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                case Role.Student:
                    return _db.Students.Any(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                default:
                    return false;
            }
        }

        public List<string> GetUserNames(Role role, Admin loggedAdmin)
        {
            switch (role)
            {
                case Role.Admin:
                    return _db.Admins.Where(x => x.Username != loggedAdmin.Username).Select(x => x.Username).ToList();
                case Role.Trainer:
                    return _db.Trainers.Select(x => x.Username).ToList();
                case Role.Student:
                    return _db.Students.Select(x => x.Username).ToList();
                default:
                    throw new Exception("Error occured while retreiving usernames from database");
            }
        }

        public void CreateNewUser(string fname, string lname, string username, string password, string age, Role role)
        {
            switch (role)
            {
                case Role.Admin:    
                    Admin newAdmin = new Admin(fname, lname, username, password, int.Parse(age));
                    _db.Admins.Add(newAdmin);
                    break;
                case Role.Trainer:
                    _db.Trainers.Add(new Trainer(fname, lname, username, password, int.Parse(age)));
                    break;
                case Role.Student:
                    _db.Students.Add(new Student(fname, lname, username, password, int.Parse(age)));
                    break;
                default:
                    throw new Exception("Error occured while creating new user");
            }
        }

        public bool DeleteUser(string username, Role role)
        {
            switch (role)
            {
                case Role.Admin:
                    Admin? adminFromDb = _db.Admins.FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                    return _db.Admins.Remove(adminFromDb);
                case Role.Trainer:
                    Trainer? trainerFromDb = _db.Trainers.FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                    return _db.Trainers.Remove(trainerFromDb);
                case Role.Student:
                    Student? studentFromDb = _db.Students.FirstOrDefault(x => x.Username.ToLower().Trim() == username.ToLower().Trim());
                    return _db.Students.Remove(studentFromDb);
                default:
                    return false;
            }
        }



    }
}
