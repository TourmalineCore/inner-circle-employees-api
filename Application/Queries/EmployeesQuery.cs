using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class EmployeesQuery : IEmployeesQuery
{
  private readonly EmployeeDbContext _context;

  public EmployeesQuery(EmployeeDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<Employee>> GetEmployeesAsync(long tenantId)
  {
    return await _context
      .Employees
      .Where(x => !x.IsSpecial && x.TenantId == tenantId)
      .ToListAsync();
  }
}
