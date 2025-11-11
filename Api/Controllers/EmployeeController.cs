using Api.Responses;
using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourmalineCore.AspNetCore.JwtAuthentication.Core.Filters;

namespace Api.Controllers;

[Authorize]
[Route("api/employees")]
public class EmployeeController : Controller
{
  private readonly EmployeesService _employeesService;

  public EmployeeController(EmployeesService employeeService)
  {
    _employeesService = employeeService;
  }

  [RequiresPermission(UserClaimsProvider.ViewPersonalProfile)]
  [HttpGet("get-profile")]
  public async Task<EmployeeProfileResponse> GetProfileAsync()
  {
    var employee = await _employeesService.GetByCorporateEmailAsync(User.GetCorporateEmail());
    return new EmployeeProfileResponse(employee);
  }

  [RequiresPermission(UserClaimsProvider.ViewContacts)]
  [HttpGet("all")]
  public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
  {
    var tenantId = User.GetTenantId();
    var userIsAvailableToViewSalaryAndDocumentsData = User.IsAvailableToViewSalaryAndDocumentData();

    if (!userIsAvailableToViewSalaryAndDocumentsData)
    {
      var currentEmployees = await _employeesService.GetCurrentEmployeesAsync(tenantId);
      return currentEmployees
        .Select(employee => new EmployeeResponse(employee));
    }

    var allEmployees = await _employeesService.GetAllAsync(tenantId);
    return allEmployees
      .Select(employee => new EmployeeResponse(employee));
  }

  [RequiresPermission(UserClaimsProvider.EditFullEmployeesData)]
  [HttpPut("update")]
  public async Task UpdateEmployeeAsync([FromBody] EmployeeUpdateDto employeeUpdateParameters)
  {
    await _employeesService.UpdateAsync(employeeUpdateParameters);
  }

  [RequiresPermission(UserClaimsProvider.EditFullEmployeesData)]
  [HttpGet("{employeeId:long}")]
  public async Task<EmployeeResponse> GetEmployeeAsync([FromRoute] long employeeId)
  {
    var employee = await _employeesService.GetByIdAsync(employeeId);
    return new EmployeeResponse(employee);
  }

  [RequiresPermission(UserClaimsProvider.ViewPersonalProfile)]
  [HttpPut("update-profile")]
  public async Task UpdateProfileAsync([FromBody] ProfileUpdatingParameters profileUpdatingParameters)
  {
    await _employeesService.UpdateProfileAsync(User.GetCorporateEmail(), profileUpdatingParameters);
  }
}
