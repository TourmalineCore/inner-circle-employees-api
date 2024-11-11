using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class TotalFinancesQuery : ITotalFinancesQuery
{
    private readonly EmployeeDbContext _context;

    public TotalFinancesQuery(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<TotalFinances?> GetTotalFinancesAsync()
    {
        return await _context.QueryableAsNoTracking<TotalFinances>().SingleOrDefaultAsync();
    }
}
