using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopersModelGamesModel");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistration",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "GameOwning",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Game",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    IsBuy = table.Column<bool>(type: "bit", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameKeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameKeys_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameKeys_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderToGame",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderToGame", x => new { x.OrderId, x.GameId });
                    table.ForeignKey(
                        name: "FK_OrderToGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderToGame_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameKeys_GameId",
                table: "GameKeys",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GameKeys_OrderId",
                table: "GameKeys",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderToGame_GameId",
                table: "OrderToGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameKeys");

            migrationBuilder.DropTable(
                name: "OrderToGame");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropColumn(
                name: "DateRegistration",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "GameOwning",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Game");

            migrationBuilder.CreateTable(
                name: "DevelopersModelGamesModel",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevelopersModelGamesModel", x => new { x.DeveloperId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_DevelopersModelGamesModel_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevelopersModelGamesModel_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
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

            migrationBuilder.CreateIndex(
                name: "IX_DevelopersModelGamesModel_GamesId",
                table: "DevelopersModelGamesModel",
                column: "GamesId");

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
        }
    }
}
