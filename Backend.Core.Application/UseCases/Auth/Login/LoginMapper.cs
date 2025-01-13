using AutoMapper;
using Backend.Core.Application.DTOs;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Auth.Login;

public sealed class LoginMapper : Profile
{
    public LoginMapper()
    {
        CreateMap<Entities.User, UserDTO>();
    }
}
