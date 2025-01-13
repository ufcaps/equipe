using MediatR;

namespace Backend.Core.Application.UseCases.Task.GetTasksByUserId;

public sealed record GetTasksByUserIdRequest(int UserId) : IRequest<List<GetTasksByUserIdResponse>>;
