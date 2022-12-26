using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trial_project_for_MVC_Core.Migrations
{
    public partial class aax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Universities_UniversityId1",
                table: "Colleges");

            migrationBuilder.RenameColumn(
                name: "UniversityId1",
                table: "Colleges",
                newName: "UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Colleges_UniversityId1",
                table: "Colleges",
                newName: "IX_Colleges_UniversityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Universities_UniversityId",
                table: "Colleges",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Universities_UniversityId",
                table: "Colleges");

            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Colleges",
                newName: "UniversityId1");

            migrationBuilder.RenameIndex(
                name: "IX_Colleges_UniversityId",
                table: "Colleges",
                newName: "IX_Colleges_UniversityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Universities_UniversityId1",
                table: "Colleges",
                column: "UniversityId1",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
