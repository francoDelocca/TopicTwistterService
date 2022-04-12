using Microsoft.EntityFrameworkCore.Migrations;

namespace TopicTwisterService.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    WordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.WordId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryWord",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    WordsWordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryWord", x => new { x.CategoriesCategoryId, x.WordsWordId });
                    table.ForeignKey(
                        name: "FK_CategoryWord_Categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryWord_Words_WordsWordId",
                        column: x => x.WordsWordId,
                        principalTable: "Words",
                        principalColumn: "WordId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                });

            migrationBuilder.CreateTable(
                name: "WordsEnteredByPlayer",
                columns: table => new
                {
                    WordsEnteredByPlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    RoundId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    WordEntered = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordsEnteredByPlayer", x => x.WordsEnteredByPlayerId);
                    table.ForeignKey(
                        name: "FK_WordsEnteredByPlayer_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WordsEnteredByPlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    RoundLetter = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchClosed = table.Column<bool>(type: "bit", nullable: false),
                    WinnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    CurrentRoundRoundId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    OpponentPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Players_OpponentPlayerId",
                        column: x => x.OpponentPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Players_WinnerPlayerId",
                        column: x => x.WinnerPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Rounds_CurrentRoundRoundId",
                        column: x => x.CurrentRoundRoundId,
                        principalTable: "Rounds",
                        principalColumn: "RoundId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRound_RoundsRoundId",
                table: "CategoryRound",
                column: "RoundsRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryWord_WordsWordId",
                table: "CategoryWord",
                column: "WordsWordId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_CurrentRoundRoundId",
                table: "Matches",
                column: "CurrentRoundRoundId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_OpponentPlayerId",
                table: "Matches",
                column: "OpponentPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_PlayerId",
                table: "Matches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_WinnerPlayerId",
                table: "Matches",
                column: "WinnerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_MatchId",
                table: "Rounds",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_WinnerPlayerId",
                table: "Rounds",
                column: "WinnerPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsEnteredByPlayer_CategoryId",
                table: "WordsEnteredByPlayer",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsEnteredByPlayer_PlayerId",
                table: "WordsEnteredByPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_WordsEnteredByPlayer_RoundId",
                table: "WordsEnteredByPlayer",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRound_Rounds_RoundsRoundId",
                table: "CategoryRound",
                column: "RoundsRoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordsEnteredByPlayer_Rounds_RoundId",
                table: "WordsEnteredByPlayer",
                column: "RoundId",
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

            migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Name" },
            values: new object[,]
            {
                { "Frutas y Verduras" },
                { "Objetos" },
                { "Idiomas" },
                { "Paises y Ciudades" },
                { "Nombres" }
            });

            migrationBuilder.InsertData(
            table: "Words",
            columns: new[] { "Name" },
            values: new object[,]
            {
                { "anana" },
                { "anzuelo" },
                { "aleman" },
                { "alemania" },
                { "andrea" },
                { "espinaca" },
                { "edredon" },
                { "eslovaco" },
                { "eslovenia" },
                { "esteban" },
                { "oliva" },
                { "ocarina" },
                { "otomi" },
                { "oslo" },
                { "oscar" },
                { "icaco" },
                { "iman" },
                { "irani" },
                { "iran" },
                { "iñaki" },
                { "uva" },
                { "uña" },
                { "ucrania" },
                { "ucraniano" },
                { "urraca" }

                
                
            });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Name", "email", "password" },
                values: new object[,]
                {
                    {
                        "groso", "groso@gmail.com", "123",
                        
                    },
                    
                    {
                        "suller", "suller@gmail.com", "123",
                        
                    }
                    
                });

            migrationBuilder.InsertData(
            table: "CategoryWord",
            columns: new[] { "CategoriesCategoryId", "WordsWordId" },
            values: new object[,]
            {
              
                
                {1,1},
                {1,6},
                {1,11},
                {1,16},
                {1,21},
                
                {2,2},
                {2,7},
                {2,12},
                {2,17},
                {2,22},
                
                {3,3},
                {3,8},
                {3,13},
                {3,18},
                {3,23},
                
                {4,4},
                {4,9},
                {4,14},
                {4,19},
                {4,25},
                
                {5,5},
                {5,10},
                {5,15},
                {5,20},
                {5,25},
         
            });
            
          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Rounds_CurrentRoundRoundId",
                table: "Matches");

            migrationBuilder.DropTable(
                name: "CategoryRound");

            migrationBuilder.DropTable(
                name: "CategoryWord");

            migrationBuilder.DropTable(
                name: "WordsEnteredByPlayer");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
