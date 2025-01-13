using Entities = Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Core.Application.Exceptions;
using static BCrypt.Net.BCrypt;

namespace Backend.Core.Application.UseCases.Auth.Login;

public class LoginUseCase(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<(Entities.User, string)> Execute(string email, string password, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(email, cancellationToken)
            ?? throw new UnauthorizedException("Invalid email or password.");

        if (!Verify(password, user.Password))
            throw new UnauthorizedException("Invalid email or password.");

        var token = _jwtTokenGenerator.Generate(user.Id, user.Email);

        return (user, token);
    }
}
