using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class AddedByStatusConfig : IEntityTypeConfiguration<AddedByStatusEntity>
    {
        public void Configure(EntityTypeBuilder<AddedByStatusEntity> builder)
        {
            builder.ToTable("AddedByStatus");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
