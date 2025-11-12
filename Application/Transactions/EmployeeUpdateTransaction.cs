using Application.Dtos;
using Application.Queries;
using Application.Queries.Contracts;
using Core;
using DataAccess;
using Microsoft.Extensions.Logging;
using NodaTime;

namespace Application.Transactions;

public class EmployeeUpdateTransaction
{
  private readonly EmployeeDbContext _context;
  private readonly EmployeeQuery _employeeQuery;
  private readonly ILogger<EmployeeUpdateTransaction> _logger;

  public EmployeeUpdateTransaction(
    EmployeeDbContext context,
    IWorkingPlanQuery getWorkingPlanQueryHandler,
    IClock clock,
    EmployeeQuery employeeQuery,
    ILogger<EmployeeUpdateTransaction> logger
  )
  {
    _context = context;
    _employeeQuery = employeeQuery;
    _logger = logger;
  }

  public async Task ExecuteAsync(EmployeeUpdateDto request)
  {
    var employee = await _employeeQuery.GetEmployeeAsync(request.EmployeeId);
    await using var transaction = await _context
      .Database
      .BeginTransactionAsync();

    try
    {
      await UpdateEmployeeInfoAsync(employee, request);
      await transaction.CommitAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex.Message);
      await transaction.RollbackAsync();
      throw;
    }
  }

  private async Task UpdateEmployeeInfoAsync(Employee employee, EmployeeUpdateDto request)
  {
    employee.Update(
      request.Phone,
      request.BirthDate,
      request.Specializations,
      request.PersonalEmail,
      request.GitHub,
      request.GitLab,
      request.WorkerTime
    );

    _context.Update(employee);
    await _context.SaveChangesAsync();
  }
}
