using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class CreateDeveloperTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Games_count = table.Column<int>(type: "int", nullable: true),
                    Image_Background = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

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
                name: "IX_Game_DeveloperId",
                table: "Game",
                column: "DeveloperId");

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
                name: "FK_Game_Developer_DeveloperId",
                table: "Game",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GamesToDeveloper");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Game_DeveloperId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Game");
        }
    }
}
