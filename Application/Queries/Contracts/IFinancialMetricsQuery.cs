using Core;

namespace Application.Queries.Contracts;

public interface IFinancialMetricsQuery
{
    Task<IEnumerable<EmployeeFinancialMetrics>> HandleAsync();
}
