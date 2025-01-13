using Backend.Core.Domain.Enums;

namespace Backend.Core.Domain.Entities;

public class Task : Entity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required Priority Priority { get; set; }
    public required Status Status { get; set; }
    public required DateTime Date { get; set; }
    public required User User { get; set; }
    public required int UserId { get; set; }
}
