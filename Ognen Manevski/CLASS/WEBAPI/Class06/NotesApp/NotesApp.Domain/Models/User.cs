using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Domain.Models;

//using data annotations to validate the model
//not needed if using fluent api to configure the model
//using local verison of Abstractions
[Table("User")]
[Index("Username", IsUnique = true)]

public class User : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [MaxLength(30)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    public List<Note> Notes { get; set; } = new();
}