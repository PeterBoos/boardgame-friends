using Microsoft.EntityFrameworkCore.Migrations;

namespace BGF.App.Data.Migrations
{
    public partial class boardgameExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "BoardGames");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BoardGames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BoardGames",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThumbNail",
                table: "BoardGames",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearPublished",
                table: "BoardGames",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "ThumbNail",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "YearPublished",
                table: "BoardGames");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BoardGames",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
