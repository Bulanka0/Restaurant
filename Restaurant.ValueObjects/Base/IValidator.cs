namespace Restaurant.ValueObjects.Base;

public interface IValidator<T>
{
    void Validate(T value);
}
