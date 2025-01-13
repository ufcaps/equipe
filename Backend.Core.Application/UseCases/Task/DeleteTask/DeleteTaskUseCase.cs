using Backend.Core.Domain.Interfaces;
using Tasks = System.Threading.Tasks;
using Backend.Core.Application.UseCases.Task.GetTaskById;

namespace Backend.Core.Application.UseCases.Task.DeleteTask;

public class DeleteTaskUseCase(
    GetTaskByIdUseCase getTaskByIdUseCase,
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork
)
{
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase = getTaskByIdUseCase;
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Tasks.Task Execute(int id, CancellationToken cancellationToken)
    {
        var task = await _getTaskByIdUseCase.Execute(id, cancellationToken);

        _taskRepository.Delete(task);
        await _unitOfWork.Commit(cancellationToken);
    }
}
