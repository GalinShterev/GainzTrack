using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzTrack.Infrastructure.Data.Migrations
{
    public partial class NewArchitectureChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUsers_AspNetUsers_UserId",
                table: "AchievementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Titles_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CopiedWorkoutsFromUsers_AspNetUsers_UserId",
                table: "CopiedWorkoutsFromUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_AspNetUsers_CreatorId",
                table: "WorkoutRoutines");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AchievementPoints",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "MainUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IdentityUserId = table.Column<string>(nullable: true),
                    AchievementPoints = table.Column<int>(nullable: false),
                    TitleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainUsers_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainUsers_TitleId",
                table: "MainUsers",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUsers_MainUsers_UserId",
                table: "AchievementUsers",
                column: "UserId",
                principalTable: "MainUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CopiedWorkoutsFromUsers_MainUsers_UserId",
                table: "CopiedWorkoutsFromUsers",
                column: "UserId",
                principalTable: "MainUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AchievementUsers_MainUsers_UserId",
                table: "AchievementUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CopiedWorkoutsFromUsers_MainUsers_UserId",
                table: "CopiedWorkoutsFromUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkoutRoutines_MainUsers_CreatorId",
                table: "WorkoutRoutines");

            migrationBuilder.DropTable(
                name: "MainUsers");

            migrationBuilder.AddColumn<int>(
                name: "AchievementPoints",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TitleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TitleId",
                table: "AspNetUsers",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AchievementUsers_AspNetUsers_UserId",
                table: "AchievementUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Titles_TitleId",
                table: "AspNetUsers",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CopiedWorkoutsFromUsers_AspNetUsers_UserId",
                table: "CopiedWorkoutsFromUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
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
    }
}
