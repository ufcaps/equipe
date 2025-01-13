using AutoMapper;
using Entities = Backend.Core.Domain.Entities;
using MediatR;

namespace Backend.Core.Application.UseCases.Task.CreateTask;

public class CreateTaskHandler(CreateTaskUseCase createTaskUseCase, IMapper mapper) : IRequestHandler<CreateTaskRequest, CreateTaskResponse>
{
    private readonly CreateTaskUseCase _createTaskUseCase = createTaskUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateTaskResponse> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Entities.Task>(request);
        var task = await _createTaskUseCase.Execute(data, cancellationToken);
        return _mapper.Map<CreateTaskResponse>(task);
    }
}
