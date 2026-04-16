namespace Restaurant.Domain.Exceptions;

public class ArgumentNullValueException(string paramName)
    : ArgumentNullException(paramName, $"Параметр '{paramName}' не может быть null.");
