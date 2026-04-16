namespace Restaurant.ValueObjects.Exceptions;

public class PersonNameTooLongException(string name, int maxLength)
    : FormatException($"Имя '{name}' слишком длинное. Максимальная длина: {maxLength} символов.");
