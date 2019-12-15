namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(ps => new { ps.GameId, ps.PlayerId });

            builder
                .HasOne(ps => ps.Player)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);

            builder
                .HasOne(ps => ps.Game)
                .WithMany(ps => ps.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

            builder
                .Property(ps => ps.ScoredGoals)
                .IsRequired(true);

            builder
                .Property(ps => ps.Assists)
                .IsRequired(true);

            builder
                .Property(ps => ps.MinutesPlayed)
                .IsRequired(true);

        }
    }
}
