using AutoMapper;
using Entities = Backend.Core.Domain.Entities;

namespace Backend.Core.Application.UseCases.Task.CreateTask;

public sealed class CreateTaskMapper : Profile
{
    public CreateTaskMapper()
    {
        CreateMap<CreateTaskRequest, Entities.Task>();
        CreateMap<Entities.Task, CreateTaskResponse>();
    }
}
