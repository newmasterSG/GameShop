using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class StoreInfoConfig : IEntityTypeConfiguration<StoreInfoEntity>
    {
        public void Configure(EntityTypeBuilder<StoreInfoEntity> builder)
        {
            builder.ToTable("StoreInfo");
        }
    }
}
