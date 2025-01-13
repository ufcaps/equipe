using MediatR;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public sealed record UpdateUserRequest : IRequest<UpdateUserResponse>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
};
