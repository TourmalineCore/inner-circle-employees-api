using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class GetEmployeesByIdsQuery
{
    private readonly EmployeeDbContext _context;

    public GetEmployeesByIdsQuery(EmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<List<Employee>> GetEmployeesByIdsAsync(EmployeesIdsModel ids, long tenantId)
    {
        return await _context
            .Employees
            .Where(x => x.TenantId == tenantId)
            .Where(x => x.DeletedAtUtc == null)
            .Where(x => ids.EmployeesIds.Contains(x.Id))
            .ToListAsync();
    }
}
