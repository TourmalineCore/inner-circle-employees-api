using Application.Dtos;
using Core;
using DataAccess;

namespace Application.Commands;

public class EmployeeCreationCommand
{
  private readonly EmployeeDbContext _context;

  public EmployeeCreationCommand(EmployeeDbContext employeeDbContext)
  {
    _context = employeeDbContext;
  }

  public async Task ExecuteAsync(EmployeeCreationParameters parameters)
  {
    var employee = new Employee(
      parameters.FirstName,
      parameters.LastName,
      parameters.MiddleName,
      parameters.CorporateEmail,
      parameters.TenantId
    );

    await _context.AddAsync(employee);
    await _context.SaveChangesAsync();
  }
}
