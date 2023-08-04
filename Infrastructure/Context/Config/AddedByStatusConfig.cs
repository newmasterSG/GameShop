using Domain.Models.AddedByStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class AddedByStatusConfig : IEntityTypeConfiguration<AddedByStatusModel>
    {
        public void Configure(EntityTypeBuilder<AddedByStatusModel> builder)
        {
            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
