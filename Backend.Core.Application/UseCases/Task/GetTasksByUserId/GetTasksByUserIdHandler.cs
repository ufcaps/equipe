using AutoMapper;
using Backend.Core.Application.UseCases.User.GetUserById;
using MediatR;

namespace Backend.Core.Application.UseCases.Task.GetTasksByUserId;

public class GetTasksByUserIdHandler(
GetUserByIdUseCase getUserByIdUseCase,
GetTasksByUserIdUseCase getTasksByUserIdUseCase,
IMapper mapper
)
: IRequestHandler<GetTasksByUserIdRequest, List<GetTasksByUserIdResponse>>
{
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly GetTasksByUserIdUseCase _getTasksByUserIdUseCase = getTasksByUserIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetTasksByUserIdResponse>> Handle(GetTasksByUserIdRequest request, CancellationToken cancellationToken)
    {
        await _getUserByIdUseCase.Execute(request.UserId, cancellationToken);
        var tasks = await _getTasksByUserIdUseCase.Execute(request.UserId, cancellationToken);
        return tasks.Select(_mapper.Map<GetTasksByUserIdResponse>).ToList();
    }
}
