using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepAppCrudOpration.Migrations
{
    public partial class InitilazerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hr");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Hr",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employes",
                schema: "Hr",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "varchar(200)", nullable: false),
                    ImageUser = table.Column<string>(type: "varchar(250)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NationalId = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employes_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "Hr",
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_DepartmentId",
                schema: "Hr",
                table: "Employes",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employes",
                schema: "Hr");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Hr");
        }
    }
}
