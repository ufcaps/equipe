using Backend.Core.Application.DTOs;

namespace Backend.Core.Application.UseCases.Auth.Login;

public sealed record LoginResponse
{
    public required string Token { get; init; }
    public required UserDTO User { get; set; }
}
