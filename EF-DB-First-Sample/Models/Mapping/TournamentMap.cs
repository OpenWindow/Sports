using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_DB_First_Sample.Models.Mapping
{
    public class TournamentMap : EntityTypeConfiguration<Tournament>
    {
        public TournamentMap()
        {
            // Primary Key
            this.HasKey(t => t.TournamentId);

            // Properties
            this.Property(t => t.TournamentName)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("Tournament", "AppUser");
            this.Property(t => t.TournamentId).HasColumnName("TournamentId");
            this.Property(t => t.TournamentName).HasColumnName("TournamentName");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.TournamentFlags).HasColumnName("TournamentFlags");
        }
    }
}
