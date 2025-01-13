using MediatR;
using Tasks = System.Threading.Tasks;

namespace Backend.Core.Application.UseCases.User.DeleteUser;

public class DeleteUserHandler(DeleteUserUseCase deleteUserUseCase) : IRequestHandler<DeleteUserRequest>
{
    private readonly DeleteUserUseCase _deleteUserUseCase = deleteUserUseCase;

    public async Tasks.Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        => await _deleteUserUseCase.Execute(request.Id, cancellationToken);
}
