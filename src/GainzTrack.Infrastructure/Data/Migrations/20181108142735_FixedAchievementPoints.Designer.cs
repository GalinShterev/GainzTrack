﻿// <auto-generated />
using System;
using GainzTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181108142735_FixedAchievementPoints")]
    partial class FixedAchievementPoints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GainzTrack.Core.Models.Achievement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AchievementPointsGain");

                    b.Property<string>("ExerciseId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.AchievementUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AchievementId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("AchievementUsers");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("AchievementPoints");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("TitleId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("TitleId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.ExerciseWorkoutDay", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExerciseId");

                    b.Property<string>("WorkoutDayId");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutDayId");

                    b.ToTable("ExerciseWorkoutDays");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.Title", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RequiredAP");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.WorkoutDay", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.HasKey("Id");

                    b.ToTable("WorkoutDays");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.WorkoutDayWorkoutRoutine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("WorkoutDayId");

                    b.Property<string>("WorkoutRoutineId");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutDayId");

                    b.HasIndex("WorkoutRoutineId");

                    b.ToTable("WorkoutDayWorkoutRoutines");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.WorkoutRoutine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutRoutines");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.Achievement", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.Exercise", "Exercise")
                        .WithMany("InAchievements")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.AchievementUser", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.Achievement", "Achievement")
                        .WithMany("AchievementUsers")
                        .HasForeignKey("AchievementId");

                    b.HasOne("GainzTrack.Core.Models.ApplicationUser", "User")
                        .WithMany("AchievementUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.ApplicationUser", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.Title", "Title")
                        .WithMany("AchievedUsers")
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.ExerciseWorkoutDay", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.Exercise", "Exercise")
                        .WithMany("ExerciseWorkoutDays")
                        .HasForeignKey("ExerciseId");

                    b.HasOne("GainzTrack.Core.Models.WorkoutDay", "WorkoutDay")
                        .WithMany("ExerciseWorkoutDay")
                        .HasForeignKey("WorkoutDayId");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.WorkoutDayWorkoutRoutine", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.WorkoutDay", "WorkoutDay")
                        .WithMany("WorkoutDayWorkoutRoutines")
                        .HasForeignKey("WorkoutDayId");

                    b.HasOne("GainzTrack.Core.Models.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany("WorkoutDayWorkoutRoutines")
                        .HasForeignKey("WorkoutRoutineId");
                });

            modelBuilder.Entity("GainzTrack.Core.Models.WorkoutRoutine", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.ApplicationUser", "User")
                        .WithMany("WorkoutRoutines")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GainzTrack.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GainzTrack.Core.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
