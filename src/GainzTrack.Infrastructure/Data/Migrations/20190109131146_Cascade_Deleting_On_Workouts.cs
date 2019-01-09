using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class Cascade_Deleting_On_Workouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_MainUsers_CreatorId",
                table: "WorkoutRoutines");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays",
                column: "WorkoutRoutineId",
                principalTable: "WorkoutRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRoutines_MainUsers_CreatorId",
                table: "WorkoutRoutines",
                column: "CreatorId",
                principalTable: "MainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_MainUsers_CreatorId",
                table: "WorkoutRoutines");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays",
                column: "WorkoutRoutineId",
                principalTable: "WorkoutRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRoutines_MainUsers_CreatorId",
                table: "WorkoutRoutines",
                column: "CreatorId",
                principalTable: "MainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
