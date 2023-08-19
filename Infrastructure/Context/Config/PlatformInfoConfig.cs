using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class PlatformInfoConfig : IEntityTypeConfiguration<PlatformInfoEntity>
    {
        public void Configure(EntityTypeBuilder<PlatformInfoEntity> builder)
        {
            builder.ToTable("PlatformInfo");
        }
    }
}
