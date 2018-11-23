using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<string>(
                name: "TitleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RequiredAP = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDays",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Day = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutRoutines",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRoutines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AchievementPointsGain = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseWorkoutDay",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ExerciseId = table.Column<string>(nullable: true),
                    WorkoutDayId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseWorkoutDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutDay_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseWorkoutDay_WorkoutDays_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutDayWorkoutRoutine",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WorkoutDayId = table.Column<string>(nullable: true),
                    WorkoutRoutineId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDayWorkoutRoutine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutRoutine_WorkoutDays_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutRoutine_WorkoutRoutines_WorkoutRoutineId",
                        column: x => x.WorkoutRoutineId,
                        principalTable: "WorkoutRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AchievementUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AchievementId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AchievementUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AchievementUser_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AchievementUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ExerciseId",
                table: "Achievements",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_AchievementId",
                table: "AchievementUser",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_AchievementUser_UserId",
                table: "AchievementUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkoutDay_ExerciseId",
                table: "ExerciseWorkoutDay",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkoutDay_WorkoutDayId",
                table: "ExerciseWorkoutDay",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayWorkoutRoutine_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutine",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayWorkoutRoutine_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutine",
                column: "WorkoutRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRoutines_UserId",
                table: "WorkoutRoutines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Titles_TitleId",
                table: "AspNetUsers",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Titles_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AchievementUser");

            migrationBuilder.DropTable(
                name: "ExerciseWorkoutDay");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "WorkoutDayWorkoutRoutine");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "WorkoutDays");

            migrationBuilder.DropTable(
                name: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "AspNetUsers");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId",
                table: "AspNetUserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }
    }
}
