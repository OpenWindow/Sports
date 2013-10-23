using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sports.Domain.Entities;

namespace Sports.Domain.Abstract
{
  public interface ITeamRepository
  {

    IQueryable<Team> Teams { get; }
    Team GetTeam(int teamId);

  }
}
