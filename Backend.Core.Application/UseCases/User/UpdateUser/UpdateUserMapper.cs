using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.User.UpdateUser;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, Entities.User>();
        CreateMap<Entities.User, UpdateUserResponse>();

        CreateMap<Entities.User, Entities.User>()
            .ForAllMembers(x => x.Condition((_, _, src) => src != null));
    }
}
