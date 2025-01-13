using Backend.Core.Domain.Entities;

namespace Backend.Core.Domain.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
    Task<bool> EmailExists(string email);
}
