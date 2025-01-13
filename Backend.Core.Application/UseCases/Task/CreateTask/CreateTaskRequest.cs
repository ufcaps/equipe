using MediatR;

namespace Backend.Core.Application.UseCases.Task.CreateTask;

public sealed record CreateTaskRequest(string Title, string? Description, string Priority, string Status, DateTime Date, int UserId) : IRequest<CreateTaskResponse>;
