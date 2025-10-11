using Core;

namespace Application.Queries.Contracts;

public interface IEstimatedFinancialEfficiencyQuery
{
  Task<EstimatedFinancialEfficiency?> GetEstimatedFinancialEfficiencyAsync();
}
