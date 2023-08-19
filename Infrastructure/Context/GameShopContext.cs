using Domain.Entities;
using Infrastructure.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class GameShopContext : IdentityDbContext<UserModel>
    {
        public DbSet<AddedByStatusEntity> AddedByStatus { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<GamesEntity> Games { get; set; }

        public DbSet<ESRBRatingEntity> ESRBRatings { get; set; }

        public DbSet<GamesToGenresEntity> GamesToGenres { get; set; }

        public DbSet<GamesToRatingEntity> GamesToRating { get; set; }

        public DbSet<GamesToStoresEntity> GamesToStores { get; set; }

        public DbSet<GamesToTagsEntity> GamesToTags { get; set; }

        public DbSet<GamesToPlatfrormEntity> GamesToPlatfrorms { get; set; }

        public DbSet<PlatformEntity> PlatformModels { get; set; }

        public DbSet<PlatformInfoEntity> PlatformInfoModels { get; set; }

        public DbSet<RatingEntity> RatingModels { get; set; }

        public DbSet<ShortScreenshotEntity> ShortScreenshotModels { get; set; }

        public DbSet<StoreEntity> StoreModels { get; set; }

        public DbSet<StoreInfoEntity> StoreInfoModels { get; set; }

        public DbSet<TagEntity> Tags { get; set; }

        public DbSet<GamesToScreenshotsEntity> GamesToScreenshots { get; set; }

        public DbSet<DevelopersEntity> Developers { get; set; }

        public DbSet<GamesToDeveloperEntity> GamesToDevelopers { get; set; }

        public override DbSet<UserModel> Users { get; set; }

        public DbSet<GameKeyEntity> GameKeys { get; set; }

        public DbSet<OrderEntity> Orders { get; set; }

        public DbSet<OrderGameEntity> OrderGames { get; set; }

        public GameShopContext(DbContextOptions<GameShopContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
