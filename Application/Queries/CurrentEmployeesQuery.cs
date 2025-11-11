using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class CurrentEmployeesQuery
{
  private readonly EmployeeDbContext _context;

  public CurrentEmployeesQuery(EmployeeDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Employee>> GetCurrentEmployeesAsync(long tenantId)
  {
    return await _context
      .Employees
      .Where(x => !x.IsSpecial && x.IsCurrentEmployee && x.TenantId == tenantId)
      .ToListAsync();
  }
}
