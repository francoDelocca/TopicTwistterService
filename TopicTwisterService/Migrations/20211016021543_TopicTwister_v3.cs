using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class TopicTwister_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Rounds_RoundId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_RoundId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Categories");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryRound");

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
        }
    }
}
