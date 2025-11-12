using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    public partial class RemoveFinancialsAndAnalyticsFunctional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeFinancialMetricsHistory_Employees_EmployeeId",
                table: "EmployeeFinancialMetricsHistory");

            migrationBuilder.DropTable(
                name: "CoefficientOptions");

            migrationBuilder.DropTable(
                name: "EmployeeFinancialMetrics");

            migrationBuilder.DropTable(
                name: "EstimatedFinancialEfficiency");

            migrationBuilder.DropTable(
                name: "TotalFinances");

            migrationBuilder.DropTable(
                name: "TotalFinancesHistory");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeFinancialMetricsHistory_EmployeeId",
                table: "EmployeeFinancialMetricsHistory");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsEmployedOfficially",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PersonnelNumber",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FromUtc",
                table: "EmployeeFinancialMetricsHistory");

            migrationBuilder.DropColumn(
                name: "ToUtc",
                table: "EmployeeFinancialMetricsHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Instant>(
                name: "HireDate",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmployedOfficially",
                table: "Employees",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PersonnelNumber",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Instant>(
                name: "FromUtc",
                table: "EmployeeFinancialMetricsHistory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: NodaTime.Instant.FromUnixTimeTicks(0L));

            migrationBuilder.AddColumn<Instant>(
                name: "ToUtc",
                table: "EmployeeFinancialMetricsHistory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CoefficientOptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictCoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    IncomeTaxPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    MinimumWage = table.Column<decimal>(type: "numeric", nullable: false),
                    OfficeExpenses = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoefficientOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFinancialMetrics",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    AccountingPerMonth = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAtUtc = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    DistrictCoefficient = table.Column<decimal>(type: "numeric", nullable: false),
                    Earnings = table.Column<decimal>(type: "numeric", nullable: false),
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
                    table.PrimaryKey("PK_EmployeeFinancialMetrics", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeFinancialMetrics_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatedFinancialEfficiency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAtUtc = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    DesiredEarnings = table.Column<decimal>(type: "numeric", nullable: false),
                    DesiredProfit = table.Column<decimal>(type: "numeric", nullable: false),
                    DesiredProfitability = table.Column<decimal>(type: "numeric", nullable: false),
                    ReserveForHalfYear = table.Column<decimal>(type: "numeric", nullable: false),
                    ReserveForQuarter = table.Column<decimal>(type: "numeric", nullable: false),
                    ReserveForYear = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatedFinancialEfficiency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalFinances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAtUtc = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    PayrollExpense = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalFinances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TotalFinancesHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUtc = table.Column<Instant>(type: "timestamp with time zone", nullable: false),
                    ToUtc = table.Column<Instant>(type: "timestamp with time zone", nullable: true),
                    PayrollExpense = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalExpense = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalFinancesHistory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoefficientOptions",
                columns: new[] { "Id", "DistrictCoefficient", "IncomeTaxPercent", "MinimumWage", "OfficeExpenses" },
                values: new object[] { 1L, 0.15m, 0.13m, 15279m, 49000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HireDate", "IsEmployedOfficially" },
                values: new object[] { NodaTime.Instant.FromUnixTimeTicks(15778368000000000L), true });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "HireDate", "IsEmployedOfficially" },
                values: new object[] { NodaTime.Instant.FromUnixTimeTicks(15778368000000000L), true });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "HireDate", "IsEmployedOfficially" },
                values: new object[] { NodaTime.Instant.FromUnixTimeTicks(15778368000000000L), true });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFinancialMetricsHistory_EmployeeId",
                table: "EmployeeFinancialMetricsHistory",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeFinancialMetricsHistory_Employees_EmployeeId",
                table: "EmployeeFinancialMetricsHistory",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
