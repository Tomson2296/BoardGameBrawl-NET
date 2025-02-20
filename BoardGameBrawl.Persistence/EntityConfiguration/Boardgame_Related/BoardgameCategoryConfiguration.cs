﻿using BoardGameBrawl.Domain.Entities.Boardgame_Related;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoardGameBrawl.Persistence.EntityConfiguration.Boardgame_Related
{
    internal class BoardgameCategoryConfiguration : IEntityTypeConfiguration<BoardgameCategory>
    {
        public void Configure(EntityTypeBuilder<BoardgameCategory> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Category)
                .HasMaxLength(256)
                .IsRequired();

            entity.HasIndex(e => e.Category)
                .HasDatabaseName("BoardgameCategoryIndex")
                .IsUnique();

            //entity.HasMany(e => e.BoardgameCategoryTags)
            //   .WithOne()
            //   .HasForeignKey(t => t.CategoryId)
            //   .IsRequired();

            entity.ToTable("BoardgameCategories");
        }
    }
}
