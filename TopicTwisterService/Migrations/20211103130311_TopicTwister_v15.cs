using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "WordsEnteredByPlayer",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "WordsEnteredByPlayer");
        }
    }
}
