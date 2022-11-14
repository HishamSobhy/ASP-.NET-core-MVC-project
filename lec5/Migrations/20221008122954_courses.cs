using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lec5.Migrations
{
    public partial class courses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coursess",
                columns: table => new
                {
                    Cour_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cour_name = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Cour_Hours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coursess", x => x.Cour_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coursess");
        }
    }
}
