using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF_DB_First_Sample.Models.Mapping;

namespace EF_DB_First_Sample.Models
{
    public class Testdb1Context : DbContext
    {
        static Testdb1Context()
        {
            Database.SetInitializer<Testdb1Context>(null);
        }

		public Testdb1Context()
			: base("Name=Testdb1Context")
		{
		}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeamMap());
            modelBuilder.Configurations.Add(new TournamentMap());
        }
    }
}
