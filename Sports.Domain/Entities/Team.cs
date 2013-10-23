using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sports.Domain.Entities
{
  public class Team
  {
    public int TeamId { get; set; }
    public string TeamName { get; set; }
    public string TeamNameAb { get; set; } //abbreviation
    public string TeamPOC { get; set; }
    public int TournamentId { get; set; }
    public int GroupId { get; set; }
    public int Flags { get; set; }

    //navigation
    public virtual Tournament Tournament { get; set; }
  }
}
