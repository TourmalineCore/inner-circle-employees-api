using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class AddNewFieldsToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "Specialization",
                table: "Employees",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkerTime",
                table: "Employees",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "WorkerTime",
                table: "Employees");
        }
    }
}
