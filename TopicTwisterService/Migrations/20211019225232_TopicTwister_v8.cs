using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordsEnteredByPlayer_Categories_CategoryId",
                table: "WordsEnteredByPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_WordsEnteredByPlayer_Rounds_RoundId",
                table: "WordsEnteredByPlayer");

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "WordsEnteredByPlayer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "WordsEnteredByPlayer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsEnteredByPlayer_Categories_CategoryId",
                table: "WordsEnteredByPlayer",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsEnteredByPlayer_Rounds_RoundId",
                table: "WordsEnteredByPlayer",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordsEnteredByPlayer_Categories_CategoryId",
                table: "WordsEnteredByPlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_WordsEnteredByPlayer_Rounds_RoundId",
                table: "WordsEnteredByPlayer");

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "WordsEnteredByPlayer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "WordsEnteredByPlayer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_WordsEnteredByPlayer_Categories_CategoryId",
                table: "WordsEnteredByPlayer",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsEnteredByPlayer_Rounds_RoundId",
                table: "WordsEnteredByPlayer",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
