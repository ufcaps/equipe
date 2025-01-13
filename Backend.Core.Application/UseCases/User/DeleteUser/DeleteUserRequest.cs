using MediatR;

namespace Backend.Core.Application.UseCases.User.DeleteUser;

public sealed record DeleteUserRequest(int Id) : IRequest;
