using Domain.Entities.Platform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class PlatformConfig : IEntityTypeConfiguration<PlatformModel>
    {
        public void Configure(EntityTypeBuilder<PlatformModel> builder)
        {
            builder.ToTable("Platform");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
