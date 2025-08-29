using Application.Queries;
using Core;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class GetEmployeesByIdsQueryTests
{
    private const long TENANT_ID = 1;
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
            1L,
            true
        );

        var employee2 = new Employee(
            "employee2",
            "employee2",
            "employee2",
            "employee2@tourmalinecore.com",
            2L,
            true
        );

        var employee3 = new Employee(
            "employee3",
            "employee3",
            "employee3",
            "employee3@tourmalinecore.com",
            1L
        );

        _context.Employees.AddRange(employee1, employee2, employee3);
        await _context.SaveChangesAsync();

        var result = await _query.GetEmployeesByIdsAsync(new List<long>{
            1,
            3
        });

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(result, t => t.Id == 1 && t.FirstName == "employee1");
        Assert.Contains(result, t => t.Id == 3 && t.FirstName == "employee3");
    }
}