using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.User.GetUserById;

public sealed class GetUserByIdMapper : Profile
{
    public GetUserByIdMapper()
    {
        CreateMap<Entities.User, GetUserByIdResponse>();
    }
}
