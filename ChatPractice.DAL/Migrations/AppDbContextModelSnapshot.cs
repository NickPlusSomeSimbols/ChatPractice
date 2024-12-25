﻿// <auto-generated />
using System;
using ChatPractice.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChatPractice.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BelvedereFood.DAL.Models.Dialogue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserOneId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserTwoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("UserId");

                    b.HasIndex("UserOneId");

                    b.HasIndex("UserTwoId");

                    b.ToTable("dialogue", (string)null);
                });

            modelBuilder.Entity("BelvedereFood.DAL.Models.UserSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("UserId");

                    b.ToTable("user_session", (string)null);
                });

            modelBuilder.Entity("ChatPractice.DAL.Models.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("DialogueId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(32768)
                        .HasColumnType("character varying(32768)");

                    b.HasKey("Id");

                    b.HasIndex("DialogueId");

                    b.HasIndex("IsDeleted");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("ChatPractice.DAL.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IsDeleted");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("BelvedereFood.DAL.Models.Dialogue", b =>
                {
                    b.HasOne("ChatPractice.DAL.Models.User", null)
                        .WithMany("Dialogues")
                        .HasForeignKey("UserId");

                    b.HasOne("ChatPractice.DAL.Models.User", "UserOne")
                        .WithMany()
                        .HasForeignKey("UserOneId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ChatPractice.DAL.Models.User", "UserTwo")
                        .WithMany()
                        .HasForeignKey("UserTwoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UserOne");

                    b.Navigation("UserTwo");
                });

            modelBuilder.Entity("BelvedereFood.DAL.Models.UserSession", b =>
                {
                    b.HasOne("ChatPractice.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ChatPractice.DAL.Models.Message", b =>
                {
                    b.HasOne("BelvedereFood.DAL.Models.Dialogue", "Dialogue")
                        .WithMany()
                        .HasForeignKey("DialogueId");

                    b.Navigation("Dialogue");
                });

            modelBuilder.Entity("ChatPractice.DAL.Models.User", b =>
                {
                    b.Navigation("Dialogues");
                });
#pragma warning restore 612, 618
        }
    }
}
