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
    [Migration("20190103124206_Added_VideoIdAndIsApproved_ToAchievementUser")]
    partial class Added_VideoIdAndIsApproved_ToAchievementUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview3-35497")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GainzTrack.Core.Entities.Achievement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AchievementPointsGain");

                    b.Property<string>("CreatedById");

                    b.Property<int>("Difficulty");

                    b.Property<string>("ExerciseId");

                    b.Property<int>("OverloadAmount");

                    b.Property<int>("OverloadType");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ExerciseId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.AchievementUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AchievementId");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("UserId");

                    b.Property<string>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("AchievementId");

                    b.HasIndex("UserId");

                    b.ToTable("AchievementUsers");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.CopiedWorkoutsFromUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.Property<string>("WorkoutRoutineId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkoutRoutineId");

                    b.ToTable("CopiedWorkoutsFromUsers");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.Exercise", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ExerciseName");

                    b.Property<string>("VideoUrl");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.ExerciseWorkoutDay", b =>
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

            modelBuilder.Entity("GainzTrack.Core.Entities.MainUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AchievementPoints");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("TitleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("TitleId");

                    b.ToTable("MainUsers");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.Title", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("RequiredAP");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.WorkoutDay", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Day");

                    b.Property<string>("WorkoutRoutineId");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutRoutineId");

                    b.ToTable("WorkoutDays");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.WorkoutRoutine", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatorId");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("WorkoutRoutines");
                });

            modelBuilder.Entity("GainzTrack.Infrastructure.Identity.IdentityApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

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

                    b.ToTable("AspNetUsers");
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

            modelBuilder.Entity("GainzTrack.Core.Entities.Achievement", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.MainUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("GainzTrack.Core.Entities.Exercise", "Exercise")
                        .WithMany("InAchievements")
                        .HasForeignKey("ExerciseId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.AchievementUser", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.Achievement", "Achievement")
                        .WithMany("AchievementUsers")
                        .HasForeignKey("AchievementId");

                    b.HasOne("GainzTrack.Core.Entities.MainUser", "User")
                        .WithMany("AchievementUsers")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.CopiedWorkoutsFromUsers", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.MainUser", "User")
                        .WithMany("CopiedWorkoutsFromUsers")
                        .HasForeignKey("UserId");

                    b.HasOne("GainzTrack.Core.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany("TimesCopied")
                        .HasForeignKey("WorkoutRoutineId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.ExerciseWorkoutDay", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.Exercise", "Exercise")
                        .WithMany("ExerciseWorkoutDays")
                        .HasForeignKey("ExerciseId");

                    b.HasOne("GainzTrack.Core.Entities.WorkoutDay", "WorkoutDay")
                        .WithMany("ExerciseWorkoutDay")
                        .HasForeignKey("WorkoutDayId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.MainUser", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.Title", "Title")
                        .WithMany("AchievedUsers")
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.WorkoutDay", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.WorkoutRoutine", "WorkoutRoutine")
                        .WithMany("WorkoutDays")
                        .HasForeignKey("WorkoutRoutineId");
                });

            modelBuilder.Entity("GainzTrack.Core.Entities.WorkoutRoutine", b =>
                {
                    b.HasOne("GainzTrack.Core.Entities.MainUser", "Creator")
                        .WithMany("WorkoutRoutines")
                        .HasForeignKey("CreatorId");
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
                    b.HasOne("GainzTrack.Infrastructure.Identity.IdentityApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GainzTrack.Infrastructure.Identity.IdentityApplicationUser")
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

                    b.HasOne("GainzTrack.Infrastructure.Identity.IdentityApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GainzTrack.Infrastructure.Identity.IdentityApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
