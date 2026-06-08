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
                          //Data Source=(localdb)\\MSSQLLocalDB;Database=SEDC_DEMO_SHARP;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;
StudentRepository studentRepository = new StudentRepository(ConnectionString);

List<Student> allStudents = studentRepository.GetAllStudents();

Console.WriteLine("============ All Students ================");
PrintStudents(allStudents);

//

Console.Write("Enter first name: ");
string firstName = Console.ReadLine();


if (!string.IsNullOrEmpty(firstName))
{

    Student student = new Student
    {
        FirstName = firstName,
        LastName = "Doe",
        DateOfBirth = DateTime.UtcNow.AddYears(-32),
        EnrolledDate = DateTime.UtcNow,
        Gender = 'M',
        NationalIdNumber = 1234567890123,
        StudentCardNumber = "ST-77518-bla"
    };

//studentRepository.InsertStudentSqlInjection(student);
studentRepository.InsertStudentSafe(student);

}

Console.ReadLine();