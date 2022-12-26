using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace trial_project_for_MVC_Core.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_College_Universities_UniversityId",
                table: "College");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_College_CollegeId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_College",
                table: "College");

            migrationBuilder.RenameTable(
                name: "College",
                newName: "Colleges");

            migrationBuilder.RenameColumn(
                name: "UniversityId",
                table: "Colleges",
                newName: "UniversityId1");

            migrationBuilder.RenameIndex(
                name: "IX_College_UniversityId",
                table: "Colleges",
                newName: "IX_Colleges_UniversityId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Colleges_Universities_UniversityId1",
                table: "Colleges",
                column: "UniversityId1",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Colleges_CollegeId",
                table: "Department",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colleges_Universities_UniversityId1",
                table: "Colleges");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Colleges_CollegeId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges");

            migrationBuilder.RenameTable(
                name: "Colleges",
                newName: "College");

            migrationBuilder.RenameColumn(
                name: "UniversityId1",
                table: "College",
                newName: "UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_Colleges_UniversityId1",
                table: "College",
                newName: "IX_College_UniversityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_College",
                table: "College",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_College_Universities_UniversityId",
                table: "College",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_College_CollegeId",
                table: "Department",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
