using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class ShortScreenshotConfig : IEntityTypeConfiguration<ShortScreenshotEntity>
    {
        public void Configure(EntityTypeBuilder<ShortScreenshotEntity> builder)
        {
            builder.ToTable("ShortScreenshot");

             builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
