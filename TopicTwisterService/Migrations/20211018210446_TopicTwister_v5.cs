using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_WinnerPlayerId",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "WinnerPlayerId",
                table: "Rounds",
                newName: "WinnerRoundPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_WinnerPlayerId",
                table: "Rounds",
                newName: "IX_Rounds_WinnerRoundPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Players_WinnerRoundPlayerId",
                table: "Rounds",
                column: "WinnerRoundPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Players_WinnerRoundPlayerId",
                table: "Rounds");

            migrationBuilder.RenameColumn(
                name: "WinnerRoundPlayerId",
                table: "Rounds",
                newName: "WinnerPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_WinnerRoundPlayerId",
                table: "Rounds",
                newName: "IX_Rounds_WinnerPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Players_WinnerPlayerId",
                table: "Rounds",
                column: "WinnerPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
