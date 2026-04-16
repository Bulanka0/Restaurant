using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Domain.Entities;

/// <summary>
/// Агрегатный корень — бронь столика.
/// </summary>
public class Reservation : Entity<Guid>
{
    public Guid ClientId { get; private set; }
    public int TableId { get; private set; }
    public Guid? ConfirmedBy { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public int GuestsCount { get; private set; }
    public ReservationStatus Status { get; private set; }

    protected Reservation()
    {
    }

    public Reservation(Guid clientId, int tableId, DateTime startTime, DateTime endTime, int guestsCount)
        : this(Guid.NewGuid(), clientId, tableId, startTime, endTime, guestsCount)
    {
    }

    protected Reservation(Guid id, Guid clientId, int tableId, DateTime startTime, DateTime endTime, int guestsCount)
        : base(id)
    {
        if (clientId == Guid.Empty)
            throw new ArgumentNullValueException(nameof(clientId));

        if (guestsCount <= 0)
            throw new InvalidGuestsCountException(guestsCount);

        if (startTime <= DateTime.UtcNow)
            throw new InvalidReservationTimeException(startTime);

        if (endTime <= startTime)
            throw new InvalidReservationTimeException(endTime);

        ClientId = clientId;
        TableId = tableId;
        StartTime = startTime;
        EndTime = endTime;
        GuestsCount = guestsCount;
        Status = ReservationStatus.Pending;
    }

    /// <summary>
    /// Подтвердить бронь (только администратор).
    /// </summary>
    public void Confirm(Guid adminId)
    {
        if (Status != ReservationStatus.Pending)
            throw new ReservationNotPendingException(Id);

        ConfirmedBy = adminId;
        Status = ReservationStatus.Confirmed;
    }

    /// <summary>
    /// Отменить бронь (клиент или администратор).
    /// </summary>
    public void Cancel()
    {
        if (Status == ReservationStatus.Cancelled)
            throw new ReservationAlreadyCancelledException(Id);

        if (Status == ReservationStatus.Expired)
            throw new InvalidOperationException($"Нельзя отменить истёкшую бронь '{Id}'.");

        Status = ReservationStatus.Cancelled;
    }

    /// <summary>
    /// Пометить бронь как истёкшую — клиент не пришёл в течение 15 минут.
    /// </summary>
    public void Expire()
    {
        if (Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException($"Бронь '{Id}' нельзя пометить как истёкшую: она не подтверждена.");

        Status = ReservationStatus.Expired;
    }

    /// <summary>
    /// Перенести бронь на другое время и/или другой столик.
    /// Бронь возвращается в статус Pending для повторного подтверждения.
    /// </summary>
    public void Transfer(int newTableId, DateTime newStartTime, DateTime newEndTime, int newGuestsCount)
    {
        if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
            throw new InvalidOperationException($"Бронь '{Id}' нельзя перенести: статус '{Status}'.");

        if (newStartTime <= DateTime.UtcNow)
            throw new InvalidReservationTimeException(newStartTime);

        if (newEndTime <= newStartTime)
            throw new InvalidReservationTimeException(newEndTime);

        if (newGuestsCount <= 0)
            throw new InvalidGuestsCountException(newGuestsCount);

        TableId = newTableId;
        StartTime = newStartTime;
        EndTime = newEndTime;
        GuestsCount = newGuestsCount;
        ConfirmedBy = null;
        Status = ReservationStatus.Pending;
    }
}
