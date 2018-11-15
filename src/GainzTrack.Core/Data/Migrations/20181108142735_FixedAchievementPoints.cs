using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Core.Data.Migrations
{
    public partial class FixedAchievementPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUser_Achievements_AchievementId",
                table: "AchievementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId",
                table: "AchievementUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDay_Exercises_ExerciseId",
                table: "ExerciseWorkoutDay");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDay_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDay");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDayWorkoutRoutine_WorkoutDays_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutine");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDayWorkoutRoutine_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutDayWorkoutRoutine",
                table: "WorkoutDayWorkoutRoutine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkoutDay",
                table: "ExerciseWorkoutDay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AchievementUser",
                table: "AchievementUser");

            migrationBuilder.RenameTable(
                name: "WorkoutDayWorkoutRoutine",
                newName: "WorkoutDayWorkoutRoutines");

            migrationBuilder.RenameTable(
                name: "ExerciseWorkoutDay",
                newName: "ExerciseWorkoutDays");

            migrationBuilder.RenameTable(
                name: "AchievementUser",
                newName: "AchievementUsers");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutDayWorkoutRoutine_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutines",
                newName: "IX_WorkoutDayWorkoutRoutines_WorkoutRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutDayWorkoutRoutine_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutines",
                newName: "IX_WorkoutDayWorkoutRoutines_WorkoutDayId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseWorkoutDay_WorkoutDayId",
                table: "ExerciseWorkoutDays",
                newName: "IX_ExerciseWorkoutDays_WorkoutDayId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseWorkoutDay_ExerciseId",
                table: "ExerciseWorkoutDays",
                newName: "IX_ExerciseWorkoutDays_ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementUser_UserId",
                table: "AchievementUsers",
                newName: "IX_AchievementUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementUser_AchievementId",
                table: "AchievementUsers",
                newName: "IX_AchievementUsers_AchievementId");

            migrationBuilder.AddColumn<int>(
                name: "AchievementPoints",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutDayWorkoutRoutines",
                table: "WorkoutDayWorkoutRoutines",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkoutDays",
                table: "ExerciseWorkoutDays",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AchievementUsers",
                table: "AchievementUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUsers_Achievements_AchievementId",
                table: "AchievementUsers",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUsers_AspNetUsers_UserId",
                table: "AchievementUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDays_Exercises_ExerciseId",
                table: "ExerciseWorkoutDays",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDays_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDays",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDayWorkoutRoutines_WorkoutDays_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutines",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDayWorkoutRoutines_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutines",
                column: "WorkoutRoutineId",
                principalTable: "WorkoutRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUsers_Achievements_AchievementId",
                table: "AchievementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUsers_AspNetUsers_UserId",
                table: "AchievementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_Exercises_ExerciseId",
                table: "ExerciseWorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDayWorkoutRoutines_WorkoutDays_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutines");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDayWorkoutRoutines_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutDayWorkoutRoutines",
                table: "WorkoutDayWorkoutRoutines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseWorkoutDays",
                table: "ExerciseWorkoutDays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AchievementUsers",
                table: "AchievementUsers");

            migrationBuilder.DropColumn(
                name: "AchievementPoints",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "WorkoutDayWorkoutRoutines",
                newName: "WorkoutDayWorkoutRoutine");

            migrationBuilder.RenameTable(
                name: "ExerciseWorkoutDays",
                newName: "ExerciseWorkoutDay");

            migrationBuilder.RenameTable(
                name: "AchievementUsers",
                newName: "AchievementUser");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutDayWorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutine",
                newName: "IX_WorkoutDayWorkoutRoutine_WorkoutRoutineId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutDayWorkoutRoutines_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutine",
                newName: "IX_WorkoutDayWorkoutRoutine_WorkoutDayId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseWorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDay",
                newName: "IX_ExerciseWorkoutDay_WorkoutDayId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseWorkoutDays_ExerciseId",
                table: "ExerciseWorkoutDay",
                newName: "IX_ExerciseWorkoutDay_ExerciseId");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementUsers_UserId",
                table: "AchievementUser",
                newName: "IX_AchievementUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AchievementUsers_AchievementId",
                table: "AchievementUser",
                newName: "IX_AchievementUser_AchievementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutDayWorkoutRoutine",
                table: "WorkoutDayWorkoutRoutine",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseWorkoutDay",
                table: "ExerciseWorkoutDay",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AchievementUser",
                table: "AchievementUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUser_Achievements_AchievementId",
                table: "AchievementUser",
                column: "AchievementId",
                principalTable: "Achievements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUser_AspNetUsers_UserId",
                table: "AchievementUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDay_Exercises_ExerciseId",
                table: "ExerciseWorkoutDay",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDay_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDay",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDayWorkoutRoutine_WorkoutDays_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutine",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDayWorkoutRoutine_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutine",
                column: "WorkoutRoutineId",
                principalTable: "WorkoutRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
