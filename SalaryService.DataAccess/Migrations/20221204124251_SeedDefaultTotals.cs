﻿using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class SeedDefaultTotals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeExpense",
                table: "TotalFinancesHistory");

            migrationBuilder.InsertData(
                table: "TotalFinances",
                columns: new[] { "Id", "ActualFromUtc", "PayrollExpense", "TotalExpense" },
                values: new object[] { 1L, NodaTime.Instant.FromUnixTimeTicks(0L), 0.0, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TotalFinances",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.AddColumn<double>(
                name: "OfficeExpense",
                table: "TotalFinancesHistory",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
