using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class HotspotModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AR360",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SourcePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AR360", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeoCoordinates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeoCoordinates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieInterviewDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Uploader = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInterviewDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotspots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    GeoCoordinatesId = table.Column<int>(nullable: false),
                    InterviewDetailsId = table.Column<int>(nullable: false),
                    AR360Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotspots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotspots_AR360_AR360Id",
                        column: x => x.AR360Id,
                        principalTable: "AR360",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotspots_GeoCoordinates_GeoCoordinatesId",
                        column: x => x.GeoCoordinatesId,
                        principalTable: "GeoCoordinates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotspots_MovieInterviewDetails_InterviewDetailsId",
                        column: x => x.InterviewDetailsId,
                        principalTable: "MovieInterviewDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_AR360Id",
                table: "Hotspots",
                column: "AR360Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_GeoCoordinatesId",
                table: "Hotspots",
                column: "GeoCoordinatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotspots_InterviewDetailsId",
                table: "Hotspots",
                column: "InterviewDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotspots");

            migrationBuilder.DropTable(
                name: "AR360");

            migrationBuilder.DropTable(
                name: "GeoCoordinates");

            migrationBuilder.DropTable(
                name: "MovieInterviewDetails");
        }
    }
}
