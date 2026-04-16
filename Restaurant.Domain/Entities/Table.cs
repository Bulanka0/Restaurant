using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Domain.Entities;

public class Table : Entity<int>
{
    public int Number { get; private set; }
    public int Seats { get; private set; }
    public bool IsAvailable { get; private set; }

    protected Table()
    {
    }

    public Table(int id, int number, int seats)
        : base(id)
    {
        if (number <= 0)
            throw new ArgumentNullValueException(nameof(number));

        if (seats <= 0)
            throw new ArgumentNullValueException(nameof(seats));

        Number = number;
        Seats = seats;
        IsAvailable = true;
    }

    public void MakeAvailable()
    {
        IsAvailable = true;
    }

    public void MakeUnavailable()
    {
        IsAvailable = false;
    }
}
