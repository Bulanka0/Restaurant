namespace Restaurant.ValueObjects.Exceptions;

public class PersonNameTooShortException(string name, int minLength)
    : FormatException($"Имя '{name}' слишком короткое. Минимальная длина: {minLength} символа.");
