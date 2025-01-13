using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.UseCases.User.GetUserById;

namespace Backend.Core.Application.UseCases.Task.CreateTask;

public class CreateTaskUseCase(
    GetUserByIdUseCase getUserByIdUseCase,
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork
)
{
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.Task> Execute(Entities.Task task, CancellationToken cancellationToken)
    {
        var user = await _getUserByIdUseCase.Execute(task.UserId, cancellationToken);
        task.User = user;

        _taskRepository.Create(task);
        await _unitOfWork.Commit(cancellationToken);

        return task;
    }
}
