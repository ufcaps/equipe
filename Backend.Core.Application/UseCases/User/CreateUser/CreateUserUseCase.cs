using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.UseCases.User.EmailExists;
using static BCrypt.Net.BCrypt;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public class CreateUserUseCase(EmailExistsUseCase emailExistsUseCase, IUserRepository userRepository, IUnitOfWork unitOfWork)
{
    private readonly EmailExistsUseCase _emailExistsUseCase = emailExistsUseCase;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Entities.User> Execute(Entities.User user, CancellationToken cancellationToken)
    {
        await _emailExistsUseCase.Execute(user.Email);

        user.Password = HashPassword(user.Password, GenerateSalt());

        _userRepository.Create(user);
        await _unitOfWork.Commit(cancellationToken);

        return user;
    }
}
