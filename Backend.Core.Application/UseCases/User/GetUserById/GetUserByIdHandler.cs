using AutoMapper;
using Backend.Core.Application.UseCases.Task.GetTasksByUserId;
using MediatR;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public class GetUserByIdHandler(
    GetTasksByUserIdUseCase getTasksByUserIdUseCase,
    GetUserByIdUseCase getUserByIdUseCase,
    IMapper mapper
) : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly GetTasksByUserIdUseCase _getTasksByUserIdUseCase = getTasksByUserIdUseCase;
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await _getUserByIdUseCase.Execute(request.Id, cancellationToken);
        user.Tasks = await _getTasksByUserIdUseCase.Execute(request.Id, cancellationToken);
        return _mapper.Map<GetUserByIdResponse>(user);
    }
}
