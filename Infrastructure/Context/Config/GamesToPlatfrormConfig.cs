﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToPlatfrormConfig : IEntityTypeConfiguration<GamesToPlatfrormEntity>
    {
        public void Configure(EntityTypeBuilder<GamesToPlatfrormEntity> builder)
        {
            builder.ToTable("GamesToPlatfrorm");

            builder.HasKey(gtg => new { gtg.GameId, gtg.PlatformId });

            builder
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToPlatfrorms)
                .HasForeignKey(gtg => gtg.GameId);

            builder
               .HasOne(gtg => gtg.Platform)
               .WithMany(g => g.GamesToPlatfrorms)
               .HasForeignKey(gtg => gtg.PlatformId);
        }
    }
}
