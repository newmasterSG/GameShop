using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class DeveloperTableCanNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Dominant_Color",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "Saturated_Color",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Game",
                newName: "DevelopersId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DeveloperId",
                table: "Game",
                newName: "IX_Game_DevelopersId");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Image_Background",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DevelopersId",
                table: "Game",
                column: "DevelopersId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Developer_DevelopersId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "DevelopersId",
                table: "Game",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_DevelopersId",
                table: "Game",
                newName: "IX_Game_DeveloperId");

            migrationBuilder.AddColumn<string>(
                name: "Dominant_Color",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Saturated_Color",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image_Background",
                table: "Developer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Developer_DeveloperId",
                table: "Game",
                column: "DeveloperId",
                principalTable: "Developer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
