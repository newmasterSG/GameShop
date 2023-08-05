using Domain.Entities.AddedByStatus;
using Domain.Entities.Developer;
using Domain.Entities.ESRBRating;
using Domain.Entities.Games;
using Domain.Entities.GamesToAddedByStatus;
using Domain.Entities.GamesToDeveloper;
using Domain.Entities.GamesToESRBRating;
using Domain.Entities.GamesToGenres;
using Domain.Entities.GamesToPlatform;
using Domain.Entities.GamesToRating;
using Domain.Entities.GamesToScreenshots;
using Domain.Entities.GamesToStore;
using Domain.Entities.GamesToTags;
using Domain.Entities.Genres;
using Domain.Entities.Platform;
using Domain.Entities.PlatformInfo;
using Domain.Entities.Rating;
using Domain.Entities.ShortScreenshot;
using Domain.Entities.Store;
using Domain.Entities.StoreInfo;
using Domain.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Context
{
    public class GameShopContext : DbContext
    {
        public DbSet<AddedByStatusModel> AddedByStatus { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<GamesModel> Games { get; set; }

        public DbSet<AddedByStatusModel> Additions { get; set; }

        public DbSet<ESRBRatingModel> ESRBRatings { get; set; }

        public DbSet<GamesToPlatfrormModel> GamesToPlatfrorms { get; set; }

        public DbSet<PlatformModel> PlatformModels { get; set; }

        public DbSet<PlatformInfoModel> PlatformInfoModels { get; set; }

        public DbSet<RatingModel> RatingModels { get; set; }

        public DbSet<ShortScreenshotModel> ShortScreenshotModels { get; set; }

        public DbSet<StoreModel> StoreModels { get; set; }

        public DbSet<StoreInfoModel> StoreInfoModels { get; set; }

        public DbSet<TagModel> Tags { get; set; }

        public DbSet<GamesToAddedByStatusModel> GamesToAddedByStatuses { get; set; }

        public DbSet<GamesToScreenshotsModel> GamesToScreenshots { get; set; }

        public DbSet<DevelopersModel> Developers { get; set; }

        public DbSet<GamesToDeveloperModel> GamesToDevelopers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GShop;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
