using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.Context.Config
{
    public class ESRBRatingConfig : IEntityTypeConfiguration<ESRBRatingEntity>
    {
        public void Configure(EntityTypeBuilder<ESRBRatingEntity> builder)
        {
            builder.ToTable("ESRBRating");
            builder.HasKey(f => f.Id);
        }
    }
}
