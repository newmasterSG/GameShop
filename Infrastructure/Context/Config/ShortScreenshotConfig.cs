using Domain.Entities.ShortScreenshot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class ShortScreenshotConfig : IEntityTypeConfiguration<ShortScreenshotModel>
    {
        public void Configure(EntityTypeBuilder<ShortScreenshotModel> builder)
        {
            builder.ToTable("ShortScreenshot");

             builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
