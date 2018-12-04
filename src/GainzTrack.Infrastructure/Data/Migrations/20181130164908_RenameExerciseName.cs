using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class RenameExerciseName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Exercises",
                newName: "ExerciseName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExerciseName",
                table: "Exercises",
                newName: "Name");
        }
    }
}
