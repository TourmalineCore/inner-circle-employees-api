using Application.Dtos;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class EmployeeDeletionCommand
{
    private readonly EmployeeDbContext _context;

    public EmployeeDeletionCommand(EmployeeDbContext employeeDbContext)
    {
        _context = employeeDbContext;
    }

    public async Task ExecuteAsync(EmployeeDeletionParameters parameters)
    {
        var employee = await _context
            .Queryable<Employee>()
            .SingleAsync(x => x.CorporateEmail == parameters.CorporateEmail && x.DeletedAtUtc == null);

        _context.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
