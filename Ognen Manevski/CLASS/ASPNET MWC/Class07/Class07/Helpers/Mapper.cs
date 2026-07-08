using Class07.Database;
using Class07.Models.Domain;
using Class07.Models.ViewModels;

namespace Class07.Helpers;

public static class Mapper
{
    public static StudentVM MapToStudentVM(Student student)
    {
        return new StudentVM
        {
            Id = student.Id,
            FullName = student.GetFullName(),
            Age = DateTime.Now.Year - student.DateOfBirth.Year,
            Email = student.Email
        };
    }

    public static StudentDetailsVM MapToStudentDetailsVM(Student student)
    {
        return new StudentDetailsVM
        {
            Id = student.Id,
            FullName = student.GetFullName(),
            Age = DateTime.Now.Year - student.DateOfBirth.Year,
            Email = student.Email,
            PhoneNumber = student.PhoneNumber
        };
    }

    public static Student MapToStudent(CreateStudentVM studentVM)
    {
        return new Student
        {
            Id = StaticDb.Students.Count() + 1,
            FirstName = studentVM.FirstName,
            LastName = studentVM.LastName,
            DateOfBirth = studentVM.DateOfBirth,
            Email = studentVM.Email,
            PhoneNumber = studentVM.PhoneNumber
        };
    }



    
}
