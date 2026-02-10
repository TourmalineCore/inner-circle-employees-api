using Application.Dtos;
using Core;
using Core.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EmployeeService.Tests;

public class EmployeeUpdateTests
{
  private readonly EmployeeDbContext _context;
  public EmployeeUpdateTests()
  {
    var options = new DbContextOptionsBuilder<EmployeeDbContext>()
      .UseInMemoryDatabase(databaseName: "EmployeeUpdateDatabase")
      .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
      .Options;

    _context = new EmployeeDbContext(options);
  }

  [Fact]
  public async Task UpdateEmployee_ShouldUpdateEmployeeInDb()
  {
    var employee = new Employee(
      firstName: "Test",
      lastName: "Test", 
      middleName: "Test",
      corporateEmail: "test@tourmalinecore.com",
      tenantId: 1
    );

    _context.Employees.Add(employee);

    await _context.SaveChangesAsync();

    var employeeUpdateDto = new EmployeeUpdateDto()
    {
      EmployeeId = 1,
      Phone = "+71234567890",
      BirthDate = "2000-10-12",
      Specializations = new List<Specialization>{ Specialization.Embedded }
    };

    employee.Update(
      employeeUpdateDto.Phone,
      employeeUpdateDto.BirthDate,
      employeeUpdateDto.Specializations,
      employeeUpdateDto.PersonalEmail,
      employeeUpdateDto.GitHub,
      employeeUpdateDto.GitLab,
      employeeUpdateDto.WorkerTime
    );

    _context.Update(employee);

    await _context.SaveChangesAsync();

    var updatedEmployee = await _context
      .Employees
      .SingleOrDefaultAsync(x => x.Id == employeeUpdateDto.EmployeeId);

    Assert.NotNull(updatedEmployee);
    Assert.Equal(employeeUpdateDto.Phone, updatedEmployee.Phone);
    Assert.Equal(employeeUpdateDto.BirthDate, updatedEmployee.BirthDate);
    Assert.Equal(employeeUpdateDto.Specializations, updatedEmployee.Specializations);
    Assert.True(updatedEmployee.IsCurrentEmployee);
    Assert.False(updatedEmployee.IsBlankEmployee);
  }
}
