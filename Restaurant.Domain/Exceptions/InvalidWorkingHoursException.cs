namespace Restaurant.Domain.Exceptions;

public class InvalidWorkingHoursException(TimeSpan openTime, TimeSpan closeTime)
    : ArgumentException($"Некорректный график: время открытия ({openTime:hh\\:mm}) должно быть раньше времени закрытия ({closeTime:hh\\:mm}).");
