﻿namespace P03_FootballBetting.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> position)
        {
            position.HasKey(p => p.PositionId);

            position
                .Property(p => p.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
        }
    }
}
