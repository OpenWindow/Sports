using System.Linq;
using Sports.Domain.Abstract;
using Sports.Domain.Entities;

namespace Sports.Domain.Concrete
{
  public class EFScheduleRepository : IScheduleRepository
  {
      private EFDbContext context = new EFDbContext();

    public IQueryable<Schedule> Schedule
    {
        get { return context.Schedule; }
    }

    public Schedule GetSchedule(int scheduleId)
    {
        return context.Schedule.FirstOrDefault(s => s.ScheduleId == scheduleId);
    }

    public IQueryable<Schedule> GetCurrentSchedule(int tournamentId)
    {
        return context.Schedule.Where(s => s.TournamentId == tournamentId);
    }
  }
}
