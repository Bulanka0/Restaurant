namespace Restaurant.ValueObjects.Exceptions;

public class ArgumentNullOrWhiteSpaceException(string paramName)
    : ArgumentNullException(paramName, $"Argument '{paramName}' не может быть пустым или состоять из пробелов.");
