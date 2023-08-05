using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DevelopersId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GamesToDeveloper");

            migrationBuilder.RenameColumn(
                name: "DevelopersId",
                table: "Game",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DevelopersId",
                table: "Game",
                newName: "IX_Game_DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Game",
                newName: "DevelopersId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DeveloperId",
                table: "Game",
                newName: "IX_Game_DevelopersId");

            migrationBuilder.CreateTable(
                name: "GamesToDeveloper",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamesToDeveloper", x => new { x.GameId, x.DeveloperId });
                    table.ForeignKey(
                        name: "FK_GamesToDeveloper_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GamesToDeveloper_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamesToDeveloper_DeveloperId",
                table: "GamesToDeveloper",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GamesToDeveloper_GameId",
                table: "GamesToDeveloper",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DevelopersId",
                table: "Game",
                column: "DevelopersId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
