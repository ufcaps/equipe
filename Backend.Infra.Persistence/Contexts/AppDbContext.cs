using Entities = Backend.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<Entities.User> Users { get; set; } = null!;
    public DbSet<Entities.Task> Tasks { get; set; } = null!;
}
