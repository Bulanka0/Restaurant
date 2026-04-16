using Restaurant.ValueObjects.Base;
using Restaurant.ValueObjects.Validators;

namespace Restaurant.ValueObjects;

public class PersonName(string value) : ValueObject<string>(new PersonNameValidator(), value);
