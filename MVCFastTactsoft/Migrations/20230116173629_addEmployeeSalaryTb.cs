using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCFastTactsoft.Migrations
{
    public partial class addEmployeeSalaryTb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSalaryTbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Basic = table.Column<double>(type: "float", nullable: false),
                    Hr = table.Column<double>(type: "float", nullable: false),
                    Pf = table.Column<double>(type: "float", nullable: false),
                    Ta = table.Column<double>(type: "float", nullable: false),
                    Ma = table.Column<double>(type: "float", nullable: false),
                    Bonus = table.Column<double>(type: "float", nullable: false),
                    Gross = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalaryTbs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalaryTbs");
        }
    }
}
