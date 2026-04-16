namespace Restaurant.Domain.Exceptions;

public class ReservationAlreadyCancelledException(Guid reservationId)
    : InvalidOperationException($"Бронь '{reservationId}' уже отменена.");
