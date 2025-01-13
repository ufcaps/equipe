using Backend.Core.Application.Exceptions;
using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.Task.GetTaskById;

public class GetTaskByIdUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<Entities.Task> Execute(int id, CancellationToken cancellationToken)
        => await _taskRepository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("Task does not exist.");
}
