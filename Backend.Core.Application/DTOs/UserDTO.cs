namespace Backend.Core.Application.DTOs;

public record UserDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
