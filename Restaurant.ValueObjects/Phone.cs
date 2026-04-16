using Restaurant.ValueObjects.Base;
using Restaurant.ValueObjects.Validators;

namespace Restaurant.ValueObjects;

public class Phone(string value) : ValueObject<string>(new PhoneValidator(), value);
