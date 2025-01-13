using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IRepository<T> where T : Entity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetById(int id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
}
