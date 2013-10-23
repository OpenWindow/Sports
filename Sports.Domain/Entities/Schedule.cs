using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sports.Domain.Entities
{

    public enum MatchResult
    {
        Success,
        Draw,
        Abondoned,
        WashedOut
    }

  public partial class Schedule
  {
    
    //Primary Key
    public int ScheduleId { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public DateTime GameTimestamp { get; set; }
    public int WinnerId { get; set; }
    public MatchResult Result { get; set; }
    public string Umpiring { get; set; }


    //Foreign Key
    public int TournamentId { get; set; }

    //navigation
    public ICollection<Team> Teams { get; set; }
 
  }
}
