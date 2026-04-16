namespace Restaurant.Domain.Exceptions;

public class TableNotAvailableException(int tableNumber)
    : InvalidOperationException($"Столик №{tableNumber} недоступен для бронирования.");
