using Domain.Entities.GamesToESRBRating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class GamesToESRBRatingConfig : IEntityTypeConfiguration<GamesToESRBRatingModel>
    {
        public void Configure(EntityTypeBuilder<GamesToESRBRatingModel> builder)
        {
            builder.ToTable("GamesToESRBRating");

            builder.HasKey(gtg => new { gtg.GameId, gtg.ESRBId });

            builder
                .HasOne(gta => gta.Game)
                .WithOne(g => g.GamesToESRBRating)
                .HasForeignKey<GamesToESRBRatingModel>(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(gtg => gtg.ESRBRatingModel)
               .WithMany(g => g.GamesToESRBRating)
               .HasForeignKey(gtg => gtg.ESRBId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
