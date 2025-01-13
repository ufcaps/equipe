using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public class GetUserByIdUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Entities.User> Execute(int id, CancellationToken cancellationToken)
        => await _userRepository.GetById(id, cancellationToken)
            ?? throw new NotFoundException("User does not exist.");
}
