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
    internal class GroupParticipantsConfiguration : IEntityTypeConfiguration<GroupParticipants>
    {
        public void Configure(EntityTypeBuilder<GroupParticipants> entity)
        {
            entity.HasKey(e => new { e.GroupId, e.UserId });

            entity.HasOne(e => e.Group)
               .WithMany(g => g.GroupParticipants)
               .HasForeignKey(e => e.GroupId);

            entity.HasOne(e => e.User)
                .WithMany(u => u.GroupParticipants)
                .HasForeignKey(e => e.UserId);

            //entity.HasQueryFilter(e => !e.IsSoftDeleted);

            entity.ToTable("GroupParticipants");
        }
    }
}
