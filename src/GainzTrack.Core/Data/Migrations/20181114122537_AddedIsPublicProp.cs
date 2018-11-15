using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Core.Data.Migrations
{
    public partial class AddedIsPublicProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "WorkoutRoutines",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "WorkoutRoutines");
        }
    }
}
