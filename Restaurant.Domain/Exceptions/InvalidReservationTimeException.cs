namespace Restaurant.Domain.Exceptions;

public class InvalidReservationTimeException(DateTime reservedAt)
    : ArgumentException($"Время бронирования '{reservedAt:dd.MM.yyyy HH:mm}' некорректно. Нельзя бронировать на прошедшее время.");
