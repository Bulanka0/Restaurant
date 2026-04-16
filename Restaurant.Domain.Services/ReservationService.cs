using Restaurant.Domain.Entities;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Domain.Services;

public class ReservationService
{
    /// <summary>
    /// Создать новую бронь.
    /// Проверяет столик, вместимость и график работы ресторана.
    /// </summary>
    public Reservation CreateReservation(
        Client client,
        Table table,
        WorkingHours workingHours,
        DateTime startTime,
        DateTime endTime,
        int guestsCount)
    {
        if (client is null)
            throw new ArgumentNullValueException(nameof(client));

        if (table is null)
            throw new ArgumentNullValueException(nameof(table));

        if (workingHours is null)
            throw new ArgumentNullValueException(nameof(workingHours));

        // ресторан не работает в этот день
        if (!workingHours.IsWorkingDay)
            throw new RestaurantClosedException(startTime);

        // время брони вне рабочих часов
        if (startTime.TimeOfDay < workingHours.OpenTime || endTime.TimeOfDay > workingHours.CloseTime)
            throw new InvalidReservationTimeException(startTime);

        // столик недоступен
        if (!table.IsAvailable)
            throw new TableNotAvailableException(table.Number);

        // гостей больше чем мест
        if (guestsCount > table.Seats)
            throw new TableSeatsExceededException(guestsCount, table.Seats);

        return new Reservation(client.Id, table.Id, startTime, endTime, guestsCount);
    }

    /// <summary>
    /// Перенести бронь на другое время и/или столик.
    /// </summary>
    public void TransferReservation(
        Reservation reservation,
        Table newTable,
        WorkingHours workingHours,
        DateTime newStartTime,
        DateTime newEndTime,
        int newGuestsCount)
    {
        if (reservation is null)
            throw new ArgumentNullValueException(nameof(reservation));

        if (newTable is null)
            throw new ArgumentNullValueException(nameof(newTable));

        if (workingHours is null)
            throw new ArgumentNullValueException(nameof(workingHours));

        // ресторан не работает в этот день
        if (!workingHours.IsWorkingDay)
            throw new RestaurantClosedException(newStartTime);

        // время брони вне рабочих часов
        if (newStartTime.TimeOfDay < workingHours.OpenTime || newEndTime.TimeOfDay > workingHours.CloseTime)
            throw new InvalidReservationTimeException(newStartTime);

        // столик недоступен
        if (!newTable.IsAvailable)
            throw new TableNotAvailableException(newTable.Number);

        // гостей больше чем мест
        if (newGuestsCount > newTable.Seats)
            throw new TableSeatsExceededException(newGuestsCount, newTable.Seats);

        reservation.Transfer(newTable.Id, newStartTime, newEndTime, newGuestsCount);
    }
}
