using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeByLocalUser",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeByOpponent",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeByLocalUser",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "TimeByOpponent",
                table: "Rounds");
        }
    }
}
