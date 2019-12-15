namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> game)
        {
            game.HasKey(g => g.GameId);

            game
                .Property(g => g.AwayTeamBetRate)
                .IsRequired(true);

            game
                .Property(g => g.AwayTeamGoals)
                .IsRequired(true);

            game
                .Property(g => g.HomeTeamBetRate)
                .IsRequired(true);

            game
                .Property(g => g.HomeTeamGoals)
                .IsRequired(true);

            game
                .Property(g => g.Result)
                .IsRequired(true);

            game
                .Property(g => g.DateTime)
                .IsRequired(true)
                .HasColumnType("SMALLDATETIME");

            game
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId);

            game
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId);
        }
    }
}
