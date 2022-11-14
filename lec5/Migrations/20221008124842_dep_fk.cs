using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec5.Migrations
{
    public partial class dep_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Dept_Id",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_Dept_Id",
                table: "students",
                column: "Dept_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_students_Departments_Dept_Id",
                table: "students",
                column: "Dept_Id",
                principalTable: "Departments",
                principalColumn: "Dept_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_Departments_Dept_Id",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_Dept_Id",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Dept_Id",
                table: "students");
        }
    }
}
