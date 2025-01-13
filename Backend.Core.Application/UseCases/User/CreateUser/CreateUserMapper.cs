using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.User.CreateUser;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, Entities.User>();
        CreateMap<Entities.User, CreateUserResponse>();
    }
}
