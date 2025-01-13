using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Task.GetTasksByUserId;

public sealed class GetTasksByUserIdMapper : Profile
{
    public GetTasksByUserIdMapper()
    {
        CreateMap<Entities.Task, GetTasksByUserIdResponse>();
    }
}
