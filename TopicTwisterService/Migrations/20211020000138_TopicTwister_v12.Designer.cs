﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TopicTwisterService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211020000138_TopicTwister_v12")]
    partial class TopicTwister_v12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
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

                    b.Property<int?>("PlayerOneId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerTwoId")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerPlayerId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("PlayerOneId");

                    b.HasIndex("PlayerTwoId");

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

                    b.Property<int>("TimeByPlayerOne")
                        .HasColumnType("int");

                    b.Property<int>("TimeByPlayerTwo")
                        .HasColumnType("int");

                    b.Property<int?>("WinnerRoundPlayerId")
                        .HasColumnType("int");

                    b.HasKey("RoundId");

                    b.HasIndex("MatchId");

                    b.HasIndex("WinnerRoundPlayerId");

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

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int>("RoundId")
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
                    b.HasOne("TopicTwisterService.Models.Player", "PlayerOne")
                        .WithMany()
                        .HasForeignKey("PlayerOneId");

                    b.HasOne("TopicTwisterService.Models.Player", "PlayerTwo")
                        .WithMany()
                        .HasForeignKey("PlayerTwoId");

                    b.HasOne("TopicTwisterService.Models.Player", "WinnerPlayer")
                        .WithMany()
                        .HasForeignKey("WinnerPlayerId");

                    b.Navigation("PlayerOne");

                    b.Navigation("PlayerTwo");

                    b.Navigation("WinnerPlayer");
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
                        .HasForeignKey("WinnerRoundPlayerId");

                    b.Navigation("Match");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("TopicTwisterService.Models.WordsEnteredByPlayer", b =>
                {
                    b.HasOne("TopicTwisterService.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopicTwisterService.Models.Round", "Round")
                        .WithMany("WordEnteredByPlayers")
                        .HasForeignKey("RoundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                    b.Navigation("WordEnteredByPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
