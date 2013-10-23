using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Sports.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sports.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
          Database.SetInitializer(new CreateDatabaseIfNotExists<EFDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<UserProfile>().Property(u => u.DisplayName).IsRequired();
        }

        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
   
}
