using Restaurant.Domain.Entities.Base;
using Restaurant.Domain.Exceptions;

namespace Restaurant.Domain.Entities;

public class WorkingHours : Entity<int>
{
    public DayOfWeek DayOfWeek { get; private set; }
    public TimeSpan OpenTime { get; private set; }
    public TimeSpan CloseTime { get; private set; }
    public bool IsWorkingDay { get; private set; }

    protected WorkingHours()
    {
    }

    public WorkingHours(int id, DayOfWeek dayOfWeek, TimeSpan openTime, TimeSpan closeTime, bool isWorkingDay)
        : base(id)
    {
        if (openTime >= closeTime)
            throw new InvalidWorkingHoursException(openTime, closeTime);

        DayOfWeek = dayOfWeek;
        OpenTime = openTime;
        CloseTime = closeTime;
        IsWorkingDay = isWorkingDay;
    }

    public void UpdateSchedule(TimeSpan openTime, TimeSpan closeTime)
    {
        if (openTime >= closeTime)
            throw new InvalidWorkingHoursException(openTime, closeTime);

        OpenTime = openTime;
        CloseTime = closeTime;
    }

    public void SetWorkingDay(bool isWorkingDay)
    {
        IsWorkingDay = isWorkingDay;
    }
}
