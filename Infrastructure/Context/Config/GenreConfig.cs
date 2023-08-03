using Infrastructure.Models.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GenreConfig : IEntityTypeConfiguration<GenreModel>
    {
        public void Configure(EntityTypeBuilder<GenreModel> builder)
        {
            builder.HasKey(f => f.Id);
        }
    }
}
