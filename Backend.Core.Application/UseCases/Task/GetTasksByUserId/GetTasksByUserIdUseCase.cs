using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;

namespace Backend.Core.Application.UseCases.Task.GetTasksByUserId;

public class GetTasksByUserIdUseCase(ITaskRepository taskRepository)
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<List<Entities.Task>> Execute(int userId, CancellationToken cancellationToken)
        => await _taskRepository.GetByUserId(userId, cancellationToken);
}
