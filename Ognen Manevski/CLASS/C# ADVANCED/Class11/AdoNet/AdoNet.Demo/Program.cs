using AdoNet.Demo.Models;
using AdoNet.Demo.Models.DataAccess;

void PrintStudents(List<Student> students)
{
    foreach (Student student in students)
    {
        Console.WriteLine(student);
    }
}

const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=SEDC_DEMO_SHARP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

StudentRepository studentRepository = new StudentRepository(ConnectionString);

List<Student> allStudents = studentRepository.GetAllStudents();

Console.WriteLine("============ All Students ================");
PrintStudents(allStudents);