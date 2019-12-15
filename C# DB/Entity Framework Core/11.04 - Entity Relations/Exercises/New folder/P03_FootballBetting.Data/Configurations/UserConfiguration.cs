namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(u => u.UserId);

            user
                .Property(u => u.Username)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

            user
                .Property(u => u.Password)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(20);

            user
                .Property(u => u.Email)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);

            user
                .Property(u => u.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(30);

            user
                .Property(u => u.Balance)
                .IsRequired(true);
        }
    }
}
