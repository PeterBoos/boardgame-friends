using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BGF.App.Data.Migrations
{
    public partial class changedBgRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_GameSessions_GameSessionId",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_BoardGames_AspNetUsers_UserId",
                table: "BoardGames");

            migrationBuilder.DropForeignKey(
                name: "FK_GameSessions_AspNetUsers_UserId",
                table: "GameSessions");

            migrationBuilder.DropIndex(
                name: "IX_GameSessions_UserId",
                table: "GameSessions");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_GameSessionId",
                table: "BoardGames");

            migrationBuilder.DropIndex(
                name: "IX_BoardGames_UserId",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameSessions");

            migrationBuilder.DropColumn(
                name: "GameSessionId",
                table: "BoardGames");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BoardGames");

            migrationBuilder.CreateTable(
                name: "GameSessionBoardgames",
                columns: table => new
                {
                    GameSessionId = table.Column<Guid>(nullable: false),
                    BoardgameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessionBoardgames", x => new { x.GameSessionId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_GameSessionBoardgames_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameSessionBoardgames_GameSessions_GameSessionId",
                        column: x => x.GameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBoardgames",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    BoardgameId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBoardgames", x => new { x.UserId, x.BoardgameId });
                    table.ForeignKey(
                        name: "FK_UserBoardgames_BoardGames_BoardgameId",
                        column: x => x.BoardgameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBoardgames_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGameSessions",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    GameSessionid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameSessions", x => new { x.UserId, x.GameSessionid });
                    table.ForeignKey(
                        name: "FK_UserGameSessions_GameSessions_GameSessionid",
                        column: x => x.GameSessionid,
                        principalTable: "GameSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGameSessions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSessionBoardgames_BoardgameId",
                table: "GameSessionBoardgames",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBoardgames_BoardgameId",
                table: "UserBoardgames",
                column: "BoardgameId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGameSessions_GameSessionid",
                table: "UserGameSessions",
                column: "GameSessionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameSessionBoardgames");

            migrationBuilder.DropTable(
                name: "UserBoardgames");

            migrationBuilder.DropTable(
                name: "UserGameSessions");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GameSessions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GameSessionId",
                table: "BoardGames",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BoardGames",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_UserId",
                table: "GameSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_GameSessionId",
                table: "BoardGames",
                column: "GameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_UserId",
                table: "BoardGames",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_GameSessions_GameSessionId",
                table: "BoardGames",
                column: "GameSessionId",
                principalTable: "GameSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGames_AspNetUsers_UserId",
                table: "BoardGames",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameSessions_AspNetUsers_UserId",
                table: "GameSessions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
