using Restaurant.ValueObjects.Base;
using Restaurant.ValueObjects.Exceptions;
using System.Text.RegularExpressions;

namespace Restaurant.ValueObjects.Validators;

public class PhoneValidator : IValidator<string>
{
    private static readonly Regex PhoneRegex = new(@"^\+?[78]\d{10}$", RegexOptions.Compiled);

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (!PhoneRegex.IsMatch(value))
            throw new InvalidPhoneException(value);
    }
}
