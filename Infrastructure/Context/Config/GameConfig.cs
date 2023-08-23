using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Config
{
    public class GameConfig : IEntityTypeConfiguration<GamesEntity>
    {
        public void Configure(EntityTypeBuilder<GamesEntity> builder)
        {
            builder.ToTable("Game");

            builder
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            builder.HasMany(g => g.Tags)
                .WithMany(t => t.Games)
                .UsingEntity<GamesToTagsEntity>();

            builder.HasMany(g => g.Developer)
                .WithMany(t => t.Games)
                .UsingEntity<GamesToDeveloperEntity>();

            builder.HasMany(g => g.Genres)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToGenresEntity>();

            builder.HasMany(g => g.Stores)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToStoresEntity>();

            builder.HasMany(g => g.Platforms)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToPlatfrormEntity>();

            builder.HasMany(g => g.Ratings)
              .WithMany(t => t.Games)
              .UsingEntity<GamesToRatingEntity>();

            builder.HasMany(g => g.GameKeys)
              .WithOne(t => t.Game);

            builder.HasMany(g => g.Orders)
               .WithMany(t => t.Games)
               .UsingEntity<OrderGameEntity>();
        }
    }
}
