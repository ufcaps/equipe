using MediatR;

namespace Backend.Core.Application.UseCases.Task.GetTaskById;

public sealed record GetTaskByIdRequest(int Id) : IRequest<GetTaskByIdResponse>;
