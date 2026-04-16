using Restaurant.Domain.Entities;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Repositories.Abstractions;

public interface IReservationRepository : IRepository<Reservation, Guid>
{
    Task<IEnumerable<Reservation>> GetByClientIdAsync(Guid clientId, CancellationToken cancellationToken);

    Task<IEnumerable<Reservation>> GetByDateAsync(DateTime date, CancellationToken cancellationToken);

    Task<IEnumerable<Reservation>> GetByStatusAsync(ReservationStatus status, CancellationToken cancellationToken);

    /// <summary>
    /// Подтверждённые брони, время которых уже прошло — для проверки 15-минутного правила.
    /// </summary>
    Task<IEnumerable<Reservation>> GetExpiredConfirmedAsync(DateTime olderThan, CancellationToken cancellationToken);
}
