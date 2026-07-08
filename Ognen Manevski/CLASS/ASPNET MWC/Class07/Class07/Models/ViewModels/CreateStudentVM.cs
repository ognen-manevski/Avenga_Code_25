using System.ComponentModel.DataAnnotations;

namespace Class07.Models.ViewModels;

public class CreateStudentVM
{
    [Required]
    [MinLength(2, ErrorMessage = "The first name must have atleast 2 characters")]
    [MaxLength(50, ErrorMessage = "The first name cant have more than 50 characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "The last name must be 2 to 50 characters long")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "The e-mail address is not valid")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }


    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }
}
