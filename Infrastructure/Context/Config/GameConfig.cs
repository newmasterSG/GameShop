using Domain.Entities.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GameConfig : IEntityTypeConfiguration<GamesModel>
    {
        public void Configure(EntityTypeBuilder<GamesModel> builder)
        {
            builder.ToTable("Game");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);
        }
    }
}
