// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TopicTwisterService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211015000344_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CategoryRound", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("RoundsRoundId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryId", "RoundsRoundId");

                    b.HasIndex("RoundsRoundId");

                    b.ToTable("CategoryRound");
                });

            modelBuilder.Entity("CategoryWord", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WordsWordId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesCategoryId", "WordsWordId");

                    b.HasIndex("WordsWordId");

                    b.ToTable("CategoryWord");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Match", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("MatchClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("OpponentPlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerPlayerId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("OpponentPlayerId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Close")
                        .HasColumnType("bit");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<string>("RoundLetter")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int?>("WinnerPlayerId")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("MatchId");

                    b.HasIndex("WinnerPlayerId");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("TopicTwisterService.Models.WordsEnteredByPlayer", b =>
                {
                    b.Property<int>("WordsEnteredByPlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<string>("WordEntered")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordsEnteredByPlayerId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RoundId");

                    b.ToTable("WordsEnteredByPlayer");
                });

            modelBuilder.Entity("CategoryRound", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Round", null)
                        .WithMany()
                        .HasForeignKey("RoundsRoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CategoryWord", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Word", null)
                        .WithMany()
                        .HasForeignKey("WordsWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicTwisterService.Models.Match", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Player", "Opponent")
                        .WithMany()
                        .HasForeignKey("OpponentPlayerId");

                    b.HasOne("TopicTwisterService.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("TopicTwisterService.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");

                    b.Navigation("Opponent");

                    b.Navigation("Player");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Round", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Match", "Match")
                        .WithMany("Rounds")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Player", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");

                    b.Navigation("Match");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TopicTwisterService.Models.WordsEnteredByPlayer", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("TopicTwisterService.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Round", "Round")
                        .WithMany("Rounds")
                        .HasForeignKey("RoundId");

                    b.Navigation("Category");

                    b.Navigation("Player");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Match", b =>
                {
                    b.Navigation("Rounds");
                });

            modelBuilder.Entity("TopicTwisterService.Models.Round", b =>
                {
                    b.Navigation("Rounds");
                });
#pragma warning restore 612, 618
        }
    }
}
