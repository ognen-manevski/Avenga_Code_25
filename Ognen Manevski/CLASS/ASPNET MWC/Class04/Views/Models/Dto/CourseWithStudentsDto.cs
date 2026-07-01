namespace Class04.Views.Models.Dto;

public class CourseWithStudentsDto
{
    public int Id { get; set; } //course id
    public string Name { get; set; } //course name
    public List<StudentDto> Students { get; set; }

    public string Description { get; set; } //course description for demo -> nullable
    public string Subscribe { get; set; } //course description for demo -> nullable
    public string Role { get; set; } //course description for demo -> nullable
}
