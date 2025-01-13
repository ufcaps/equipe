using MediatR;
using Tasks = System.Threading.Tasks;

namespace Backend.Core.Application.UseCases.Task.DeleteTask;

public class DeleteTaskHandler(DeleteTaskUseCase deleteTaskUseCase) : IRequestHandler<DeleteTaskRequest>
{
    private readonly DeleteTaskUseCase _deleteTaskUseCase = deleteTaskUseCase;

    public async Tasks.Task Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        => await _deleteTaskUseCase.Execute(request.Id, cancellationToken);
}
