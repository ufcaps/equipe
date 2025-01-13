using AutoMapper;
using Backend.Core.Application.DTOs;
using MediatR;

namespace Backend.Core.Application.UseCases.Auth.Login;

public class LoginHandler(LoginUseCase loginUseCase, IMapper mapper) : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly LoginUseCase _loginUseCase = loginUseCase;
    private readonly IMapper _mapper = mapper;

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var (user, token) = await _loginUseCase.Execute(request.Email, request.Password, cancellationToken);

        return new LoginResponse
        {
            Token = token,
            User = _mapper.Map<UserDTO>(user)
        };
    }
}
