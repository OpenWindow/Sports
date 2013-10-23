using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sports.Domain.Entities;

namespace Sports.Domain.Abstract
{
    public interface ITournamentRepository
    {
        IQueryable<Tournament> Tournaments { get; }
        void SaveTournament(Tournament tournament);
        void DeleteTournament(Tournament tournament);
    }
}
