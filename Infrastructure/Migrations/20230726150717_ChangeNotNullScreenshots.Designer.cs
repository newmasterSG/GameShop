﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(GameShopContext))]
    [Migration("20230726150717_ChangeNotNullScreenshots")]
    partial class ChangeNotNullScreenshots
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GamesModelGenreModel", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "GenresId");

                    b.HasIndex("GenresId");

                    b.ToTable("GamesModelGenreModel");
                });

            modelBuilder.Entity("GamesModelPlatformModel", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamesModelPlatformModel");
                });

            modelBuilder.Entity("GamesModelRatingModel", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("RatingsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "RatingsId");

                    b.HasIndex("RatingsId");

                    b.ToTable("GamesModelRatingModel");
                });

            modelBuilder.Entity("GamesModelStoreModel", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("StoresId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "StoresId");

                    b.HasIndex("StoresId");

                    b.ToTable("GamesModelStoreModel");
                });

            modelBuilder.Entity("GamesModelTagModel", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("GamesModelTagModel");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddedByStatus.AddedByStatusModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Beaten")
                        .HasColumnType("int");

                    b.Property<int?>("Dropped")
                        .HasColumnType("int");

                    b.Property<int?>("Owned")
                        .HasColumnType("int");

                    b.Property<int?>("Playing")
                        .HasColumnType("int");

                    b.Property<int?>("Toplay")
                        .HasColumnType("int");

                    b.Property<int?>("Yet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AddedByStatus");
                });

            modelBuilder.Entity("Infrastructure.Entities.ESRBRating.ESRBRatingModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ESRBRating");
                });

            modelBuilder.Entity("Infrastructure.Entities.Games.GamesModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Added_By_StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Background_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dominant_Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ESRB_RatingId")
                        .HasColumnType("int");

                    b.Property<int?>("Metacritic")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Playtime")
                        .HasColumnType("int");

                    b.Property<double?>("Rating")
                        .HasColumnType("float");

                    b.Property<int?>("Rating_Top")
                        .HasColumnType("int");

                    b.Property<int?>("Ratings_Count")
                        .HasColumnType("int");

                    b.Property<string>("Released")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Reviews_Count")
                        .HasColumnType("int");

                    b.Property<int?>("Reviews_Text_Count")
                        .HasColumnType("int");

                    b.Property<string>("Saturated_Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Suggestions_Count")
                        .HasColumnType("int");

                    b.Property<bool?>("Tba")
                        .HasColumnType("bit");

                    b.Property<string>("Updated")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Added_By_StatusId");

                    b.HasIndex("ESRB_RatingId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToAddedByStatus.GamesToAddedByStatusModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("AddedByStatusId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "AddedByStatusId");

                    b.HasIndex("AddedByStatusId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("GamesToAddedByStatus");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToESRBRating.GamesToESRBRatingModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("ESRBId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "ESRBId");

                    b.HasIndex("ESRBId");

                    b.HasIndex("GameId")
                        .IsUnique();

                    b.ToTable("GamesToESRBRating");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToGenres.GamesToGenresModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GamesToGenres");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToPlatform.GamesToPlatfrormModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "PlatformId");

                    b.HasIndex("PlatformId");

                    b.ToTable("GamesToPlatfrorm");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToRating.GamesToRatingModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("RatingId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "RatingId");

                    b.HasIndex("RatingId");

                    b.ToTable("GamesToRating");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToScreenshots.GamesToScreenshotsModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("ScreenshotId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "ScreenshotId");

                    b.HasIndex("ScreenshotId")
                        .IsUnique();

                    b.ToTable("GamesToScreenshots");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToStore.GamesToStoresModel", b =>
                {
                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("GameId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("GamesToStores");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToTags.GamesToTagsModel", b =>
                {
                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<int?>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "TagsId");

                    b.HasIndex("TagsId");

                    b.ToTable("GamesToTags");
                });

            modelBuilder.Entity("Infrastructure.Entities.Genres.GenreModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("GamesCount")
                        .HasColumnType("int");

                    b.Property<string>("Image_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("Infrastructure.Entities.Platform.PlatformModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<string>("Released_At")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Platform");
                });

            modelBuilder.Entity("Infrastructure.Entities.PlatformInfo.PlatformInfoModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int>("Games_Count")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year_End")
                        .HasColumnType("int");

                    b.Property<int?>("Year_start")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlatformInfo");
                });

            modelBuilder.Entity("Infrastructure.Entities.Rating.RatingModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<double?>("Percent")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("Infrastructure.Entities.ShortScreenshot.ShortScreenshotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("ShortScreenshot");
                });

            modelBuilder.Entity("Infrastructure.Entities.Store.StoreModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Infrastructure.Entities.StoreInfo.StoreInfoModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Games_Count")
                        .HasColumnType("int");

                    b.Property<string>("Image_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StoreInfo");
                });

            modelBuilder.Entity("Infrastructure.Entities.Tags.TagModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Key", true);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<int?>("Games_Count")
                        .HasColumnType("int");

                    b.Property<string>("Image_Background")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("GamesModelGenreModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Genres.GenreModel", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesModelPlatformModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Platform.PlatformModel", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesModelRatingModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Rating.RatingModel", null)
                        .WithMany()
                        .HasForeignKey("RatingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesModelStoreModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Store.StoreModel", null)
                        .WithMany()
                        .HasForeignKey("StoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesModelTagModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Tags.TagModel", null)
                        .WithMany()
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Entities.Games.GamesModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.AddedByStatus.AddedByStatusModel", "Added_By_Status")
                        .WithMany("Games")
                        .HasForeignKey("Added_By_StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.ESRBRating.ESRBRatingModel", "ESRB_Rating")
                        .WithMany("Games")
                        .HasForeignKey("ESRB_RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Added_By_Status");

                    b.Navigation("ESRB_Rating");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToAddedByStatus.GamesToAddedByStatusModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.AddedByStatus.AddedByStatusModel", "AddedByStatus")
                        .WithMany("GamesToAddedByStatus")
                        .HasForeignKey("AddedByStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Games")
                        .WithOne("GamesToAddedByStatuses")
                        .HasForeignKey("Infrastructure.Entities.GamesToAddedByStatus.GamesToAddedByStatusModel", "GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AddedByStatus");

                    b.Navigation("Games");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToESRBRating.GamesToESRBRatingModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.ESRBRating.ESRBRatingModel", "ESRBRatingModel")
                        .WithMany("GamesToESRBRating")
                        .HasForeignKey("ESRBId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithOne("GamesToESRBRating")
                        .HasForeignKey("Infrastructure.Entities.GamesToESRBRating.GamesToESRBRatingModel", "GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ESRBRatingModel");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToGenres.GamesToGenresModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GamesToGenres")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Genres.GenreModel", "Genre")
                        .WithMany("GamesToGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToPlatform.GamesToPlatfrormModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GamesToPlatfrorms")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Platform.PlatformModel", "Platform")
                        .WithMany("GamesToPlatfrorms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToRating.GamesToRatingModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GamesToRatings")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Rating.RatingModel", "Rating")
                        .WithMany("GamesToRatings")
                        .HasForeignKey("RatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Rating");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToScreenshots.GamesToScreenshotsModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GameToShortScreenshots")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.ShortScreenshot.ShortScreenshotModel", "ShortScreenshot")
                        .WithOne("GamesToScreenshots")
                        .HasForeignKey("Infrastructure.Entities.GamesToScreenshots.GamesToScreenshotsModel", "ScreenshotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("ShortScreenshot");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToStore.GamesToStoresModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GamesToStores")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Store.StoreModel", "Store")
                        .WithMany("GamesToStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Infrastructure.Entities.GamesToTags.GamesToTagsModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("GamesToTags")
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Tags.TagModel", "Tag")
                        .WithMany("ToTagsModels")
                        .HasForeignKey("TagsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Infrastructure.Entities.Platform.PlatformModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.PlatformInfo.PlatformInfoModel", "Platform")
                        .WithMany()
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Infrastructure.Entities.ShortScreenshot.ShortScreenshotModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.Games.GamesModel", "Game")
                        .WithMany("Short_Screenshots")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Infrastructure.Entities.Store.StoreModel", b =>
                {
                    b.HasOne("Infrastructure.Entities.StoreInfo.StoreInfoModel", "Store")
                        .WithMany()
                        .HasForeignKey("StoreId");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Infrastructure.Entities.AddedByStatus.AddedByStatusModel", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("GamesToAddedByStatus");
                });

            modelBuilder.Entity("Infrastructure.Entities.ESRBRating.ESRBRatingModel", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("GamesToESRBRating");
                });

            modelBuilder.Entity("Infrastructure.Entities.Games.GamesModel", b =>
                {
                    b.Navigation("GameToShortScreenshots");

                    b.Navigation("GamesToAddedByStatuses")
                        .IsRequired();

                    b.Navigation("GamesToESRBRating")
                        .IsRequired();

                    b.Navigation("GamesToGenres");

                    b.Navigation("GamesToPlatfrorms");

                    b.Navigation("GamesToRatings");

                    b.Navigation("GamesToStores");

                    b.Navigation("GamesToTags");

                    b.Navigation("Short_Screenshots");
                });

            modelBuilder.Entity("Infrastructure.Entities.Genres.GenreModel", b =>
                {
                    b.Navigation("GamesToGenres");
                });

            modelBuilder.Entity("Infrastructure.Entities.Platform.PlatformModel", b =>
                {
                    b.Navigation("GamesToPlatfrorms");
                });

            modelBuilder.Entity("Infrastructure.Entities.Rating.RatingModel", b =>
                {
                    b.Navigation("GamesToRatings");
                });

            modelBuilder.Entity("Infrastructure.Entities.ShortScreenshot.ShortScreenshotModel", b =>
                {
                    b.Navigation("GamesToScreenshots")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Entities.Store.StoreModel", b =>
                {
                    b.Navigation("GamesToStores");
                });

            modelBuilder.Entity("Infrastructure.Entities.Tags.TagModel", b =>
                {
                    b.Navigation("ToTagsModels");
                });
#pragma warning restore 612, 618
        }
    }
}
