using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GamesToScreenshotsConfig : IEntityTypeConfiguration<GamesToScreenshotsEntity>
    {
        public void Configure(EntityTypeBuilder<GamesToScreenshotsEntity> builder)
        {
            builder.ToTable("GamesToScreenshots");

            builder
           .HasKey(gtg => new { gtg.GameId, gtg.ScreenshotId });

            builder
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GameToShortScreenshots)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(gtg => gtg.ShortScreenshot)
               .WithOne(g => g.GamesToScreenshots)
               .HasForeignKey<GamesToScreenshotsEntity>(gtg => gtg.ScreenshotId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
