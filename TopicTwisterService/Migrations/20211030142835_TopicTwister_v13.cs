using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerPlayerId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "CategoryRound");

            migrationBuilder.RenameColumn(
                name: "WinnerPlayerId",
                table: "Matches",
                newName: "WinnerPlayerPlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoId",
                table: "Matches",
                newName: "PlayerTwoPlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerOneId",
                table: "Matches",
                newName: "PlayerOnePlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerPlayerId",
                table: "Matches",
                newName: "IX_Matches_WinnerPlayerPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTwoId",
                table: "Matches",
                newName: "IX_Matches_PlayerTwoPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerOneId",
                table: "Matches",
                newName: "IX_Matches_PlayerOnePlayerId");

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_RoundId",
                table: "Categories",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Rounds_RoundId",
                table: "Categories",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOnePlayerId",
                table: "Matches",
                column: "PlayerOnePlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoPlayerId",
                table: "Matches",
                column: "PlayerTwoPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerPlayerPlayerId",
                table: "Matches",
                column: "WinnerPlayerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Rounds_RoundId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOnePlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoPlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerPlayerPlayerId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RoundId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "WinnerPlayerPlayerId",
                table: "Matches",
                newName: "WinnerPlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoPlayerId",
                table: "Matches",
                newName: "PlayerTwoId");

            migrationBuilder.RenameColumn(
                name: "PlayerOnePlayerId",
                table: "Matches",
                newName: "PlayerOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerPlayerPlayerId",
                table: "Matches",
                newName: "IX_Matches_WinnerPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTwoPlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerOnePlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerOneId");

            migrationBuilder.CreateTable(
                name: "CategoryRound",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    RoundsRoundId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRound", x => new { x.CategoriesCategoryId, x.RoundsRoundId });
                    table.ForeignKey(
                        name: "FK_CategoryRound_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryRound_Rounds_RoundsRoundId",
                        column: x => x.RoundsRoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRound_RoundsRoundId",
                table: "CategoryRound",
                column: "RoundsRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerPlayerId",
                table: "Matches",
                column: "WinnerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
