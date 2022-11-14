using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec5.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_coursess_coursesId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.RenameTable(
                name: "StudentCourses",
                newName: "StudentCoursess");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCourses_coursesId",
                table: "StudentCoursess",
                newName: "IX_StudentCoursess_coursesId");

            migrationBuilder.AlterColumn<string>(
                name: "Dept_Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cour_name",
                table: "coursess",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "Cour_Hours",
                table: "coursess",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCoursess",
                table: "StudentCoursess",
                columns: new[] { "StudentId", "coursesId" });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Userrole",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    rolesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userrole", x => new { x.UsersId, x.rolesId });
                    table.ForeignKey(
                        name: "FK_Userrole_Roles_rolesId",
                        column: x => x.rolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Userrole_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Userrole_rolesId",
                table: "Userrole",
                column: "rolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCoursess_coursess_coursesId",
                table: "StudentCoursess",
                column: "coursesId",
                principalTable: "coursess",
                principalColumn: "Cour_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCoursess_students_StudentId",
                table: "StudentCoursess",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCoursess_coursess_coursesId",
                table: "StudentCoursess");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCoursess_students_StudentId",
                table: "StudentCoursess");

            migrationBuilder.DropTable(
                name: "Userrole");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCoursess",
                table: "StudentCoursess");

            migrationBuilder.RenameTable(
                name: "StudentCoursess",
                newName: "StudentCourses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentCoursess_coursesId",
                table: "StudentCourses",
                newName: "IX_StudentCourses_coursesId");

            migrationBuilder.AlterColumn<string>(
                name: "Dept_Name",
                table: "Departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Cour_name",
                table: "coursess",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cour_Hours",
                table: "coursess",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                columns: new[] { "StudentId", "coursesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_coursess_coursesId",
                table: "StudentCourses",
                column: "coursesId",
                principalTable: "coursess",
                principalColumn: "Cour_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
