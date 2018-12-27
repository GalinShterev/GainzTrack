using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class AddedNewAchievementProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Achievements",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_CreatedById",
                table: "Achievements",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_MainUsers_CreatedById",
                table: "Achievements",
                column: "CreatedById",
                principalTable: "MainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_MainUsers_CreatedById",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_CreatedById",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Achievements");
        }
    }
}
