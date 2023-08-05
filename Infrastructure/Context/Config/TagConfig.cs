using Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class TagConfig : IEntityTypeConfiguration<TagModel>
    {
        public void Configure(EntityTypeBuilder<TagModel> builder)
        {
            builder.ToTable("Tag");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
