using Application.Commands;
using Application.Dtos;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace SalaryService.Tests;

public class EmployeePersonalInformationUpdateCommandTests
{
  private readonly EmployeeDbContext _context;
  private readonly EmployeePersonalInformationUpdateCommand _command;
  public EmployeePersonalInformationUpdateCommandTests()
  {
    var options = new DbContextOptionsBuilder<EmployeeDbContext>()
      .UseInMemoryDatabase(databaseName: "EmployeePersonalInformationUpdateCommandEmployeesDatabase")
      .Options;

    _context = new EmployeeDbContext(options);

    _command = new EmployeePersonalInformationUpdateCommand(_context);
  }

  [Fact]
  public async Task UpdatePersonalEmployeeInfo_PersonalInfoUpdated()
  {
    var employee = new Employee(
      "Test",
      "Test",
      "Test",
      "test@tourmalinecore.com",
      1
    );

    _context.Employees.Add(employee);
    await _context.SaveChangesAsync();

    var updateRequest = new EmployeePersonalInformationUpdateParameters()
    {
      CorporateEmail = "test@tourmalinecore.com",
      FirstName = "Updated",
      LastName = "Updated",
      MiddleName = "Updated"
    };

    await _command.ExecuteAsync(updateRequest);

    var updatedEmployee = await _context
      .Employees
      .SingleOrDefaultAsync(x => x.CorporateEmail == updateRequest.CorporateEmail);

    Assert.NotNull(updatedEmployee);
    Assert.Equal(updateRequest.FirstName, updatedEmployee.FirstName);
    Assert.Equal(updateRequest.MiddleName, updatedEmployee.MiddleName);
    Assert.Equal(updateRequest.LastName, updatedEmployee.LastName);
  }
}
