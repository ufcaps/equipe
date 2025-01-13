using AutoMapper;
using Backend.Core.Application.UseCases.Task.GetTaskById;
using Backend.Core.Domain.Interfaces;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Task.UpdateTask;

public class UpdateTaskUseCase(
    GetTaskByIdUseCase getTaskByIdUseCase,
    ITaskRepository taskRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
)
{
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase = getTaskByIdUseCase;
    private readonly ITaskRepository _taskRepository = taskRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Entities.Task> Execute(int id, Entities.Task data, CancellationToken cancellationToken)
    {
        var task = await _getTaskByIdUseCase.Execute(id, cancellationToken);
        task = _mapper.Map(data, task);

        _taskRepository.Update(task);
        await _unitOfWork.Commit(cancellationToken);

        return task;
    }
}
