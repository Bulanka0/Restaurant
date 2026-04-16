namespace Restaurant.ValueObjects.Exceptions;

public class ValidatorNullException(string paramName)
    : ArgumentNullException(paramName, "Validator must be specified for type.");
