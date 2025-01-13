namespace Backend.Core.Application.DTOs;

public record TaskDTO
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Priority { get; set; }
    public required string Status { get; set; }
    public required DateTime Date { get; set; }
    public required int UserId { get; set; }
}
