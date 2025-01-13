using MediatR;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public sealed record CreateUserRequest(string Name, string Email, string Password) : IRequest<CreateUserResponse>;
