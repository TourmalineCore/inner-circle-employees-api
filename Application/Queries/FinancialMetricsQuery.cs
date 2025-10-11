using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class FinancialMetricsQuery : IFinancialMetricsQuery
{
  private readonly EmployeeDbContext _context;

  public FinancialMetricsQuery(EmployeeDbContext employeeDbContext)
  {
    _context = employeeDbContext;
  }

  public async Task<IEnumerable<EmployeeFinancialMetrics>> HandleAsync()
  {
    return await _context
      .Employees
      .Include(x => x.FinancialMetrics)
      .Where(x => x.FinancialMetrics != null)
      .Select(x => x.FinancialMetrics)
      .AsNoTracking()
      .ToListAsync();
  }
}
