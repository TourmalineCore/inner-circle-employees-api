using Application.Queries.Contracts;
using Core;
using NodaTime;

namespace Application.Commands;

public class RecalcFinancialMetricsCommand
{
  private readonly RecalcEstimatedFinancialEfficiencyCommand _recalcEstimatedFinancialEfficiencyCommand;
  private readonly RecalcTotalMetricsCommand _recalcTotalMetricsCommand;
  private readonly IFinancialMetricsQuery _financialMetricsQuery;

  public RecalcFinancialMetricsCommand(
    RecalcEstimatedFinancialEfficiencyCommand recalcEstimatedFinancialEfficiencyCommand,
    RecalcTotalMetricsCommand recalcTotalMetricsCommand,
    IFinancialMetricsQuery financialMetricsQuery
  )
  {
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

