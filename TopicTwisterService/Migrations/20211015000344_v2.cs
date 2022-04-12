using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Rounds_CurrentRoundRoundId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Matches_MatchId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Matches_CurrentRoundRoundId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "CurrentRoundRoundId",
                table: "Matches");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Close",
                table: "Rounds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Matches_MatchId",
                table: "Rounds",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Matches_MatchId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "Close",
                table: "Rounds");

            migrationBuilder.AlterColumn<int>(
                name: "MatchId",
                table: "Rounds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CurrentRoundRoundId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CurrentRoundRoundId",
                table: "Matches",
                column: "CurrentRoundRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Rounds_CurrentRoundRoundId",
                table: "Matches",
                column: "CurrentRoundRoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Matches_MatchId",
                table: "Rounds",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "MatchId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
