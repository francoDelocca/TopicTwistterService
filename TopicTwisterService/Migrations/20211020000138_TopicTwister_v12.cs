using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOnePlayerId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerOnePlayerId",
                table: "Matches",
                newName: "PlayerOneId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerOnePlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerOneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches",
                column: "PlayerOneId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerOneId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "PlayerOneId",
                table: "Matches",
                newName: "PlayerOnePlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerOneId",
                table: "Matches",
                newName: "IX_Matches_PlayerOnePlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerOnePlayerId",
                table: "Matches",
                column: "PlayerOnePlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
