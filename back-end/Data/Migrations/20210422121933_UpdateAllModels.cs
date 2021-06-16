using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotspots_MovieInterviewDetails_InterviewDetailsId",
                table: "Hotspots");

            migrationBuilder.DropIndex(
                name: "IX_Hotspots_InterviewDetailsId",
                table: "Hotspots");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "Uploader",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "InterviewDetailsId",
                table: "Hotspots");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionInterview",
                table: "MovieInterviewDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleInterview",
                table: "MovieInterviewDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploaderInterview",
                table: "MovieInterviewDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewId",
                table: "Hotspots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_InterviewId",
                table: "Hotspots",
                column: "InterviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotspots_MovieInterviewDetails_InterviewId",
                table: "Hotspots",
                column: "InterviewId",
                principalTable: "MovieInterviewDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotspots_MovieInterviewDetails_InterviewId",
                table: "Hotspots");

            migrationBuilder.DropIndex(
                name: "IX_Hotspots_InterviewId",
                table: "Hotspots");

            migrationBuilder.DropColumn(
                name: "DescriptionInterview",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "TitleInterview",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "UploaderInterview",
                table: "MovieInterviewDetails");

            migrationBuilder.DropColumn(
                name: "InterviewId",
                table: "Hotspots");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MovieInterviewDetails",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "MovieInterviewDetails",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uploader",
                table: "MovieInterviewDetails",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterviewDetailsId",
                table: "Hotspots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_InterviewDetailsId",
                table: "Hotspots",
                column: "InterviewDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotspots_MovieInterviewDetails_InterviewDetailsId",
                table: "Hotspots",
                column: "InterviewDetailsId",
                principalTable: "MovieInterviewDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
