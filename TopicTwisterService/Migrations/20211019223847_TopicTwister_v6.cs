using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeByOpponent",
                table: "Rounds",
                newName: "TimeByPlayerTwo");

            migrationBuilder.RenameColumn(
                name: "TimeByLocalUser",
                table: "Rounds",
                newName: "TimeByPlayerOne");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeByPlayerTwo",
                table: "Rounds",
                newName: "TimeByOpponent");

            migrationBuilder.RenameColumn(
                name: "TimeByPlayerOne",
                table: "Rounds",
                newName: "TimeByLocalUser");
        }
    }
}
