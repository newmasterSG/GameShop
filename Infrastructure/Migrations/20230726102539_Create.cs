using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddedByStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Yet = table.Column<int>(type: "int", nullable: false),
                    Owned = table.Column<int>(type: "int", nullable: false),
                    Beaten = table.Column<int>(type: "int", nullable: false),
                    Toplay = table.Column<int>(type: "int", nullable: false),
                    Dropped = table.Column<int>(type: "int", nullable: false),
                    Playing = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddedByStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ESRBRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESRBRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamesCount = table.Column<int>(type: "int", nullable: false),
                    Image_Background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlatformInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year_End = table.Column<int>(type: "int", nullable: true),
                    Year_start = table.Column<int>(type: "int", nullable: true),
                    Games_Count = table.Column<int>(type: "int", nullable: false),
                    Image_Background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatformInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Games_Count = table.Column<int>(type: "int", nullable: false),
                    Image_Background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Games_Count = table.Column<int>(type: "int", nullable: false),
                    Image_Background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Added_By_StatusId = table.Column<int>(type: "int", nullable: false),
                    Background_Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dominant_Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESRB_RatingId = table.Column<int>(type: "int", nullable: false),
                    Metacritic = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Playtime = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Rating_Top = table.Column<int>(type: "int", nullable: false),
                    Ratings_Count = table.Column<int>(type: "int", nullable: false),
                    Released = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reviews_Count = table.Column<int>(type: "int", nullable: false),
                    Reviews_Text_Count = table.Column<int>(type: "int", nullable: false),
                    Saturated_Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suggestions_Count = table.Column<int>(type: "int", nullable: false),
                    Tba = table.Column<bool>(type: "bit", nullable: false),
                    Updated = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_AddedByStatus_Added_By_StatusId",
                        column: x => x.Added_By_StatusId,
                        principalTable: "AddedByStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_ESRBRating_ESRB_RatingId",
                        column: x => x.ESRB_RatingId,
                        principalTable: "ESRBRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    Released_At = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Platform_PlatformInfo_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "PlatformInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_StoreInfo_StoreId",
                        column: x => x.StoreId,
                        principalTable: "StoreInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesModelGenreModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModelGenreModel", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GamesModelGenreModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModelGenreModel_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesModelRatingModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    RatingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModelRatingModel", x => new { x.GamesId, x.RatingsId });
                    table.ForeignKey(
                        name: "FK_GamesModelRatingModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModelRatingModel_Rating_RatingsId",
                        column: x => x.RatingsId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesModelTagModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModelTagModel", x => new { x.GamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GamesModelTagModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModelTagModel_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToAddedByStatus",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    AddedByStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToAddedByStatus", x => new { x.GameId, x.AddedByStatusId });
                    table.ForeignKey(
                        name: "FK_GamesToAddedByStatus_AddedByStatus_AddedByStatusId",
                        column: x => x.AddedByStatusId,
                        principalTable: "AddedByStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesToAddedByStatus_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamesToESRBRating",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ESRBId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToESRBRating", x => new { x.GameId, x.ESRBId });
                    table.ForeignKey(
                        name: "FK_GamesToESRBRating_ESRBRating_ESRBId",
                        column: x => x.ESRBId,
                        principalTable: "ESRBRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesToESRBRating_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GamesToGenres",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToGenres", x => new { x.GameId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_GamesToGenres_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToGenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToRating",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToRating", x => new { x.GameId, x.RatingId });
                    table.ForeignKey(
                        name: "FK_GamesToRating_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToRating_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToTags",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToTags", x => new { x.GamesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_GamesToTags_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToTags_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShortScreenshot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortScreenshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortScreenshot_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesModelPlatformModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    PlatformsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModelPlatformModel", x => new { x.GamesId, x.PlatformsId });
                    table.ForeignKey(
                        name: "FK_GamesModelPlatformModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModelPlatformModel_Platform_PlatformsId",
                        column: x => x.PlatformsId,
                        principalTable: "Platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToPlatfrorm",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToPlatfrorm", x => new { x.GameId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_GamesToPlatfrorm_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToPlatfrorm_Platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesModelStoreModel",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesModelStoreModel", x => new { x.GamesId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_GamesModelStoreModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesModelStoreModel_Store_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToStores",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToStores", x => new { x.GameId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_GamesToStores_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToStores_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamesToScreenshots",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    ScreenshotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToScreenshots", x => new { x.GameId, x.ScreenshotId });
                    table.ForeignKey(
                        name: "FK_GamesToScreenshots_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesToScreenshots_ShortScreenshot_ScreenshotId",
                        column: x => x.ScreenshotId,
                        principalTable: "ShortScreenshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_Added_By_StatusId",
                table: "Game",
                column: "Added_By_StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_ESRB_RatingId",
                table: "Game",
                column: "ESRB_RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelGenreModel_GenresId",
                table: "GamesModelGenreModel",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelPlatformModel_PlatformsId",
                table: "GamesModelPlatformModel",
                column: "PlatformsId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelRatingModel_RatingsId",
                table: "GamesModelRatingModel",
                column: "RatingsId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelStoreModel_StoresId",
                table: "GamesModelStoreModel",
                column: "StoresId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelTagModel_TagsId",
                table: "GamesModelTagModel",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToAddedByStatus_AddedByStatusId",
                table: "GamesToAddedByStatus",
                column: "AddedByStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToAddedByStatus_GameId",
                table: "GamesToAddedByStatus",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesToESRBRating_ESRBId",
                table: "GamesToESRBRating",
                column: "ESRBId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToESRBRating_GameId",
                table: "GamesToESRBRating",
                column: "GameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesToGenres_GenreId",
                table: "GamesToGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToPlatfrorm_PlatformId",
                table: "GamesToPlatfrorm",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToRating_RatingId",
                table: "GamesToRating",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToScreenshots_ScreenshotId",
                table: "GamesToScreenshots",
                column: "ScreenshotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesToStores_StoreId",
                table: "GamesToStores",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToTags_TagsId",
                table: "GamesToTags",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Platform_PlatformId",
                table: "Platform",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_ShortScreenshot_GameId",
                table: "ShortScreenshot",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_StoreId",
                table: "Store",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamesModelGenreModel");

            migrationBuilder.DropTable(
                name: "GamesModelPlatformModel");

            migrationBuilder.DropTable(
                name: "GamesModelRatingModel");

            migrationBuilder.DropTable(
                name: "GamesModelStoreModel");

            migrationBuilder.DropTable(
                name: "GamesModelTagModel");

            migrationBuilder.DropTable(
                name: "GamesToAddedByStatus");

            migrationBuilder.DropTable(
                name: "GamesToESRBRating");

            migrationBuilder.DropTable(
                name: "GamesToGenres");

            migrationBuilder.DropTable(
                name: "GamesToPlatfrorm");

            migrationBuilder.DropTable(
                name: "GamesToRating");

            migrationBuilder.DropTable(
                name: "GamesToScreenshots");

            migrationBuilder.DropTable(
                name: "GamesToStores");

            migrationBuilder.DropTable(
                name: "GamesToTags");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "ShortScreenshot");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "PlatformInfo");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "StoreInfo");

            migrationBuilder.DropTable(
                name: "AddedByStatus");

            migrationBuilder.DropTable(
                name: "ESRBRating");
        }
    }
}
