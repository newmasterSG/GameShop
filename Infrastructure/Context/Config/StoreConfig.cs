using Domain.Entities.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class StoreConfig : IEntityTypeConfiguration<StoreModel>
    {
        public void Configure(EntityTypeBuilder<StoreModel> builder)
        {
            builder.ToTable("Store");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
