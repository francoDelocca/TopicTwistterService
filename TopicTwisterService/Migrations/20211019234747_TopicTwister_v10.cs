using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoPlayerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoPlayerId",
                table: "Matches",
                newName: "PlayerTwoId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTwoPlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerTwoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches",
                column: "PlayerTwoId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTwoId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerTwoId",
                table: "Matches",
                newName: "PlayerTwoPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTwoId",
                table: "Matches",
                newName: "IX_Matches_PlayerTwoPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTwoPlayerId",
                table: "Matches",
                column: "PlayerTwoPlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
