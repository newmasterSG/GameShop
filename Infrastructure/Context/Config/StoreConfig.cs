using Domain.Models.Store;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class StoreConfig : IEntityTypeConfiguration<StoreModel>
    {
        public void Configure(EntityTypeBuilder<StoreModel> builder)
        {
            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
