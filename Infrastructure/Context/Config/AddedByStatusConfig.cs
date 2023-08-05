using Domain.Entities.AddedByStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class AddedByStatusConfig : IEntityTypeConfiguration<AddedByStatusModel>
    {
        public void Configure(EntityTypeBuilder<AddedByStatusModel> builder)
        {
            builder.ToTable("AddedByStatus");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
