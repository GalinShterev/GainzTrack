using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class Added_VideoIdAndIsApproved_ToAchievementUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "AchievementUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VideoId",
                table: "AchievementUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "AchievementUsers");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "AchievementUsers");
        }
    }
}
