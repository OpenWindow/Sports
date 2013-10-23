using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EF_DB_First_Sample.Models.Mapping
{
    public class TeamMap : EntityTypeConfiguration<Team>
    {
        public TeamMap()
        {
            // Primary Key
            this.HasKey(t => t.TeamId);

            // Properties
            this.Property(t => t.TeamName)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(t => t.TeamPOC)
                .IsRequired()
                .HasMaxLength(120);

            // Table & Column Mappings
            this.ToTable("Team", "AppUser");
            this.Property(t => t.TeamId).HasColumnName("TeamId");
            this.Property(t => t.TeamName).HasColumnName("TeamName");
            this.Property(t => t.TeamPOC).HasColumnName("TeamPOC");
            this.Property(t => t.TournamentId).HasColumnName("TournamentId");
            this.Property(t => t.TeamFlags).HasColumnName("TeamFlags");
        }
    }
}
