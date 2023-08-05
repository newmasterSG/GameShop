using Domain.Entities.PlatformInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class PlatformInfoConfig : IEntityTypeConfiguration<PlatformInfoModel>
    {
        public void Configure(EntityTypeBuilder<PlatformInfoModel> builder)
        {
            builder.ToTable("PlatformInfo");
        }
    }
}
