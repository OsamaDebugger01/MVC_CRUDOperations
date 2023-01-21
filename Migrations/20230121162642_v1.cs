using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCCRUDOperations.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Ssn = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Bdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    SuperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Ssn);
                    table.ForeignKey(
                        name: "FK_employees_employees_SuperID",
                        column: x => x.SuperID,
                        principalTable: "employees",
                        principalColumn: "Ssn");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLocations",
                columns: table => new
                {
                    DeptNumber = table.Column<int>(name: "Dept_Number", type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocations", x => x.DeptNumber);
                    table.ForeignKey(
                        name: "FK_DepartmentLocations_Department_Dept_Number",
                        column: x => x.DeptNumber,
                        principalTable: "Department",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => new { x.Name, x.Number });
                    table.ForeignKey(
                        name: "FK_projects_Department_Number",
                        column: x => x.Number,
                        principalTable: "Department",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dependents",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Relationship = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Empssn = table.Column<int>(name: "Emp_ssn", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependents", x => x.name);
                    table.ForeignKey(
                        name: "FK_dependents_employees_Emp_ssn",
                        column: x => x.Empssn,
                        principalTable: "employees",
                        principalColumn: "Ssn");
                });

            migrationBuilder.CreateTable(
                name: "Work_For",
                columns: table => new
                {
                    Empssn = table.Column<int>(name: "Emp_ssn", type: "int", nullable: false),
                    Projnumber = table.Column<int>(name: "Proj_number", type: "int", nullable: false),
                    employeeSsn = table.Column<int>(type: "int", nullable: false),
                    projectName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    projectNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work_For", x => new { x.Projnumber, x.Empssn });
                    table.ForeignKey(
                        name: "FK_Work_For_employees_employeeSsn",
                        column: x => x.employeeSsn,
                        principalTable: "employees",
                        principalColumn: "Ssn",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Work_For_projects_projectName_projectNumber",
                        columns: x => new { x.projectName, x.projectNumber },
                        principalTable: "projects",
                        principalColumns: new[] { "Name", "Number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dependents_Emp_ssn",
                table: "dependents",
                column: "Emp_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_employees_SuperID",
                table: "employees",
                column: "SuperID");

            migrationBuilder.CreateIndex(
                name: "IX_projects_Number",
                table: "projects",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Work_For_employeeSsn",
                table: "Work_For",
                column: "employeeSsn");

            migrationBuilder.CreateIndex(
                name: "IX_Work_For_projectName_projectNumber",
                table: "Work_For",
                columns: new[] { "projectName", "projectNumber" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLocations");

            migrationBuilder.DropTable(
                name: "dependents");

            migrationBuilder.DropTable(
                name: "Work_For");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
