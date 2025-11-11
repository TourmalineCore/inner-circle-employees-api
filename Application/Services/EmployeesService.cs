using Application.Commands;
using Application.Dtos;
using Application.Queries;
using Application.Queries.Contracts;
using Application.Transactions;
using Application.Validators;
using Core;
using FluentValidation;

namespace Application.Services;

public class EmployeesService
{
  private readonly EmployeeCreationCommand _employeeCreationCommand;
  private readonly EmployeeDeletionCommand _employeeDeletionCommand;
  private readonly EmployeeQuery _employeeQuery;
  private readonly IEmployeesQuery _employeesQuery;
  private readonly GetEmployeesByIdsQuery _getEmployeesByIdsQuery;
  private readonly ProfileUpdateCommand _profileUpdateCommand;
  private readonly EmployeeUpdateParametersValidator _employeeUpdateParametersValidator;
  private readonly EmployeeUpdateTransaction _employeeUpdateTransaction;
  private readonly EmployeesForAnalyticsQuery _employeesForAnalyticsQuery;
  private readonly CurrentEmployeesQuery _currentEmployeesQuery;
  private readonly ProfileUpdatingParametersValidator _profileUpdatingParametersValidator;

  public EmployeesService(
    EmployeeCreationCommand createEmployeeCommandHandler,
    EmployeeDeletionCommand deleteEmployeeCommandHandler,
    ProfileUpdateCommand updateProfileCommandHandler,
    EmployeeUpdateParametersValidator employeeUpdateParametersValidator,
    EmployeeUpdateTransaction employeeUpdateTransaction,
    EmployeeQuery employeeQuery,
    IEmployeesQuery employeesQuery,
    GetEmployeesByIdsQuery getEmployeesByIdsQuery,
    EmployeesForAnalyticsQuery employeesForAnalyticsQuery,
    CurrentEmployeesQuery currentEmployeesQuery,
    ProfileUpdatingParametersValidator profileUpdatingParametersValidator
  )
  {
    _employeeCreationCommand = createEmployeeCommandHandler;
    _employeeDeletionCommand = deleteEmployeeCommandHandler;
    _profileUpdateCommand = updateProfileCommandHandler;
    _employeeUpdateParametersValidator = employeeUpdateParametersValidator;
    _employeeUpdateTransaction = employeeUpdateTransaction;
    _employeeQuery = employeeQuery;
    _employeesQuery = employeesQuery;
    _getEmployeesByIdsQuery = getEmployeesByIdsQuery;
    _employeesForAnalyticsQuery = employeesForAnalyticsQuery;
    _currentEmployeesQuery = currentEmployeesQuery;
    _profileUpdatingParametersValidator = profileUpdatingParametersValidator;
  }

  public async Task<Employee> GetByIdAsync(long employeeId)
  {
    return await _employeeQuery.GetEmployeeAsync(employeeId);
  }

  public async Task<Employee> GetByCorporateEmailAsync(string corporateEmail)
  {
    return await _employeeQuery.GetEmployeeAsync(corporateEmail);
  }

  public async Task<IEnumerable<Employee>> GetAllAsync(long tenantId)
  {
    return await _employeesQuery.GetEmployeesAsync(tenantId);
  }

  public async Task<List<Employee>> GetEmployeesByIdsAsync(EmployeesIdsModel ids, long tenantId)
  {
    return await _getEmployeesByIdsQuery.GetEmployeesByIdsAsync(ids, tenantId);
  }

  public async Task<IEnumerable<Employee>> GetCurrentEmployeesAsync(long tenantId)
  {
    return await _currentEmployeesQuery.GetCurrentEmployeesAsync(tenantId);
  }

  public async Task<IEnumerable<Employee>> GetEmployeesForAnalytics()
  {
    return await _employeesForAnalyticsQuery.GetEmployeesForAnalyticsAsync();
  }

  public async Task CreateAsync(EmployeeCreationParameters parameters)
  {
    await _employeeCreationCommand.ExecuteAsync(parameters);
  }

  public async Task DeleteAsync(EmployeeDeletionParameters parameters)
  {
    await _employeeDeletionCommand.ExecuteAsync(parameters);
  }

  public async Task UpdateAsync(EmployeeUpdateDto request)
  {
    var validationResult = await _employeeUpdateParametersValidator.ValidateAsync(request);

    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult.Errors[0].ErrorMessage);
    }

    await _employeeUpdateTransaction.ExecuteAsync(request);
  }

  public async Task UpdateProfileAsync(string corporateEmail, ProfileUpdatingParameters updatingParameters)
  {
    var validationResult = await _profileUpdatingParametersValidator.ValidateAsync(updatingParameters);

    if (!validationResult.IsValid)
    {
      throw new ValidationException(validationResult.Errors[0].ErrorMessage);
    }

    await _profileUpdateCommand.ExecuteAsync(corporateEmail, updatingParameters);
  }
}
