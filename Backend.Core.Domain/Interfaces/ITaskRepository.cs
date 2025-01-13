namespace Backend.Core.Domain.Interfaces;

public interface ITaskRepository : IRepository<Entities.Task>
{
    Task<List<Entities.Task>> GetByUserId(int userId, CancellationToken cancellationToken);
}
