namespace Restaurant.Domain.Exceptions;

public class RestaurantClosedException(DateTime reservationTime)
    : InvalidOperationException($"Ресторан не работает {reservationTime:dd.MM.yyyy} ({reservationTime.DayOfWeek}).");
