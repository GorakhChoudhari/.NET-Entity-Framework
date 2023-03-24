using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assesment.Migrations
{
    /// <inheritdoc />
    public partial class updatefieldname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentsDepartmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_DepartmentsDepartmentId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "DepartmentsDepartmentId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "employee",
                newName: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentId",
                table: "employee",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_DepartmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_DepartmentId",
                table: "employee");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "employee",
                newName: "DeptId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentsDepartmentId",
                table: "employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employee_DepartmentsDepartmentId",
                table: "employee",
                column: "DepartmentsDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_DepartmentsDepartmentId",
                table: "employee",
                column: "DepartmentsDepartmentId",
                principalTable: "department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
