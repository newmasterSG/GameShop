using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToGenresConfig : IEntityTypeConfiguration<GamesToGenresEntity>
    {
        public void Configure(EntityTypeBuilder<GamesToGenresEntity> builder)
        {
            builder.ToTable("GamesToGenres");

            builder.HasKey(gtg => new { gtg.GameId, gtg.GenreId });

            builder
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToGenres)
                .HasForeignKey(gtg => gtg.GameId);

            builder
               .HasOne(gtg => gtg.Genre)
               .WithMany(g => g.GamesToGenres)
               .HasForeignKey(gtg => gtg.GenreId);
        }
    }
}
