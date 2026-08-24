using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApp.Domain.Models;

[Table("Tag")]
[Index("Name", IsUnique = true)]

public class Tag : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    //[Column("HexColor")] //renaming the column in the database to HexColor
    public string Color { get; set; } = string.Empty;
}