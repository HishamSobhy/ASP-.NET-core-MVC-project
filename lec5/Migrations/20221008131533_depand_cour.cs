using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec5.Migrations
{
    public partial class depand_cour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departmentcourses",
                columns: table => new
                {
                    DepartmentsDept_Id = table.Column<int>(type: "int", nullable: false),
                    coursessCour_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmentcourses", x => new { x.DepartmentsDept_Id, x.coursessCour_Id });
                    table.ForeignKey(
                        name: "FK_Departmentcourses_coursess_coursessCour_Id",
                        column: x => x.coursessCour_Id,
                        principalTable: "coursess",
                        principalColumn: "Cour_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Departmentcourses_Departments_DepartmentsDept_Id",
                        column: x => x.DepartmentsDept_Id,
                        principalTable: "Departments",
                        principalColumn: "Dept_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmentcourses_coursessCour_Id",
                table: "Departmentcourses",
                column: "coursessCour_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departmentcourses");
        }
    }
}
