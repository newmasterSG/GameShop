using Infrastructure.Models.AddedByStatus;
using Infrastructure.Models.Developer;
using Infrastructure.Models.ESRBRating;
using Infrastructure.Models.Games;
using Infrastructure.Models.GamesToAddedByStatus;
using Infrastructure.Models.GamesToESRBRating;
using Infrastructure.Models.GamesToGenres;
using Infrastructure.Models.GamesToPlatform;
using Infrastructure.Models.GamesToRating;
using Infrastructure.Models.GamesToScreenshots;
using Infrastructure.Models.GamesToStore;
using Infrastructure.Models.GamesToTags;
using Infrastructure.Models.Genres;
using Infrastructure.Models.Platform;
using Infrastructure.Models.PlatformInfo;
using Infrastructure.Models.Rating;
using Infrastructure.Models.ShortScreenshot;
using Infrastructure.Models.Store;
using Infrastructure.Models.StoreInfo;
using Infrastructure.Models.Tags;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GamesShop;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
