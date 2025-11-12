using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class AddNewFieldsToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specialization",
                table: "Employees",
                newName: "Specializations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Specializations",
                table: "Employees",
                newName: "Specialization");
        }
    }
}
