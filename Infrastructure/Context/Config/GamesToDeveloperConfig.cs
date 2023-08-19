using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context.Config
{
    public class GamesToDeveloperConfig : IEntityTypeConfiguration<GamesToDeveloperEntity>
    {
        public void Configure(EntityTypeBuilder<GamesToDeveloperEntity> builder)
        {
            builder.ToTable("GamesToDevelopers");

            builder.HasKey(gtg => new { gtg.GameId, gtg.DeveloperId });

            builder
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToDevelopers)
                .HasForeignKey(gtg => gtg.GameId);

            builder
               .HasOne(gtg => gtg.Developer)
               .WithMany(g => g.GamesToDevelopers)
               .HasForeignKey(gtg => gtg.DeveloperId);
        }
    }
}
