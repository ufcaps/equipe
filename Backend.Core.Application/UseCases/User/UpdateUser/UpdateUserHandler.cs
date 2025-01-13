using AutoMapper;
using MediatR;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public class UpdateUserHandler(UpdateUserUseCase updateUserUseCase, IMapper mapper) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly UpdateUserUseCase _updateUserUseCase = updateUserUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Entities.User>(request);
        var user = await _updateUserUseCase.Execute(request.Id, data, cancellationToken);
        return _mapper.Map<UpdateUserResponse>(user);
    }
}
