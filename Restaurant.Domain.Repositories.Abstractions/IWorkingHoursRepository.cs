using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Repositories.Abstractions;

public interface IWorkingHoursRepository : IRepository<WorkingHours, int>
{
    Task<WorkingHours?> GetByDayOfWeekAsync(DayOfWeek dayOfWeek, CancellationToken cancellationToken);
}
