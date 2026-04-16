namespace Restaurant.Domain.Exceptions;

public class TableSeatsExceededException(int guestsCount, int seats)
    : InvalidOperationException($"Количество гостей ({guestsCount}) превышает вместимость столика ({seats} мест).");
