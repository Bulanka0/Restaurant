using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstractions;

public interface ITableRepository : IRepository<Table, int>
{
    Task<IEnumerable<Table>> GetAvailableTablesAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Table>> GetTablesBySeatsAsync(int minSeats, CancellationToken cancellationToken);
}
