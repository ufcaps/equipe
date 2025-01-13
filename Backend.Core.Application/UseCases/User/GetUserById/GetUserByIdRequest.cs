using MediatR;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public sealed record GetUserByIdRequest(int Id) : IRequest<GetUserByIdResponse>;
