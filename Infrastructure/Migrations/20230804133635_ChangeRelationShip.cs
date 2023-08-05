using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_GamesToESRBRating_Game_GamesModelId",
                table: "GamesToESRBRating");

            migrationBuilder.DropIndex(
                name: "IX_GamesToESRBRating_GamesModelId",
                table: "GamesToESRBRating");

            migrationBuilder.DropIndex(
                name: "IX_Game_DeveloperId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GamesModelId",
                table: "GamesToESRBRating");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
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
                name: "GamesToDevelopers",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToDevelopers", x => new { x.GameId, x.DeveloperId });
                    table.ForeignKey(
                        name: "FK_GamesToDevelopers_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamesToDevelopers_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevelopersModelGamesModel_GamesId",
                table: "DevelopersModelGamesModel",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToDevelopers_DeveloperId",
                table: "GamesToDevelopers",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevelopersModelGamesModel");

            migrationBuilder.DropTable(
                name: "GamesToDevelopers");

            migrationBuilder.AddColumn<int>(
                name: "GamesModelId",
                table: "GamesToESRBRating",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GamesToESRBRating_GamesModelId",
                table: "GamesToESRBRating",
                column: "GamesModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_DeveloperId",
                table: "Game",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GamesToESRBRating_Game_GamesModelId",
                table: "GamesToESRBRating",
                column: "GamesModelId",
                principalTable: "Game",
                principalColumn: "Id");
        }
    }
}
