﻿using BoardGameBrawl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameBrawl.Persistence.EntityConfiguration
{
    internal class BoardgameCategoryConfiguration : IEntityTypeConfiguration<BoardgameCategory>
    {
        public void Configure(EntityTypeBuilder<BoardgameCategory> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Category).HasMaxLength(256).IsRequired();

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("BoardgameCategories");
        }
    }
}
