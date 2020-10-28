using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BGF.App.Data.Migrations
{
    public partial class foundationCoreSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MinUsers = table.Column<int>(nullable: false),
                    MaxUsers = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    BggId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GameSessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGames_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameSessionDates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    GameSessionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessionDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameSessionDates_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameSessionId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionComments_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_GameSessionId",
                table: "BoardGames",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionDates_GameSessionId",
                table: "GameSessionDates",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionComments_GameSessionId",
                table: "SessionComments",
                column: "GameSessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "GameSessionDates");

            migrationBuilder.DropTable(
                name: "SessionComments");

            migrationBuilder.DropTable(
                name: "GameSessions");
        }
    }
}
