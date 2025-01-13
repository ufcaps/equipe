using Entities = Backend.Core.Domain.Entities;
using Backend.Infra.Persistence.Contexts;
using Backend.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class TaskRepository(AppDbContext context) : Repository<Entities.Task>(context), ITaskRepository
{
    public async Task<List<Entities.Task>> GetByUserId(int userId, CancellationToken cancellationToken)
        => await context.Tasks.Where(x => x.UserId == userId).ToListAsync(cancellationToken);
}
