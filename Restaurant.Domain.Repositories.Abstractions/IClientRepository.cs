using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstractions;

public interface IClientRepository : IRepository<Client, Guid>
{
    Task<Client?> GetByPhoneAsync(string phone, CancellationToken cancellationToken);
}
