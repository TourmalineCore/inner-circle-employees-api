using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries;

public class CoefficientsQuery : ICoefficientsQuery
{
    private readonly EmployeeDbContext _context;

    public CoefficientsQuery(EmployeeDbContext employeeDbContext)
    {
        _context = employeeDbContext;
    }

    public async Task<CoefficientOptions> GetCoefficientsAsync()
    {
        return await _context.QueryableAsNoTracking<CoefficientOptions>().SingleAsync();
    }
}
