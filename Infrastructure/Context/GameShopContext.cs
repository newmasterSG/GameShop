using Domain.Models.AddedByStatus;
using Domain.Models.Developer;
using Domain.Models.ESRBRating;
using Domain.Models.Games;
using Domain.Models.GamesToAddedByStatus;
using Domain.Models.GamesToESRBRating;
using Domain.Models.GamesToGenres;
using Domain.Models.GamesToPlatform;
using Domain.Models.GamesToRating;
using Domain.Models.GamesToScreenshots;
using Domain.Models.GamesToStore;
using Domain.Models.GamesToTags;
using Domain.Models.Genres;
using Domain.Models.Platform;
using Domain.Models.PlatformInfo;
using Domain.Models.Rating;
using Domain.Models.ShortScreenshot;
using Domain.Models.Store;
using Domain.Models.StoreInfo;
using Domain.Models.Tags;
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
