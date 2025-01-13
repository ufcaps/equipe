using MediatR;

namespace Backend.Core.Application.UseCases.Task.DeleteTask;

public sealed record DeleteTaskRequest(int Id) : IRequest;
