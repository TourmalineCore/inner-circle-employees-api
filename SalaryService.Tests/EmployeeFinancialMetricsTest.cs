using Moq;
using NodaTime;
using SalaryService.Domain;
using SalaryService.Tests.Data;

namespace SalaryService.Tests;

public class EmployeeFinancialMetricsTest
{
    [Fact]
    public void CalculateOfficialEmployeeMetrics_MetricsAreCorrect()
    {
        var employeeFinancialMetrics = new EmployeeFinancialMetrics(new FinancesForPayroll(0, 20000, 1, 1800),
            true,
            EmployeeFinancialTestsData.CoefficientOptions,
            EmployeeFinancialTestsData.WorkingPlan,
            It.IsAny<Instant>());

        Assert.Equal(20000, employeeFinancialMetrics.Salary);
        Assert.Equal(230.45m, Math.Round(employeeFinancialMetrics.HourlyCostFact, 2));
        Assert.Equal(125.00m, Math.Round(employeeFinancialMetrics.HourlyCostHand, 2));
        Assert.Equal(0.00m, Math.Round(employeeFinancialMetrics.Earnings, 2));
        Assert.Equal(3000.00m, Math.Round(employeeFinancialMetrics.DistrictCoefficient, 2));
        Assert.Equal(2990.00m, Math.Round(employeeFinancialMetrics.IncomeTaxContributions, 2));
        Assert.Equal(4133.48m, Math.Round(employeeFinancialMetrics.PensionContributions, 2));
        Assert.Equal(1165.28m, Math.Round(employeeFinancialMetrics.MedicalContributions, 2));
        Assert.Equal(443.09m, Math.Round(employeeFinancialMetrics.SocialInsuranceContributions, 2));
        Assert.Equal(46.00m, Math.Round(employeeFinancialMetrics.InjuriesContributions, 2));
        Assert.Equal(31187.85m, Math.Round(employeeFinancialMetrics.Expenses, 2));
        Assert.Equal(-31187.85m, Math.Round(employeeFinancialMetrics.Profit, 2));
        Assert.Equal(-100.00m, Math.Round(employeeFinancialMetrics.ProfitAbility, 2));
        Assert.Equal(23000.00m, Math.Round(employeeFinancialMetrics.GrossSalary, 2));
        Assert.Equal(20010.00m, Math.Round(employeeFinancialMetrics.NetSalary, 2));
        Assert.Equal(10005.00m, Math.Round(employeeFinancialMetrics.Prepayment, 2));
        Assert.Equal(600, Math.Round(employeeFinancialMetrics.AccountingPerMonth, 2));
        Assert.Equal(1800, Math.Round(employeeFinancialMetrics.ParkingCostPerMonth, 2));
    }

    [Fact]
    public void CalculateUnofficialEmployeeMetrics_MetricsAreCorrect()
    {
        var employeeFinancialMetrics = new EmployeeFinancialMetrics(new FinancesForPayroll(400, 20000, 1, 1800),
            false,
            EmployeeFinancialTestsData.CoefficientOptions,
            EmployeeFinancialTestsData.WorkingPlan,
            It.IsAny<Instant>());

        Assert.Equal(20000, employeeFinancialMetrics.Salary);
        Assert.Equal(161.08m, Math.Round(employeeFinancialMetrics.HourlyCostFact, 2));
        Assert.Equal(125.00m, Math.Round(employeeFinancialMetrics.HourlyCostHand, 2));
        Assert.Equal(54133.33m, Math.Round(employeeFinancialMetrics.Earnings, 2));
        Assert.Equal(21800, Math.Round(employeeFinancialMetrics.Expenses, 2));
        Assert.Equal(32333.33m, Math.Round(employeeFinancialMetrics.Profit, 2));
        Assert.Equal(59.73m, Math.Round(employeeFinancialMetrics.ProfitAbility, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.DistrictCoefficient, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.IncomeTaxContributions, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.PensionContributions, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.MedicalContributions, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.SocialInsuranceContributions, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.InjuriesContributions, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.GrossSalary, 2));
        Assert.Equal(20000, Math.Round(employeeFinancialMetrics.NetSalary, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.Prepayment, 2));
        Assert.Equal(0, Math.Round(employeeFinancialMetrics.AccountingPerMonth, 2));
        Assert.Equal(1800, Math.Round(employeeFinancialMetrics.ParkingCostPerMonth, 2));
    }
}