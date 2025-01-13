using AutoMapper;
using Entities = Backend.Core.Domain.Entities;
using MediatR;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public class CreateUserHandler(CreateUserUseCase createUserUse, IMapper mapper) : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly CreateUserUseCase _createUserUseCase = createUserUse;
    private readonly IMapper _mapper = mapper;

    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Entities.User>(request);
        var user = await _createUserUseCase.Execute(data, cancellationToken);
        return _mapper.Map<CreateUserResponse>(user);
    }
}
