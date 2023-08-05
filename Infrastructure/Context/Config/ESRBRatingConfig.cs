using Domain.Entities.ESRBRating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class ESRBRatingConfig : IEntityTypeConfiguration<ESRBRatingModel>
    {
        public void Configure(EntityTypeBuilder<ESRBRatingModel> builder)
        {
            builder.ToTable("ESRBRating");
            builder.HasKey(f => f.Id);
        }
    }
}
