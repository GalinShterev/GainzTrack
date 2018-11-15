using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Core.Data.Migrations
{
    public partial class Updated_Models_Structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_AspNetUsers_UserId",
                table: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "WorkoutDayWorkoutRoutines");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkoutRoutines",
                newName: "CreatorId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutRoutines_UserId",
                table: "WorkoutRoutines",
                newName: "IX_WorkoutRoutines_CreatorId");

            migrationBuilder.AddColumn<string>(
                name: "WorkoutRoutineId",
                table: "WorkoutDays",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CopiedWorkoutsFromUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    WorkoutRoutineId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CopiedWorkoutsFromUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CopiedWorkoutsFromUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CopiedWorkoutsFromUsers_WorkoutRoutines_WorkoutRoutineId",
                        column: x => x.WorkoutRoutineId,
                        principalTable: "WorkoutRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDays_WorkoutRoutineId",
                table: "WorkoutDays",
                column: "WorkoutRoutineId");

            migrationBuilder.CreateIndex(
                name: "IX_CopiedWorkoutsFromUsers_UserId",
                table: "CopiedWorkoutsFromUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CopiedWorkoutsFromUsers_WorkoutRoutineId",
                table: "CopiedWorkoutsFromUsers",
                column: "WorkoutRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays",
                column: "WorkoutRoutineId",
                principalTable: "WorkoutRoutines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRoutines_AspNetUsers_CreatorId",
                table: "WorkoutRoutines",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutDays_WorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDays");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_AspNetUsers_CreatorId",
                table: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "CopiedWorkoutsFromUsers");

            migrationBuilder.DropIndex(
                name: "IX_WorkoutDays_WorkoutRoutineId",
                table: "WorkoutDays");

            migrationBuilder.DropColumn(
                name: "WorkoutRoutineId",
                table: "WorkoutDays");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "WorkoutRoutines",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkoutRoutines_CreatorId",
                table: "WorkoutRoutines",
                newName: "IX_WorkoutRoutines_UserId");

            migrationBuilder.CreateTable(
                name: "WorkoutDayWorkoutRoutines",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WorkoutDayId = table.Column<string>(nullable: true),
                    WorkoutRoutineId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutDayWorkoutRoutines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutRoutines_WorkoutDays_WorkoutDayId",
                        column: x => x.WorkoutDayId,
                        principalTable: "WorkoutDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkoutDayWorkoutRoutines_WorkoutRoutines_WorkoutRoutineId",
                        column: x => x.WorkoutRoutineId,
                        principalTable: "WorkoutRoutines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayWorkoutRoutines_WorkoutDayId",
                table: "WorkoutDayWorkoutRoutines",
                column: "WorkoutDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutDayWorkoutRoutines_WorkoutRoutineId",
                table: "WorkoutDayWorkoutRoutines",
                column: "WorkoutRoutineId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkoutRoutines_AspNetUsers_UserId",
                table: "WorkoutRoutines",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
