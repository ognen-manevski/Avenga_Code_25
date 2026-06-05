using Microsoft.Data.SqlClient;

namespace AdoNet.Demo.Models.DataAccess;


//SQLConnection,
//SQLCommand,
//SQLDataReader,
//SQLDataAdapter,
//DataSet,
//DataTable,
//DataRow

internal class StudentRepository
{
    private readonly string _connectionString;
    public StudentRepository(string connectionString)
    {
        _connectionString = connectionString;
    }
    public List<Student> GetAllStudents()
    {
        List<Student> students = new List<Student>();


        //1) establish connection to the database

        using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            //2) write the SQL query
            string query = @"
                SELECT 
	                s.Id,
	                s.FirstName,
	                s.LastName,
	                s.DateOfBirth,
	                s.EnrolledDate,
	                s.Gender,
	                S.NationalIdNumber,
	                S.StudentCardNumber
                FROM [dbo].[Student] s
                ";

            // 3) Create slq command
            using SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            //4 ) Execute the command

            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                //5) Read the data and convert it to a list of students
                while (reader.Read())
                {
                    //6) Map the data from the received columns to a student object
                    //1 Kalin Mitev 1995-01-01 2020-09-01 M 1234567890123 sc-77518
                    Student student = new Student
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.IsDBNull(1) ? null : reader.GetString(1),
                        LastName = reader.IsDBNull(2) ? null : reader.GetString(2),
                        DateOfBirth = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                        EnrolledDate = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                        Gender = reader.IsDBNull(5) ? (char?)null : reader.GetString(5)[0],
                        NationalIdNumber = reader.IsDBNull(6) ? (long?)null : reader.GetInt64(6),
                        StudentCardNumber = reader.IsDBNull(7) ? null : reader.GetString(7)
                    };
                    students.Add(student);
                }
            }

        }
        //7) Return the list of students
        return students;
    }
}
