using Infrastructure.Models.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class TagConfig : IEntityTypeConfiguration<TagModel>
    {
        public void Configure(EntityTypeBuilder<TagModel> builder)
        {
            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
