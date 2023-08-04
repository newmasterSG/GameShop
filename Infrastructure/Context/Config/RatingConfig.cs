using Domain.Models.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class RatingConfig : IEntityTypeConfiguration<RatingModel>
    {
        public void Configure(EntityTypeBuilder<RatingModel> builder)
        {
            builder.
                Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
