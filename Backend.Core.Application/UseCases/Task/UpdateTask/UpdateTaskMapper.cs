using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Task.UpdateTask;

public sealed class UpdateTaskMapper : Profile
{
    public UpdateTaskMapper()
    {
        CreateMap<UpdateTaskRequest, Entities.Task>();
        CreateMap<Entities.Task, UpdateTaskResponse>();

        CreateMap<Entities.Task, Entities.Task>()
            .ForMember(x => x.UserId, opt => opt.Ignore())
            .ForAllMembers(x => x.Condition((_, _, src) => src != null));
    }
}
