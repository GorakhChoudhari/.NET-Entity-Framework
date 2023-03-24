using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesment.Migrations
{
    /// <inheritdoc />
    public partial class updateforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "employee",
                newName: "DepartmentsDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_DepartmentId",
                table: "employee",
                newName: "IX_employee_DepartmentsDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentsDepartmentId",
                table: "employee",
                column: "DepartmentsDepartmentId",
                principalTable: "department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentsDepartmentId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentsDepartmentId",
                table: "employee",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_employee_DepartmentsDepartmentId",
                table: "employee",
                newName: "IX_employee_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
