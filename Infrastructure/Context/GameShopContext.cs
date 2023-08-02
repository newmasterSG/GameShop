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

namespace Infrastructure.Context
{
    public class GameShopContext : DbContext
    {
        public DbSet<AddedByStatusModel> AddedByStatus { get; set; }
        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<GamesModel> Games { get; set; }

        public DbSet<GamesToTagsModel> GamesToTags { get; set; }

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

        public DbSet<GamesToGenresModel> GamesToGenres { get; set; }

        public DbSet<GamesToAddedByStatusModel> GamesToAddedByStatuses { get; set; }

        public DbSet<GamesToStoresModel> GamesToStores { get; set; }

        public DbSet<GamesToScreenshotsModel> GamesToScreenshots { get; set; }

        public DbSet<GamesToRatingModel> GamesToRatings { get; set; }

        public DbSet<DevelopersModel> Developers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Standart Models

            modelBuilder.Entity<GamesModel>()
                    .Property(f => f.Id)
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("Key", true);

            modelBuilder.Entity<DevelopersModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<GamesModel>()
                .HasOne(g => g.Developer)
                .WithMany(d => d.Games)
                .HasForeignKey(g => g.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AddedByStatusModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<ESRBRatingModel>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<GenreModel>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<PlatformModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<RatingModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<ShortScreenshotModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<StoreModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            modelBuilder.Entity<TagModel>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd()
                .HasAnnotation("Key", true);

            #endregion

            #region RelationShip Models

            #region GamesToTagsModel Settings

            modelBuilder.Entity<GamesToTagsModel>()
                .HasKey(gtt => new { gtt.GamesId, gtt.TagsId });

            modelBuilder.Entity<GamesToTagsModel>()
                .HasOne(gtt => gtt.Game)
                .WithMany(g => g.GamesToTags)
                .HasForeignKey(gtt => gtt.GamesId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GamesToTagsModel>()
                .HasOne(gtt => gtt.Tag)
                .WithMany(g => g.ToTagsModels)
                .HasForeignKey(gtt => gtt.TagsId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region GamesToGenresModel Settings

            modelBuilder.Entity<GamesToGenresModel>()
                .HasKey(gtg => new { gtg.GameId, gtg.GenreId });

            modelBuilder.Entity<GamesToGenresModel>()
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToGenres)
                .HasForeignKey(gtg => gtg.GameId);

            modelBuilder.Entity<GamesToGenresModel>()
               .HasOne(gtg => gtg.Genre)
               .WithMany(g => g.GamesToGenres)
               .HasForeignKey(gtg => gtg.GenreId);

            #endregion

            #region GamesToPlatfrormModel Settings

            modelBuilder.Entity<GamesToPlatfrormModel>()
                .HasKey(gtg => new { gtg.GameId, gtg.PlatformId });

            modelBuilder.Entity<GamesToPlatfrormModel>()
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToPlatfrorms)
                .HasForeignKey(gtg => gtg.GameId);

            modelBuilder.Entity<GamesToPlatfrormModel>()
               .HasOne(gtg => gtg.Platform)
               .WithMany(g => g.GamesToPlatfrorms)
               .HasForeignKey(gtg => gtg.PlatformId);

            #endregion

            #region GamesToAddedByStatusModel Settings

            modelBuilder.Entity<GamesToAddedByStatusModel>()
               .HasKey(gtg => new { gtg.GameId, gtg.AddedByStatusId });

            modelBuilder.Entity<GamesToAddedByStatusModel>()
                .HasOne(gta => gta.Games)
                .WithOne(g => g.GamesToAddedByStatuses)
                .HasForeignKey<GamesToAddedByStatusModel>(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamesToAddedByStatusModel>()
               .HasOne(gtg => gtg.AddedByStatus)
               .WithMany(g => g.GamesToAddedByStatus)
               .HasForeignKey(gtg => gtg.AddedByStatusId)
               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region GamesToESRBRatingModel Settings

            modelBuilder.Entity<GamesToESRBRatingModel>()
            .HasKey(gtg => new { gtg.GameId, gtg.ESRBId });

            modelBuilder.Entity<GamesToESRBRatingModel>()
                .HasOne(gta => gta.Game)
                .WithOne(g => g.GamesToESRBRating)
                .HasForeignKey<GamesToESRBRatingModel>(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamesToESRBRatingModel>()
               .HasOne(gtg => gtg.ESRBRatingModel)
               .WithMany(g => g.GamesToESRBRating)
               .HasForeignKey(gtg => gtg.ESRBId)
               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region GamesToRatingModel Settings

            modelBuilder.Entity<GamesToRatingModel>()
            .HasKey(gtg => new { gtg.GameId, gtg.RatingId });

            modelBuilder.Entity<GamesToRatingModel>()
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GamesToRatings)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GamesToRatingModel>()
               .HasOne(gtg => gtg.Rating)
               .WithMany(g => g.GamesToRatings)
               .HasForeignKey(gtg => gtg.RatingId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region GamesToScreenshotsModel Settings

            modelBuilder.Entity<GamesToScreenshotsModel>()
            .HasKey(gtg => new { gtg.GameId, gtg.ScreenshotId });

            modelBuilder.Entity<GamesToScreenshotsModel>()
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GameToShortScreenshots)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GamesToScreenshotsModel>()
               .HasOne(gtg => gtg.ShortScreenshot)
               .WithOne(g => g.GamesToScreenshots)
               .HasForeignKey<GamesToScreenshotsModel>(gtg => gtg.ScreenshotId)
               .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region GamesToStoresModel Settings

            modelBuilder.Entity<GamesToStoresModel>()
            .HasKey(gtg => new { gtg.GameId, gtg.StoreId });

            modelBuilder.Entity<GamesToStoresModel>()
                .HasOne(gta => gta.Game)
                .WithMany(g => g.GamesToStores)
                .HasForeignKey(gta => gta.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GamesToStoresModel>()
               .HasOne(gtg => gtg.Store)
               .WithMany(g => g.GamesToStores)
               .HasForeignKey(gtg => gtg.StoreId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GamesShop;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
