namespace Restaurant.ValueObjects.Exceptions;

public class InvalidPhoneException(string phone)
    : FormatException($"Номер телефона '{phone}' имеет неверный формат. Ожидается: +7XXXXXXXXXX или 8XXXXXXXXXX.");
