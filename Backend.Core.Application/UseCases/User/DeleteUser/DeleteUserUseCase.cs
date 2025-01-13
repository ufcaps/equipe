using Backend.Core.Application.UseCases.User.GetUserById;
using Backend.Core.Domain.Interfaces;
using Tasks = System.Threading.Tasks;

namespace Backend.Core.Application.UseCases.User.DeleteUser;

public class DeleteUserUseCase(
    GetUserByIdUseCase getUserByIdUseCase,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
)
{
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Tasks.Task Execute(int id, CancellationToken cancellationToken)
    {
        var user = await _getUserByIdUseCase.Execute(id, cancellationToken);

        _userRepository.Delete(user);
        await _unitOfWork.Commit(cancellationToken);
    }
}
