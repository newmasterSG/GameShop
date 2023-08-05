using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ESRBRating_ESRB_RatingId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GamesModelGenreModel");

            migrationBuilder.DropIndex(
                name: "IX_Game_ESRB_RatingId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ESRB_RatingId",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "ESRBRatingModelId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreModelId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_ESRBRatingModelId",
                table: "Game",
                column: "ESRBRatingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreModelId",
                table: "Game",
                column: "GenreModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ESRBRating_ESRBRatingModelId",
                table: "Game",
                column: "ESRBRatingModelId",
                principalTable: "ESRBRating",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Genre_GenreModelId",
                table: "Game",
                column: "GenreModelId",
                principalTable: "Genre",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_ESRBRating_ESRBRatingModelId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_Genre_GenreModelId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_ESRBRatingModelId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_GenreModelId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "ESRBRatingModelId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GenreModelId",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "ESRB_RatingId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Game_ESRB_RatingId",
                table: "Game",
                column: "ESRB_RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesModelGenreModel_GenresId",
                table: "GamesModelGenreModel",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_ESRBRating_ESRB_RatingId",
                table: "Game",
                column: "ESRB_RatingId",
                principalTable: "ESRBRating",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
