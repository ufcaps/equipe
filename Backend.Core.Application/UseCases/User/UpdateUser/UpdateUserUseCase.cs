using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using AutoMapper;
using Backend.Core.Application.UseCases.User.GetUserById;
using Backend.Core.Application.UseCases.User.EmailExists;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public class UpdateUserUseCase(
    GetUserByIdUseCase getUserByIdUseCase,
    EmailExistsUseCase emailExistsUseCase,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
)
{
    private readonly GetUserByIdUseCase _getUserByIdUseCase = getUserByIdUseCase;
    private readonly EmailExistsUseCase _emailExistsUseCase = emailExistsUseCase;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<Entities.User> Execute(int id, Entities.User data, CancellationToken cancellationToken)
    {
        var user = await _getUserByIdUseCase.Execute(id, cancellationToken);

        if (!string.IsNullOrEmpty(data.Email) && data.Email != user.Email)
            await _emailExistsUseCase.Execute(data.Email);

        user = _mapper.Map(data, user);

        _userRepository.Update(user);
        await _unitOfWork.Commit(cancellationToken);

        return user;
    }
}
