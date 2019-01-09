using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class NewCascading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_Exercises_ExerciseId",
                table: "ExerciseWorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDays");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDays_Exercises_ExerciseId",
                table: "ExerciseWorkoutDays",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkoutDays_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDays",
                column: "WorkoutDayId",
                principalTable: "WorkoutDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_Exercises_ExerciseId",
                table: "ExerciseWorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkoutDays_WorkoutDays_WorkoutDayId",
                table: "ExerciseWorkoutDays");

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
        }
    }
}
