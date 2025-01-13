using Backend.Core.Application.Exceptions;
using Backend.Core.Domain.Interfaces;
using Tasks = System.Threading.Tasks;

namespace Backend.Core.Application.UseCases.User.EmailExists;

public class EmailExistsUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Tasks.Task Execute(string email)
    {
        if (await _userRepository.EmailExists(email))
            throw new ConflictException("The email address is already in use.");
    }
}
