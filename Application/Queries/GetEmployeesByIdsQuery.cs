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

    public async Task<List<Employee>> GetEmployeesByIdsAsync(List<long> ids)
    {
        return await _context
            .Employees
            .Where(x => ids.Contains(x.Id))
            .Where(x => x.DeletedAtUtc == null)
            .ToListAsync();
    }
}
