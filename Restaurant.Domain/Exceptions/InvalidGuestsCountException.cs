namespace Restaurant.Domain.Exceptions;

public class InvalidGuestsCountException(int guestsCount)
    : ArgumentException($"Количество гостей ({guestsCount}) должно быть больше нуля.");
