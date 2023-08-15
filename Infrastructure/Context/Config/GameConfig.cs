using Domain.Entities.Games;
using Domain.Entities.GamesToDeveloper;
using Domain.Entities.GamesToGenres;
using Domain.Entities.GamesToPlatform;
using Domain.Entities.GamesToRating;
using Domain.Entities.GamesToStore;
using Domain.Entities.GamesToTags;
using Domain.Entities.OrderToGame;
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

            builder.HasMany(g => g.Tags)
                .WithMany(t => t.Games)
                .UsingEntity<GamesToTagsModel>();

            builder.HasMany(g => g.Developer)
                .WithMany(t => t.Games)
                .UsingEntity<GamesToDeveloperModel>();

            builder.HasMany(g => g.Genres)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToGenresModel>();

            builder.HasMany(g => g.Stores)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToStoresModel>();

            builder.HasMany(g => g.Platforms)
               .WithMany(t => t.Games)
               .UsingEntity<GamesToPlatfrormModel>();

            builder.HasMany(g => g.Ratings)
              .WithMany(t => t.Games)
              .UsingEntity<GamesToRatingModel>();

            builder.HasMany(g => g.GameKeys)
              .WithOne(t => t.Game);

            builder.HasMany(g => g.Orders)
               .WithMany(t => t.Games)
               .UsingEntity<OrderGame>();
        }
    }
}
