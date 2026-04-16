using Restaurant.ValueObjects.Base;
using Restaurant.ValueObjects.Exceptions;

namespace Restaurant.ValueObjects.Validators;

public class PersonNameValidator : IValidator<string>
{
    public const int MinLength = 2;
    public const int MaxLength = 100;

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length < MinLength)
            throw new PersonNameTooShortException(value, MinLength);

        if (value.Length > MaxLength)
            throw new PersonNameTooLongException(value, MaxLength);
    }
}
