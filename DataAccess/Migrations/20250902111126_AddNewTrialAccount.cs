using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class AddNewTrialAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CorporateEmail", "DeletedAtUtc", "FirstName", "GitHub", "GitLab", "HireDate", "IsBlankEmployee", "IsCurrentEmployee", "IsEmployedOfficially", "IsSpecial", "LastName", "MiddleName", "PersonalEmail", "PersonnelNumber", "Phone", "TenantId" },
                values: new object[] { 3L, "trial@tourmalinecore.com", null, "Trial", null, null, NodaTime.Instant.FromUnixTimeTicks(15778368000000000L), true, true, true, false, "Trial", "Trial", "trial@gmail.com", null, null, 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L);
        }
    }
}
