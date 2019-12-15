namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> team)
        {
            team.HasKey(t => t.TeamId);

            team
                .Property(t => t.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);

            team
                .Property(t => t.LogoUrl)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(300);

            team
                .Property(t => t.Initials)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);

            team
                .Property(t => t.Budget)
                .IsRequired(true);

            team
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId);

            team
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId);

            team
                .HasOne(t => t.Town)
                .WithMany(tn => tn.Teams)
                .HasForeignKey(t => t.TownId);
        }
    }
}
