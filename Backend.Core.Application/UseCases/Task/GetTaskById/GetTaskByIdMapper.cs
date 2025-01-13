using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Task.GetTaskById;

public sealed class GetTaskByIdMapper : Profile
{
    public GetTaskByIdMapper()
    {
        CreateMap<Entities.Task, GetTaskByIdResponse>();
    }
}
