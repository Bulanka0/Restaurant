using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Exceptions;
using Restaurant.ValueObjects;

namespace Restaurant.Domain.Entities;

public class Client : Entity<Guid>
{
    public PersonName Name { get; private set; } = default!;
    public Phone Phone { get; private set; } = default!;

    protected Client()
    {
    }

    public Client(PersonName name, Phone phone)
        : this(Guid.NewGuid(), name, phone)
    {
    }

    protected Client(Guid id, PersonName name, Phone phone)
        : base(id)
    {
        Name = name ?? throw new ArgumentNullValueException(nameof(name));
        Phone = phone ?? throw new ArgumentNullValueException(nameof(phone));
    }

    public void ChangeName(PersonName newName)
    {
        Name = newName ?? throw new ArgumentNullValueException(nameof(newName));
    }

    public void ChangePhone(Phone newPhone)
    {
        Phone = newPhone ?? throw new ArgumentNullValueException(nameof(newPhone));
    }
}
