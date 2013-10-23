using System.Linq;
using Sports.Domain.Abstract;
using Sports.Domain.Entities;

namespace Sports.Domain.Concrete
{
    public class EFTournamentRepository : ITournamentRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Tournament> Tournaments
        {
            get { return context.Tournaments; }
        }

        public void SaveTournament(Tournament tournament)
        {
          if (tournament.TournamentId == 0)
          {
            context.Tournaments.Add(tournament);
          }
          else
          {
            context.Entry(tournament).State = System.Data.EntityState.Modified;
          }
          context.SaveChanges();
        }

        public void DeleteTournament(Tournament tournament)
        {
          context.Tournaments.Remove(tournament);
          context.SaveChanges();
        }
    }
}
