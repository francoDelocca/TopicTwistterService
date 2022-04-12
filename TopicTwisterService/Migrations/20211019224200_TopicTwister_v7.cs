using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_OpponentPlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Matches",
                newName: "PlayerTwoPlayerId");

            migrationBuilder.RenameColumn(
                name: "OpponentPlayerId",
                table: "Matches",
                newName: "PlayerOnePlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerTwoPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_OpponentPlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerOnePlayerId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOnePlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoPlayerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoPlayerId",
                table: "Matches",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerOnePlayerId",
                table: "Matches",
                newName: "OpponentPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTwoPlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerOnePlayerId",
                table: "Matches",
                newName: "IX_Matches_OpponentPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_OpponentPlayerId",
                table: "Matches",
                column: "OpponentPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
