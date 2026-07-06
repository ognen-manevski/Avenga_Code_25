using System.ComponentModel.DataAnnotations;

namespace Class07.Models.ViewModels;

public class CreateStudentVM
{
    public string FirstName { get; set; }
    [Display(Name = "Full Name")]
    public string LastName { get; set; }
    public string Email { get; set; }
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }
}
