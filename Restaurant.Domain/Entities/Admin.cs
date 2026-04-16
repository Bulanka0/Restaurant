using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Exceptions;
using Restaurant.ValueObjects;

namespace Restaurant.Domain.Entities;

public class Admin : Entity<Guid>
{
    public PersonName Name { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;
    public string PasswordHash { get; private set; } = default!;

    protected Admin()
    {
    }

    public Admin(PersonName name, Phone phone, string passwordHash)
        : this(Guid.NewGuid(), name, phone, passwordHash)
    {
    }

    protected Admin(Guid id, PersonName name, Phone phone, string passwordHash)
        : base(id)
    {
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        Phone = phone ?? throw new ArgumentNullValueException(nameof(phone));

        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentNullValueException(nameof(passwordHash));

        PasswordHash = passwordHash;
    }

    public void ChangePasswordHash(string newPasswordHash)
    {
        if (string.IsNullOrWhiteSpace(newPasswordHash))
            throw new ArgumentNullValueException(nameof(newPasswordHash));

        PasswordHash = newPasswordHash;
    }
}
