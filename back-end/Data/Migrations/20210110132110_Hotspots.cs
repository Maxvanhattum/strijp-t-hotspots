using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Hotspots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotspots_AR360_AR360Id",
                table: "Hotspots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AR360",
                table: "AR360");

            migrationBuilder.RenameTable(
                name: "AR360",
                newName: "AR360s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AR360s",
                table: "AR360s",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotspots_AR360s_AR360Id",
                table: "Hotspots",
                column: "AR360Id",
                principalTable: "AR360s",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotspots_AR360s_AR360Id",
                table: "Hotspots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AR360s",
                table: "AR360s");

            migrationBuilder.RenameTable(
                name: "AR360s",
                newName: "AR360");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AR360",
                table: "AR360",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotspots_AR360_AR360Id",
                table: "Hotspots",
                column: "AR360Id",
                principalTable: "AR360",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
