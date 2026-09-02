namespace MoviesApp.Domain.Models;

public abstract class BaseEntity
{
    public required int Id { get; set; }
    public required DateTime CreatedDate { get; set; }
    public required DateTime UpdatedDate { get; set; }

    protected BaseEntity()
    {
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }
}
