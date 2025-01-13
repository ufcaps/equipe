using Backend.Core.Domain.Entities;
using Backend.Core.Domain.Interfaces;
using Backend.Infra.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Persistence.Repositories;

public class Repository<T>(AppDbContext context) : IRepository<T> where T : Entity
{
    protected readonly AppDbContext context = context;

    public void Create(T entity)
        => context.Set<T>().Add(entity);

    public void Update(T entity)
        => context.Set<T>().Update(entity);

    public void Delete(T entity)
        => context.Set<T>().Remove(entity);

    public async Task<T?> GetById(int id, CancellationToken cancellationToken)
        => await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        => await context.Set<T>().ToListAsync(cancellationToken);
}
