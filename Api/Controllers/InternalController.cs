using System.Net;
using Api.Models;
using Application.Commands;
using Application.Dtos;
using Application.Services;
using Core;
using Microsoft.AspNetCore.Mvc;
using TourmalineCore.AspNetCore.JwtAuthentication.Core.Filters;

namespace Api.Controllers;

[Route("internal")]
[ApiController]
public class InternalController : ControllerBase
{
    private const int CreatedStatusCode = (int)HttpStatusCode.Created;
    private const int UpdatedStatusCode = (int)HttpStatusCode.OK;
    private const int InternalServerErrorCode = (int)HttpStatusCode.InternalServerError;

    private readonly EmployeesService _employeeService;
    private readonly EmployeePersonalInformationUpdateCommand _employeePersonalInformationUpdateCommand;

    public InternalController(EmployeesService employeeService,
        EmployeePersonalInformationUpdateCommand employeePersonalInformationUpdateCommand)
    {
        _employeeService = employeeService;
        _employeePersonalInformationUpdateCommand = employeePersonalInformationUpdateCommand;
    }

    [HttpPost("create-employee")]
    public async Task<ActionResult> CreateEmployeeAsync([FromBody] EmployeeCreationParameters employeeCreationParameters)
    {
        try
        {
            await _employeeService.CreateAsync(employeeCreationParameters);
            return StatusCode(CreatedStatusCode);
        }
        catch(Exception ex)
        {
            var message = ex.InnerException != null
                ? ex.InnerException.Message
                : ex.Message;

            return Problem(message, null, InternalServerErrorCode);
        }
    }

    [HttpPost("update-employee-personal-info")]
    public async Task<ActionResult> CreateEmployeeAsync([FromBody] EmployeePersonalInformationUpdateParameters employeePersonalInformationUpdateParameters)
    {
        try
        {
            await _employeePersonalInformationUpdateCommand.ExecuteAsync(employeePersonalInformationUpdateParameters);
            return StatusCode(UpdatedStatusCode);
        }
        catch(Exception ex)
        {
            var message = ex.InnerException != null
                ? ex.InnerException.Message
                : ex.Message;

            return Problem(message, null, InternalServerErrorCode);
        }
    }

    [RequiresPermission(UserClaimsProvider.IsAccountsHardDeleteAllowed)]
    [HttpDelete("delete-employee")]
    public async Task DeleteEmployeeAsync([FromBody] EmployeeDeletionParameters employeeDeletionParameters)
    {
        await _employeeService.DeleteAsync(employeeDeletionParameters);
    }

    [HttpGet("get-employee")]
    public async Task<EmployeeDto> GetEmployeeByCorporateEmailAsync([FromQuery] string corporateEmail)
    {
        var employee = await _employeeService.GetByCorporateEmailAsync(corporateEmail);
        return new EmployeeDto(employee);
    }

    [HttpGet("get-employees")]
    public async Task<List<EmployeeDto>> GetEmployeesAsync([FromQuery] long tenantId)
    {
        var employees = await _employeeService.GetAllAsync(tenantId);
        return employees
            .Select(x => new EmployeeDto(x))
            .ToList();
    }

    [HttpPost("get-employees-by-ids")]
    public async Task<List<EmployeeDto>> GetEmployeesByIdsAsync([FromBody] EmployeesIdsModel ids)
    {
        var tenantId = User.GetTenantId();
        var employees = await _employeeService.GetEmployeesByIdsAsync(ids, tenantId);

        return employees
            .Select(x => new EmployeeDto(x))
            .ToList();
    }
}
