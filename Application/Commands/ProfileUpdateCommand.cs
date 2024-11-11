using Application.Dtos;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class ProfileUpdateCommand
{
    private readonly EmployeeDbContext _context;

    public ProfileUpdateCommand(EmployeeDbContext employeeDbContext)
    {
        _context = employeeDbContext;
    }

    public async Task ExecuteAsync(string corporateEmail, ProfileUpdatingParameters request)
    {
        var employee = await _context
            .Queryable<Employee>()
            .SingleAsync(x => x.CorporateEmail == corporateEmail && x.DeletedAtUtc == null);

        employee.Update(request.Phone, request.PersonalEmail, request.GitHub, request.GitLab);

        _context.Update(employee);
        await _context.SaveChangesAsync();
    }
}