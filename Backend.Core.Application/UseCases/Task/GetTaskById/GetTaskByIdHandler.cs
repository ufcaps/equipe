using AutoMapper;
using MediatR;

namespace Backend.Core.Application.UseCases.Task.GetTaskById;

public class GetTaskByIdHandler(GetTaskByIdUseCase getTaskByIdUseCase, IMapper mapper) : IRequestHandler<GetTaskByIdRequest, GetTaskByIdResponse>
{
    private readonly GetTaskByIdUseCase _getTaskByIdUseCase = getTaskByIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<GetTaskByIdResponse> Handle(GetTaskByIdRequest request, CancellationToken cancellationToken)
    {
        var task = await _getTaskByIdUseCase.Execute(request.Id, cancellationToken);
        return _mapper.Map<GetTaskByIdResponse>(task);
    }
}
