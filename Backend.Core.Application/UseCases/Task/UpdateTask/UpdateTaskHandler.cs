using AutoMapper;
using Entities = Backend.Core.Domain.Entities;
using MediatR;

namespace Backend.Core.Application.UseCases.Task.UpdateTask;

public class UpdateTaskHandler(UpdateTaskUseCase updateTaskUseCase, IMapper mapper) : IRequestHandler<UpdateTaskRequest, UpdateTaskResponse>
{
    private readonly UpdateTaskUseCase _updateTaskUseCase = updateTaskUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateTaskResponse> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Entities.Task>(request);
        var task = await _updateTaskUseCase.Execute(request.Id, data, cancellationToken);
        return _mapper.Map<UpdateTaskResponse>(task);
    }
}
