using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class EstimatedFinancialEfficiencyQuery : IEstimatedFinancialEfficiencyQuery
{
    private readonly EmployeeDbContext _context;

    public EstimatedFinancialEfficiencyQuery(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<EstimatedFinancialEfficiency?> GetEstimatedFinancialEfficiencyAsync()
    {
        return await _context.QueryableAsNoTracking<EstimatedFinancialEfficiency>().SingleOrDefaultAsync();
    }
}
