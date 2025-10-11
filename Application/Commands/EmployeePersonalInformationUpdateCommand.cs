using Application.Dtos;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands;

public class EmployeePersonalInformationUpdateCommand
{
  private readonly EmployeeDbContext _context;

  public EmployeePersonalInformationUpdateCommand(EmployeeDbContext employeeDbContext)
  {
    _context = employeeDbContext;
  }

  public async Task ExecuteAsync(EmployeePersonalInformationUpdateParameters parameters)
  {
    var employee = await _context
      .Queryable<Employee>()
      .SingleAsync(x => x.CorporateEmail == parameters.CorporateEmail && x.DeletedAtUtc == null);

    employee.UpdatePersonalInfo(
      parameters.FirstName,
      parameters.MiddleName,
      parameters.LastName
    );

    _context.Update(employee);
    await _context.SaveChangesAsync();
  }
}
