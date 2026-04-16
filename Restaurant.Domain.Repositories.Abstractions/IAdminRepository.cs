using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstractions;

public interface IAdminRepository : IRepository<Admin, Guid>
{
    Task<Admin?> GetByPhoneAsync(string phone, CancellationToken cancellationToken);
}
