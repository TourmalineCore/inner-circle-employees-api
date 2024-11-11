using Core;

namespace Application.Queries.Contracts;

public interface ITotalFinancesQuery
{
    Task<TotalFinances?> GetTotalFinancesAsync();
}