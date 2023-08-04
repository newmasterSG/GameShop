using Domain.Models.GamesToScreenshots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GamesToScreenshotsConfig : IEntityTypeConfiguration<GamesToScreenshotsModel>
    {
        public void Configure(EntityTypeBuilder<GamesToScreenshotsModel> builder)
        {
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
               .HasForeignKey<GamesToScreenshotsModel>(gtg => gtg.ScreenshotId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
