using Domain.Entities.StoreInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class StoreInfoConfig : IEntityTypeConfiguration<StoreInfoModel>
    {
        public void Configure(EntityTypeBuilder<StoreInfoModel> builder)
        {
            builder.ToTable("StoreInfo");
        }
    }
}
