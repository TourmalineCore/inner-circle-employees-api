using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class RemoveEmployeeFinancialMetricsHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFinancialMetricsHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeFinancialMetricsHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountingPerMonth = table.Column<decimal>(type: "numeric", nullable: false),
                    Earnings = table.Column<decimal>(type: "numeric", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    EmploymentType = table.Column<decimal>(type: "numeric", nullable: false),
                    Expenses = table.Column<decimal>(type: "numeric", nullable: false),
                    GrossSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    HourlyCostFact = table.Column<decimal>(type: "numeric", nullable: false),
                    HourlyCostHand = table.Column<decimal>(type: "numeric", nullable: false),
                    IncomeTaxContributions = table.Column<decimal>(type: "numeric", nullable: false),
                    InjuriesContributions = table.Column<decimal>(type: "numeric", nullable: false),
                    MedicalContributions = table.Column<decimal>(type: "numeric", nullable: false),
                    NetSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    ParkingCostPerMonth = table.Column<decimal>(type: "numeric", nullable: false),
                    Pay = table.Column<decimal>(type: "numeric", nullable: false),
                    PensionContributions = table.Column<decimal>(type: "numeric", nullable: false),
                    Prepayment = table.Column<decimal>(type: "numeric", nullable: false),
                    Profit = table.Column<decimal>(type: "numeric", nullable: false),
                    ProfitAbility = table.Column<decimal>(type: "numeric", nullable: false),
                    RatePerHour = table.Column<decimal>(type: "numeric", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    SocialInsuranceContributions = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFinancialMetricsHistory", x => x.Id);
                });
        }
    }
}
