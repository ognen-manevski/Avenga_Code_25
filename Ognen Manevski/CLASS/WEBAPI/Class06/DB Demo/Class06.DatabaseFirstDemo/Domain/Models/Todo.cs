using System;
using System.Collections.Generic;

namespace Class06.DatabaseFirstDemo.Domain.Models;

public partial class Todo
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public int CategoryId { get; set; }

    public int StatusId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
