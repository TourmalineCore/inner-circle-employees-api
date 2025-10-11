using Application.Dtos;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using Xunit;

namespace Application.Queries;

public class GetEmployeesByIdsQueryTests
{
  private const long TENANT_ID = 1L;
  private const long TENANT_ID_DIFF = 2L;

  private readonly EmployeeDbContext _context;
  private readonly GetEmployeesByIdsQuery _query;

  public GetEmployeesByIdsQueryTests()
  {
    var options = new DbContextOptionsBuilder<EmployeeDbContext>()
      .UseInMemoryDatabase("GetEmployeesByIdsQuery")
      .Options;

    _context = new EmployeeDbContext(options);
    _query = new GetEmployeesByIdsQuery(_context);
  }

  [Fact]
  public async Task GetEmployeesByIdsAsync_ShouldReturnEmployees()
  {
    var employee1 = new Employee(
      "employee1",
      "employee1",
      "employee1",
      "employee1@tourmalinecore.com",
      TENANT_ID_DIFF,
      true
    );

    var employee2 = new Employee(
      "employee2",
      "employee2",
      "employee2",
      "employee2@tourmalinecore.com",
      TENANT_ID,
      true
    );

    var employee3 = new Employee(
      "employee3",
      "employee3",
      "employee3",
      "employee3@tourmalinecore.com",
      TENANT_ID
    );

    var employee4 = new Employee(
      "employee4",
      "employee4",
      "employee4",
      "employee4@tourmalinecore.com",
      TENANT_ID
    );

    _context
      .Employees
      .AddRange(employee1, employee2, employee3, employee4);

    await _context.SaveChangesAsync();

    employee4.Delete(Instant.FromUtc(2023, 1, 1, 0, 0));
    await _context.SaveChangesAsync();

    var result = await _query.GetEmployeesByIdsAsync(
      new EmployeesIdsModel
      {
        EmployeesIds = new List<long> { 1, 3, 4 }
      },
      TENANT_ID
    );

    Assert.NotNull(result);
    Assert.Single(result);
    Assert.Contains(result, t => t.Id == 3 && t.FirstName == "employee3");
    Assert.DoesNotContain(result, t => t.Id == 1); // Employee whose TenantId is different should not be in result
    Assert.DoesNotContain(result, t => t.Id == 2); // Employee whose ID was not requested should not be in result
    Assert.DoesNotContain(result, t => t.Id == 4); // Deleted employee should not be in result
  }
}
