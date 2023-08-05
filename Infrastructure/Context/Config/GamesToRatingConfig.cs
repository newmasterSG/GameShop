using Domain.Entities.GamesToRating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToRatingConfig : IEntityTypeConfiguration<GamesToRatingModel>
    {
        public void Configure(EntityTypeBuilder<GamesToRatingModel> builder)
        {
            builder.ToTable("GamesToRating");

            builder.HasKey(gtg => new { gtg.GameId, gtg.RatingId });

            builder
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GamesToRatings)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(gtg => gtg.Rating)
               .WithMany(g => g.GamesToRatings)
               .HasForeignKey(gtg => gtg.RatingId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
