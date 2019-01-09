using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class Removed_Props_From_MainUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainUsers_Titles_TitleId",
                table: "MainUsers");

            migrationBuilder.DropIndex(
                name: "IX_MainUsers_TitleId",
                table: "MainUsers");

            migrationBuilder.DropColumn(
                name: "AchievementPoints",
                table: "MainUsers");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "MainUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AchievementPoints",
                table: "MainUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TitleId",
                table: "MainUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainUsers_TitleId",
                table: "MainUsers",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainUsers_Titles_TitleId",
                table: "MainUsers",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
