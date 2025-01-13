using System.Reflection;
using Backend.Core.Application.Shared.Behavior;
using Backend.Core.Application.UseCases.Auth.Login;
using Backend.Core.Application.UseCases.Task.CreateTask;
using Backend.Core.Application.UseCases.Task.DeleteTask;
using Backend.Core.Application.UseCases.Task.GetTaskById;
using Backend.Core.Application.UseCases.Task.GetTasksByUserId;
using Backend.Core.Application.UseCases.Task.UpdateTask;
using Backend.Core.Application.UseCases.User.CreateUser;
using Backend.Core.Application.UseCases.User.DeleteUser;
using Backend.Core.Application.UseCases.User.EmailExists;
using Backend.Core.Application.UseCases.User.GetUserById;
using Backend.Core.Application.UseCases.User.UpdateUser;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Core.Application.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddTransient<CreateUserUseCase>();
        services.AddTransient<UpdateUserUseCase>();
        services.AddTransient<DeleteUserUseCase>();
        services.AddTransient<GetUserByIdUseCase>();
        services.AddTransient<EmailExistsUseCase>();

        services.AddTransient<CreateTaskUseCase>();
        services.AddTransient<UpdateTaskUseCase>();
        services.AddTransient<DeleteTaskUseCase>();
        services.AddTransient<GetTaskByIdUseCase>();
        services.AddTransient<GetTasksByUserIdUseCase>();

        services.AddTransient<LoginUseCase>();
    }
}
