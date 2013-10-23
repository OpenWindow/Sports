using System;
using System.Collections.Generic;

namespace EF_DB_First_Sample.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TournamentFlags { get; set; }
    }
}
