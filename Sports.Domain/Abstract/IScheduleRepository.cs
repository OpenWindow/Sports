using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sports.Domain.Entities;

namespace Sports.Domain.Abstract
{
  public interface IScheduleRepository
  {
    IQueryable<Schedule> Schedule { get; }

    Schedule GetSchedule(int scheduleId);

    IQueryable<Schedule> GetCurrentSchedule(int tournamentId);
  }
}
