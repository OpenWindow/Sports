using System;
using System.Collections.Generic;

namespace EF_DB_First_Sample.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamPOC { get; set; }
        public int TournamentId { get; set; }
        public int TeamFlags { get; set; }
    }
}
