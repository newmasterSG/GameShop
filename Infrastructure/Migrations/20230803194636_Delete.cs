using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GamesModelId",
                table: "GamesToESRBRating",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GamesToESRBRating_GamesModelId",
                table: "GamesToESRBRating",
                column: "GamesModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_GamesToESRBRating_Game_GamesModelId",
                table: "GamesToESRBRating",
                column: "GamesModelId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamesToESRBRating_Game_GamesModelId",
                table: "GamesToESRBRating");

            migrationBuilder.DropIndex(
                name: "IX_GamesToESRBRating_GamesModelId",
                table: "GamesToESRBRating");

            migrationBuilder.DropColumn(
                name: "GamesModelId",
                table: "GamesToESRBRating");
        }
    }
}
