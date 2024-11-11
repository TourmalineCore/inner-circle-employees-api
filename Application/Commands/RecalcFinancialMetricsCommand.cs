using Application.Queries.Contracts;
using Core;
using DataAccess;
using NodaTime;

namespace Application.Commands;

public class RecalcFinancialMetricsCommand
{
    private readonly EmployeeDbContext _context;
    private readonly RecalcEstimatedFinancialEfficiencyCommand _recalcEstimatedFinancialEfficiencyCommand;
    private readonly RecalcTotalMetricsCommand _recalcTotalMetricsCommand;
    private readonly IFinancialMetricsQuery _financialMetricsQuery;

    public RecalcFinancialMetricsCommand(
        EmployeeDbContext context,
        RecalcEstimatedFinancialEfficiencyCommand recalcEstimatedFinancialEfficiencyCommand,
        RecalcTotalMetricsCommand recalcTotalMetricsCommand,
        IFinancialMetricsQuery financialMetricsQuery)
    {
        _context = context;
        _recalcEstimatedFinancialEfficiencyCommand = recalcEstimatedFinancialEfficiencyCommand;
        _recalcTotalMetricsCommand = recalcTotalMetricsCommand;
        _financialMetricsQuery = financialMetricsQuery;
    }

    public async Task ExecuteAsync(CoefficientOptions coefficients, Instant utcNow)
    {
        var employeeFinancialMetrics = await _financialMetricsQuery.HandleAsync();
        var newTotals = await _recalcTotalMetricsCommand.ExecuteAsync(employeeFinancialMetrics, coefficients, utcNow);
        await _recalcEstimatedFinancialEfficiencyCommand.ExecuteAsync(employeeFinancialMetrics, coefficients, newTotals.TotalExpense, utcNow);
    }
}

