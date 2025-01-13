using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Contexts;
using Backend.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infra.Persistence.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("database"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}
