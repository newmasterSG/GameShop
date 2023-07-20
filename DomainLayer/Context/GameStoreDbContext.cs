using Microsoft.EntityFrameworkCore;
using DomainLayer.Models;
using DomainLayer.Models.Games;
using DomainLayer.Models.Language;
using DomainLayer.Models.CountryCode;
using DomainLayer.Models.Tags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainLayer.Models.GamesToLanguage;
using DomainLayer.Models.GamesToTags;
using DomainLayer.Models.AddedByStatus;
using DomainLayer.Models.ESRBRating;
using DomainLayer.Models.GamesToPlatform;
using DomainLayer.Models.Platform;
using DomainLayer.Models.PlatformInfo;
using DomainLayer.Models.Rating;
using DomainLayer.Models.ShortScreenshot;
using DomainLayer.Models.Store;
using DomainLayer.Models.StoreInfo;
using DomainLayer.Models.GamesToGenres;
using DomainLayer.Models.GamesToAddedByStatus;

namespace DomainLayer.Context
{
    public class GameStoreDbContext : DbContext
    {
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

        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamesModel>()
                .HasKey(g => g.Id);

            #region RelationShip Models

            #region GamesToTagsModel Settings

            modelBuilder.Entity<GamesToTagsModel>()
                .HasKey(gtt => new { gtt.GamesId, gtt.TagsId });

            modelBuilder.Entity<GamesToTagsModel>()
                .HasOne(gtt => gtt.Game)
                .WithMany(g => g.GamesToTags)
                .HasForeignKey(gtt => gtt.GamesId);

            modelBuilder.Entity<GamesToTagsModel>()
                .HasOne(gtt => gtt.Tag)
                .WithMany(g => g.ToTagsModels)
                .HasForeignKey(gtt => gtt.TagsId);

            #endregion

            #region GamesToGenresModel Settings

            modelBuilder.Entity<GamesToGenresModel>()
                .HasKey(gtg => new { gtg.GameId, gtg.GenreId});

            modelBuilder.Entity<GamesToGenresModel>()
                .HasOne(gtg => gtg.Game)
                .WithMany(g => g.GamesToGenres)
                .HasForeignKey(gtg =>  gtg.GameId);

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
                .HasForeignKey<GamesToAddedByStatusModel>(gta => gta.GameId);

            modelBuilder.Entity<GamesToAddedByStatusModel>()
               .HasOne(gtg => gtg.AddedByStatus)
               .WithMany(g => g.GamesToAddedByStatus)
               .HasForeignKey(gtg => gtg.AddedByStatusId);

            #endregion

            #region

            #endregion


            #endregion

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Код для настройки провайдера базы данных
        }
    }
}
