using MediatR;

namespace Backend.Core.Application.UseCases.Task.UpdateTask;

public sealed record UpdateTaskRequest : IRequest<UpdateTaskResponse>
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Priority { get; set; }
    public string? Status { get; set; }
    public DateTime? Date { get; set; }
}
